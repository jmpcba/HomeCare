Public Class frmEmail
    'Dim mail As Email
    Dim ut As New utils
    Dim txtBoxes As TextBox()
    Dim db As New DB

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            btnGuardar.Enabled = False
            ut.validarTxtBoxLleno(txtBoxes)

            db.actualizarMail(txtEmail.Text)
            db.actualizarMailPass(txtPass.Text)
            ut.mensaje("Guardado Exitoso", utils.mensajes.info)
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        Finally
            btnGuardar.Enabled = True
        End Try
    End Sub

    Private Sub iniciarControles()
        ut.iniciarTxtBoxes(txtBoxes)
    End Sub

    Private Sub frmPacientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBoxes = {txtEmail, txtPass}
        Try
            txtEmail.Text = db.getEmail
            txtPass.Text = db.getEmailPass
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        iniciarControles()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
End Class