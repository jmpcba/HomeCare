Imports Newtonsoft
Public Class GestorPracticas
    Private _practicas As New List(Of Practica)

    Public ReadOnly Property practicas As List(Of Practica)
        Get
            Return _practicas
        End Get
    End Property

    Public Sub add(_practica As Practica)
        _practicas.Add(_practica)
    End Sub

    Public Sub guardar()
        Try
            Dim api As New Backend(Backend.services.liquidacion)
            Dim serialObject = Json.JsonConvert.SerializeObject(Me)
            api.send_post_put(serialObject, Backend.methods.httpPOST)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
