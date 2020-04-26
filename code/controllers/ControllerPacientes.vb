Imports Newtonsoft
Public Class ControllerPacientes
    Private _pacientes As DataTable

    Public Sub New(Optional loadAll As Boolean = True)
        If loadAll Then
            loadPacientes()
        End If
    End Sub

    Private Sub loadPacientes()
        Try
            Dim api As New API(API.resources.PACIENTE)
            _pacientes = api.get_table()
            Dim c = _pacientes.Columns.Count
            _pacientes.Columns("ultima_modificacion").SetOrdinal(c - 1)
            _pacientes.Columns("usuario_ultima_modificacion").SetOrdinal(c - 2)
            _pacientes.Columns("id").SetOrdinal(0)
            _pacientes.Columns("afiliado").SetOrdinal(1)
            _pacientes.Columns("dni").SetOrdinal(2)
            _pacientes.Columns("nombre").SetOrdinal(3)
            _pacientes.Columns("apellido").SetOrdinal(4)

            _pacientes.Columns.Add("COMBO").SetOrdinal(5)

            For Each r As DataRow In _pacientes.Rows
                Dim nom As String
                Dim ape As String
                nom = r("nombre")
                ape = r("apellido")

                r("COMBO") = String.Format("{0} {1}", ape, nom)
            Next
            _pacientes.DefaultView.Sort = "COMBO"
        Catch ex As apiException
            Throw
        End Try
    End Sub

    Public Sub refrescar()
        Try
            loadPacientes()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub insertar(_afiliado As String, _dni As String, _nombre As String, _apellido As String, _obrasocial As String, _localidad As String, _observaciones As String, _modulo As String, _subModulo As String, _fechaBaja As Date)
        Try
            Dim p = New Paciente(_afiliado, _dni, _nombre, _apellido, _obrasocial, _localidad, _observaciones, _modulo, _subModulo, _fechaBaja)
            Dim api As New API(API.resources.PACIENTE)
            Dim serialObject = Json.JsonConvert.SerializeObject(p)
            api.send_post_put(serialObject, API.httpMethods.httpPOST)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub actualizar(p As Paciente)
        Try
            Dim api As New API(API.resources.PACIENTE)
            Dim serialObject = Json.JsonConvert.SerializeObject(p)
            api.send_post_put(serialObject, API.httpMethods.httpPUT)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub llenarcombo(_combo As ComboBox)
        Dim DV = New DataView(_pacientes)
        DV.RowFilter = "BAJA = FALSE"
        DV.Sort = "APELLIDO ASC"

        _combo.DataSource = DV
        _combo.DisplayMember = "combo"
        _combo.ValueMember = "id"
        _combo.SelectedIndex = -1
    End Sub

    Public ReadOnly Property pacientes As DataTable
        Get
            Return _pacientes
        End Get
    End Property

    Public ReadOnly Property paciente(id As Integer) As Paciente
        Get
            Dim r As DataRow()
            Dim p = New Paciente()
            r = _pacientes.Select("id='" & id & "'")

            If r.Length = 1 Then
                p.id = id
                p.afiliado = r(0)("afiliado")
                p.DNI = r(0)("dni")
                p.nombre = r(0)("nombre")
                p.apellido = r(0)("apellido")
                If IsDBNull(r(0)("obra_social")) Then
                    p.obra_social = ""
                Else
                    p.obra_social = r(0)("obra_social")
                End If
                p.localidad = r(0)("localidad")
                If Not IsDBNull(r(0)("baja")) Then
                    p.baja = r(0)("baja")
                End If
                If IsDBNull(r(0)("observacion")) Then
                    p.observacion = ""
                Else
                    p.observacion = r(0)("observacion")
                End If

                If IsDBNull(r(0)("modulo")) Then
                    p.modulo = ""
                Else
                    p.modulo = r(0)("modulo")
                End If

                If IsDBNull(r(0)("sub_modulo")) Then
                    p.sub_modulo = ""
                Else
                    p.sub_modulo = r(0)("sub_modulo")
                End If

                Return p
            Else
                Return Nothing
            End If
        End Get
    End Property


End Class
