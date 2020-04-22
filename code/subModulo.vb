Imports Newtonsoft

Public Class subModulo
    Private _id As Integer
    Private _codigo As String
    Private _descripcion As String
    Private _numTope As Integer
    Private _modifUser As String
    Private _fechaMod As Date
    Private _modificado = False
    Private _subModulos As DataTable

    Public Sub New(_cod As String, _desc As String)
        Dim um = New UserManager()
        _codigo = _cod
        _descripcion = _desc
        _modifUser = um.currentSession.userName
        _fechaMod = Date.Today
    End Sub

    Public Sub New()
        Try
            Dim api As New API(API.resources.SUBMODULO)
            _subModulos = api.get_table()
            Dim c = _subModulos.Columns.Count
            _subModulos.Columns("ultima_modificacion").SetOrdinal(c - 1)
            _subModulos.Columns("usuario_ultima_modificacion").SetOrdinal(c - 2)
            _subModulos.Columns("id").SetOrdinal(0)
            _subModulos.Columns("codigo").SetOrdinal(1)

            _subModulos.Columns.Add("COMBO")
            For Each r As DataRow In _subModulos.Rows
                Dim codigo = r("codigo")
                Dim descripcion = r("descripcion")
                r("COMBO") = String.Format("{0} - {1}", codigo, descripcion)
            Next
            _subModulos.DefaultView.Sort = "COMBO"
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Property id As String
        Set(value As String)
            Dim r As DataRow()
            r = _subModulos.Select("id = " & value)
            If r.Length = 1 Then
                _id = value
                _codigo = r(0)("codigo")
                _descripcion = r(0)("descripcion")
                _modifUser = r(0)("usuario_ultima_modificacion")
                _fechaMod = r(0)("ultima_modificacion")
            Else
                Throw New Exception("Codigo Inexistente")
            End If
        End Set

        Get
            Return _id
        End Get
    End Property

    Public Property codigo
        Set(value)
            _codigo = value
        End Set
        Get
            Return _codigo
        End Get
    End Property

    Public Function getSubModulos() As DataTable
        Return _subModulos
    End Function

    Friend Sub llenarcombo(_combo As ComboBox)
        _combo.DataSource = _subModulos
        _combo.DisplayMember = "combo"
        _combo.ValueMember = "id"
        _combo.SelectedIndex = -1
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
            Dim api As New API(API.resources.SUBMODULO)
            _subModulos = Nothing
            Dim serialObject = Json.JsonConvert.SerializeObject(Me)
            api.send_post_put(serialObject, API.httpMethods.httpPOST)
        Catch ex As apiException
            Throw
        End Try
    End Sub

    Public Sub actualizar()
        Try
            If _modificado Then
                _modifUser = New UserManager().currentSession.userName
                Dim api As New API(API.resources.SUBMODULO)
                _subModulos = Nothing
                Dim serialObject = Json.JsonConvert.SerializeObject(Me)
                api.send_post_put(serialObject, API.httpMethods.httpPUT)
            Else
                Throw New Exception("No se realizaron modificaciones")
            End If

        Catch ex As apiException
            Throw
        End Try
    End Sub
End Class