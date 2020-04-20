Public Class frmUsuarios
    Dim um As UserManager
    Dim ut As New utils
    Dim txtBoxes As TextBox()
    Dim db As New DB

    Private Async Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            um = New UserManager()
            Await um.createNewUser(txtUsuario.Text.Trim, txtPassw.Text.Trim, txtMail.Text.Trim, txtNombre.Text.Trim, txtApellido.Text.Trim)

            ut.mensaje("Guardado Exitoso", utils.mensajes.info)
            iniciarControles()
            'Else
            '    Dim enc As New Encriptador()
            '    ut.validarTxtBoxLleno(txtBoxes)
            '    ut.validarNumerico(txtUsuario)
            '    ut.validarLargo(txtUsuario, 8)
            '    If txtMail.Text.Trim <> user.nombre Then
            '        user.nombre = txtMail.Text.Trim

            'If txtApellido.Text.Trim <> user.apellido Then
            '    user.apellido = txtApellido.Text.Trim
            'End If
            'If txtPassw.Text.Trim <> user.pass Then
            '    user.pass = txtPassw.Text.Trim
            'End If
            'If cbNivel.SelectedItem <> user.nivel Then
            '    user.nivel = cbNivel.SelectedItem
            'End If

            'user.actualizar()
            'ut.mensaje("Guardado Exitoso", utils.mensajes.info)
            'iniciarControles()
            'ut.iniciarTxtBoxes(txtBoxes)
            'user = Nothing
            'End If



        Catch ex As Exception
            If ex.Message.Contains("User already exists") Then
                ut.mensaje("El nombre de usuario ya existe", utils.mensajes.err)

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

            iniciarControles()
        End Try
    End Sub

    'Public Sub resultadoBusqueda(ByRef _usuario As Usuario)
    '    txtUsuario.ReadOnly = True
    '    txtUsuario.Text = _usuario.dni
    '    txtMail.Text = _usuario.nombre
    '    txtApellido.Text = _usuario.apellido
    '    txtPassw.Text = _usuario.pass
    '    cbNivel.SelectedItem = _usuario.nivel
    '    cbNivel.Enabled = True
    '    user = _usuario
    'End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        iniciarControles()
    End Sub

    Private Sub iniciarControles()
        cbNivel.Enabled = True
        cbNivel.SelectedIndex = -1
        txtUsuario.ReadOnly = False
        ut.iniciarTxtBoxes(txtBoxes)
    End Sub

    Private Sub frmusuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBoxes = {txtUsuario, txtMail, txtApellido, txtPassw}

    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub frmUsuarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub
End Class
