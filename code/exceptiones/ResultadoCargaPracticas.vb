Public Class ResultadoCargaPracticas

    Public filaError As Integer
    Public mensajeError As String

    Public Sub New(_filaError As Integer, _mensajeError As String)
        filaError = _filaError
        mensajeError = _mensajeError
    End Sub
End Class
