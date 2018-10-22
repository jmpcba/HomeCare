<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnVisita = New System.Windows.Forms.Button()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ConfiguracionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BaseDeDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVisita
        '
        Me.btnVisita.Location = New System.Drawing.Point(12, 48)
        Me.btnVisita.Name = "btnVisita"
        Me.btnVisita.Size = New System.Drawing.Size(260, 53)
        Me.btnVisita.TabIndex = 0
        Me.btnVisita.Text = "Cargar Visita"
        Me.btnVisita.UseVisualStyleBackColor = True
        '
        'btnReporte
        '
        Me.btnReporte.Location = New System.Drawing.Point(12, 104)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(260, 53)
        Me.btnReporte.TabIndex = 1
        Me.btnReporte.Text = "Historial De Visitas"
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguracionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(284, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConfiguracionToolStripMenuItem
        '
        Me.ConfiguracionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BaseDeDatosToolStripMenuItem})
        Me.ConfiguracionToolStripMenuItem.Name = "ConfiguracionToolStripMenuItem"
        Me.ConfiguracionToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.ConfiguracionToolStripMenuItem.Text = "Configuracio&n"
        '
        'BaseDeDatosToolStripMenuItem
        '
        Me.BaseDeDatosToolStripMenuItem.Name = "BaseDeDatosToolStripMenuItem"
        Me.BaseDeDatosToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BaseDeDatosToolStripMenuItem.Text = "&Base De Datos"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btnReporte)
        Me.Controls.Add(Me.btnVisita)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmPrincipal"
        Me.Text = "frmPrincipal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnVisita As Button
    Friend WithEvents btnReporte As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ConfiguracionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BaseDeDatosToolStripMenuItem As ToolStripMenuItem
End Class
