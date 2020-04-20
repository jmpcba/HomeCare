Imports System
Imports Amazon
Imports Amazon.CognitoIdentity
Imports Amazon.CognitoIdentityProvider
Imports Amazon.CognitoIdentityProvider.Model
Imports Amazon.Extensions.CognitoAuthentication
Imports Amazon.Runtime

Friend NotInheritable Class User
    Private Shared _instance As User
    Private _userName As String
    Private _pass As String
    Private _token As String
    Private _userGroup As String
    Private _mail As String
    Private _cognitoUser As CognitoUser
    Private Shared ReadOnly _Sync As New Object

    Public Sub New()

    End Sub

    Public Async Function loginAsync() As Task

        Try
            pass = My.Settings.userPass
            userName = My.Settings.userName
            Dim anonymousClient =
            New AmazonCognitoIdentityProviderClient(New Amazon.Runtime.AnonymousAWSCredentials(), RegionEndpoint.USEast1)
            Dim userPool = New CognitoUserPool(My.Settings.poolID, My.Settings.clientID, anonymousClient)
            _cognitoUser = New CognitoUser(userName, My.Settings.clientID, userPool, anonymousClient)
            Dim authRequest = New InitiateSrpAuthRequest()
            authRequest.Password = pass

            Dim authResponse = Await _cognitoUser.StartWithSrpAuthAsync(authRequest).ConfigureAwait(False)
            _token = authResponse.AuthenticationResult.IdToken
            'pruebas para obtener los grupos
            Dim client = New AmazonCognitoIdentityProviderClient(RegionEndpoint.USEast1)
            Dim userGroupRequest = New AdminListGroupsForUserRequest
            userGroupRequest.Username = _userName
            userGroupRequest.UserPoolId = My.Settings.poolID
            Dim userGroupResponse As AdminListGroupsForUserResponse
            userGroupResponse = client.AdminListGroupsForUser(userGroupRequest)

            Dim group As GroupType
            group = userGroupResponse.Groups(0)
            _userGroup = group.GroupName
            If _userGroup = "admin" Then
                My.Settings.nivel = 0
            ElseIf _userGroup = "supervisores" Then
                My.Settings.nivel = 1
            ElseIf _userGroup = "operadores" Then
                My.Settings.nivel = 2
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub logout()
        _cognitoUser.SignOut()
    End Sub
    Public Async Function resetPass() As Task

    End Function

    Public Async Function confirmAsync() As Task
        pass = My.Settings.userPass
        userName = My.Settings.userName
        Dim verificationCode = My.Settings.verificationCode
        Dim client = New AmazonCognitoIdentityProviderClient(RegionEndpoint.USEast1)
        Dim confirmRequest As ConfirmSignUpRequest
        confirmRequest = New ConfirmSignUpRequest()
        confirmRequest.ClientId = My.Settings.clientID
        confirmRequest.Username = userName
        confirmRequest.ConfirmationCode = My.Settings.verificationCode
        Dim confirmResult = client.ConfirmSignUpAsync(confirmRequest)
        Await loginAsync()
    End Function

    Public Property userName As String
        Set(value As String)
            _userName = value
        End Set
        Get
            Return _userName
        End Get
    End Property

    Public Property pass As String
        Set(value As String)
            _pass = value
        End Set
        Get
            Return _pass
        End Get
    End Property

    Public ReadOnly Property token As String
        Get
            Return _token
        End Get
    End Property

    Public ReadOnly Property isloggedIn As Boolean
        Get
            If token Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public ReadOnly Property userGroup As String
        Get
            Return _userGroup
        End Get
    End Property

    Public ReadOnly Property mail As String
        Get
            Return _mail
        End Get
    End Property


    'IMPLEMENTACION DE SINGLETON
    Public Shared ReadOnly Property Instance() As User
        Get
            If _instance Is Nothing Then
                SyncLock _Sync
                    If _instance Is Nothing Then
                        _instance = New User()
                    End If
                End SyncLock
            End If
            Return _instance
        End Get
    End Property
End Class