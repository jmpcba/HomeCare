Public Class frmLiquidar
    Dim sel As Boolean = False
    WithEvents ut As New utils
    Dim dt As New DataTable
    Dim carga As Boolean = False
    Dim tipo As liquidaciones

    Public Enum liquidaciones
        abiertas
        cerradas
    End Enum
    Public Sub New(_tipo As liquidaciones)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim titulo As String
        tipo = _tipo

        If tipo = liquidaciones.cerradas Then
            titulo = "LIQUIDACIONES CERRADAS"
            txtObservaciones.Visible = False
            lblObservaciones.Visible = False
        ElseIf tipo = liquidaciones.abiertas Then
            titulo = "LIQUIDACIONES PENDIENTES"

        End If
        Me.Text = titulo
        lblTitulo.Text = titulo

    End Sub
    Private Sub dtMes_ValueChanged(sender As Object, e As EventArgs) Handles dtMes.ValueChanged
        If Not carga Then
            llenarGrilla()
        End If
    End Sub

    Public Sub llenarGrilla()
        Dim columnasEsconder
        Try
            btnGuardar.Enabled = False
            Dim db As New DB()
            Dim mes = dtMes.Value

            If tipo = liquidaciones.abiertas Then
                columnasEsconder = {"ID_PREST", "ESPECIALIDAD", "LOCALIDAD", "SERVICIO"}
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

                End With
            Else

                Dim chkclm As New DataGridViewCheckBoxColumn
                columnasEsconder = {"ID_PREST"}
                dt = db.getLiquidacion(mes, DB.tiposLiquidacion.cerrada)
                dt.Columns.Add("RESULTADO CARGA")
                With chkclm
                    .HeaderText = ""
                    .Name = ""
                    .ReadOnly = False
                End With

                With gridLiqui
                    .Columns.Clear()
                    gridLiqui.DataSource = dt

                    If dt.Rows.Count <> 0 Then
                        .Columns.Insert(0, chkclm)
                        btnGuardar.Enabled = True
                        btnSelec.Enabled = True
                    Else
                        btnGuardar.Enabled = False
                        btnSelec.Enabled = False
                    End If
                    .Columns("ID").Visible = False
                    .DataSource = dt
                End With
            End If

            With gridLiqui
                .AutoResizeColumns()
                .AutoResizeRows()
                .ClearSelection()

                For Each c As DataGridViewColumn In .Columns
                    If c.Index <> 0 Then
                        c.ReadOnly = True
                    End If
                Next

                For Each c In columnasEsconder
                    .Columns(c).Visible = False
                Next
            End With

            If dt.Rows.Count = 0 Then
                btnSelec.Enabled = False
            Else
                btnSelec.Enabled = True
            End If

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        Finally
            btnGuardar.Enabled = True
        End Try

    End Sub

    Private Sub frmLiquidar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carga = True
        btnGuardar.Enabled = False
        Me.WindowState = FormWindowState.Maximized
        dtMes.Value = Today.AddMonths(-1)
        llenarGrilla()
        txtObservaciones.Text = " "

        If My.Settings.nivel > 1 Then
            btnGuardar.Visible = False
        Else
            btnGuardar.Visible = True
        End If

        If My.Settings.nivel = 0 And tipo = liquidaciones.cerradas Then
            btnReAbrir.Visible = True
        Else
            btnReAbrir.Visible = False
        End If

        carga = False
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
            btnSelec.Text = "NINGUNO"
        Else
            btnSelec.Text = "TODOS"
        End If

        For Each r As DataGridViewRow In gridLiqui.Rows
            r.Cells(0).Value = sel
        Next
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim mes As New Date(dtMes.Value.Year, dtMes.Value.Month, Date.DaysInMonth(dtMes.Value.Year, dtMes.Value.Month))

        Dim msg As String

        If tipo = liquidaciones.abiertas Then
            msg = "Desea cerrar las liquidaciones seleccionadas?"
        ElseIf tipo = liquidaciones.cerradas Then
            msg = "Las liquidaciones listadas ya estan cerradas" & vbCrLf & vbCrLf & "Desea reenviar el mail de notificacion?"
        End If

        If ut.mensaje(msg, utils.mensajes.preg) = MsgBoxResult.Yes Then
            Try
                btnGuardar.Enabled = False
                gridLiqui.Columns("RESULTADO CARGA").ReadOnly = False

                For Each r As DataGridViewRow In gridLiqui.Rows
                    If r.Cells(0).Value Then
                        Try
                            Dim prest = New Prestador
                            prest.id = r.Cells("ID_PREST").Value
                            Dim liq = New Liquidacion(prest, mes, r.Cells("HS LUN a VIE").Value, r.Cells("HS SAB DOM y FER").Value, r.Cells("DIFERENCIAL").Value, r.Cells("$ LUN a VIE").Value, r.Cells("$ SAB DOM y FER").Value, r.Cells("$ DIF").Value, r.Cells("MONTO FIJO").Value, txtObservaciones.Text)

                            If tipo = liquidaciones.cerradas Then
                                liq.notificar()
                                r.Cells("RESULTADO CARGA").Value = "Mail Re-enviado"
                                r.DefaultCellStyle.BackColor = Color.LightGreen
                            Else
                                liq.liquidar()
                                r.Cells("RESULTADO CARGA").Value = "Liquidacion Cerrada"
                                r.DefaultCellStyle.BackColor = Color.LightGreen
                                r.Cells("ESTADO").Value = "CERRADA"
                            End If
                        Catch ex As Exception
                            r.DefaultCellStyle.BackColor = Color.Red
                            r.Cells("RESULTADO CARGA").Value = ex.Message
                        Finally
                            r.Cells(0).Value = False
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
            pb.Visible = True
            Dim dtExport As New DataTable
            dtExport = dt.Copy
            dtExport.Columns.Remove("ESTADO")
            dtExport.Columns.Add("OBSERVACIONES")
            Dim prest As New Prestador

            For Each r As DataRow In dtExport.Rows
                prest.id = r("ID_PREST")
                r("OBSERVACIONES") = prest.observaciones
            Next

            'ut.exportarExcel(dtExport)
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        Finally
            pb.Visible = False
            Me.Focus()
        End Try
    End Sub

    Private Sub TodasLasPracticasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TodasLasPracticasToolStripMenuItem.Click
        Try
            pb.Visible = True
            Dim practicas = New Practica
            'ut.exportarExcel(practicas.getPracticas(dtMes.Value))
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        Finally
            pb.Visible = False
            Me.Focus()
        End Try
    End Sub

    Private Sub frmLiquidar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        dt.DefaultView.RowFilter = String.Format("[APELLIDO PRESTADOR] Like '%{0}%'", txtFiltro.Text.Trim)
        gridLiqui.Refresh()
    End Sub

    Private Sub CierreLiquidacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CierreLiquidacionToolStripMenuItem.Click
        Dim dtPrestadores As New DataTable("RESUMEN PRESTADORES")
        Dim dtPracticas As New DataTable("DETALLE PRACTICAS")
        Dim ds As New DataSet

        Try
            pb.Visible = True
            dtPrestadores = dt.Copy
            dtPrestadores.TableName = "RESUMEN PRESTADORES"
            dtPrestadores.Columns.Remove("RESULTADO CARGA")
            dtPrestadores.Columns.Remove("ESTADO")
            dtPrestadores.Columns.Add("OBSERVACIONES")
            Dim prest As New Prestador

            For Each r As DataRow In dtPrestadores.Rows
                prest.id = r("ID_PREST")
                r("OBSERVACIONES") = prest.observaciones
            Next


            Dim practicas = New Practica
            dtPracticas = practicas.getPracticas(dtMes.Value).Copy

            ds.Tables.Add(dtPrestadores)
            ds.Tables.Add(dtPracticas)

            With pb
                .Minimum = 0
                .Maximum = dtPracticas.Rows.Count + dtPrestadores.Rows.Count
                .Visible = True
            End With


            'ut.exportarExcel(ds)
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        Finally
            pb.Visible = False
            Me.Focus()
        End Try
    End Sub

    Private Sub progressBar() Handles ut.cambioBarraDeProgreso
        pb.Increment(1)
    End Sub

    Public Sub progresoStatusBar() Handles ut.progresoExportExcel
        pb.Increment(1)
    End Sub

    Private Sub btnReAbrir_Click(sender As Object, e As EventArgs) Handles btnReAbrir.Click
        If ut.mensaje("Esta liquidacion esta cerrada!!!" & vbCrLf & "Esta seguro de reabrirla?", utils.mensajes.preg) = MsgBoxResult.Yes Then
            Try
                Dim db As New DB()
                Dim ids As New List(Of Integer)

                gridLiqui.ClearSelection()

                For Each r As DataGridViewRow In gridLiqui.Rows
                    If r.Cells(0).Value Then
                        Dim id = r.Cells("id").Value
                        r.Cells("RESULTADO CARGA").Value = "Liquidacion reabierta"
                        r.DefaultCellStyle.BackColor = Color.LightGreen
                        ids.Add(id)
                    End If
                Next

                db.eliminarLiquidaciones(ids)

            Catch ex As Exception
                For Each r As DataGridViewRow In gridLiqui.Rows
                    If r.Cells(0).Value Then
                        Dim id = r.Cells("id").Value
                        r.Cells("RESULTADO CARGA").Value = ex.Message
                        r.DefaultCellStyle.BackColor = Color.Red
                    End If
                Next
            End Try
        End If
    End Sub
End Class