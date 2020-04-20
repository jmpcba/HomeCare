Imports Newtonsoft

Public Class Paciente

    Private _pacientes As DataTable
    Private _id As Integer
    Private _afiliado As String
    Private _dni As String
    Private _nombre As String
    Private _apellido As String
    Private _localidad As String
    Private _obraSocial As String
    Private _observaciones As String
    Private _modulo As String
    Private _subModulo As String
    Private _baja As Boolean
    Private _creoUser As String
    Private _modifUser As String
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False

    Public Sub New()
        Try
            Try
                Dim api As New API(API.resources.PACIENTE)
                _pacientes = api.get_table()
                Dim c = _pacientes.Columns.Count
                _pacientes.Columns("ultima_modificacion").SetOrdinal(c - 1)
                _pacientes.Columns("usuario_ultima_modificacion").SetOrdinal(c - 2)
                _pacientes.Columns("apellido").SetOrdinal(1)
                _pacientes.Columns("apellido").SetOrdinal(2)
                _pacientes.Columns("id").SetOrdinal(0)

                _pacientes.Columns.Add("COMBO").SetOrdinal(0)

                For Each r As DataRow In _pacientes.Rows
                    Dim nom As String
                    Dim ape As String
                    nom = r("nombre")
                    ape = r("apellido")

                    r("COMBO") = String.Format("{0} {1}", ape, nom)
                Next
                _pacientes.DefaultView.Sort = "COMBO"
            Catch ex As Exception
                Throw
            End Try
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub New(_afiliado As String, _dni As String, _nombre As String, _apellido As String, _obrasocial As String, _localidad As String, _observaciones As String, _modulo As String, _subModulo As String, _fechaBaja As Date)
        Me._dni = _dni
        Me._afiliado = _afiliado
        Me._nombre = _nombre
        Me._apellido = _apellido
        Me._obraSocial = _obrasocial
        Me._localidad = _localidad
        Me._observaciones = _observaciones
        Me._subModulo = _subModulo
        Me._modulo = _modulo
        Me._modifUser = My.Settings.userName
        Me._fechaCarga = Date.Today
        Me._fechaMod = Date.Today
    End Sub

    Public Property DNI As String
        Set(value As String)
            _dni = value
            _modificado = True
        End Set
        Get
            Return _dni
        End Get
    End Property

    Public Property afiliado As String
        Set(value As String)
            _dni = value
            _modificado = True
        End Set
        Get
            Return _dni
        End Get
    End Property

    Public Property id As String
        Set(value As String)
            Dim r As DataRow()

            r = _pacientes.Select("id='" & value & "'")

            If r.Length = 1 Then
                _id = value
                _afiliado = r(0)("afiliado")
                _dni = r(0)("dni")
                _nombre = r(0)("nombre")
                _apellido = r(0)("apellido")
                If IsDBNull(r(0)("obra_social")) Then
                    _obraSocial = ""
                Else
                    _obraSocial = r(0)("obra_social")
                End If
                _localidad = r(0)("localidad")
                If Not IsDBNull(r(0)("baja")) Then
                    _baja = r(0)("baja")
                End If
                If IsDBNull(r(0)("observacion")) Then
                    _observaciones = ""
                Else
                    _observaciones = r(0)("observacion")
                End If

                If IsDBNull(r(0)("modulo")) Then
                    _modulo = ""
                Else
                    _modulo = r(0)("modulo")
                End If

                If IsDBNull(r(0)("sub_modulo")) Then
                    _subModulo = ""
                Else
                    _subModulo = r(0)("sub_modulo")
                End If
            Else
                Throw New Exception("Codigo Inexistente")
            End If

        End Set
        Get
            Return _id
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

    Public Property apellido As String
        Set(value As String)
            _apellido = value
            _modificado = True
        End Set
        Get
            Return _apellido
        End Get
    End Property

    Public Property obra_social As String
        Set(value As String)
            _obraSocial = value
            _modificado = True
        End Set
        Get
            Return _obraSocial
        End Get
    End Property

    Public Property localidad As String
        Set(value As String)
            _localidad = value
            _modificado = True
        End Set
        Get
            Return _localidad
        End Get
    End Property

    Public Property observacion As String
        Set(value As String)
            _observaciones = value
            _modificado = True
        End Set
        Get
            Return _observaciones
        End Get
    End Property

    Public Property modulo As String
        Set(value As String)
            _modulo = value
            _modificado = True
        End Set
        Get
            Return _modulo
        End Get
    End Property

    Public Property sub_modulo As String
        Set(value As String)
            _subModulo = value
            _modificado = True
        End Set
        Get
            Return _subModulo
        End Get
    End Property

    Public Property baja As Boolean
        Set(value As Boolean)
            _baja = value
            _modificado = True
        End Set
        Get
            Return _baja
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

    Public Function getPacientes() As DataTable
        Return _pacientes
    End Function

    Public Sub insertar()
        Try
            Dim api As New API(API.resources.PACIENTE)
            Me.baja = False
            Dim serialObject = Json.JsonConvert.SerializeObject(Me)
            api.send_post_put(serialObject, API.httpMethods.httpPOST)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub actualizar()
        Try
            If _modificado Then
                Dim api As New API(API.resources.PACIENTE)
                _pacientes = Nothing
                Dim serialObject = Json.JsonConvert.SerializeObject(Me)
                api.send_post_put(serialObject, API.httpMethods.httpPUT)
            Else
                Throw New Exception("No se realizaron modificaciones")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Friend Sub reactivar()
        Try
            Dim db As New DB
            db.reactivarPaciente(afiliado)
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

    Public Sub refrescar()
        Try
            getPacientes()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function getModificado() As Boolean
        Return _modificado
    End Function
End Class