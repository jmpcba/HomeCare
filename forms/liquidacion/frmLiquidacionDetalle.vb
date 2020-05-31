Public Class frmLiquidacionDetalle
    Dim ut As New utils
    Dim db As New DB
    Dim ds As New DataSet
    Dim fecha As Date
    Dim idPrestador As String
    Dim frmParent As frmLiquidar
    Dim sel As Boolean = False
    Dim pc As ControllerPractica

    Public Sub New(_idPrest As Integer, _fecha As Date, ByRef _parent As frmLiquidar)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.WindowState = FormWindowState.Maximized
        frmParent = _parent
        Try
            Me.Text = "DETALLE PRESTADOR " & _idPrest
            lblDetalle.Text = "DETALLE PRESTADOR"
            fecha = _fecha
            idPrestador = _idPrest
            pc = New ControllerPractica()
            llenarGrilla()

            If ds.Tables("DETALLE").Rows.Count > 0 Then
                ToolStripMenuItemDetalle.Enabled = True
            Else
                ToolStripMenuItemDetalle.Enabled = False
            End If
            
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Public Sub New(_idPrest As String, _fecha As Date)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.WindowState = FormWindowState.Maximized

        Try
            Me.Text = "DETALLE PRESTADOR " & _idPrest
            lblDetalle.Text = "DETALLE PRESTADOR"
            fecha = _fecha
            idPrestador = _idPrest
            pc = New ControllerPractica()
            llenarGrilla()

            If ds.Tables("detail").Rows.Count > 0 Then
                ToolStripMenuItemDetalle.Enabled = True
            Else
                ToolStripMenuItemDetalle.Enabled = False
            End If

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub frmLiquidacionDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnEliminar.Enabled = False
        If My.Settings.nivel > 2 Then
            btnEliminar.Visible = False
        Else
            btnEliminar.Visible = True
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim ids As New List(Of String)
        Dim idsError As New DataTable

        btnEliminar.Enabled = False
        dgDetalle.ClearSelection()

        For Each r As DataGridViewRow In dgDetalle.Rows
            If r.Cells(0).Value Then
                Dim id As String
                Dim rIndex As Integer

                id = r.Cells("id").Value

                rIndex = r.Index

                r.DefaultCellStyle.BackColor = Color.LightGreen
                ids.Add(id)
            End If
        Next


        If ut.mensaje("Desea eliminar las practicas seleccionadas?", utils.mensajes.preg) = MsgBoxResult.Yes Then

            Try
                Dim err = pc.delete(ids, fecha.Month, fecha.Year)

                If err.Rows.Count > 0 Then
                    For Each r As DataGridViewRow In dgDetalle.Rows
                        Dim id As String
                        Dim reRow As DataRow()

                        id = r.Cells("id").Value
                        reRow = err.Select(String.Format("id={0}", id))
                        If reRow.Count <> 0 Then
                            r.DefaultCellStyle.BackColor = Color.Red
                        End If
                    Next
                    Throw New Exception("LAS PRACTICAS EN ROJO NO PUEDEN ELIMINARSE" & vbCrLf & "Liquidacion cerrada")
                End If

                llenarGrilla()
                dgDetalle.Refresh()

            Catch ex As Exception
                ut.mensaje(ex.Message, utils.mensajes.err)
            End Try
        End If
    End Sub

    Private Sub dgDetalle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetalle.CellContentClick

        If e.RowIndex <> -1 Then
            Dim sel = dgDetalle.Rows(e.RowIndex).Cells(0).Value
            sel = Not sel
            btnEliminar.Enabled = sel
            dgDetalle.Rows(e.RowIndex).Cells(0).Value = sel
        Else
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub frmLiquidacionDetalle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Not IsNothing(frmParent) Then
            frmParent.llenarGrilla()
        End If
    End Sub

    Private Sub frmLiquidacionDetalle_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        dgDetalle.ClearSelection()
    End Sub

    Private Sub DetallePrestadorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDetalle.Click
        Try
            'ut.exportarExcel(ds.Tables("DETALLE"))
            Focus()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub llenarGrilla()

        Try
            Dim chkclm As New DataGridViewCheckBoxColumn
            Dim cpac = New ControllerPractica()
            btnEliminar.Enabled = False
            ds.Clear()

            ds = cpac.practicas(fecha, ControllerPractica.tipoPracticas.prestador, idPrestador)
            If ds.Tables("detail").Rows.Count = 0 Then
                btnSelec.Enabled = False
            End If

            With ds.Tables("detail")
                .Columns("AFILIADO").SetOrdinal(0)
                .Columns("CUIT").SetOrdinal(1)
                .Columns("APELLIDO PACIENTE").SetOrdinal(2)
                .Columns("NOMBRE PACIENTE").SetOrdinal(3)
                .Columns("FECHA PRACTICA").SetOrdinal(4)
                .Columns("MODULO").SetOrdinal(5)
                .Columns("CODIGO SUBMODULO").SetOrdinal(6)
                .Columns("DESCRIPCION SUBMODULO").SetOrdinal(7)
                .Columns("HS LUN A VIER").SetOrdinal(8)
                .Columns("HS SAB DOM Y FER").SetOrdinal(9)
                .Columns("DIFERENCIAL").SetOrdinal(10)
                .Columns("$ LUN A VIER").SetOrdinal(11)
                .Columns("$ SAB DOM Y FER").SetOrdinal(12)
                .Columns("$ DIFERENCIAL").SetOrdinal(13)
            End With

            With ds.Tables("summary")
                .Columns("AFILIADO").SetOrdinal(0)
                .Columns("APELLIDO PACIENTE").SetOrdinal(1)
                .Columns("NOMBRE PACIENTE").SetOrdinal(2)
                .Columns("CANT PRACTICAS").SetOrdinal(3)
                .Columns("CANT HORAS").SetOrdinal(4)
            End With

            With chkclm
                .HeaderText = ""
                .Name = ""
                .ReadOnly = False
            End With

            With dgDetalle
                .DataSource = Nothing
                .Columns.Clear()
                .DataSource = ds.Tables("detail")
                .Columns("id").Visible = False
                .AutoResizeColumns()
                .AutoResizeRows()
                .ClearSelection()
                If ds.Tables("detail").Rows.Count <> 0 Then
                    .Columns.Insert(0, chkclm)
                End If
            End With

            With grResumen
                .DataSource = Nothing
                .Columns.Clear()
                .DataSource = ds.Tables("summary")
                .AutoResizeColumns()
                .AutoResizeRows()
                .ClearSelection()
            End With

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        Finally
            btnEliminar.Enabled = True
        End Try

    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged

        Dim filtro = String.Format("[APELLIDO PACIENTE] LIKE '%{0}%'", txtFiltro.Text.Trim)

        ds.Tables("detail").DefaultView.RowFilter = filtro
        ds.Tables("summary").DefaultView.RowFilter = filtro

        dgDetalle.Refresh()
        grResumen.Refresh()
    End Sub

    Private Sub btnSelec_Click(sender As Object, e As EventArgs) Handles btnSelec.Click
        sel = Not sel

        If sel Then
            btnSelec.Text = "NINGUNO"
            btnEliminar.Enabled = True
        Else
            btnSelec.Text = "TODOS"
            btnEliminar.Enabled = False
        End If

        For Each r As DataGridViewRow In dgDetalle.Rows
            r.Cells(0).Value = sel
        Next
    End Sub

End Class