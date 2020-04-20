Imports Amazon
Imports Amazon.CognitoIdentityProvider.Model
Imports Amazon.CognitoIdentityProvider

Public Class UserManager
    Private _currentUser As User

    Public Sub New()
        _currentUser = User.Instance
    End Sub

    Public Function listallUsers() As DataTable
        Dim listUserespose As ListUsersResponse
        Dim client = New AmazonCognitoIdentityProviderClient(RegionEndpoint.USEast1)
        Dim request = New ListUsersRequest()
        Dim table As New DataTable
        request.UserPoolId = My.Settings.poolID

        listUserespose = client.ListUsers(request)

        ' Create four typed columns in the DataTable.
        table.Columns.Add("Usuario", GetType(String))
        table.Columns.Add("Estado", GetType(String))
        table.Columns.Add("Mail", GetType(String))

        For Each u As UserType In listUserespose.Users
            Dim mail = ""
            For Each a In u.Attributes
                If a.Name = "email" Then
                    mail = a.Value
                    Exit For
                End If
            Next
            table.Rows.Add(u.Username, u.UserStatus, mail)
        Next

        Return table
    End Function

    Public Async Sub createNewUser(_userName As String, _pass As String, _mail As String)
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
    End Sub

    Public Sub deleteUser()

    End Sub

    Public ReadOnly Property userList As DataTable
        Get
            Return listallUsers()
        End Get
    End Property

    Public ReadOnly Property currentUser
        Get
            Return _currentUser
        End Get
    End Property

    Public Async Sub loginCurrentUser()
        Try
            Await _currentUser.loginAsync()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Async Sub verifyCurrentUser()
        Try
            Await _currentUser.confirmAsync()
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
