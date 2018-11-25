﻿Public Class frmLiquidacionDetalle
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
            dt = db.getLiquidacion(_idPrest, _fecha)
            dgDetalle.DataSource = dt
            dgDetalle.AutoResizeColumns()
            dgDetalle.AutoResizeRows()
            Me.Text = "DETALLE PRESTADOR " & _idPrest
            lblDetalle.Text = "DETALLE PRESTADOR " & _idPrest
            dgDetalle.ClearSelection()
            dgDetalle.Columns("id").Visible = False
            fecha = _fecha
            idPrestador = _idPrest

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub frmLiquidacionDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnEliminar.Enabled = False
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If ut.mensaje("Desea eliminar la practica seleccionada?", utils.mensajes.preg) = MsgBoxResult.Yes Then
            Dim r As DataGridViewRow

            r = dgDetalle.CurrentRow

            Dim id = r.Cells("id").Value
            Dim rIndex = dgDetalle.CurrentRow.Index
            Try
                If ut.validarLiquidacion(idPrestador, fecha) Then
                    Throw New Exception("LIQUIDACION CERRADA - NO SE PUEDE ELIMINAR")
                Else
                    db.eliminarLiquidacion(id)
                End If

                dt.Rows(rIndex).Delete()
                dgDetalle.DataSource = dt
                btnEliminar.Enabled = False

            Catch ex As Exception
                ut.mensaje(ex.Message, utils.mensajes.err)
            End Try
        End If
    End Sub

    Private Sub dgDetalle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetalle.CellClick
        If e.RowIndex <> -1 Then
            btnEliminar.Enabled = True
        Else
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub frmLiquidacionDetalle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmParent.llenarGrilla()
    End Sub
End Class