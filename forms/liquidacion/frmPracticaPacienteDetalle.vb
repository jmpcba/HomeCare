Public Class frmPracticaPacienteDetalle
    Dim ut As New utils
    Dim db As New DB
    Dim ds As New DataSet
    Dim fecha As Date
    Dim afiliado As String
    Dim frmParent As frmPracticasPaciente
    Dim sel As Boolean = False

    Public Sub New(_afiliado As String, _fecha As Date, ByRef _parent As frmPracticasPaciente)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.WindowState = FormWindowState.Maximized
        frmParent = _parent
        Try
            Me.Text = "DETALLE AFILIADO" & _afiliado

            fecha = _fecha
            afiliado = _afiliado

            llenarGrilla()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Public Sub New(_afiliado As String, _fecha As Date)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.WindowState = FormWindowState.Maximized

        Try
            Me.Text = "DETALLE AFILIADO" & _afiliado

            fecha = _fecha
            afiliado = _afiliado

            llenarGrilla()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub llenarGrilla()
        Try
            Dim chkclm As New DataGridViewCheckBoxColumn
            btnEliminar.Enabled = False
            ds.Clear()
            ds = db.getPracticasPaciente(afiliado, fecha)

            If ds.Tables("DETALLE").Rows.Count = 0 Then
                btnSel.Enabled = False
            End If

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
                .Columns("id_prestador").Visible = False

                If ds.Tables("DETALLE").Rows.Count <> 0 Then
                    .Columns.Insert(0, chkclm)
                End If
            End With

            With dgResumen
                .DataSource = Nothing
                .Columns.Clear()
                .DataSource = ds.Tables("RESUMEN")
                .AutoResizeColumns()
                .AutoResizeRows()
                .ClearSelection()
            End With

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub frmPracticaPacienteDetalle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Not IsNothing(frmParent) Then
            frmParent.llenarGrilla()
        End If
    End Sub

    Private Sub frmPracticaPacienteDetalle_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        dgDetalle.ClearSelection()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim ids As New List(Of Integer())
        Dim idsError As New List(Of Integer)

        btnEliminar.Enabled = False
        dgDetalle.ClearSelection()

        For Each r As DataGridViewRow In dgDetalle.Rows
            If r.Cells(0).Value Then
                Dim id As Integer
                Dim idPrest As Integer
                Dim rIndex As Integer

                id = r.Cells("id").Value
                idPrest = r.Cells("id_prestador").Value
                rIndex = r.Index

                r.DefaultCellStyle.BackColor = Color.LightGreen
                ids.Add({id, idPrest})
            End If
        Next

        If ut.mensaje("Desea eliminar las practicas seleccionadas?", utils.mensajes.preg) = MsgBoxResult.Yes Then

            Try
                For Each id As Integer() In ids
                    If ut.validarLiquidacion(id(1), fecha) Then
                        idsError.Add(id(0))
                    End If
                Next

                If idsError.Count > 0 Then
                    For Each r As DataGridViewRow In dgDetalle.Rows
                        Dim idPractica As Integer = r.Cells("id").Value
                        If idsError.Contains(idPractica) Then
                            r.DefaultCellStyle.BackColor = Color.Red
                        End If
                    Next
                    Throw New Exception("LAS PRACTICAS EN ROJO NO PUEDEN ELIMINARSE" & vbCrLf & "Liquidacion cerrada")
                End If

                Dim idsEliminar As New List(Of Integer)
                For Each i As Integer() In ids
                    idsEliminar.Add(i(0))
                Next

                db.eliminarPractica(idsEliminar)
                llenarGrilla()
                dgDetalle.Refresh()

            Catch ex As Exception
                ut.mensaje(ex.Message, utils.mensajes.err)
            End Try
        End If
    End Sub

    Private Sub dgDetalle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetalle.CellClick
        If e.RowIndex <> -1 Then
            Dim sel = dgDetalle.Rows(e.RowIndex).Cells(0).Value
            sel = Not sel
            btnEliminar.Enabled = sel
            dgDetalle.Rows(e.RowIndex).Cells(0).Value = sel
        Else
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        ds.Tables("DETALLE").DefaultView.RowFilter = String.Format("[APELLIDO PRESTADOR] LIKE '%{0}%'", txtFiltro.Text.Trim)
        ds.Tables("RESUMEN").DefaultView.RowFilter = String.Format("[APELLIDO PRESTADOR] LIKE '%{0}%'", txtFiltro.Text.Trim)
        dgDetalle.Refresh()
    End Sub

    Private Sub ExportarListaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarListaToolStripMenuItem.Click
        Try
            'ut.exportarExcel(ds.Tables("DETALLE"))
            Focus()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub btnSel_Click(sender As Object, e As EventArgs) Handles btnSel.Click
        sel = Not sel

        If sel Then
            btnSel.Text = "NINGUNA"
            btnEliminar.Enabled = True
        Else
            btnSel.Text = "TODAS"
            btnEliminar.Enabled = False
        End If

        For Each r As DataGridViewRow In dgDetalle.Rows
            r.Cells(0).Value = sel
        Next
    End Sub
End Class