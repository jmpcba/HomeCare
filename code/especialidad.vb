Public Class especialidad
    Private _id As Integer
    Private _nombre As String
    Private _especialidades As DataTable

    Public Sub New()

        Dim db = New DB()
        Try
            _especialidades = db.getTable(DB.tablas.especialidades)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub llenarcombo(_combo As ComboBox)
        _combo.DataSource = _especialidades
        _combo.DisplayMember = "nombre"
        _combo.ValueMember = "nombre"
        _combo.SelectedIndex = -1
    End Sub
End Class
