Public Class Prestador

    Private _prestadores As DataTable
    Private _id As String
    Private _cuit As String
    Private _nombre As String
    Private _apellido As String
    Private _email As String
    Private _especialidad As String
    Private _localidad As String
    Private _montoLV As Decimal
    Private _montoFer As Decimal
    Private _montoFijo As Decimal
    Private _montoDiferencial As Decimal
    Private _fechaCese As Date
    Private _creoUser As String
    Private _modifUser As String
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False
    Private _obraSocial As String
    Private _estado As Integer
    Private _comentario As String

    Public Sub New()
        Dim db = New DB()
        Try
            _prestadores = db.getTable(DB.tablas.prestadores)
            _prestadores.Columns.Add("COMBO")
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

    Public Sub New(_cuit As String, _nombre As String, _apellido As String, _email As String, _especialidad As String, _localidad As String, _montoLV As Decimal, _montoFer As Decimal, _montoFijo As Decimal, _diferencial As Decimal, _fechaCese As Date, _obraSocial As String, _comentario As String)

        Me._cuit = _cuit
        Me._nombre = _nombre
        Me._apellido = _apellido
        Me._email = _email
        Me._especialidad = _especialidad
        Me._localidad = _localidad
        Me._obraSocial = _obraSocial
        Me._montoLV = _montoLV
        Me._montoFer = _montoFer
        Me._montoFijo = _montoFijo
        Me._montoDiferencial = _diferencial
        Me._fechaCese = _fechaCese
        Me._comentario = _comentario
        Me._modifUser = My.Settings.dni
        Me._creoUser = My.Settings.dni
        Me._fechaCarga = Date.Today
        Me._fechaMod = Date.Today

    End Sub

    Public Property id As String
        Set(value As String)
            Dim r As DataRow()
            r = _prestadores.Select("ID = '" & value.ToString & "'")

            If r.Length = 1 Then
                _id = value
                _cuit = r(0)("cuit")
                _nombre = r(0)("nombre")
                _apellido = r(0)("apellido")

                If IsDBNull(r(0)("email")) Then
                    _email = ""
                Else
                    _email = r(0)("email")
                End If

                _especialidad = r(0)("especialidad")
                _localidad = r(0)("localidad")

                If IsDBNull(r(0)("servicio")) Then
                    _obraSocial = ""
                Else
                    _obraSocial = r(0)("servicio")
                End If

                _montoLV = r(0)("monto_semana")

                If IsDBNull(r(0)("monto_feriado")) Then
                    _montoFer = 0
                Else
                    _montoFer = r(0)("monto_feriado")
                End If

                If IsDBNull(r(0)("monto_fijo")) Then
                    _montoFijo = 0
                Else
                    _montoFijo = r(0)("monto_fijo")
                End If

                If IsDBNull(r(0)("porcentaje")) Then
                    _montoDiferencial = 0
                Else
                    _montoDiferencial = r(0)("porcentaje")
                End If

                If Not IsDBNull(r(0)("fecha_cese")) Then
                    _fechaCese = r(0)("fecha_cese")
                End If
                If IsDBNull(r(0)("comentario")) Then
                    _comentario = ""
                Else
                    _comentario = r(0)("comentario")
                End If

                _modifUser = r(0)("modifico_usuario")
                    _creoUser = r(0)("cargo_usuario")
                    _fechaCarga = r(0)("fecha_carga")
                    _fechaMod = r(0)("fecha_modificacion")
                Else
                    Throw New Exception("No se encontro el prestador")
            End If

        End Set
        Get
            Return _id
        End Get
    End Property

    Friend Sub reactivar()
        Try
            Dim db As New DB
            db.reactivarPrestador(id)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Property cuit As String
        Set(value As String)
            _cuit = value
        End Set
        Get
            Return _cuit
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

    Public Property especialidad As String
        Set(value As String)
            _especialidad = value
            _modificado = True
        End Set
        Get
            Return _especialidad
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

    Public Property email As String
        Set(value As String)
            _email = value
            _modificado = True
        End Set
        Get
            Return _email
        End Get
    End Property

    Public Property obraSocial As String
        Set(value As String)
            _obraSocial = value
            _modificado = True
        End Set
        Get
            Return _obraSocial
        End Get
    End Property

    Public Property montoNormal As Decimal
        Set(value As Decimal)
            _montoLV = value
            _modificado = True
        End Set
        Get
            Return _montoLV
        End Get
    End Property

    Public Property montoFeriado As Decimal
        Set(value As Decimal)
            _montoFer = value
            _modificado = True
        End Set
        Get
            Return _montoFer
        End Get
    End Property

    Public Property montoFijo As Decimal
        Set(value As Decimal)
            _montoFijo = value
            _modificado = True
        End Set
        Get
            Return _montoFijo
        End Get
    End Property

    Public Property montoDiferencial As Decimal
        Set(value As Decimal)
            _montoDiferencial = value
            _modificado = True
        End Set
        Get
            Return _montoDiferencial
        End Get
    End Property

    Public Property fechaCese As Date
        Set(value As Date)
            _fechaCese = value
            _modificado = True
        End Set
        Get
            Return _fechaCese
        End Get
    End Property

    Public Property comentario As String
        Set(value As String)
            _comentario = value
            _modificado = True
        End Set
        Get
            Return _comentario
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

    Public ReadOnly Property prestadores As DataTable
        Get
            Return _prestadores
        End Get
    End Property

    Public Property estado As Integer
        Set(value As Integer)
            _estado = value
        End Set
        Get
            Return _estado
        End Get
    End Property

    Public Sub insertar()
        Try
            _comentario = _comentario.Replace("'", " ")
            Dim db = New DB
            Dim ut As New utils
            Dim r As DataRow()
            _prestadores = db.getTable(DB.tablas.prestadores)
            r = _prestadores.Select("CUIT = '" & Me.cuit.ToString & "'")

            If r.Length > 0 Then
                If ut.mensaje("Ya existe un prestador con este CUIT" & vbCrLf & "Desea continuar?", utils.mensajes.preg) = MsgBoxResult.Yes Then
                    db.insertar(Me)
                End If
            Else
                db.insertar(Me)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub actualizar()
        Dim db = New DB
        Try
            If _modificado Then
                _comentario = _comentario.Replace("'", " ")
                _fechaMod = Date.Today
                _modifUser = My.Settings.dni
                db.actualizar(Me)
            Else
                Throw New Exception("No se realizaron modificaciones")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub llenarcombo(_combo As ComboBox)
        Dim DV = New DataView(_prestadores)
        DV.RowFilter = "FECHA_CESE IS NULL"
        DV.Sort = "APELLIDO ASC"
        _combo.DataSource = DV
        _combo.DisplayMember = "combo"
        _combo.ValueMember = "id"
        _combo.SelectedIndex = -1

    End Sub
End Class
