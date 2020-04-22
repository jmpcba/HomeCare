Imports Newtonsoft
Public Class Zona

    Private _zonas As DataTable

    Private _idzona As Decimal
    Private _nombre As String
    Private _email As String
    Private _pass As String
    Private _propietario As String
    Private _modifUser As String
    Private _fechaMod As Date
    Private _modificado = False

    Public Sub New()
        Try
            Try
                Dim api As New API(API.resources.ZONA)
                _zonas = api.get_table()
                Dim c = _zonas.Columns.Count
                _zonas.Columns("ultima_modificacion").SetOrdinal(c - 1)
                _zonas.Columns("usuario_ultima_modificacion").SetOrdinal(c - 2)
                _zonas.Columns("nombre").SetOrdinal(1)
                _zonas.Columns("mail").SetOrdinal(2)
                _zonas.Columns("pwd").SetOrdinal(3)
                _zonas.Columns("id").SetOrdinal(0)
            Catch ex As Exception
                Throw
            End Try
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub New(_nombre As String, _email As String, _pass As String, _propietario As String)
        Dim um = New UserManager
        Me._nombre = _nombre
        Me._email = _email
        Me._pass = _pass
        Me._propietario = _propietario
        Me._modifUser = um.currentSession.userName
        Me._fechaMod = Date.Today
    End Sub

    Public Property id As String
        Set(value As String)
            Dim encriptador As New Encriptador()
            Dim r As DataRow()
            r = _zonas.Select("id = " & value)
            If r.Length = 1 Then
                _idzona = value
                _nombre = r(0)("nombre")
                _email = r(0)("mail")
                _pass = encriptador.desencriptar(r(0)("pwd"))
                _propietario = r(0)("propietario")
                _modifUser = r(0)("usuario_ultima_modificacion")
                _fechaMod = r(0)("ultima_modificacion")
            Else
                Throw New Exception("Zona Inexistente")
            End If
        End Set

        Get
            Return _idzona
        End Get
    End Property

    Public Property mail As String
        Set(value As String)
            _email = value
            _modificado = True
        End Set
        Get
            Return _email
        End Get
    End Property
    Public Property pwd As String
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

    Public Property propietario As String
        Set(value As String)
            _propietario = value
            _modificado = True
        End Set
        Get
            Return _propietario
        End Get
    End Property

    Public ReadOnly Property usuario_ultima_modificacion As String
        Get
            Return _modifUser
        End Get
    End Property

    Public ReadOnly Property ultima_modificacion As Date
        Get
            Return _fechaMod
        End Get
    End Property

    Public Sub insertar()
        Try
            _zonas = Nothing
            Dim api As New API(API.resources.ZONA)
            Dim serialObject = Json.JsonConvert.SerializeObject(Me)
            api.send_post_put(serialObject, API.httpMethods.httpPOST)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function getZonas() As DataTable
        Return _zonas
    End Function

    Public Sub actualizar()
        Try
            If _modificado Then
                Dim api As New API(API.resources.ZONA)
                _zonas = Nothing
                Dim serialObject = Json.JsonConvert.SerializeObject(Me)
                api.send_post_put(serialObject, API.httpMethods.httpPUT)
            Else
                Throw New Exception("No se realizaron modificaciones")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub llenarcombo(_combo As ComboBox)
        Dim DV = New DataView(_zonas)
        DV.Sort = "NOMBRE ASC"
        _combo.DataSource = DV
        _combo.DisplayMember = "NOMBRE"
        _combo.ValueMember = "id"
        _combo.SelectedIndex = -1
    End Sub
End Class

