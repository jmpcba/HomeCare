Public Class Paciente

    Public DNI As Integer
    Public nombre As String
    Public beneficio As Integer

    Public Sub New(_DNI As Integer)
        Dim db = New DB()
        Dim dt As DataTable

        Try
            dt = db.getPaciente(_DNI)

            DNI = dt(0)(0)
            nombre = dt(0)(1)
            beneficio = dt(0)(2)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub New(_dni As Integer, _nombre As String, _beneficio As Integer)
        DNI = _dni
        nombre = _nombre
        beneficio = _beneficio
    End Sub
End Class
