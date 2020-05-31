Imports Newtonsoft
Public Class ControllerPrestador
    Private _prestadores As DataTable

    Public Sub New(Optional loadAll As Boolean = True)
        If loadAll Then
            loadPrestadores()
        End If
    End Sub

    Private Sub loadPrestadores()
        Dim api As New API(API.resources.PRESTADOR)
        Try
            _prestadores = api.get_table()
            _prestadores.Columns.Add("COMBO").SetOrdinal(0)
            For Each r As DataRow In _prestadores.Rows
                Dim nombre = r("nombre")
                Dim apellido = r("apellido")
                Dim especialidad = r("especialidad")
                Dim localidad = r("localidad")
                Dim servicio = r("servicio")
                r("COMBO") = String.Format("{0} {1} - {2} - {3} - {4}", apellido, nombre, localidad, especialidad, servicio)
            Next
            _prestadores.DefaultView.Sort = "COMBO"
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public ReadOnly Property prestadores As DataTable
        Get
            Return _prestadores
        End Get
    End Property

    Public ReadOnly Property prestador(id As String) As Prestador
        Get
            Dim p = New Prestador()
            Dim r As DataRow()
            r = _prestadores.Select("ID = '" & id.ToString & "'")

            If r.Length = 1 Then
                p.id = id
                p.CUIT = r(0)("cuit")
                p.nombre = r(0)("nombre")
                p.apellido = r(0)("apellido")

                If IsDBNull(r(0)("mail")) Then
                    p.mail = ""
                Else
                    p.mail = r(0)("mail")
                End If

                p.especialidad = r(0)("especialidad")
                p.localidad = r(0)("localidad")

                If IsDBNull(r(0)("servicio")) Then
                    p.servicio = ""
                Else
                    p.servicio = r(0)("servicio")
                End If

                p.monto_semana = r(0)("monto_semana")

                If IsDBNull(r(0)("monto_feriado")) Then
                    p.monto_feriado = 0
                Else
                    p.monto_feriado = r(0)("monto_feriado")
                End If

                If IsDBNull(r(0)("monto_fijo")) Then
                    p.monto_fijo = 0
                Else
                    p.monto_fijo = r(0)("monto_fijo")
                End If

                If IsDBNull(r(0)("monto_diferencial")) Then
                    p.monto_diferencial = 0
                Else
                    p.monto_diferencial = r(0)("monto_diferencial")
                End If

                If IsDBNull(r(0)("comentario")) Then
                    p.comentario = ""
                Else
                    p.comentario = r(0)("comentario")
                End If

                If IsDBNull(r(0)("zona")) Then
                    p.zona = 1
                Else
                    p.zona = r(0)("zona")
                End If

                Return p
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Sub insertar(_cuit As String, _nombre As String, _apellido As String, _email As String, _especialidad As String, _localidad As String, _montoLV As Decimal, _montoFer As Decimal, _montoFijo As Decimal, _diferencial As Decimal, _fechaCese As Date, _obraSocial As String, _comentario As String, _zona As Integer)
        Dim r As DataRow()
        Dim ut = New utils()
        Dim p = New Prestador(_cuit, _nombre, _apellido, _email, _especialidad, _localidad, _montoLV, _montoFer, _montoFijo, _diferencial, _fechaCese, _obraSocial, _comentario, _zona)
        Try
            Try
                loadPrestadores()
                If _prestadores.Rows.Count > 0 Then
                    r = _prestadores.Select("CUIT = '" & p.CUIT.ToString & "'")
                End If
            Catch ex As apiException
                _prestadores = New DataTable
            End Try

            If Not IsNothing(r) Then
                If r.Length > 0 Then
                    If ut.mensaje("Ya existe un prestador con este CUIT" & vbCrLf & "Desea continuar?", utils.mensajes.preg) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If

            Dim api As New API(API.resources.PRESTADOR)
            Dim serialObject = Json.JsonConvert.SerializeObject(p)
            api.send_request(serialObject, API.httpMethods.httpPOST)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub actualizar(p As Prestador)
        Try
            Dim api As New API(API.resources.PRESTADOR)
            _prestadores = Nothing
            Dim serialObject = Json.JsonConvert.SerializeObject(p)
            api.send_request(serialObject, API.httpMethods.httpPUT)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub llenarcombo(_combo As ComboBox)
        Dim DV = New DataView(_prestadores)
        DV.RowFilter = "BAJA = FALSE"
        DV.Sort = "APELLIDO ASC"
        _combo.DataSource = DV
        _combo.DisplayMember = "combo"
        _combo.ValueMember = "id"
        _combo.SelectedIndex = -1
    End Sub

    Public Sub refrescar()
        Try
            loadPrestadores()
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
