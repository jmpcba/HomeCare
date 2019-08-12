Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft

Public Class Backend

    Private endpoint As String
    Public Enum services
        prestador
        paciente
        zona
        modulo
        subModulo
    End Enum

    Public Enum methods
        httpGET
        httpPOST
        httpPUT
    End Enum

    Public Sub New(service As services)
        If service = services.prestador Then
            endpoint = "https://2idw8jlsf6.execute-api.us-east-1.amazonaws.com/prod/v1/prestador"
        ElseIf service = services.paciente Then
            endpoint = "https://2idw8jlsf6.execute-api.us-east-1.amazonaws.com/prod/v1/paciente"
        End If
    End Sub

    Public Function get_table() As DataTable
        Dim response As WebResponse
        Dim dataStream As Stream
        Dim reader As StreamReader

        Try
            Dim request As WebRequest = WebRequest.Create(endpoint)
            request.Method = "GET"

            request.ContentType = "application/json"
            response = request.GetResponse()
            dataStream = response.GetResponseStream()
            reader = New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()


            Dim dt = Json.JsonConvert.DeserializeObject(Of DataTable)(responseFromServer)
            Try
                dt.Columns.Remove("_sa_instance_state")
            Catch ex As Exception

            End Try

            Return dt

        Catch ex As Exception
            Throw

        Finally
            reader.Close()
            dataStream.Close()
            response.Close()
        End Try

    End Function

    Public Sub send_post_put(json As String, method As methods)
        Dim stream As Stream
        Dim response As Stream
        Dim reader As StreamReader
        Dim res As String

        Try
            Dim data = Encoding.Default.GetBytes(json)
            Dim req As WebRequest = WebRequest.Create(endpoint)
            req.ContentType = "application/json"

            If method = methods.httpPOST Then
                req.Method = "POST"
            ElseIf method = methods.httpPUT Then
                req.Method = "PUT"
            End If

            req.ContentLength = data.Length

            stream = req.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()

            response = req.GetResponse().GetResponseStream()

            reader = New StreamReader(response)
            res = reader.ReadToEnd()

        Catch ex As Exception
            Throw

        Finally
            If Not IsNothing(reader) Then
                reader.Close()
            End If

            If Not IsNothing(response) Then
                response.Close()
            End If
        End Try
    End Sub
End Class
