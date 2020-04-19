Imports Amazon
Imports Amazon.CognitoIdentityProvider.Model
Imports Amazon.CognitoIdentityProvider

Public Class User
    Private _userName
    Private _pass
    Private _mail

    Public Sub New(userName As String, pass As String, mail As String)
        _userName = userName
        _pass = pass
        _mail = mail
    End Sub

    Public Async Function registerAsync() As Task
        Try
            Dim client = New AmazonCognitoIdentityProviderClient(RegionEndpoint.USEast1)
            Dim signUpRequest = New SignUpRequest()
            signUpRequest.ClientId = My.Settings.clientID
            signUpRequest.Password = _pass
            signUpRequest.Username = _userName

            Dim emailAttribute = New AttributeType()
            emailAttribute.Name = "email"
            emailAttribute.Value = _mail
            signUpRequest.UserAttributes.Add(emailAttribute)
            Await client.SignUpAsync(signUpRequest)

        Catch ex As Exception
            Throw
        End Try

    End Function
End Class