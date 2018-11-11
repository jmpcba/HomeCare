Public Class frmLiquidacionDetalle

    Public Sub New(cuit As String, fecha As Date)
        Dim db As New DB
        Dim dt As New DataTable
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.WindowState = FormWindowState.Maximized

        Try
            dgDetalle.DataSource = db.getLiquidacion(cuit, fecha)
            dgDetalle.AutoResizeColumns()
            dgDetalle.AutoResizeRows()
            Me.Text = "DETALLE PRESTADOR " & cuit
            lblDetalle.Text = "DETALLE PRESTADOR " & cuit

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class