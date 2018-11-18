Public Class Modulo
    Private _codigo As Integer
    Private _topeMedico As Integer
    Private _topeEnfermeria As Integer
    Private _topeKinesio As Integer
    Private _topeFono As Integer
    Private _topeCuidador As Integer
    Private _modifUser As Integer
    Private _creoUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False
    Private _modulos As DataTable
    Private _user As Usuario

    Public Sub New()
        Dim db = New DB()
        Try
            _modulos = db.getTable(DB.tablas.modulo)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub New(_cod As Integer, _topeMedico As Integer, _topeEnfer As Integer, _topeKine As Integer, _topeFon As Integer, _topeCuid As Integer)
        _user = New Usuario
        Me._codigo = _cod
        Me._topeMedico = _topeMedico
        Me._topeEnfermeria = _topeEnfer
        Me._topeKinesio = _topeKine
        Me._topeFono = _topeFon
        Me._topeCuidador = _topeCuid
        Me._modifUser = _user.dni
        Me._creoUser = _user.dni
        Me._fechaCarga = Date.Today
        Me._fechaMod = Date.Today
    End Sub


    Public Property codigo As Integer
        Set(value As Integer)
            Dim r As DataRow()
            r = _modulos.Select("codigo=" & value)
            If r.Length = 1 Then
                _codigo = r(0)("codigo")
                _topeMedico = r(0)("medico")
                _topeEnfermeria = r(0)("enfermeria")
                _topeKinesio = r(0)("kinesio")
                _topeFono = r(0)("fono")
                _topeCuidador = r(0)("cuidador")
                _user = New Usuario
                _modifUser = r(0)("modifico_usuario")
                _creoUser = r(0)("cargo_usuario")
                _fechaCarga = r(0)("fecha_carga")
                _fechaMod = r(0)("fecha_modificacion")
            Else
                Throw New Exception("Codigo Inexistente")
            End If
        End Set
        Get
            Return _codigo
        End Get
    End Property

    Friend Sub llenarcombo(_combo As ComboBox)
        _combo.DataSource = _modulos
        _combo.DisplayMember = "codigo"
        _combo.ValueMember = "codigo"
        _combo.SelectedIndex = -1
    End Sub

    Public ReadOnly Property tope(_tipo As String) As Integer
        Get
            If _tipo = "MEDICO" Then
                Return _topeMedico
            ElseIf _tipo = "ENFERMERIA" Then
                Return _topeEnfermeria
            ElseIf _tipo = "KINESIO" Then
                Return _topeKinesio
            ElseIf _tipo = "FONO" Then
                Return _topeFono
            ElseIf _tipo = "CUIDADOR" Then
                Return _topeCuidador
            Else
                Return 0
            End If
        End Get
    End Property

    Public Property topeMedico As Integer
        Set(value As Integer)
            _topeMedico = value
            _modificado = True
        End Set
        Get
            Return _topeMedico
        End Get
    End Property
    Public Property topeEnfermeria As Integer
        Set(value As Integer)
            _topeEnfermeria = value
            _modificado = True
        End Set
        Get
            Return _topeEnfermeria
        End Get
    End Property
    Public Property topeKinesio As Integer
        Set(value As Integer)
            _topeKinesio = value
            _modificado = True
        End Set
        Get
            Return _topeKinesio
        End Get
    End Property
    Public Property topeFono As Integer
        Set(value As Integer)
            _topeFono = value
            _modificado = True
        End Set
        Get
            Return _topeFono
        End Get
    End Property
    Public Property topeCuidador As Integer
        Set(value As Integer)
            _topeCuidador = value
            _modificado = True
        End Set
        Get
            Return _topeCuidador
        End Get
    End Property

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

    Public Sub insertar()
        Try
            Dim db = New DB
            db.insertar(Me)
        Catch ex As Exception
            Throw
        End Try
    End Sub

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
End Class
