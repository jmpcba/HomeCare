Public Class frmIngresar
    Dim usuario As Usuario
    Dim ut As utils
    Dim txtBoxes As TextBox()
    Dim db As DB

    Private Async Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            ut.validarTxtBoxLleno(txtBoxes)
            My.Settings.userName = numDni.Text.Trim
            My.Settings.userPass = txtPassw.Text.Trim
            Dim cg As Cognito = Cognito.Instance
            Await cg.login()
            My.Settings.dni = "2918898"
            My.Settings.nivel = 0
            Me.Hide()
            frmPrincipal.ShowDialog()

        Catch ex As Amazon.CognitoIdentityProvider.Model.NotAuthorizedException
            numDni.Focus()
            ut.mensaje("Contraseña invalida", utils.mensajes.err)

        Catch ex As Amazon.CognitoIdentityProvider.Model.UserNotFoundException
        numDni.Focus()
        ut.mensaje("No existe el usuario", utils.mensajes.err)
        End Try
    End Sub

    Private Sub iniciarControles()
            ut.iniciarTxtBoxes(txtBoxes)
        End Sub

    Private Sub frmusuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            txtBoxes = {numDni, txtPassw}
            ut = New utils
            If My.Settings.DBPath = "" Then
                ut.mensaje("Seleccione la ubicacion de la base de datos", utils.mensajes.err)
                ut.setDB()
                ut.mensaje("Base de datos configurada con exito - Reinicie la aplicacion", utils.mensajes.info)
                Me.Close()
            Else
                usuario = New Usuario()
                db = New DB
            End If
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try

    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
End Class
