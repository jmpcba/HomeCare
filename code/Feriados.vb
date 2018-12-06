Public Class Feriado

    Private _feriado As DataTable
    Private _fecha As Date
    Private _descripcion As String
    Private _creoUser As String
    Private _modifUser As String
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False

    Public Sub New()
        Dim db = New DB()
        Try
            _feriado = db.getTable(DB.tablas.feriados)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub New(_fecha As Date, _descripcion As String)
        Me._fecha = _fecha
        Me._descripcion = _descripcion
        Me._modifUser = My.Settings.dni
        Me._creoUser = My.Settings.dni
        Me._fechaCarga = Date.Today
        Me._fechaMod = Date.Today
    End Sub

    Public Property descripcion As String
        Set(value As String)
            _descripcion = value
            _modificado = True
        End Set
        Get
            Return _descripcion
        End Get
    End Property

    Public Property fecha As Date
        Set(value As Date)
            Dim r As DataRow()
            r = _feriado.Select("fecha=" & value)
            _descripcion = r(0)("descripcion")
        End Set
        Get
            Return _fecha
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