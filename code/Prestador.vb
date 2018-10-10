Public Class Prestador
    Public matricula As Integer
    Public nombre As String
    Public prestador As String

    Public Sub New(_matricula As Integer)
        Dim db = New DB()
        Dim dt As DataTable

        Try
            dt = db.getRow(_matricula, DB.tablas.medicos)
            matricula = dt(0)(0)
            nombre = dt(0)(1)
            prestador = dt(0)(2)

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub New(_matricula As Integer, _nombre As String, _prestador As String)
        Try
            matricula = _matricula
            nombre = _nombre
            prestador = _prestador
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
