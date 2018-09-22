Public Class Paciente

    Public DNI As Integer
    Public nombre As String
    Public beneficio As Integer

    Public Sub New(_DNI As Integer)
        'TODO: CODIGO PARA QUE BUSQUE EL CLIENTE EN LA DB Y CONSTRUYA EL OBJETO CON ESOS DATOS
    End Sub

    Public Sub New(_dni As Integer, _nombre As String, _beneficio As Integer)
        DNI = _dni
        nombre = _nombre
        beneficio = _beneficio
    End Sub
End Class
