Public Class frmSubMod
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'despues de hacer doble click al boton se abre este metodo que maneja el evento click del boton

        'dentro de un try catch se crea un objeto nuevo
        Try
            'se crea el objeto, los parametros varian segun el objeto. en este caso es codigo y descripcion
            Dim submod As New subModulo(txtCodigo.Text, txtDescripcion.Text, numTope.Text)

            'llamar al metodo insertar del objeto
            submod.insertar()
        Catch ex As Exception
            'esta linea es siempre la misma. es un pop up box, ex.message es el texto de la excepcion
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class