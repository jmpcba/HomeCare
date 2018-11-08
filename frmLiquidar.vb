Public Class frmLiquidar
    Private Sub dtMes_ValueChanged(sender As Object, e As EventArgs) Handles dtMes.ValueChanged
        grilla()
    End Sub

    Public Sub grilla()
        Dim db As New DB()
        Dim mes = dtMes.Value
        Dim dt As New DataTable
        dt = db.liquidacion(mes, DB.liquidaciones.medico)
        gridLiqui.DataSource = dt
        gridLiqui.AutoResizeColumns()
        gridLiqui.AutoResizeRows()
    End Sub

    Private Sub frmLiquidar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grilla()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub gridLiqui_DoubleClick(sender As Object, e As EventArgs) Handles gridLiqui.DoubleClick
        'Dim frm = New frmliqui
    End Sub
End Class