Public Class frmPacientes
    Dim pacientes As Paciente
    Dim ut As New utils
    Dim txtBoxes As TextBox()

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If IsNothing(pacientes) Then
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarLargo(numDni, 8)
                ut.validarLargo(numAfiliado, 12)
                pacientes = New Paciente(numAfiliado.Text, numDni.Text, txtNombre.Text, txtApellido.Text, txtObSocial.Text, txtLocalidad.Text)
                pacientes.insertar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
            Else
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarLargo(numDni, 8)
                ut.validarLargo(numAfiliado, 12)
                If txtObSocial.Text <> pacientes.obrasocial Then
                    pacientes.obrasocial = txtObSocial.Text
                End If
                If txtNombre.Text <> pacientes.nombre Then
                    pacientes.nombre = txtNombre.Text
                End If
                If txtApellido.Text <> pacientes.apellido Then
                    pacientes.apellido = txtApellido.Text
                End If
                If txtObSocial.Text <> pacientes.obrasocial Then
                    pacientes.obrasocial = txtObSocial.Text
                End If
                If txtLocalidad.Text <> pacientes.localidad Then
                    pacientes.localidad = txtLocalidad.Text
                End If

                pacientes.actualizar()
                ut.iniciarTxtBoxes(txtBoxes)
                pacientes = Nothing
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
            End If
        Catch ex As Exception
            If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                ut.mensaje("Ya existe un paciente con el mismo numero", utils.mensajes.err)
            Else
                ut.mensaje(ex.Message, utils.mensajes.err)
            End If
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            pacientes = New Paciente
            pacientes.afiliado = numAfiliado.Text
            numDni.Text = pacientes.dni
            txtNombre.Text = pacientes.nombre
            txtApellido.Text = pacientes.apellido
            txtObSocial.Text = pacientes.obrasocial
            txtLocalidad.Text = pacientes.localidad
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            pacientes = Nothing
            iniciarControles()
        End Try
    End Sub

    Private Sub iniciarControles()
        numAfiliado.Text = ""
        numDni.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtObSocial.Text = ""
        txtLocalidad.Text = ""
    End Sub

   Private Sub txtAfiliado_TextChanged(sender As Object, e As EventArgs) Handles numAfiliado.TextChanged
        Try
            If numAfiliado.Text <> "" Then
                btnBuscar.Enabled = True
            Else
                btnBuscar.Enabled = False
            End If
            ut.validarNumerico(numAfiliado)
            If Not IsNothing(pacientes) Then
                pacientes = Nothing
            End If

        Catch ex As Exception
            numAfiliado.Text = ""
            btnBuscar.Enabled = False
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub frmPacientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnBuscar.Enabled = False
        txtBoxes = {numAfiliado, numDni, txtNombre, txtApellido, txtObSocial, txtLocalidad}
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class