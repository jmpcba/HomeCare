Public Class frmSubMod
    Dim subMod As subModulo
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If IsNothing(subMod) Then
                validarControles()
                subMod = New subModulo(txtCodigo.Text, txtDescripcion.Text, txtTope.Text)
                subMod.insertar()
                MessageBox.Show("Guardado Exitoso")
            Else
                If txtDescripcion.Text <> subMod.descripcion Then
                    subMod.descripcion = txtDescripcion.Text
                End If

                If txtTope.Text <> subMod.tope Then
                    subMod.tope = txtTope.Text
                End If
                subMod.actualizar()
                MessageBox.Show("Guardado Exitoso")
            End If
        Catch ex As Exception
            If ex.Message.Contains("duplicate values in the index") Then
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

    Private Sub validarControles()
        If txtCodigo.Text = "" Or txtDescripcion.Text = "" Or txtTope.Text = "" Then
            Throw New Exception("Ingrese valores para todos los campos")
        End If
    End Sub

    Private Sub validarNumerico(_txtBox As TextBox)
        If _txtBox.Text <> "" Then
            If Not IsNumeric(_txtBox.Text) Then
                _txtBox.Text = ""
                Throw New Exception("Debe ingresar un valor numerico")
            End If
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        Try
            If txtCodigo.Text <> "" Then
                btnBuscar.Enabled = True
            Else
                btnBuscar.Enabled = False
            End If
            validarNumerico(txtCodigo)

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
            validarNumerico(txtDescripcion)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtTope_TextChanged(sender As Object, e As EventArgs) Handles txtTope.TextChanged
        Try
            validarNumerico(txtTope)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmSubMod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnBuscar.Enabled = False
    End Sub
End Class