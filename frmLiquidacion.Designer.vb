<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiquidacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tbReporte = New System.Windows.Forms.TabControl()
        Me.tabDetalle = New System.Windows.Forms.TabPage()
        Me.dgDetalle = New System.Windows.Forms.DataGridView()
        Me.tabMedico = New System.Windows.Forms.TabPage()
        Me.tabPaciente = New System.Windows.Forms.TabPage()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.tbReporte.SuspendLayout()
        Me.tabDetalle.SuspendLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbReporte
        '
        Me.tbReporte.Controls.Add(Me.tabDetalle)
        Me.tbReporte.Controls.Add(Me.tabMedico)
        Me.tbReporte.Controls.Add(Me.tabPaciente)
        Me.tbReporte.Location = New System.Drawing.Point(12, 40)
        Me.tbReporte.Name = "tbReporte"
        Me.tbReporte.SelectedIndex = 0
        Me.tbReporte.Size = New System.Drawing.Size(1155, 753)
        Me.tbReporte.TabIndex = 0
        '
        'tabDetalle
        '
        Me.tabDetalle.BackColor = System.Drawing.Color.Gainsboro
        Me.tabDetalle.Controls.Add(Me.dtFecha)
        Me.tabDetalle.Controls.Add(Me.dgDetalle)
        Me.tabDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDetalle.Location = New System.Drawing.Point(4, 22)
        Me.tabDetalle.Name = "tabDetalle"
        Me.tabDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetalle.Size = New System.Drawing.Size(1147, 727)
        Me.tabDetalle.TabIndex = 0
        Me.tabDetalle.Text = "DETALLE"
        '
        'dgDetalle
        '
        Me.dgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetalle.Location = New System.Drawing.Point(0, 104)
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.Size = New System.Drawing.Size(1147, 620)
        Me.dgDetalle.TabIndex = 0
        '
        'tabMedico
        '
        Me.tabMedico.BackColor = System.Drawing.Color.Gainsboro
        Me.tabMedico.Location = New System.Drawing.Point(4, 22)
        Me.tabMedico.Name = "tabMedico"
        Me.tabMedico.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMedico.Size = New System.Drawing.Size(1147, 727)
        Me.tabMedico.TabIndex = 1
        Me.tabMedico.Text = "Totales por Medico"
        '
        'tabPaciente
        '
        Me.tabPaciente.BackColor = System.Drawing.Color.Gainsboro
        Me.tabPaciente.Location = New System.Drawing.Point(4, 22)
        Me.tabPaciente.Name = "tabPaciente"
        Me.tabPaciente.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPaciente.Size = New System.Drawing.Size(1147, 727)
        Me.tabPaciente.TabIndex = 2
        Me.tabPaciente.Text = "Totales por Paciente"
        '
        'dtFecha
        '
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFecha.Location = New System.Drawing.Point(127, 49)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(200, 23)
        Me.dtFecha.TabIndex = 1
        '
        'frmLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1179, 805)
        Me.Controls.Add(Me.tbReporte)
        Me.Name = "frmLiquidacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLiquidacion"
        Me.tbReporte.ResumeLayout(False)
        Me.tabDetalle.ResumeLayout(False)
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tbReporte As TabControl
    Friend WithEvents tabDetalle As TabPage
    Friend WithEvents tabMedico As TabPage
    Friend WithEvents tabPaciente As TabPage
    Friend WithEvents dgDetalle As DataGridView
    Friend WithEvents dtFecha As DateTimePicker
End Class
