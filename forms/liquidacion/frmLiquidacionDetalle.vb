Public Class frmLiquidacionDetalle
    Dim ut As New utils
    Dim db As New DB
    Dim ds As New DataSet
    Dim fecha As Date
    Dim idPrestador As Integer
    Dim frmParent As frmLiquidar
    Dim sel As Boolean = False

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

    Public Sub New(_idPrest As Integer, _fecha As Date)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.WindowState = FormWindowState.Maximized

        Try
            Me.Text = "DETALLE PRESTADOR " & _idPrest
            lblDetalle.Text = "DETALLE PRESTADOR"
            fecha = _fecha
            idPrestador = _idPrest

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

    Private Sub frmLiquidacionDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnEliminar.Enabled = False
        If My.Settings.nivel > 2 Then
            btnEliminar.Visible = False
        Else
            btnEliminar.Visible = True
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim ids As New List(Of Integer)
        Dim idsError As New List(Of Integer)

        dgDetalle.ClearSelection()

        For Each r As DataGridViewRow In dgDetalle.Rows
            If r.Cells(0).Value Then
                Dim id = r.Cells("id").Value

                r.DefaultCellStyle.BackColor = Color.LightGreen
                ids.Add(id)
            Else
                r.DefaultCellStyle.BackColor = Color.White
            End If
        Next

        If ut.mensaje("Desea eliminar las practicas seleccionadas?", utils.mensajes.preg) = MsgBoxResult.Yes Then

            Try
                If ut.validarLiquidacion(idPrestador, fecha) Then
                    Throw New Exception("LIQUIDACION CERRADA - NO SE PUEDE ELIMINAR")
                Else
                    db.eliminarPractica(ids)
                    llenarGrilla()
                    'dgDetalle.Refresh()
                    'grResumen.Refresh()
                End If

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
        Dim chkclm As New DataGridViewCheckBoxColumn

        Try
            btnEliminar.Enabled = False
            ds.Clear()
            ds = db.getLiquidacion(idPrestador, fecha)

            With chkclm
                .HeaderText = ""
                .Name = ""
                .ReadOnly = False
            End With

            With dgDetalle
                .DataSource = Nothing
                .Columns.Clear()
                .DataSource = ds.Tables("DETALLE")
                .AutoResizeColumns()
                .AutoResizeRows()
                .ClearSelection()
                .Columns("id").Visible = False

                If ds.Tables("DETALLE").Rows.Count <> 0 Then
                    .Columns.Insert(0, chkclm)
                End If
            End With

            With grResumen
                .DataSource = Nothing
                .Columns.Clear()
                .DataSource = ds.Tables("RESUMEN")
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

        ds.Tables("DETALLE").DefaultView.RowFilter = filtro
        ds.Tables("RESUMEN").DefaultView.RowFilter = filtro

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