Public Class frmBuscar
    Dim obj As Object
    Dim frmParent As Object
    Dim filtro As String
    Dim ut As New utils
    Dim dt As New DataTable
    Public Sub New(_parent As Object)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        frmParent = _parent
        txtFiltro.Focus()
    End Sub

    Private Sub frmBuscar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If frmParent.GetType.Name = "frmPrestadores" Then
                obj = New Prestador()
                dt = obj.prestadores
                dgBuscar.DataSource = dt
                filtro = "Apellido"
                lblFiltro.Text = filtro
                Me.Text = "BUSCAR PRESTADOR"

            ElseIf frmParent.GetType.Name = "frmPacientes" Then
                obj = New Paciente()
                dt = obj.pacientes
                dgBuscar.DataSource = dt
                filtro = "Apellido"
                lblFiltro.Text = filtro
                Me.Text = "BUSCAR PACIENTE"

            ElseIf frmParent.GetType.Name = "frmModulo" Then
                obj = New Modulo()
                dt = obj.modulos
                dgBuscar.DataSource = dt
                filtro = "codigo"
                lblFiltro.Text = filtro
                Me.Text = "BUSCAR MODULO"
            End If
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try

    End Sub

    Private Sub dgBuscar_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBuscar.CellDoubleClick
        Try
            Dim r As DataGridViewRow
            r = dgBuscar.Rows(e.RowIndex)

            If frmParent.GetType.Name = "frmPrestadores" Then
                obj.id = r.Cells("ID").Value
            ElseIf frmParent.GetType.Name = "frmPacientes" Then
                obj.afiliado = r.Cells("AFILIADO").Value
            End If

            frmParent.resultadoBusqueda(obj)
            Me.Close()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        dt.DefaultView.RowFilter = String.Format("{0} LIKE '%{1}%'", filtro, txtFiltro.Text.Trim)
        dgBuscar.Refresh()
    End Sub
End Class