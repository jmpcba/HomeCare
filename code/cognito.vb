Imports System
Imports Amazon
Imports Amazon.CognitoIdentity
Imports Amazon.CognitoIdentityProvider
Imports Amazon.Extensions.CognitoAuthentication
Imports Amazon.Runtime
Public Class Cognito

    Public Async Sub getCognitotoken()
        Dim provider =
        New AmazonCognitoIdentityProviderClient(New Amazon.Runtime.AnonymousAWSCredentials(), RegionEndpoint.USEast1)
        Dim userPool = New CognitoUserPool(My.Settings.poolID, My.Settings.clientID, provider)
        Dim user = New CognitoUser(My.Settings.apiUser, My.Settings.clientID, userPool, provider)
        Dim authRequest = New InitiateSrpAuthRequest()
        authRequest.Password = My.Settings.apiPassword

        Dim authResponse = Await user.StartWithSrpAuthAsync(authRequest).ConfigureAwait(False)
        Dim accessToken = authResponse.AuthenticationResult.IdToken
        My.Settings.cognito = accessToken
    End Sub
End Class
