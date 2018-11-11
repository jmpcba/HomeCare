Public Class frmPrestacion
    Dim prestacion As Prestacion
    Dim ut As New utils
    Dim txtBoxes As TextBox()

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If IsNothing(prestacion) Then
                ut.validarLargo(numPresCod, 6)
                ut.validarTxtBoxLleno(txtBoxes)
                prestacion = New Prestacion(numPresCod.Text, txtDescri.Text)
                prestacion.insertar()
                MessageBox.Show("Guardado Exitoso")
                iniciarControles()
            Else
                ut.validarLargo(numPresCod, 6)
                ut.validarTxtBoxLleno(txtBoxes)

                If txtDescri.Text <> prestacion.descripcion Then
                    prestacion.descripcion = txtDescri.Text
                End If

                prestacion.actualizar()
                ut.iniciarTxtBoxes(txtBoxes)
                prestacion = Nothing
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            prestacion = New Prestacion
            prestacion.codigo = numPresCod.Text
            txtDescri.Text = prestacion.descripcion
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            prestacion = Nothing
            iniciarControles()
        End Try
    End Sub

    Private Sub iniciarControles()
        numPresCod.Text = ""
        txtDescri.Text = ""
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles numPresCod.TextChanged
        Try
            If numPresCod.Text <> "" Then
                btnBuscar.Enabled = True
            Else
                btnBuscar.Enabled = False
            End If
            ut.validarNumerico(numPresCod)

            If Not IsNothing(prestacion) Then
                prestacion = Nothing
            End If

        Catch ex As Exception
            numPresCod.Text = ""
            btnBuscar.Enabled = False
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmprestacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnBuscar.Enabled = False
        txtBoxes = {numPresCod, txtDescri}
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtDescri.TextChanged

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class