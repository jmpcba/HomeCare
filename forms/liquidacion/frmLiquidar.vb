Public Class frmLiquidar
    Dim sel As Boolean = False
    Dim ut As New utils
    Dim dt As New DataTable
    Private Sub dtMes_ValueChanged(sender As Object, e As EventArgs) Handles dtMes.ValueChanged
        llenarGrilla()
    End Sub

    Public Sub llenarGrilla()
        Try
            btnGuardar.Enabled = False
            Dim db As New DB()
            Dim mes = dtMes.Value

            dt = db.getLiquidacion(mes, DB.tiposLiquidacion.medico)

            dt.Columns.Add("RESULTADO CARGA")


            Dim chkclm As New DataGridViewCheckBoxColumn

            With chkclm
                .HeaderText = ""
                .Name = ""
                .ReadOnly = False
            End With

            With gridLiqui
                .Columns.Clear()

                If dt.Rows.Count <> 0 Then
                    .Columns.Insert(0, chkclm)
                    btnGuardar.Enabled = True
                    btnSelec.Enabled = True
                Else
                    btnGuardar.Enabled = False
                    btnSelec.Enabled = False
                End If

                .DataSource = dt
                .Columns("RESULTADO CARGA").DefaultCellStyle.BackColor = Color.LightGray
                .Columns("ID_PREST").Visible = False
                .AutoResizeColumns()
                .AutoResizeRows()
                .ClearSelection()
            End With

            For Each c As DataGridViewColumn In gridLiqui.Columns
                If c.Index <> 0 Then
                    c.ReadOnly = True
                End If

            Next
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        Finally
            btnGuardar.Enabled = True
        End Try

    End Sub

    Private Sub frmLiquidar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGuardar.Enabled = False
        Me.WindowState = FormWindowState.Maximized
        dtMes.Value = Today.AddMonths(-1)
        llenarGrilla()
        If My.Settings.nivel > 1 Then
            btnGuardar.Visible = False
        Else
            btnGuardar.Visible = True
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub gridLiqui_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridLiqui.CellDoubleClick
        Dim r As DataGridViewRow

        If e.RowIndex <> -1 Then
            If e.ColumnIndex <> 0 Then
                r = gridLiqui.Rows(e.RowIndex)
                Dim idPrest = r.Cells("ID_PREST").Value
                Dim fecha = dtMes.Value
                Dim frm As New frmLiquidacionDetalle(idPrest, fecha, Me)
                frm.ShowDialog()
            End If
        End If

    End Sub

    Private Sub btnSelec_Click(sender As Object, e As EventArgs) Handles btnSelec.Click
        sel = Not sel

        If sel Then
            btnSelec.Text = "Des-seleccionar todos"
        Else
            btnSelec.Text = "Seleccionar todos"
        End If

        For Each r As DataGridViewRow In gridLiqui.Rows
            r.Cells(0).Value = sel
        Next
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim mes As New Date(dtMes.Value.Year, dtMes.Value.Month, Date.DaysInMonth(dtMes.Value.Year, dtMes.Value.Month))

        If ut.mensaje("Desea cerrar las liquidaciones seleccionadas?", utils.mensajes.preg) = MsgBoxResult.Yes Then
            Try
                btnGuardar.Enabled = False
                gridLiqui.Columns("RESULTADO CARGA").ReadOnly = False

                For Each r As DataGridViewRow In gridLiqui.Rows
                    If r.Cells(0).Value Then
                        Try
                            Dim prest = New Prestador
                            prest.id = r.Cells("ID_PREST").Value
                            Dim liq = New Liquidacion(prest, mes, r.Cells("HORAS LAV").Value, r.Cells("HORAS FERIADO").Value, r.Cells("HORAS DIFERENCIAL").Value, r.Cells("TOTAL LAV").Value, r.Cells("TOTAL FERIADO").Value, r.Cells("TOTAL DIF").Value, r.Cells("MONTO FIJO").Value, txtObservaciones.Text)

                            If r.Cells("ESTADO").Value = "CERRADA" Then
                                Dim msg = String.Format("La liquidacion para el prestador {0} en el mes de {1} ya esta cerrada" & vbCrLf & vbCrLf & "Desea reenviar el mail de notificacion? ", prest.apellido, MonthName(dtMes.Value.Month).ToUpper)
                                If ut.mensaje(msg, utils.mensajes.preg) = MsgBoxResult.Yes Then
                                    liq.notificar()
                                    r.Cells("RESULTADO CARGA").Value = "Mail Re-enviado"
                                    r.DefaultCellStyle.BackColor = Color.LightGreen
                                End If
                            Else
                                liq.liquidar()
                                r.Cells("RESULTADO CARGA").Value = "Liquidacion Cerrada"
                                r.DefaultCellStyle.BackColor = Color.LightGreen
                                r.Cells("ESTADO").Value = "CERRADA"
                            End If

                        Catch ex As Exception
                            r.DefaultCellStyle.BackColor = Color.Red

                            If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                                r.Cells("RESULTADO CARGA").Value = "Esta liquidacion ya esta cerrada"
                            Else
                                r.Cells("RESULTADO CARGA").Value = ex.Message
                            End If
                        End Try
                    End If
                Next
            Catch ex As Exception
                ut.mensaje(ex.Message, utils.mensajes.err)
            Finally
                With gridLiqui
                    .Columns("RESULTADO CARGA").ReadOnly = True
                    .AutoResizeColumns()
                    .AutoResizeRows()
                    .ClearSelection()
                End With
                btnGuardar.Enabled = True
            End Try
        End If
    End Sub

    Private Sub frmLiquidar_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        gridLiqui.ClearSelection()
    End Sub

    Private Sub ResumenDePrestadoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResumenDePrestadoresToolStripMenuItem.Click
        Try
            ut.exportarExcel(dt)
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub TodasLasPracticasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TodasLasPracticasToolStripMenuItem.Click
        Try
            Dim practicas = New Practica
            ut.exportarExcel(practicas.getPracticas(dtMes.Value))
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub frmLiquidar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        dt.DefaultView.RowFilter = String.Format("[APELLIDO PRESTADOR] Like '%{0}%'", txtFiltro.Text.Trim)
        gridLiqui.Refresh()
    End Sub
End Class