Public Class Prestacion
    Private _prestaciones As DataTable
    Private _user As Usuario

    Private _codigo As Integer
    Private _descripcion As String
    Private _creoUser As Integer
    Private _modifUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False

    Public Sub New(_cod As Integer, _desc As String)
        Dim user As New Usuario

        _codigo = _cod
        _descripcion = _desc
        _modifUser = user.dni
        _creoUser = user.dni
        _fechaCarga = Date.Today
        _fechaMod = Date.Today
    End Sub

    Public Sub New()
        Dim db = New DB()
        Try
            _prestaciones = db.getTable(DB.tablas.prestaciones)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Property codigo As Integer
        Set(value As Integer)
            Dim r As DataRow()
            r = _prestaciones.Select("codigo = " & value)
            If r.Length = 1 Then
                _codigo = value
                _descripcion = r(0)("descripcion")
                _modifUser = r(0)("modifico_usuario")
                _creoUser = r(0)("cargo_usuario")
                _fechaCarga = r(0)("fecha")
                _fechaMod = r(0)("fecha_modificacion")
            Else
                Throw New Exception("Codigo Inexistente")
            End If
        End Set

        Get
            Return _codigo
        End Get
    End Property

    Public Property descripcion As String
        Set(value As String)
            _descripcion = value
            _modificado = True
        End Set
        Get
            Return _descripcion
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
        Dim db As New DB
        Try
            db.insertar(Me)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub actualizar()
        Dim db As New DB
        Try
            If _modificado Then
                _modifUser = _user.dni
                _fechaMod = Date.Today
                db.actualizar(Me)
            Else
                Throw New Exception("No se realizaron modificaciones")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
