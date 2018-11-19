Public Class frmLiquidar
    Dim sel As Boolean = False
    Private Sub dtMes_ValueChanged(sender As Object, e As EventArgs) Handles dtMes.ValueChanged
        llenargrilla()
    End Sub

    Public Sub llenarGrilla()
        Dim db As New DB()
        Dim mes = dtMes.Value
        Dim dt As New DataTable
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
        End With

        For Each c As DataGridViewColumn In gridLiqui.Columns
            If c.Index <> 0 Then
                c.ReadOnly = True
            End If
        Next

    End Sub

    Private Sub frmLiquidar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGuardar.Enabled = False
        llenargrilla()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub gridLiqui_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridLiqui.CellDoubleClick
        Dim r As DataGridViewRow
        If e.ColumnIndex <> 0 Then
            r = gridLiqui.Rows(e.RowIndex)
            Dim idPrest = r.Cells("ID_PREST").Value
            Dim fecha = dtMes.Value
            Dim frm As New frmLiquidacionDetalle(idPrest, fecha, Me)
            frm.ShowDialog()
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

        Try
            btnGuardar.Enabled = False
            gridLiqui.Columns("RESULTADO CARGA").ReadOnly = False

            For Each r As DataGridViewRow In gridLiqui.Rows
                If r.Cells(0).Value Then
                    Try
                        Dim liq = New Liquidacion(r.Cells("ID_PREST").Value, r.Cells("CUIT").Value, r.Cells("LOCALIDAD").Value, r.Cells("ESPECIALIDAD").Value, mes, r.Cells("HORAS LAV").Value, r.Cells("HORAS FERIADO").Value, r.Cells("TOTAL LAV").Value, r.Cells("TOTAL FERIADO").Value, r.Cells("MONTO FIJO").Value)
                        liq.liquidar()
                        r.Cells("RESULTADO CARGA").Value = "Cargado"
                        r.DefaultCellStyle.BackColor = Color.LightGreen
                        r.Cells("ESTADO").Value = "CERRADA"
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
            MessageBox.Show(ex.Message)
        Finally
            With gridLiqui
                .Columns("RESULTADO CARGA").ReadOnly = True
                .AutoResizeColumns()
                .AutoResizeRows()
            End With
            btnGuardar.Enabled = True
        End Try
    End Sub
End Class