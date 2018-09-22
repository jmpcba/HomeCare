Public Class Prestacion
    Public tipo As Integer
    Public nombre As String

    Public Sub New(_tipo As Integer)
        Dim db = New DB()
        Dim dt As DataTable

        Try
            dt = db.getRow(_tipo, DB.tablas.prestaciones)
            tipo = dt(0)(0)
            nombre = dt(0)(1)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub New(_tipo As Integer, _nombre As String)
        Try
            tipo = _tipo
            nombre = _nombre
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
