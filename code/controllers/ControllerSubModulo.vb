Imports Newtonsoft
Public Class ControllerSubModulo
    Private _subModulos As DataTable

    Public Sub New(Optional loadAll As Boolean = True)
        If loadAll Then
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
        End If
    End Sub

    Public ReadOnly Property subModulo(id As Integer) As subModulo
        Get
            Dim sm = New subModulo()
            Dim r As DataRow()
            r = _subModulos.Select("id = " & id)
            If r.Length = 1 Then
                sm.id = id
                sm.codigo = r(0)("codigo")
                sm.descripcion = r(0)("descripcion")
                Return sm
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property subModulos As DataTable
        Get
            Return _subModulos
        End Get
    End Property

    Friend Sub llenarcombo(_combo As ComboBox)
        _combo.DataSource = _subModulos
        _combo.DisplayMember = "combo"
        _combo.ValueMember = "id"
        _combo.SelectedIndex = -1
    End Sub

    Public Sub insertar(_cod As String, _desc As String)
        Try
            Dim sm = New subModulo(_cod, _desc)
            Dim api As New API(API.resources.SUBMODULO)
            Dim serialObject = Json.JsonConvert.SerializeObject(sm)
            api.send_post_put(serialObject, API.httpMethods.httpPOST)
        Catch ex As apiException
            Throw
        End Try
    End Sub

    Public Sub actualizar(sm As subModulo)
        Try
            Dim api As New API(API.resources.SUBMODULO)
            _subModulos = Nothing
            Dim serialObject = Json.JsonConvert.SerializeObject(sm)
            api.send_post_put(serialObject, API.httpMethods.httpPUT)
        Catch ex As apiException
            Throw
        End Try
    End Sub
End Class
