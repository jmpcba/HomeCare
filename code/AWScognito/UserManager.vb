﻿Imports Amazon
Imports Amazon.CognitoIdentityProvider.Model
Imports Amazon.CognitoIdentityProvider

Public Class UserManager
    Private _currentUser As CurrentSession
    Private _allUsers As DataTable

    Public Sub New()
        _currentUser = HomeCare.CurrentSession.Instance
    End Sub

    Private Function listallGroups() As DataTable
        Dim client = New AmazonCognitoIdentityProviderClient(RegionEndpoint.USEast1)
        Dim listGroupsRequest = New ListGroupsRequest()
        listGroupsRequest.UserPoolId = My.Settings.poolID
        Dim listGroupResponse = client.ListGroups(listGroupsRequest)
        Dim table As New DataTable

        table.Columns.Add("Nombre", GetType(String))
        table.Columns.Add("Descripcion", GetType(String))
        For Each g As GroupType In listGroupResponse.Groups
            table.Rows.Add(g.GroupName, g.Description)
        Next
        Return table
    End Function

    Private Function listallUsers() As DataTable
        Dim listUserespose As ListUsersResponse
        Dim client = New AmazonCognitoIdentityProviderClient(RegionEndpoint.USEast1)
        Dim request = New ListUsersRequest()
        Dim table As New DataTable
        request.UserPoolId = My.Settings.poolID

        listUserespose = client.ListUsers(request)

        ' Create four typed columns in the DataTable.
        table.Columns.Add("Usuario", GetType(String))
        table.Columns.Add("Mail", GetType(String))
        table.Columns.Add("Grupo", GetType(String))
        table.Columns.Add("Nombre", GetType(String))
        table.Columns.Add("Apellido", GetType(String))
        table.Columns.Add("Estado", GetType(String))

        For Each u As UserType In listUserespose.Users
            Dim mail = ""
            Dim nombre = ""
            Dim apellido = ""
            Dim grupo = ""

            Dim userGroupRequest = New AdminListGroupsForUserRequest
            userGroupRequest.Username = u.Username
            userGroupRequest.UserPoolId = My.Settings.poolID
            Dim userGroupResponse As AdminListGroupsForUserResponse
            userGroupResponse = client.AdminListGroupsForUser(userGroupRequest)

            Dim group As GroupType
            If userGroupResponse.Groups.Count > 0 Then
                group = userGroupResponse.Groups(0)
                grupo = group.GroupName
            End If

            For Each a In u.Attributes
                If a.Name = "email" Then
                    mail = a.Value
                ElseIf a.Name = "custom:nombre" Then
                    nombre = a.Value
                ElseIf a.Name = "custom:apellido" Then
                    apellido = a.Value
                End If
            Next
            table.Rows.Add(u.Username, mail, grupo, nombre, apellido, u.UserStatus)
        Next

        _allUsers = table
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

    Public ReadOnly Property allUsers As DataTable
        Get
            Return listallUsers()
        End Get
    End Property

    Public ReadOnly Property currentSession
        Get
            Return _currentUser
        End Get
    End Property

    Public ReadOnly Property allGroups As DataTable
        Get
            Return listallGroups()
        End Get
    End Property

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

    Public Function modelUser(userName As String) As UserModel
        Dim u = New UserModel()
        Dim r As DataRow()
        Dim au = allUsers
        r = au.Select(String.Format("Usuario ='{0}'", userName))
        If r.Length = 1 Then
            u.usuario = r(0)("Usuario")
            u.apellido = r(0)("Apellido")
            u.nombre = r(0)("Nombre")
            u.mail = r(0)("mail")
            u.grupo = r(0)("Grupo")
            u.estado = r(0)("Estado")
        End If
        Return u
    End Function
End Class