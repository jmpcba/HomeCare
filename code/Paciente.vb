Public Class Paciente

    Private _pacientes As DataTable
    Private _user As Usuario

    Private _afiliado As String
    Private _dni As String
    Private _nombre As String
    Private _apellido As String
    Private _localidad As String
    Private _obraSocial As String
    Private _creoUser As String
    Private _modifUser As String
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False

    Public Sub New()
        Dim db = New DB()
        Try
            _pacientes = db.getTable(DB.tablas.pacientes)
            _pacientes.Columns.Add("COMBO")

            For Each r As DataRow In _pacientes.Rows
                Dim nom As String
                Dim ape As String
                nom = r("nombre")
                ape = r("apellido")

                r("COMBO") = String.Format("{0} {1}", ape, nom)
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub New(_afiliado As String, _dni As String, _nombre As String, _apellido As String, _obrasocial As String, _localidad As String)
        _user = New Usuario
        Me._dni = _dni
        Me._afiliado = _afiliado
        Me._nombre = _nombre
        Me._apellido = _apellido
        Me._obraSocial = _obrasocial
        Me._localidad = _localidad
        Me._modifUser = _user.dni
        Me._creoUser = _user.dni
        Me._fechaCarga = Date.Today
        Me._fechaMod = Date.Today
    End Sub

    Public Property dni As String
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
            Dim r As DataRow()

            r = _pacientes.Select("afiliado=" & value)

            If r.Length = 1 Then

                _afiliado = r(0)("afiliado")
                _dni = r(0)("dni")
                _nombre = r(0)("nombre")
                _apellido = r(0)("apellido")
                _obraSocial = r(0)("obra_social")
                _localidad = r(0)("localidad")
            Else
                Throw New Exception("Codigo Inexistente")
            End If

        End Set
        Get
            Return _afiliado
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

    Public Property obrasocial As String
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

    Public Sub actualizar()
        Dim db = New DB
        Try
            If _modificado Then
                _fechaMod = Date.Today
                _modifUser = _user.dni
                db.actualizar(Me)
            Else
                Throw New Exception("No se realizaron modificaciones")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub llenarcombo(_combo As ComboBox)
        _combo.DataSource = _pacientes
        _combo.DisplayMember = "combo"
        _combo.ValueMember = "afiliado"
        _combo.SelectedIndex = -1

    End Sub
End Class