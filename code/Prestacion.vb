Public Class Prestacion
    Public tipo As Integer
    Public nombre As String

    Public Sub New(_tipo As Integer)
        'TODO: BUSCAR EN LA DB
    End Sub

    Public Sub New(_tipo As Integer, _nombre As String)
        tipo = _tipo
        nombre = _nombre
    End Sub
End Class
