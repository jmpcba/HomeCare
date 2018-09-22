Public Class Medico
    Public matricula As Integer
    Public nombre As String
    Public prestador As String

    Public Sub New(_matricula As Integer)
        'TODO: BUSCAR EN LA DB Y CREAR EL OBJETO A PARTIR DE AHI
    End Sub

    Public Sub New(_matricula As Integer, _nombre As String, _prestador As String)
        matricula = _matricula
        nombre = _nombre
        prestador = _prestador
    End Sub
End Class
