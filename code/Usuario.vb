Public Class Usuario

    Private _dni As String
    Private _apellido As String
    Private _nombre As String
    Private _nivel As Integer
    Private _pass As String
    Private _modifUser As Integer
    Private _creoUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date

    Public Property dni As String
        Set(value As String)
            _dni = value
        End Set
        Get
            Return "29188989"
        End Get
    End Property
End Class
