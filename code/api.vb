Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft
Public Class API
    Private apiEndpoint As String
    Private um As UserManager
    Public Enum resources
        PRESTADOR
        PACIENTE
        ZONA
        MODULO
        SUBMODULO
        LIQUIDACION
        ESPECIALIDAD
        FERIADO
        PRACTICA
        USUARIO
    End Enum

    Public Enum httpMethods
        httpGET
        httpPOST
        httpPUT
        httpDELETE
    End Enum

    Public Sub New(r As resources)
        apiEndpoint = "https://cl86zb12f8.execute-api.us-east-1.amazonaws.com/DEV/v1/" & r.ToString()
        um = New UserManager()
    End Sub

    Public Function get_table() As DataTable
        Dim response As WebResponse
        Dim dataStream As Stream
        Dim reader As StreamReader

        Try
            Dim request As WebRequest = WebRequest.Create(apiEndpoint)
            request.Method = "GET"
            request.Headers.Add("X-COG-ID", um.currentSession.token)
            request.ContentType = "application/json"
            response = request.GetResponse()
            dataStream = response.GetResponseStream()
            reader = New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()

            If responseFromServer = """""" Then
                Return New DataTable()
            Else
                Return Json.JsonConvert.DeserializeObject(Of DataTable)(responseFromServer)
            End If


        Catch ex As WebException
            Dim exceptionReader = New StreamReader(ex.Response.GetResponseStream())
            Dim content = exceptionReader.ReadToEnd()
            exceptionReader.Close()
            Throw New apiException(content)

        Finally
            If Not IsNothing(reader) Then
                reader.Close()
            End If

            If Not IsNothing(response) Then
                response.Close()
            End If
        End Try

    End Function

    Public Function get_table(queryString, Optional practicas = False)
        Dim response As WebResponse
        Dim dataStream As Stream
        Dim reader As StreamReader

        Dim endpoint = apiEndpoint & "?" & queryString
        Try
            Dim request As WebRequest = WebRequest.Create(endpoint)
            request.Method = "GET"
            request.Headers.Add("X-COG-ID", um.currentSession.token)
            request.ContentType = "application/json"
            response = request.GetResponse()
            dataStream = response.GetResponseStream()
            reader = New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()

            If practicas Then
                Return Json.JsonConvert.DeserializeObject(Of DataSet)(responseFromServer)
            Else
                Return Json.JsonConvert.DeserializeObject(Of DataTable)(responseFromServer)
            End If

        Catch ex As WebException
            Dim exceptionReader = New StreamReader(ex.Response.GetResponseStream())
            Dim content = exceptionReader.ReadToEnd()
            exceptionReader.Close()
            If ex.Message.Contains("404") Then
                Throw New ApiTableNotFoundException(content)
            Else
                Throw New apiException(content)
            End If


        Finally
            If Not IsNothing(reader) Then
                reader.Close()
            End If

            If Not IsNothing(response) Then
                response.Close()
            End If
        End Try

    End Function

    Public Function send_post_put(payload As String, httpMethod As httpMethods, Optional expectResponse As Boolean = False) As DataTable
        Dim stream As Stream
        Dim response As Stream
        Dim reader As StreamReader
        Dim res As String

        Try
            Dim data = Encoding.Default.GetBytes(payload)
            Dim req As WebRequest = WebRequest.Create(apiEndpoint)
            req.Headers.Add("X-COG-ID", um.currentSession.token)
            req.ContentType = "application/json"

            If httpMethod = httpMethods.httpPOST Then
                req.Method = "POST"
            ElseIf httpMethod = httpMethods.httpPUT Then
                req.Method = "PUT"
            End If

            req.ContentLength = data.Length

            stream = req.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()

            response = req.GetResponse().GetResponseStream()

            reader = New StreamReader(response)
            res = reader.ReadToEnd()

            If expectResponse Then
                Return Json.JsonConvert.DeserializeObject(Of DataTable)(res)
            Else
                Return Nothing
            End If


        Catch ex As WebException
            Dim exceptionReader = New StreamReader(ex.Response.GetResponseStream())
            Dim content = exceptionReader.ReadToEnd()
            exceptionReader.Close()
            Throw New apiException(content)

        Finally
            If Not IsNothing(reader) Then
                reader.Close()
            End If

            If Not IsNothing(response) Then
                response.Close()
            End If
        End Try
    End Function
End Class
