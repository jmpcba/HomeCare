Public Class Zona

    Private _zonas As DataTable

    Private _idzona As Decimal
    Private _nombre As String
    Private _email As String
    Private _pass As String
    Private _propietario As String
    Private _creoUser As String
    Private _modifUser As String
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False

    Public Sub New()
        Dim db = New DB()
        Try
            _zonas = db.getTable(DB.tablas.zonas)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub New(_nombre As String, _email As String, _pass As String, _propietario As String)

        Me._nombre = _nombre
        Me._email = _email
        Me._pass = _pass
        Me._propietario = _propietario
        Me._modifUser = My.Settings.dni
        Me._creoUser = My.Settings.dni
        Me._fechaCarga = Date.Today
        Me._fechaMod = Date.Today
    End Sub

    Public Property idzona As String
        Set(value As String)
            Dim encriptador As New Encriptador()
            Dim r As DataRow()
            r = _zonas.Select("id = " & value)
            If r.Length = 1 Then
                _idzona = value
                _nombre = r(0)("nombre")
                _email = r(0)("email")
                _pass = encriptador.desencriptar(r(0)("PASS"))
                _propietario = r(0)("propietario")
                _creoUser = r(0)("cargo_usuario")
                _modifUser = r(0)("modifico_usuario")
                _fechaCarga = r(0)("fecha_carga")
                _fechaMod = r(0)("fecha_modificacion")
            Else
                Throw New Exception("Zona Inexistente")
            End If
        End Set

        Get
            Return _idzona
        End Get
    End Property

    Public Property email As String
        Set(value As String)
            _email = value
            _modificado = True
        End Set
        Get
            Return _email
        End Get
    End Property
    Public Property pass As String
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

    Public ReadOnly Property zonas As DataTable
        Get
            Return _zonas
        End Get
    End Property

    Public Sub actualizar()
        Dim db = New DB
        Try
            If _modificado Then
                _fechaMod = Date.Today
                _modifUser = My.Settings.dni
                db.actualizar(Me)
            Else
                Throw New ExcepcionDeSistema("No se realizaron modificaciones")
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

