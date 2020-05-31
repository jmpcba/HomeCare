Imports Newtonsoft
Public Class ControllerModulo

    Private _modulos As DataTable

    Public Sub New(Optional loadAll As Boolean = True)
        If loadAll Then
            Try
                Dim api As New API(API.resources.MODULO)
                _modulos = api.get_table()
                Dim c = _modulos.Columns.Count
                _modulos.Columns("ultima_modificacion").SetOrdinal(c - 1)
                _modulos.Columns("usuario_ultima_modificacion").SetOrdinal(c - 2)
                _modulos.Columns("codigo").SetOrdinal(1)
                _modulos.Columns("id").SetOrdinal(0)
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub

    Public ReadOnly Property modulo(id As Integer) As Modulo
        Get
            Dim m = New Modulo()
            Dim r As DataRow()
            r = _modulos.Select("id=" & id)
            If r.Length = 1 Then
                m.id = id
                m.codigo = r(0)("codigo")
                m.medico = r(0)("medico")
                m.enfermeria = r(0)("enfermeria")
                m.kinesiologia = r(0)("kinesiologia")
                m.fonoaudiologia = r(0)("fonoaudiologia")
                m.cuidador = r(0)("cuidador")
                m.nutricion = r(0)("nutricion")

                Return m
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property modulos As DataTable
        Get
            Return _modulos
        End Get
    End Property

    Friend Sub llenarcombo(_combo As ComboBox)
        _combo.DataSource = _modulos
        _combo.DisplayMember = "codigo"
        _combo.ValueMember = "id"
        _combo.SelectedIndex = -1
    End Sub

    Public Sub actualizar(m As Modulo)
        Try
            Dim api As New API(API.resources.MODULO)
            Dim serialObject = Json.JsonConvert.SerializeObject(m)
            api.send_request(serialObject, API.httpMethods.httpPUT)
        Catch ex As apiException
            Throw
        End Try
    End Sub

    Public Sub insertar(_cod As String, _topeMedico As Integer, _topeEnfer As Integer, _topeKine As Integer, _topeFon As Integer, _topeCuid As Integer, _topeNutri As Integer)
        Try
            Dim m = New Modulo(_cod, _topeMedico, _topeEnfer, _topeKine, _topeFon, _topeCuid, _topeNutri)
            Dim api As New API(API.resources.MODULO)
            Dim serialObject = Json.JsonConvert.SerializeObject(m)
            api.send_request(serialObject, API.httpMethods.httpPOST)
        Catch ex As apiException
            Throw
        End Try
    End Sub
End Class
