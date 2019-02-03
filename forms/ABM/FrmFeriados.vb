Public Class FrmFeriados
    Dim db As New DB
    Dim ut As New utils
    Dim txtBoxes As TextBox()
    Dim fecha As Date

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmFeriados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarGrilla()
        txtBoxes = {txtDescripcion}
        btnEliminar.Enabled = False
    End Sub

    Private Sub cargarGrilla()
        Try

            Dim dt As New DataTable
            dt.Clear()
            dt = db.feriado(DtCalendario.Value)

            With dt
                .Columns.Remove("CARGO_USUARIO")
                .Columns.Remove("MODIFICO_USUARIO")
                .Columns.Remove("FECHA_CARGA")
                .Columns.Remove("FECHA_MODIFICACION")
                .DefaultView.Sort = "FECHA"
            End With

            With dgFeriados
                .DataSource = Nothing
                Refresh()
                .DataSource = dt
                .AutoResizeColumns()
                .AutoResizeRows()
            End With

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            btnGuardar.Enabled = False
            ut.validarTxtBoxLleno(txtBoxes)
            db.InsertarFeriado(DtCalendario.Value, txtDescripcion.Text.ToUpper)
            cargarGrilla()
        Catch ex As Exception
            If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                ut.mensaje("Ya existe un feriado para esa fecha", utils.mensajes.err)
            Else
                ut.mensaje(ex.Message, utils.mensajes.err)
            End If
        Finally
            btnGuardar.Enabled = True
            txtDescripcion.Text = ""

        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim r As DataGridViewRow
            r = dgFeriados.CurrentRow

            fecha = r.Cells("FECHA").Value
            btnEliminar.Enabled = False
            db.eliminarFeriado(fecha)
            cargarGrilla()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        Finally
            dgFeriados.ClearSelection()
            txtDescripcion.Text = ""
        End Try
    End Sub

    Private Sub dgFeriados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFeriados.CellClick
        If e.RowIndex <> -1 Then
            btnEliminar.Enabled = True
        Else
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub FrmFeriados_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        dgFeriados.ClearSelection()
    End Sub

    Private Sub FrmFeriados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub
End Class