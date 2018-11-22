Public Class frmEmail
    'Dim mail As Email
    Dim ut As New utils
    Dim txtBoxes As TextBox()

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

    End Sub

    Private Sub iniciarControles()
        ut.iniciarTxtBoxes(txtBoxes)
    End Sub

    Private Sub frmPacientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBoxes = {txtEmail, txtPass}
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        iniciarControles()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
End Class