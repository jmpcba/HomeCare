Imports Newtonsoft
Public Class Feriado

    Private _feriados As DataTable
    Private _fecha As Date
    Private _descripcion As String
    Private _creoUser As String
    Private _modifUser As String
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False

    Public Sub New()
        Try
            Try
                Dim api As New API(API.resources.FERIADO)
                _feriados = api.get_table()
                Dim c = _feriados.Columns.Count
                _feriados.Columns("ultima_modificacion").SetOrdinal(c - 1)
                _feriados.Columns("usuario_ultima_modificacion").SetOrdinal(c - 2)
                _feriados.Columns("nombre").SetOrdinal(1)
                _feriados.Columns("mail").SetOrdinal(2)
                _feriados.Columns("pwd").SetOrdinal(2)
                _feriados.Columns("id").SetOrdinal(0)
            Catch ex As Exception
                Throw
            End Try
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub New(_fecha As Date, _descripcion As String)
        Me._fecha = _fecha
        Me._descripcion = _descripcion
        Me._modifUser = My.Settings.dni
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
            r = _feriados.Select("fecha=" & value)
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
    Public ReadOnly Property usuario_ultima_modificacion As Date
        Get
            Return _fechaMod
        End Get
    End Property

    Public Sub insertar()
        Try
            _feriados = Nothing
            Dim api As New API(API.resources.FERIADO)
            Dim serialObject = Json.JsonConvert.SerializeObject(Me)
            api.send_post_put(serialObject, API.httpMethods.httpPOST)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub actualizar()
        Try
            If _modificado Then
                Dim api As New API(API.resources.FERIADO)
                _feriados = Nothing
                Dim serialObject = Json.JsonConvert.SerializeObject(Me)
                api.send_post_put(serialObject, API.httpMethods.httpPUT)
            Else
                Throw New Exception("No se realizaron modificaciones")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class