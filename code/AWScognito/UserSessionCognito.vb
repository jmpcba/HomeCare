Imports System
Imports Amazon
Imports Amazon.CognitoIdentity
Imports Amazon.CognitoIdentityProvider
Imports Amazon.Extensions.CognitoAuthentication
Imports Amazon.Runtime

Public NotInheritable Class UserSesionCognito
    Private userName As String
    Private userPass As String
    Private _token As String
    Private _newPass As String
    Private user As CognitoUser
    Private Shared _Instance As UserSesionCognito = Nothing
    Private Shared ReadOnly _Sync As New Object
    Private ut As utils

    Public Sub New()
        Dim ut = New utils()
    End Sub
    Public Async Function login() As Task
        userPass = My.Settings.userPass
        userName = My.Settings.userName
        Dim provider =
        New AmazonCognitoIdentityProviderClient(New Amazon.Runtime.AnonymousAWSCredentials(), RegionEndpoint.USEast1)
        Dim userPool = New CognitoUserPool(My.Settings.poolID, My.Settings.clientID, provider)
        user = New CognitoUser(userName, My.Settings.clientID, userPool, provider)
        Dim authRequest = New InitiateSrpAuthRequest()
        authRequest.Password = userPass

        Dim authResponse = Await user.StartWithSrpAuthAsync(authRequest).ConfigureAwait(False)
        _token = authResponse.AuthenticationResult.IdToken

        'While IsNothing(authResponse.AuthenticationResult)
        '    If authResponse.ChallengeName = ChallengeNameType.NEW_PASSWORD_REQUIRED And Not changePassRequired Then
        '        Dim newpass = New RespondToNewPasswordRequiredRequest()
        '        newpass.SessionID = authResponse.SessionID
        '        If IsNothing(newPassword) Then
        '            newpass.NewPassword = newPassword
        '        Else
        '            ut.mensaje("Debe ingresa una nueva clave para continuar", utils.mensajes.err)
        '            Exit Function
        '        End If

        '        authResponse = Await user.RespondToNewPasswordRequiredAsync(newpass)
        '        _token = authResponse.AuthenticationResult.IdToken
        '    End If
        'End While

        'If Not IsNothing(authResponse.AuthenticationResult) Then
        '    _token = authResponse.AuthenticationResult.IdToken
        'Else
        '    Throw New loginException()
        'End If
    End Function

    'Public Async Function loginWithResetPassword() As Task
    '    userPass = My.Settings.userPass
    '    userName = My.Settings.userName
    '    Dim provider =
    '    New AmazonCognitoIdentityProviderClient(New Amazon.Runtime.AnonymousAWSCredentials(), RegionEndpoint.USEast1)
    '    Dim userPool = New CognitoUserPool(My.Settings.poolID, My.Settings.clientID, provider)
    '    user = New CognitoUser(userName, My.Settings.clientID, userPool, provider)
    '    Dim authRequest = New InitiateSrpAuthRequest()
    '    authRequest.Password = userPass
    '    Dim authResponse As AuthFlowResponse
    '    authResponse = Await user.StartWithSrpAuthAsync(authRequest).ConfigureAwait(False)

    '    While IsNothing(authResponse.AuthenticationResult)
    '        If authResponse.ChallengeName = ChallengeNameType.NEW_PASSWORD_REQUIRED Then
    '            Dim newpass = New RespondToNewPasswordRequiredRequest()
    '            newpass.SessionID = authResponse.SessionID
    '            If IsNothing(newPassword) Then
    '                newpass.NewPassword = newPassword
    '            Else
    '                ut.mensaje("Debe ingresa una nueva clave para continuar", utils.mensajes.err)
    '                Exit Function
    '            End If

    '            authResponse = Await user.RespondToNewPasswordRequiredAsync(newpass)
    '            _token = authResponse.AuthenticationResult.IdToken
    '        End If
    '    End While

    '    If Not IsNothing(authResponse.AuthenticationResult) Then
    '        _token = authResponse.AuthenticationResult.IdToken
    '    Else
    '        Throw New loginException()
    '    End If

    'End Function

    Public Sub logout()
        user.SignOut()
    End Sub

    Public ReadOnly Property token As String
        Get
            Return _token
        End Get
    End Property

    Public Property newPassword As String
        Get
            Return _newPass
        End Get
        Set(value As String)
            _newPass = value
        End Set
    End Property

    Public Shared ReadOnly Property Instance() As UserSesionCognito
        Get
            If _Instance Is Nothing Then
                SyncLock _Sync
                    If _Instance Is Nothing Then
                        _Instance = New UserSesionCognito()
                    End If
                End SyncLock
            End If
            Return _Instance
        End Get
    End Property

    'Public Property changePassRequired As Boolean
    '    Set(value As Boolean)
    '        _changePassrequired = value
    '    End Set
    '    Get
    '        Return _changePassrequired
    '    End Get
    'End Property
End Class
