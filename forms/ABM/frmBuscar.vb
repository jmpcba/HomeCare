Public Class frmBuscar
    Dim obj As Object
    Dim ctrl As Object
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
                ctrl = New ControllerPrestador
                dt = ctrl.Prestadores
                dgBuscar.DataSource = dt
                filtro = "Apellido"
                lblFiltro.Text = filtro
                Me.Text = "BUSCAR PRESTADOR"

            ElseIf frmParent.GetType.Name = "frmPacientes" Then
                obj = New Paciente()
                ctrl = New ControllerPaciente
                dt = ctrl.Pacientes
                dgBuscar.DataSource = dt
                filtro = "Apellido"
                lblFiltro.Text = filtro
                Me.Text = "BUSCAR PACIENTE"

            ElseIf frmParent.GetType.Name = "frmModulo" Then
                obj = New Modulo()
                ctrl = New ControllerModulo
                dt = ctrl.Modulos
                dgBuscar.DataSource = dt
                filtro = "codigo"
                lblFiltro.Text = filtro
                Me.Text = "BUSCAR MODULO"
            ElseIf frmParent.GetType.Name = "frmSubMod" Then
                obj = New subModulo()
                ctrl = New ControllerSubModulo
                dt = ctrl.subModulos
                dgBuscar.DataSource = dt
                filtro = "codigo"
                lblFiltro.Text = filtro
                Me.Text = "BUSCAR SUB-MODULO"
            ElseIf frmParent.GetType.Name = "frmUsuarios" Then
                obj = New UserManager()
                dt = obj.allUsers
                dgBuscar.DataSource = dt
                filtro = "usuario"
                lblFiltro.Text = filtro
                Me.Text = "BUSCAR USUARIOS"
            ElseIf frmParent.GetType.Name = "frmZonas" Then
                ctrl = New ControllerZona()
                dt = ctrl.zonas
                dgBuscar.DataSource = dt
                filtro = "nombre"
                lblFiltro.Text = filtro
                Me.Text = "BUSCAR ZONAS"
            End If

            dgBuscar.AutoResizeColumns()
            dgBuscar.AutoResizeRows()
            txtFiltro.Focus()

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try

    End Sub

    Private Sub dgBuscar_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBuscar.CellDoubleClick
        If e.RowIndex <> -1 Then
            Try
                Dim um = New UserManager
                Dim r As DataGridViewRow
                r = dgBuscar.Rows(e.RowIndex)

                If frmParent.GetType.Name = "frmPrestadores" Then
                    obj = ctrl.prestador(r.Cells("ID").Value)
                ElseIf frmParent.GetType.Name = "frmPacientes" Then
                    obj = ctrl.paciente(r.Cells("id").Value)
                ElseIf frmParent.GetType.Name = "frmModulo" Then
                    obj = ctrl.modulo(r.Cells("id").Value)
                ElseIf frmParent.GetType.Name = "frmSubMod" Then
                    obj = ctrl.subModulo(r.Cells("id").Value)
                ElseIf frmParent.GetType.Name = "frmUsuarios" Then
                    obj = um.modelUser(r.Cells("usuario").Value)
                ElseIf frmParent.GetType.Name = "frmZonas" Then
                    obj = ctrl.zona(r.Cells("id").Value)
                End If

                frmParent.resultadoBusqueda(obj)
                Me.Close()
            Catch ex As Exception
                ut.mensaje(ex.Message, utils.mensajes.err)
            End Try
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        dt.DefaultView.RowFilter = String.Format("{0} LIKE '%{1}%'", filtro, txtFiltro.Text.Trim)
        dgBuscar.Refresh()
    End Sub

    Private Sub frmBuscar_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtFiltro.Focus()
    End Sub
End Class