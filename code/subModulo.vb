Public Class subModulo

    Private _codigo As String
    Private _descripcion As String
    Private _numTope As Integer
    Private _modifUser As Integer
    Private _creoUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False
    Private _subModulos As DataTable

    Public Sub New(_cod As String, _desc As String)

        _codigo = _cod
        _descripcion = _desc
        _modifUser = My.Settings.dni
        _creoUser = My.Settings.dni
        _fechaCarga = Date.Today
        _fechaMod = Date.Today
    End Sub

    Public Sub New()
        Dim db = New DB()
        Try
            _subModulos = db.getTable(DB.tablas.subModulo)
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
    End Sub

    Public Property codigo As String
        Set(value As String)
            Dim r As DataRow()
            r = _subModulos.Select("codigo = " & value)
            If r.Length = 1 Then
                _codigo = value
                _descripcion = r(0)("descripcion")
                _modifUser = r(0)("modifico_usuario")
                _creoUser = r(0)("cargo_usuario")
                _fechaCarga = r(0)("fecha")
                _fechaMod = r(0)("fecha_modificacion")
            Else
                Throw New Exception("Codigo Inexistente")
            End If
        End Set

        Get
            Return _codigo
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
        _combo.ValueMember = "codigo"
        _combo.SelectedIndex = -1
    End Sub

    Public Property descripcion As String
        Set(value As String)
            _descripcion = value
            _modificado = True
        End Set
        Get
            Return _descripcion
        End Get
    End Property

    Public Property tope As Integer
        Set(value As Integer)
            _numTope = value
            _modificado = True
        End Set
        Get
            Return _numTope
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
    Public readonly Property fechaMod As Date
        Get
            Return _fechaMod
        End Get
    End Property

    Public Sub insertar()
        Dim db As New DB
        Try
            db.insertar(Me)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub actualizar()
        Dim db As New DB
        Try
            If _modificado Then
                _modifUser = My.Settings.dni
                _fechaMod = Date.Today
                db.actualizar(Me)
            Else
                Throw New Exception("No se realizaron modificaciones")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class