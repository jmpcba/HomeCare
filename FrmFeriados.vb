Public Class FrmFeriados
    Dim feriados As Feriado
    Dim ut As New utils
    Dim txtBoxes As TextBox()
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If IsNothing(feriados) Then
                ut.validarTxtBoxLleno(txtBoxes)

                feriados = New Feriado(DtCalendario.Text, txtDescripcion.Text)
                feriados.insertar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                ut.iniciarTxtBoxes(txtBoxes)
            Else
                ut.validarTxtBoxLleno(txtBoxes)
                If txtDescripcion.Text <> feriados.descripcion Then
                    feriados.descripcion = txtDescripcion.Text
                End If
                feriados.actualizar()
                ut.iniciarTxtBoxes(txtBoxes)
                feriados = Nothing
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
            End If
        Catch ex As Exception
            If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                ut.mensaje("Ya existe un Prestador con el mismo cuit/especialidad/localidad", utils.mensajes.err)
            Else
                ut.mensaje(ex.Message, utils.mensajes.err)
            End If
        End Try
    End Sub
    Private Sub frmFeriados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBoxes = {txtDescripcion}
    End Sub
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DtCalendario.ValueChanged
        txtDescripcion.Text = DtCalendario.Value.ToShortDateString
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class