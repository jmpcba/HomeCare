Imports Amazon.CognitoIdentityProvider
Imports Amazon.CognitoIdentityProvider.Model

Public Class User
    Private _userName
    Private _pass
    Private _mail

    Public Sub New(user As String, pass As String, mail As String)
        _userName = user
        _pass = pass
        _mail = mail
    End Sub

    Public Async Function registerAsync() As Task
        Dim client = New AmazonCognitoIdentityProviderClient()
        Dim signUpRequest = New SignUpRequest()
        signUpRequest.ClientId = My.Settings.clientID
        signUpRequest.Password = _pass
        signUpRequest.Username = _userName

        Dim emailAttribute = New AttributeType()
        emailAttribute.Name = "email"
        emailAttribute.Value = _mail
        signUpRequest.UserAttributes.Add(emailAttribute)
        Await client.SignUpAsync(signUpRequest)
    End Function
End Class