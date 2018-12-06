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
        Me.btnInformes = New System.Windows.Forms.Button()
        Me.btnPacientes = New System.Windows.Forms.Button()
        Me.btnModulo = New System.Windows.Forms.Button()
        Me.btnNvaLiq = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCierreLiq = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSubMod = New System.Windows.Forms.Button()
        Me.btnPrestadores = New System.Windows.Forms.Button()
        Me.btnFeriados = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ConfiguracionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BaseDeDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVisita
        '
        Me.btnVisita.Location = New System.Drawing.Point(26, 45)
        Me.btnVisita.Name = "btnVisita"
        Me.btnVisita.Size = New System.Drawing.Size(260, 53)
        Me.btnVisita.TabIndex = 0
        Me.btnVisita.Text = "CARGAR PRACTICAS"
        Me.btnVisita.UseVisualStyleBackColor = True
        '
        'btnReporte
        '
        Me.btnReporte.Enabled = False
        Me.btnReporte.Location = New System.Drawing.Point(26, 104)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(260, 53)
        Me.btnReporte.TabIndex = 1
        Me.btnReporte.Text = "HISTORIAL PRACTICAS"
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 24)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(881, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnInformes
        '
        Me.btnInformes.Enabled = False
        Me.btnInformes.Location = New System.Drawing.Point(26, 163)
        Me.btnInformes.Name = "btnInformes"
        Me.btnInformes.Size = New System.Drawing.Size(260, 53)
        Me.btnInformes.TabIndex = 2
        Me.btnInformes.Text = "INFORMES"
        Me.btnInformes.UseVisualStyleBackColor = True
        '
        'btnPacientes
        '
        Me.btnPacientes.Location = New System.Drawing.Point(20, 104)
        Me.btnPacientes.Name = "btnPacientes"
        Me.btnPacientes.Size = New System.Drawing.Size(260, 53)
        Me.btnPacientes.TabIndex = 11
        Me.btnPacientes.Text = "ADMINISTRAR PACIENTES"
        Me.btnPacientes.UseVisualStyleBackColor = True
        '
        'btnModulo
        '
        Me.btnModulo.Location = New System.Drawing.Point(20, 163)
        Me.btnModulo.Name = "btnModulo"
        Me.btnModulo.Size = New System.Drawing.Size(260, 53)
        Me.btnModulo.TabIndex = 12
        Me.btnModulo.Text = "ADMINISTRAR MODULOS"
        Me.btnModulo.UseVisualStyleBackColor = True
        '
        'btnNvaLiq
        '
        Me.btnNvaLiq.Location = New System.Drawing.Point(26, 222)
        Me.btnNvaLiq.Name = "btnNvaLiq"
        Me.btnNvaLiq.Size = New System.Drawing.Size(260, 53)
        Me.btnNvaLiq.TabIndex = 4
        Me.btnNvaLiq.Text = "NUEVA LIQUIDACION"
        Me.btnNvaLiq.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCerrar.Location = New System.Drawing.Point(749, 106)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(106, 33)
        Me.btnCerrar.TabIndex = 20
        Me.btnCerrar.Text = "&CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'btnCierreLiq
        '
        Me.btnCierreLiq.Enabled = False
        Me.btnCierreLiq.Location = New System.Drawing.Point(26, 281)
        Me.btnCierreLiq.Name = "btnCierreLiq"
        Me.btnCierreLiq.Size = New System.Drawing.Size(260, 53)
        Me.btnCierreLiq.TabIndex = 5
        Me.btnCierreLiq.Text = "CERRAR LIQUIDACION"
        Me.btnCierreLiq.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnReporte)
        Me.Panel1.Controls.Add(Me.btnVisita)
        Me.Panel1.Controls.Add(Me.btnNvaLiq)
        Me.Panel1.Controls.Add(Me.btnCierreLiq)
        Me.Panel1.Controls.Add(Me.btnInformes)
        Me.Panel1.Location = New System.Drawing.Point(12, 70)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(330, 359)
        Me.Panel1.TabIndex = 103
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(85, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 24)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "PRACTICAS"
        '
        'btnSubMod
        '
        Me.btnSubMod.Location = New System.Drawing.Point(20, 222)
        Me.btnSubMod.Name = "btnSubMod"
        Me.btnSubMod.Size = New System.Drawing.Size(260, 53)
        Me.btnSubMod.TabIndex = 13
        Me.btnSubMod.Text = "ADMINISTRAR SUB-MODULOS"
        Me.btnSubMod.UseVisualStyleBackColor = True
        '
        'btnPrestadores
        '
        Me.btnPrestadores.Location = New System.Drawing.Point(402, 116)
        Me.btnPrestadores.Name = "btnPrestadores"
        Me.btnPrestadores.Size = New System.Drawing.Size(260, 53)
        Me.btnPrestadores.TabIndex = 10
        Me.btnPrestadores.Text = "ADMINISTRAR PRESTADORES"
        Me.btnPrestadores.UseVisualStyleBackColor = True
        '
        'btnFeriados
        '
        Me.btnFeriados.Location = New System.Drawing.Point(20, 281)
        Me.btnFeriados.Name = "btnFeriados"
        Me.btnFeriados.Size = New System.Drawing.Size(260, 53)
        Me.btnFeriados.TabIndex = 15
        Me.btnFeriados.Text = "ADMINISTRAR FERIADOS"
        Me.btnFeriados.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnFeriados)
        Me.Panel2.Controls.Add(Me.btnSubMod)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.btnModulo)
        Me.Panel2.Controls.Add(Me.btnPacientes)
        Me.Panel2.Location = New System.Drawing.Point(381, 70)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(330, 359)
        Me.Panel2.TabIndex = 104
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(65, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(183, 24)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "MANTENIMIENTO"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguracionToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(881, 24)
        Me.MenuStrip2.TabIndex = 105
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ConfiguracionToolStripMenuItem
        '
        Me.ConfiguracionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BaseDeDatosToolStripMenuItem, Me.MailToolStripMenuItem})
        Me.ConfiguracionToolStripMenuItem.Name = "ConfiguracionToolStripMenuItem"
        Me.ConfiguracionToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.ConfiguracionToolStripMenuItem.Text = "&Configuracion"
        '
        'BaseDeDatosToolStripMenuItem
        '
        Me.BaseDeDatosToolStripMenuItem.Name = "BaseDeDatosToolStripMenuItem"
        Me.BaseDeDatosToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.BaseDeDatosToolStripMenuItem.Text = "&Base de Datos"
        '
        'MailToolStripMenuItem
        '
        Me.MailToolStripMenuItem.Name = "MailToolStripMenuItem"
        Me.MailToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.MailToolStripMenuItem.Text = "&Mail"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(881, 471)
        Me.Controls.Add(Me.btnPrestadores)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmPrincipal"
        Me.Text = "Menu Principal"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnVisita As Button
    Friend WithEvents btnReporte As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnInformes As Button
    Friend WithEvents btnPacientes As Button
    Friend WithEvents btnModulo As Button
    Friend WithEvents btnNvaLiq As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnCierreLiq As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSubMod As Button
    Friend WithEvents btnPrestadores As Button
    Friend WithEvents btnFeriados As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents ConfiguracionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BaseDeDatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MailToolStripMenuItem As ToolStripMenuItem
End Class
