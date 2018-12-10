Public Class Usuario

    Private _usuarios As DataTable
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
    Private ut As New utils

    Public Sub New()
        Dim db = New DB()
        Try
            _usuarios = db.getTable(DB.tablas.usuarios)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub New(_dni As String, _nombre As String, _apellido As String, _pass As String, _nivel As String)
        Dim encriptador As New Encriptador()
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

    Public Function getUsuario(_dni As String) As DataTable
        Dim db As New DB
        Try
            Return db.getUsuario(_dni)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Property dni As String
        Set(value As String)
            Dim encriptador As New Encriptador()
            Dim r As DataRow()
            r = _usuarios.Select("dni = " & value)
            If r.Length = 1 Then
                _dni = value
                _apellido = r(0)("apellido")
                _nombre = r(0)("nombre")
                _nivel = r(0)("nivel")
                _pass = encriptador.DecryptData(r(0)("pass"))
                _creoUser = r(0)("cargo_usuario")
                _modifUser = r(0)("modifico_usuario")
                _fechaCarga = r(0)("fecha_carga")
                _fechaMod = r(0)("fecha_modificacion")
            Else
                Throw New Exception("DNI Inexistente")
            End If
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

    Public ReadOnly Property usuarios As DataTable
        Get
            Return _usuarios
        End Get
    End Property

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
