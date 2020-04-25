﻿Public Class Resource
    Private _ultima_modificacion As Date
    Private _usuario_ultima_modificacion As String

    Public Sub New()
        _ultima_modificacion = Today
        _usuario_ultima_modificacion = My.Settings.userName
    End Sub

    Public Property ultima_modificacion As Date
        Set(value As Date)
            _ultima_modificacion = value
        End Set
        Get
            Return _ultima_modificacion
        End Get
    End Property

    Public Property usuario_ultima_modificacion As String
        Set(value As String)
            _usuario_ultima_modificacion = value
        End Set
        Get
            Return _usuario_ultima_modificacion
        End Get
    End Property
End Class
