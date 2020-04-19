Imports Amazon.CognitoIdentityProvider.Model

Public Class frmIngresar
    Dim usuario As Usuario
    Dim ut As utils
    Dim txtBoxes As TextBox()
    Dim db As DB
    Dim verificacion = False

    Private Async Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            ut.validarTxtBoxLleno(txtBoxes)
            My.Settings.userName = numDni.Text.Trim
            My.Settings.userPass = txtPassw.Text.Trim
            Dim cg As UserSesionCognito = UserSesionCognito.Instance
            btnGuardar.Enabled = False
            If verificacion Then
                My.Settings.verificationCode = txtVerificacion.Text.Trim
                Await cg.verify()
                lblVerificacion.Visible = False
                txtVerificacion.Visible = False
                lblExplicacionVerCode.Visible = False
                verificacion = False
            Else
                Await cg.login()
            End If

            My.Settings.dni = "2918898"
            My.Settings.nivel = 0
            Me.Hide()
            frmPrincipal.ShowDialog()

        Catch ex As NotAuthorizedException
            numDni.Focus()
            ut.mensaje("Contraseña invalida", utils.mensajes.err)

        Catch ex As UserNotFoundException
            numDni.Focus()
            ut.mensaje("No existe el usuario", utils.mensajes.err)
        Catch ex As UserNotConfirmedException
            lblVerificacion.Visible = True
            txtVerificacion.Visible = True
            lblExplicacionVerCode.Visible = True
            lblExplicacionVerCode.ForeColor = Color.Red
            verificacion = True
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        Finally
            btnGuardar.Enabled = True
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
