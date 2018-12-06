﻿Public Class Usuario

    Private _usuario As DataTable
    Private _dni As String
    Private _apellido As String
    Private _nombre As String
    Private _nivel As String
    Private _pass As String
    Private _modifUser As Integer
    Private _creoUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False

    Public Sub New()
        Dim db = New DB()
        Try
            _usuario = db.getTable(DB.tablas.usuarios)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub New(_dni As String, _nombre As String, _apellido As String, _pass As String, _nivel As String)
        Me._dni = _dni
        Me._nombre = _nombre
        Me._apellido = _apellido
        Me._pass = _pass
        Me._nivel = _nivel
        Me._modifUser = My.Settings.dni
        Me._creoUser = My.Settings.dni
        Me._fechaCarga = Date.Today
        Me._fechaMod = Date.Today
    End Sub

    Public Function getUsuario(_dni As String)
        Dim db As New DB
        Try
            Return db.getUsuario(_dni)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Property dni As String
        Set(value As String)
            _dni = value
            _modificado = True
        End Set
        Get
            Return _dni
        End Get
    End Property

    Public Property pass As String
        Set(value As String)
            _pass = value
            _modificado = True
        End Set
        Get
            Return _pass
        End Get
    End Property

    Public Property nombre As String
        Set(value As String)
            _nombre = value
            _modificado = True
        End Set
        Get
            Return _nombre
        End Get
    End Property

    Public Property apellido As String
        Set(value As String)
            _apellido = value
            _modificado = True
        End Set
        Get
            Return _apellido
        End Get
    End Property

    Public Property nivel As String
        Set(value As String)
            _nivel = value
            _modificado = True
        End Set
        Get
            Return _nivel
        End Get
    End Property

    Public ReadOnly Property modifUser As Integer
        Get
            Return _modifUser
        End Get
    End Property
    Public ReadOnly Property creoUser As Integer
        Get
            Return _creoUser
        End Get
    End Property
    Public ReadOnly Property fechaCarga As Date
        Get
            Return _fechaCarga
        End Get
    End Property
    Public ReadOnly Property fechaMod As Date
        Get
            Return _fechaMod
        End Get
    End Property

    Public Sub insertar()
        Try
            Dim db = New DB
            db.insertar(Me)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub actualizar()
        Dim db = New DB
        Try
            If _modificado Then
                _fechaMod = Date.Today
                _modifUser = My.Settings.dni
                db.actualizar(Me)
            Else
                Throw New Exception("No se realizaron modificaciones")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub


End Class
