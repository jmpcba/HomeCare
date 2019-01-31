Public Class frmPracticaPacienteDetalle
    Dim ut As New utils
    Dim db As New DB
    Dim dt As New DataTable
    Dim fecha As Date
    Dim afiliado As String
    Dim frmParent As frmPracticasPaciente

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

    Private Sub llenarGrilla()
        Dim chkclm As New DataGridViewCheckBoxColumn
        dgDetalle.DataSource = Nothing
        dt.Clear()
        dt = db.getPracticasPaciente(afiliado, fecha)

        With chkclm
            .HeaderText = ""
            .Name = ""
            .ReadOnly = False
        End With

        With dgDetalle
            .Columns.Clear()
            .DataSource = dt
            .AutoResizeColumns()
            .AutoResizeRows()
            .ClearSelection()
            .Columns("id").Visible = False
            .Columns("id_prestador").Visible = False

            If dt.Rows.Count <> 0 Then
                .Columns.Insert(0, chkclm)
            End If
        End With
    End Sub

    Private Sub frmPracticaPacienteDetalle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmParent.llenarGrilla()
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
        Dim sel = dgDetalle.Rows(e.RowIndex).Cells(0).Value
        sel = Not sel

        If e.RowIndex <> -1 Then
            btnEliminar.Enabled = True
            dgDetalle.Rows(e.RowIndex).Cells(0).Value = sel
        Else
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        dt.DefaultView.RowFilter = String.Format("[APELLIDO PRESTADOR] LIKE '%{0}%'", txtFiltro.Text.Trim)
        dgDetalle.Refresh()
    End Sub
End Class