Public Class frmLiquidacionDetalle
    Dim ut As New utils
    Dim db As New DB
    Dim dt As New DataTable
    Dim fecha As Date
    Dim idPrestador As Integer
    Dim frmParent As frmLiquidar

    Public Sub New(_idPrest As Integer, _fecha As Date, ByRef _parent As frmLiquidar)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.WindowState = FormWindowState.Maximized
        frmParent = _parent
        Try
            Me.Text = "DETALLE PRESTADOR " & _idPrest
            lblDetalle.Text = "DETALLE PRESTADOR"
            fecha = _fecha
            idPrestador = _idPrest

            If dt.Rows.Count > 0 Then
                ToolStripMenuItemDetalle.Enabled = True
            Else
                ToolStripMenuItemDetalle.Enabled = False
            End If
            llenarGrilla()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub frmLiquidacionDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnEliminar.Enabled = False
        If My.Settings.nivel > 2 Then
            btnEliminar.Visible = False
        Else
            btnEliminar.Visible = True
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim ids As New List(Of Integer())
        Dim filasError As New List(Of Integer)

        dgDetalle.ClearSelection()

        For Each r As DataGridViewRow In dgDetalle.Rows
            If r.Cells(0).Value Then
                Dim id = r.Cells("id").Value
                Dim rIndex = r.Index
                Dim clave As Integer()
                clave = {id, rIndex}

                r.DefaultCellStyle.BackColor = Color.LightGreen
                ids.Add(clave)
            End If
        Next

        If ut.mensaje("Desea eliminar las practicas seleccionadas?", utils.mensajes.preg) = MsgBoxResult.Yes Then
            For Each c As Integer() In ids
                Try
                    If ut.validarLiquidacion(idPrestador, fecha) Then
                        Throw New Exception("LIQUIDACION CERRADA - NO SE PUEDE ELIMINAR")
                    Else
                        db.eliminarPractica(c(0))
                    End If
                Catch ex As Exception
                    ut.mensaje(ex.Message, utils.mensajes.err)
                    filasError.Add(c(1))
                End Try
            Next

            llenarGrilla()

            If filasError.Count > 0 Then
                For Each i As Integer In filasError
                    dgDetalle.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Next
            End If

            dgDetalle.Refresh()

        End If
    End Sub

    Private Sub dgDetalle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetalle.CellClick
        Dim sel = dgDetalle.Rows(e.RowIndex).Cells(0).Value
        sel = Not sel

        If e.RowIndex <> -1 Then
            btnEliminar.Enabled = True
            dgDetalle.Rows(e.RowIndex).Cells(0).Value = sel
        Else
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub frmLiquidacionDetalle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmParent.llenarGrilla()
    End Sub

    Private Sub frmLiquidacionDetalle_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        dgDetalle.ClearSelection()
    End Sub

    Private Sub DetallePrestadorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDetalle.Click
        Try
            ut.exportarExcel(dt)
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub llenarGrilla()
        Dim chkclm As New DataGridViewCheckBoxColumn
        dgDetalle.DataSource = Nothing
        dt.Clear()
        dt = db.getLiquidacion(idPrestador, fecha)

        With chkclm
            .HeaderText = ""
            .Name = ""
            .ReadOnly = False
        End With

        With dgDetalle
            .Columns.Clear()
            .DataSource = dt
            .AutoResizeColumns()
            .AutoResizeRows()
            .ClearSelection()
            .Columns("id").Visible = False

            If dt.Rows.Count <> 0 Then
                .Columns.Insert(0, chkclm)

            End If
        End With
    End Sub
End Class