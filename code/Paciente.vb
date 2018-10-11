Public Class Paciente

    Private pacientes As DataTable

    Private _afiliado As Integer
    Private _nombre As String
    Private _apellido As String
    Private _obraSocial As String

    Public Property afiliado
        Get
            Return _afiliado
        End Get

        Set(value)
            Dim r As DataRow()
            r = pacientes.Select("afiliado=" & value)
            _afiliado = r(0)("afiliado")
            _nombre = r(0)("nombre")
            _apellido = r(0)("apellido")
            _obraSocial = r(0)("obra_social")
        End Set
    End Property

    Public ReadOnly Property nombre
        Get
            Return _nombre
        End Get
    End Property

    Public ReadOnly Property apellido
        Get
            Return _apellido
        End Get
    End Property

    Public ReadOnly Property obraSocial
        Get
            Return _obraSocial
        End Get
    End Property

    Public Sub New()
        Dim db = New DB()
        Try
            pacientes = db.getTable(DB.tablas.pacientes)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class