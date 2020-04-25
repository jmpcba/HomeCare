Imports Newtonsoft
Public Class FeriadoControl
    Private _feriados As DataTable
    Private _year As Integer

    Public Sub New(year As Integer)
        Me._year = year
        getFeriados(year)
    End Sub

    Public Sub refresh()
        getFeriados(Me._year)
    End Sub
    Private Sub getFeriados(year As Integer)
        Dim oldCI As Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        Try
            Try

                Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

                Dim api As New API(API.resources.FERIADO)
                Dim raw_result = New DataTable
                raw_result = api.get_table(String.Format("year={0}", year))

                _feriados = raw_result.Clone()
                _feriados.Columns("fecha").DataType = GetType(Date)

                For Each r As DataRow In raw_result.Rows
                    _feriados.ImportRow(r)
                Next

                Dim c = _feriados.Columns.Count
                _feriados.Columns("ultima_modificacion").SetOrdinal(c - 1)
                _feriados.Columns("usuario_ultima_modificacion").SetOrdinal(c - 2)
                _feriados.Columns("id").SetOrdinal(0)
                _feriados.Columns("fecha").SetOrdinal(1)
                _feriados.Columns("descripcion").SetOrdinal(2)
            Catch ex As ApiTableNotFoundException
                _feriados = Nothing
            End Try
        Catch ex As apiException
            Throw
        Finally
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        End Try
    End Sub

    Public Function getFeriado(fecha As Date) As feridos_nva
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        Dim r As DataRow()
        Dim feriado_fecha As Date
        Dim feriado_descripcion As String

        If Not IsNothing(_feriados) Then
            Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            r = _feriados.Select(String.Format("fecha=#{0}#", fecha.Date))
            Threading.Thread.CurrentThread.CurrentCulture = oldCI

            If r.Length = 1 Then
                feriado_descripcion = r(0)("descripcion")
                feriado_fecha = r(0)("fecha")
                Return New feridos_nva(feriado_fecha, feriado_descripcion)
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

    End Function

    Public Function createFeriado(fecha As Date, desc As String) As feridos_nva
        Return New feridos_nva(fecha, desc)
    End Function

    Public Function esferiado(fecha) As Boolean
        Dim result = False

        If fecha.DayOfWeek = DayOfWeek.Saturday Or fecha.DayOfWeek = DayOfWeek.Sunday Then
            result = True
        Else
            If Not IsNothing(getFeriado(fecha)) Then
                result = True
            End If
        End If
        Return result
    End Function

    Public Sub insertNew(fecha As Date, descripcion As String)
        Dim feriado = New feridos_nva(fecha, descripcion)
        Try
            Dim api As New API(API.resources.FERIADO)
            Dim serialObject = Json.JsonConvert.SerializeObject(feriado)
            api.send_post_put(serialObject, API.httpMethods.httpPOST)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub modify(feriado As feridos_nva)
        Try
            Dim api As New API(API.resources.FERIADO)
            _feriados = Nothing
            Dim serialObject = Json.JsonConvert.SerializeObject(feriado)
            api.send_post_put(serialObject, API.httpMethods.httpPUT)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public ReadOnly Property feriados As DataTable
        Get
            Return _feriados
        End Get
    End Property
End Class
