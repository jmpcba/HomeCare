Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft

Public Class frmUsoInternovb
    Dim ut = New utils
    Private Sub btnDrop_Click(sender As Object, e As EventArgs) Handles btnDrop.Click
        Dim json = "{""operation"":   ""recreate""}"
        Dim apiEndpoint = "https://cl86zb12f8.execute-api.us-east-1.amazonaws.com/DEV/v1/ADMIN"
        Dim stream As Stream
        Dim response As Stream
        Dim reader As StreamReader
        Dim res As String

        Try
            Dim um = New UserManager()
            Dim data = Encoding.Default.GetBytes(json)
            Dim req As WebRequest = WebRequest.Create(apiEndpoint)
            req.ContentType = "application/json"

            req.Method = "PUT"
            req.ContentLength = data.Length
            req.Headers.Add("X-COG-ID", um.currentSession.token)

            stream = req.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()

            response = req.GetResponse().GetResponseStream()

            reader = New StreamReader(response)
            res = reader.ReadToEnd()

        Catch ex As WebException
            Dim exceptionReader = New StreamReader(ex.Response.GetResponseStream())
            Dim content = exceptionReader.ReadToEnd()
            exceptionReader.Close()
            ut.mensaje(ex.Message, utils.mensajes.err)

        Finally
            If Not IsNothing(reader) Then
                reader.Close()
            End If

            If Not IsNothing(response) Then
                response.Close()
            End If
        End Try
    End Sub

    Private Sub btnInit_Click(sender As Object, e As EventArgs) Handles btnInit.Click
        Dim json = "{""operation"":   ""create""}"
        Dim apiEndpoint = "https://cl86zb12f8.execute-api.us-east-1.amazonaws.com/DEV/v1/ADMIN"
        Dim stream As Stream
        Dim response As Stream
        Dim reader As StreamReader
        Dim res As String

        Try
            Dim um = New UserManager()
            Dim data = Encoding.Default.GetBytes(json)
            Dim req As WebRequest = WebRequest.Create(apiEndpoint)
            req.ContentType = "application/json"

            req.Method = "POST"
            req.ContentLength = data.Length
            req.Headers.Add("X-COG-ID", um.currentSession.token)

            stream = req.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()

            response = req.GetResponse().GetResponseStream()

            reader = New StreamReader(response)
            res = reader.ReadToEnd()

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
    End Sub
End Class