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

                Dim pass = usuario.getUsuario(numDni.Text)

            If pass = Nothing Or txtPassw.Text <> pass Then
                ut.mensaje("USUARIO O PASSWORD ERRONEA", utils.mensajes.err)
                numDni.Focus()
            Else
                My.Settings.dni = numDni.Text
                My.Settings.nivel = "0"
                frmPrincipal.ShowDialog()
            End If

        Catch ex As Exception

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
