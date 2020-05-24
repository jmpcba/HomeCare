Imports Newtonsoft
Imports System.DateTime

Public Class ControllerPractica
    Private _practicas As List(Of Practica)
    Private feriados As List(Of Date)
    Private fm As ControllerFeriado
    Private ut = New utils()

    Public Enum tipoPracticas
        paciente
        prestador
    End Enum

    Public Sub New()
        _practicas = New List(Of Practica)
    End Sub
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

    Public ReadOnly Property practicas(fecha As Date, tipo As tipoPracticas, id As Integer)
        Get
            Dim startDate As Date
            Dim endDate As Date
            Dim type_parameter As String
            Dim query_string As String

            Dim oldCI As Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            startDate = New Date(fecha.Year, fecha.Month, 1)
            endDate = New Date(fecha.Year, fecha.Month, DaysInMonth(fecha.Year, fecha.Month))

            If tipo = tipoPracticas.paciente Then
                type_parameter = "id_paciente"
            ElseIf tipo = tipoPracticas.prestador Then
                type_parameter = "id_prestador"
            End If

            query_string = String.Format("{0}={1}&start_date={2}&end_date={3}", type_parameter, id, startDate, endDate)
            Dim api As New API(API.resources.PRACTICA)
            Try
                Return api.get_table(query_string, True)
            Catch ex As apiException
                Throw
            Finally
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
            End Try


        End Get
    End Property
End Class
