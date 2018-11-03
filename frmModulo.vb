Public Class frmModulo

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try

            '  Dim modulos As New Modulo(txtCodigo.Text, txtDescripcion.Text, numMedico.Text, numEnfermeria.Text,
            '  numKinesio.Text, numFono.Text, numCuidador.Text)

            ' Modulo.insertar()
        Catch ex As Exception
            'esta linea es siempre la misma. es un pop up box, ex.message es el texto de la excepcion
            MessageBox.Show(ex.Message)
        End Try
    End Sub






    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()

    End Sub
End Class