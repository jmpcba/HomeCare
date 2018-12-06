Public Class frmUsuarios
    Dim usuario As New Usuario
    Dim ut As New utils
    Dim txtBoxes As TextBox()
    Dim db As New DB

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)

        Try
            If IsNothing(usuario) Then
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarLargo(numDni, 8)
                usuario = New Usuario(numDni.Text.Trim, txtNombre.Text.Trim, txtApellido.Text.Trim, txtPassw.Text.Trim, txtNivel.Text.Trim)
                usuario.insertar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
            Else
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarNumerico(numDni)
                ut.validarLargo(numDni, 8)
                If txtNombre.Text.Trim <> usuario.nombre Then
                    usuario.nombre = txtNombre.Text.Trim
                End If

                If txtApellido.Text.Trim <> usuario.apellido Then
                    usuario.apellido = txtApellido.Text.Trim
                End If
                If txtPassw.Text.Trim <> usuario.pass Then
                    usuario.pass = txtPassw.Text.Trim
                End If
                If txtNivel.Text.Trim <> usuario.Nivel Then
                    usuario.nivel = txtNivel.Text.Trim
                End If
            End If
            If txtNivel.Text.Trim <> "0" And txtNivel.Text.Trim <> "1" And txtNivel.Text.Trim <> "2" Then
                ut.mensaje("NIVEL SOLO PUEDE SER 0 1 o 2", utils.mensajes.err)
                txtNivel.Focus()
            End If

        Catch ex As Exception
            If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                ut.mensaje("Ya existe un paciente con el mismo numero", utils.mensajes.err)
            Else
                ut.mensaje(ex.Message, utils.mensajes.err)
            End If
            If ex.Message.Contains("No se realizaron modificaciones") Then
                iniciarControles()
            End If
        End Try

    End Sub

    Private Sub iniciarControles()
        ut.iniciarTxtBoxes(txtBoxes)
    End Sub

    Private Sub frmusuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBoxes = {numDni, txtNombre, txtApellido, txtPassw, txtNivel}
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class
