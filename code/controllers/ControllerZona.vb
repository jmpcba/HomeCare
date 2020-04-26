Imports Newtonsoft

Public Class ControllerZona
    Private _zonas As DataTable

    Public Sub New(Optional loadAll As Boolean = True)
        If loadAll Then
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
            Catch ex As apiException
                Throw
            End Try
        End If
    End Sub

    Public ReadOnly Property zonas As DataTable
        Get
            Return _zonas
        End Get
    End Property

    Public ReadOnly Property zona(id As Integer) As Zona
        Get
            Dim encriptador As New Encriptador()
            Dim r As DataRow()
            Dim z = New Zona()
            r = _zonas.Select("id = " & id)
            If r.Length = 1 Then
                z.id = id
                z.nombre = r(0)("nombre")
                z.mail = r(0)("mail")
                z.pwd = encriptador.desencriptar(r(0)("pwd"))
                z.propietario = r(0)("propietario")
                z.usuario_ultima_modificacion = r(0)("usuario_ultima_modificacion")
                z.ultima_modificacion = r(0)("ultima_modificacion")
                Return z
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Sub insertar(_nombre As String, _email As String, _pass As String, _propietario As String)
        Try
            Dim z = New Zona(_nombre, _email, _pass, _propietario)
            Dim api As New API(API.resources.ZONA)
            Dim serialObject = Json.JsonConvert.SerializeObject(z)
            api.send_post_put(serialObject, API.httpMethods.httpPOST)
        Catch ex As apiException
            Throw
        End Try
    End Sub

    Public Sub actualizar(z As Zona)
        Try
            Dim api As New API(API.resources.ZONA)
            Dim serialObject = Json.JsonConvert.SerializeObject(z)
            api.send_post_put(serialObject, API.httpMethods.httpPUT)
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
