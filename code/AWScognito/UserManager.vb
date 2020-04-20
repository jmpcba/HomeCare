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
        table.Columns.Add("Nombre", GetType(String))
        table.Columns.Add("Apellido", GetType(String))

        For Each u As UserType In listUserespose.Users
            Dim mail = ""
            Dim nombre = ""
            Dim apellido = ""

            For Each a In u.Attributes
                If a.Name = "email" Then
                    mail = a.Value
                ElseIf a.Name = "custom:nombre" Then
                    nombre = a.Value
                ElseIf a.Name = "custom:apellido" Then
                    apellido = a.Value
                End If
            Next
            table.Rows.Add(u.Username, u.UserStatus, mail, nombre, apellido)
        Next

        Return table
    End Function

    Public Async Function createNewUser(_userName As String, _pass As String, _mail As String, _nombre As String, _apellido As String) As Task
        Try
            Dim client = New AmazonCognitoIdentityProviderClient(RegionEndpoint.USEast1)
            Dim signUpRequest = New SignUpRequest()
            signUpRequest.ClientId = My.Settings.clientID
            signUpRequest.Password = _pass
            signUpRequest.Username = _userName

            Dim emailAttribute = New AttributeType()
            Dim apellidoAttribute = New AttributeType()
            Dim nombreAttribute = New AttributeType()

            emailAttribute.Name = "email"
            emailAttribute.Value = _mail

            apellidoAttribute.Name = "custom:apellido"
            apellidoAttribute.Value = _apellido

            nombreAttribute.Name = "custom:nombre"
            nombreAttribute.Value = _nombre


            signUpRequest.UserAttributes.Add(emailAttribute)
            signUpRequest.UserAttributes.Add(apellidoAttribute)
            signUpRequest.UserAttributes.Add(nombreAttribute)

            Await client.SignUpAsync(signUpRequest)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub deleteUser(_userName As String)
        Dim response As AdminDeleteUserResponse
        Dim request = New AdminDeleteUserRequest()
        Dim client = New AmazonCognitoIdentityProviderClient(RegionEndpoint.USEast1)
        request.Username = _userName
        request.UserPoolId = My.Settings.poolID
        response = client.AdminDeleteUser(request)
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

    'Public ReadOnly Property availableGroups
    '    Get
    '        Return _groups
    '    End Get
    'End Property

    Public Async Function loginCurrentUser() As Task

        Try
            Await _currentUser.loginAsync()
        Catch ex As NotAuthorizedException
            Throw New loginException("Contraseña invalida")

        Catch ex As UserNotFoundException
            Throw New loginException("No existe el usuario")

        Catch ex As UserNotConfirmedException
            Throw New UserConformationException("El usuario debe ser confirmado" & vbCrLf & "Ingrese el codigo que recibio por mail")
        End Try
    End Function

    Public Async Function verifyCurrentUser() As Task
        Try
            Await _currentUser.confirmAsync()
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
