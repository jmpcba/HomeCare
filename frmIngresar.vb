Public Class frmIngresar
    Dim usuario As New Usuario
    Dim ut As New utils
        Dim txtBoxes As TextBox()
        Dim db As New DB

        Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            ut.validarTxtBoxLleno(txtBoxes)
            ut.validarNumerico(numDni)
            ut.validarLargo(numDni, 8)

            usuario.dni = numDni.Text.Trim

            If txtPassw.Text.Trim <> usuario.pass Then
                numDni.Focus()
                Throw New Exception("Contraseña invalida")
            End If

            My.Settings.dni = usuario.dni
            My.Settings.nivel = usuario.nivel
            Me.Hide()
            frmPrincipal.ShowDialog()

        Catch ex As Exception
            numDni.Focus()
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

        Private Sub iniciarControles()
            ut.iniciarTxtBoxes(txtBoxes)
        End Sub

        Private Sub frmusuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            txtBoxes = {numDni, txtPassw}
        End Sub
        Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
            Me.Close()
        End Sub
    End Class
