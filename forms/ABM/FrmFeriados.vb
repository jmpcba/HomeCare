Public Class FrmFeriados
    Dim db As New DB
    Dim ut As New utils
    Dim txtBoxes As TextBox()
    Dim fecha As Date
    Dim cf As ControllerFeriados

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmFeriados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtBoxes = {txtDescripcion}
            cf = New ControllerFeriados(DtCalendario.Value.Year)
            cargarGrilla()
            txtBoxes = {txtDescripcion}
            btnEliminar.Enabled = False
            ut = New utils
        Catch ex As apiException
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub cargarGrilla()
        Try

            Dim dt As New DataTable
            dt.Clear()
            dt = cf.feriados

            If Not IsNothing(dt) Then
                With dt
                    Try
                        .Columns.Remove("ultima_modificacion")
                        .Columns.Remove("usuario_ultima_modificacion")
                        .DefaultView.Sort = "FECHA"
                    Catch ex As Exception

                    End Try

                End With

                With dgFeriados
                    .DataSource = Nothing
                    .Refresh()
                    .DataSource = dt
                    .AutoResizeColumns()
                    .AutoResizeRows()
                End With
            End If

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            btnGuardar.Enabled = False
            ut.validarTxtBoxLleno(txtBoxes)
            Dim testFeriado = cf.getFeriado(DtCalendario.Value.Date)
            If Not IsNothing(testFeriado) Then
                ut.mensaje("Ya existe un feriado para esa fecha", utils.mensajes.err)
                Exit Sub
            End If
            cf.insertNew(DtCalendario.Value, txtDescripcion.Text.ToUpper)
            cf.refresh()
            cargarGrilla()
            ut.mensaje("Guardado Exitoso", utils.mensajes.info)
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        Finally
            btnGuardar.Enabled = True
            txtDescripcion.Text = ""
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        'Try
        '    Dim r As DataGridViewRow
        '    r = dgFeriados.CurrentRow

        '    fecha = r.Cells("FECHA").Value
        '    btnEliminar.Enabled = False
        '    db.eliminarFeriado(fecha)
        '    cargarGrilla()
        'Catch ex As Exception
        '    ut.mensaje(ex.Message, utils.mensajes.err)
        'Finally
        '    dgFeriados.ClearSelection()
        '    txtDescripcion.Text = ""
        'End Try
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