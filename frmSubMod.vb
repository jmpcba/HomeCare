Public Class frmSubMod
    Dim subMod As subModulo
    Dim ut As New utils
    Dim txtBoxes As TextBox()

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If IsNothing(subMod) Then
                ut.validarLargo(txtCodigo, 6)
                ut.validarTxtBoxLleno(txtBoxes)
                subMod = New subModulo(txtCodigo.Text, txtDescripcion.Text, txtTope.Text)
                subMod.insertar()
                MessageBox.Show("Guardado Exitoso")
                iniciarControles()
            Else
                ut.validarLargo(txtCodigo, 6)
                ut.validarTxtBoxLleno(txtBoxes)

                If txtDescripcion.Text <> subMod.descripcion Then
                    subMod.descripcion = txtDescripcion.Text
                End If

                If txtTope.Text <> subMod.tope Then
                    subMod.tope = txtTope.Text
                End If
                subMod.actualizar()
                ut.iniciarTxtBoxes(txtBoxes)
                subMod = Nothing
                MessageBox.Show("Guardado Exitoso")
                iniciarControles()
            End If
        Catch ex As Exception
            If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                MessageBox.Show("Ya existe un Sub Modulo con el mismo codigo")
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
            subMod = New subModulo
            subMod.codigo = txtCodigo.Text
            txtDescripcion.Text = subMod.descripcion
            txtTope.Text = subMod.tope
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            subMod = Nothing
            iniciarControles()
        End Try
    End Sub

    Private Sub iniciarControles()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtTope.Text = ""
    End Sub

    Private Sub validarLargoCodigo()
        If txtCodigo.Text.Length <> 6 Then
            Throw New Exception("El codigo debe tener 6 digitos")
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        Try
            If txtCodigo.Text <> "" Then
                btnBuscar.Enabled = True
            Else
                btnBuscar.Enabled = False
            End If
            ut.validarNumerico(txtCodigo)

            If Not IsNothing(subMod) Then
                subMod = Nothing
            End If

        Catch ex As Exception
            txtCodigo.Text = ""
            btnBuscar.Enabled = False
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub numTope_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs)
        Try
            ut.validarNumerico(txtDescripcion)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtTope_TextChanged(sender As Object, e As EventArgs)
        Try
            ut.validarNumerico(txtTope)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmSubMod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnBuscar.Enabled = False
        txtBoxes = {txtCodigo, txtDescripcion, txtTope}
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcion.TextChanged

    End Sub

    Private Sub txtTope_TextChanged_1(sender As Object, e As EventArgs) Handles txtTope.TextChanged
        Try
            ut.validarNumerico(txtTope)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class