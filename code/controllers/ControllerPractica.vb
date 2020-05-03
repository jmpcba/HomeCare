Imports Newtonsoft
Public Class ControllerPractica
    Private _practicas As List(Of Practica)
    Private feriados As List(Of Date)
    Private fm As ControllerFeriado
    Private ut = New utils()

    Public Sub New(year)
        fm = New ControllerFeriado(year)
        _practicas = New List(Of Practica)
    End Sub

    Public Function findeFeriado(fecha) As Boolean
        Try
            Return fm.esferiado(fecha)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub addPractica(_pre As Prestador, pac As Paciente, modulo As Modulo, submodulo As subModulo,
                           hs As Decimal, hs_diferencial As Decimal, fecha As Date, obs As String, obsPac As String, obsPres As String)
        'definir si semana o finde o feriado
        Dim hsLaV As Decimal
        Dim hsferiado As Decimal
        Dim p As Practica

        If findeFeriado(fecha) Then
            hsLaV = 0
            hsferiado = hs
        Else
            hsLaV = hs
            hsferiado = 0
        End If

        p = New Practica(_pre, pac, modulo.id, submodulo.id, fecha, hsLaV, hsferiado, hs_diferencial, obsPres, obsPac, obs)
        _practicas.Add(p)
    End Sub

    Public Function InsertarPracticas() As DataTable
        Dim result = New DataTable()
        Try
            Dim api As New API(API.resources.PRACTICA)
            Dim serialObject = Json.JsonConvert.SerializeObject(_practicas)
            result = api.send_post_put(serialObject, API.httpMethods.httpPOST, True)

            Return result
        Catch ex As apiException
            Throw
        End Try
    End Function
End Class
