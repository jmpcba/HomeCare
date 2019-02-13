Public Class frmUsuarios
    Dim user As Usuario
    Dim ut As New utils
    Dim txtBoxes As TextBox()
    Dim db As New DB

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            If IsNothing(user) Then
                If cbNivel.SelectedIndex = -1 Then
                    Throw New Exception("Seleccione un valor para NIVEL")
                End If
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarLargo(numDni, 8)
                user = New Usuario(numDni.Text.Trim, txtNombre.Text.Trim, txtApellido.Text.Trim, txtPassw.Text.Trim, cbNivel.SelectedItem)
                user.insertar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
            Else
                Dim enc As New Encriptador()
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarNumerico(numDni)
                ut.validarLargo(numDni, 8)
                If txtNombre.Text.Trim <> user.nombre Then
                    user.nombre = txtNombre.Text.Trim
                End If

                If txtApellido.Text.Trim <> user.apellido Then
                    user.apellido = txtApellido.Text.Trim
                End If
                If txtPassw.Text.Trim <> user.pass Then
                    user.pass = txtPassw.Text.Trim
                End If
                If cbNivel.SelectedItem <> user.nivel Then
                    user.nivel = cbNivel.SelectedItem
                End If

                user.actualizar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
                ut.iniciarTxtBoxes(txtBoxes)
                user = Nothing
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim frmBuscar As New frmBuscar(Me)
            frmBuscar.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            user = Nothing
            iniciarControles()
        End Try
    End Sub

    Public Sub resultadoBusqueda(ByRef _usuario As Usuario)
        numDni.ReadOnly = True
        numDni.Text = _usuario.dni
        txtNombre.Text = _usuario.nombre
        txtApellido.Text = _usuario.apellido
        txtPassw.Text = _usuario.pass
        cbNivel.SelectedItem = _usuario.nivel
        cbNivel.Enabled = True
        user = _usuario
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        user = Nothing
        iniciarControles()
    End Sub

    Private Sub iniciarControles()
        cbNivel.Enabled = True
        cbNivel.SelectedIndex = -1
        numDni.ReadOnly = False
        ut.iniciarTxtBoxes(txtBoxes)
    End Sub

    Private Sub frmusuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBoxes = {numDni, txtNombre, txtApellido, txtPassw}
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub frmUsuarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub
End Class
