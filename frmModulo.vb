Public Class frmModulo
    'cambiar validaciones para que usen el objeto ut
    Dim modu As Modulo
    Dim ut As New utils
    Dim txtboxes As TextBox()

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            If IsNothing(modu) Then
                validarCampos()
                modu = New Modulo(txtCodigo.Text, txtMedico.Text, txtEnfermeria.Text, txtKinesio.Text, txtFono.Text, txtCuidador.Text)
                modu.insertar()
                iniciarControles()
                MessageBox.Show("Guardado Exitoso")
                txtCodigo.Text = ""

            Else
                If txtMedico.Text <> modu.topeMedico Then
                    modu.topeMedico = txtMedico.Text
                End If

                If txtEnfermeria.Text <> modu.topeEnfermeria Then
                    modu.topeEnfermeria = txtEnfermeria.Text
                End If

                If txtKinesio.Text <> modu.topeKinesio Then
                    modu.topeKinesio = txtKinesio.Text
                End If

                If txtFono.Text <> modu.topeFono Then
                    modu.topeFono = txtFono.Text
                End If

                If txtCuidador.Text <> modu.topeCuidador Then
                    modu.topeCuidador = txtCuidador.Text
                End If

                modu.actualizar()
                MessageBox.Show("Guardado Exitoso")
            End If

        Catch ex As Exception
            If ex.Message.Contains("duplicate values in the index") Then
                MessageBox.Show("Ya existe un Modulo con el mismo codigo")
            Else
                MessageBox.Show(ex.Message)
            End If
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            modu = New Modulo
            modu.codigo = txtCodigo.Text
            txtCuidador.Text = modu.topeCuidador
            'txtDescripcion.Text=
            txtEnfermeria.Text = modu.topeEnfermeria
            txtFono.Text = modu.topeFono
            txtKinesio.Text = modu.topeKinesio
            txtMedico.Text = modu.topeMedico
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            iniciarControles()
            modu = Nothing
        End Try
    End Sub

    Private Sub txtCodigo_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs)
        MessageBox.Show("Ingrese un Valor numerico de 6 digitos")
    End Sub

    Public Sub iniciarControles()
        txtCodigo.Text = ""
        txtCuidador.Text = ""
        txtDescripcion.Text = ""
        txtEnfermeria.Text = ""
        txtFono.Text = ""
        txtKinesio.Text = ""
        txtMedico.Text = ""
    End Sub

    Private Sub txtCodigo_Click(sender As Object, e As EventArgs)
        txtCodigo.Select(0, 0)
    End Sub

    Private Sub txtMedico_TextChanged(sender As Object, e As EventArgs)
        Try
            validarTxtBox(txtMedico)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub validarTxtBox(_txtBox As TextBox)
        If _txtBox.Text <> "" Then
            If Not IsNumeric(_txtBox.Text) Then
                _txtBox.Text = ""
                Throw New Exception("Ingrese un valor numerico")
            End If
        End If
    End Sub

    Private Sub validarCampos()
        If txtCodigo.Text = "" Or txtDescripcion.Text = "" Or txtMedico.Text = "" Or txtEnfermeria.Text = "" Or txtKinesio.Text = "" Or txtFono.Text = "" Or txtCuidador.Text = "" Then
            Throw New Exception("Complete todos los campos")
        End If
    End Sub

    Private Sub txtEnfermeria_TextChanged(sender As Object, e As EventArgs) Handles txtEnfermeria.TextChanged
        Try
            validarTxtBox(txtEnfermeria)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtKinesio_TextChanged(sender As Object, e As EventArgs) Handles txtKinesio.TextChanged
        Try
            validarTxtBox(txtKinesio)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtFono_TextChanged(sender As Object, e As EventArgs) Handles txtFono.TextChanged
        Try
            validarTxtBox(txtFono)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtCuidador_TextChanged(sender As Object, e As EventArgs) Handles txtCuidador.TextChanged
        Try
            validarTxtBox(txtCuidador)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmModulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnBuscar.Enabled = False
        txtboxes = {} 'llenar con texboxes
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs)
        Try
            If txtCodigo.Text <> "" Then
                btnBuscar.Enabled = True
            Else
                btnBuscar.Enabled = False
            End If

            If Not IsNothing(modu) Then
                modu = Nothing
            End If

            validarTxtBox(txtCodigo)

        Catch ex As Exception
            txtCodigo.Text = ""
            btnBuscar.Enabled = False
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtCodigo_TextChanged_1(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged

    End Sub
End Class