Public Class frmModulo
    Dim modu As Modulo
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
            MessageBox.Show(ex.Message)
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

    Private Sub txtCodigo_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txtCodigo.MaskInputRejected
        MessageBox.Show("Ingrese un Valor numerico de 6 digitos")
    End Sub

    Public Sub iniciarControles()

        txtCuidador.Text = ""
        txtDescripcion.Text = ""
        txtEnfermeria.Text = ""
        txtFono.Text = ""
        txtKinesio.Text = ""
        txtMedico.Text = ""
    End Sub

    Private Sub txtCodigo_Click(sender As Object, e As EventArgs) Handles txtCodigo.Click
        txtCodigo.Select(0, 0)
    End Sub

    Private Sub txtMedico_TextChanged(sender As Object, e As EventArgs) Handles txtMedico.TextChanged
        validarTxtBox(txtMedico)
    End Sub

    Private Sub validarTxtBox(_txtBox As TextBox)
        If _txtBox.Text <> "" Then
            If Not IsNumeric(_txtBox.Text) Then
                MessageBox.Show("Ingrese un valor numerico")
                _txtBox.Text = ""
            End If
        End If
    End Sub

    Private Sub validarCampos()
        If txtCodigo.Text = "" Or txtDescripcion.Text = "" Or txtMedico.Text = "" Or txtEnfermeria.Text = "" Or txtKinesio.Text = "" Or txtFono.Text = "" Or txtCuidador.Text = "" Then
            Throw New Exception("Complete todos los campos")
        End If
    End Sub

    Private Sub txtEnfermeria_TextChanged(sender As Object, e As EventArgs) Handles txtEnfermeria.TextChanged
        validarTxtBox(txtEnfermeria)
    End Sub

    Private Sub txtKinesio_TextChanged(sender As Object, e As EventArgs) Handles txtKinesio.TextChanged
        validarTxtBox(txtKinesio)
    End Sub

    Private Sub txtFono_TextChanged(sender As Object, e As EventArgs) Handles txtFono.TextChanged
        validarTxtBox(txtFono)
    End Sub

    Private Sub txtCuidador_TextChanged(sender As Object, e As EventArgs) Handles txtCuidador.TextChanged
        validarTxtBox(txtCuidador)
    End Sub
End Class