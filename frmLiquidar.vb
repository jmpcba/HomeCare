Public Class frmLiquidar
    Dim sel As Boolean = False
    Private Sub dtMes_ValueChanged(sender As Object, e As EventArgs) Handles dtMes.ValueChanged
        grilla()
    End Sub

    Public Sub grilla()
        Dim db As New DB()
        Dim mes = dtMes.Value
        Dim dt As New DataTable
        dt = db.liquidacion(mes, DB.liquidaciones.medico)


        Dim chkclm As New DataGridViewCheckBoxColumn

        With chkclm
            .HeaderText = ""
            .Name = ""
            .ReadOnly = False
        End With

        With gridLiqui
            .Columns.Clear()

            If dt.Rows.Count <> 0 Then
                .Columns.Insert(0, chkclm)
            End If

            .DataSource = dt
            .AutoResizeColumns()
            .AutoResizeRows()
        End With

        For Each c As DataGridViewColumn In gridLiqui.Columns
            If c.Index <> 0 Then
                c.ReadOnly = True
            End If
        Next

    End Sub

    Private Sub frmLiquidar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grilla()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub gridLiqui_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridLiqui.CellDoubleClick
        Dim r As DataGridViewRow
        If e.ColumnIndex <> 0 Then
            r = gridLiqui.Rows(e.RowIndex)
            Dim cuit = r.Cells("CUIT").Value
            Dim fecha = dtMes.Value
            Dim frm As New frmLiquidacionDetalle(cuit, fecha)
            frm.Show()
        End If

    End Sub

    Private Sub btnSelec_Click(sender As Object, e As EventArgs) Handles btnSelec.Click
        sel = Not sel

        If sel Then
            btnSelec.Text = "Des-seleccionar todos"
        Else
            btnSelec.Text = "Seleccionar todos"
        End If

        For Each r As DataGridViewRow In gridLiqui.Rows
            r.Cells(0).Value = sel
        Next
    End Sub
End Class