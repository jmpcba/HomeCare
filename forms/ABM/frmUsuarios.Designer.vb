<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUsuarios
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
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbNivel = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtApellido = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassw = New System.Windows.Forms.TextBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(259, 105)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(121, 20)
        Me.txtUsuario.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(106, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(14, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 24)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "USUARIOS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(106, 311)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "PASSWORD"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtNombre)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.cbNivel)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtApellido)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtMail)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtPassw)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtUsuario)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(733, 446)
        Me.Panel1.TabIndex = 0
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(259, 259)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(219, 20)
        Me.txtNombre.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(106, 266)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "NOMBRE"
        '
        'cbNivel
        '
        Me.cbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNivel.FormattingEnabled = True
        Me.cbNivel.Items.AddRange(New Object() {"0", "1", "2"})
        Me.cbNivel.Location = New System.Drawing.Point(259, 384)
        Me.cbNivel.Name = "cbNivel"
        Me.cbNivel.Size = New System.Drawing.Size(121, 21)
        Me.cbNivel.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(106, 388)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "NIVEL"
        '
        'txtApellido
        '
        Me.txtApellido.Location = New System.Drawing.Point(259, 207)
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.Size = New System.Drawing.Size(219, 20)
        Me.txtApellido.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(106, 214)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "APELLIDO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(106, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "MAIL"
        '
        'txtMail
        '
        Me.txtMail.Location = New System.Drawing.Point(259, 158)
        Me.txtMail.Name = "txtMail"
        Me.txtMail.Size = New System.Drawing.Size(197, 20)
        Me.txtMail.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(224, 340)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(197, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "distingue entre mayusculas y minusculas"
        '
        'txtPassw
        '
        Me.txtPassw.Location = New System.Drawing.Point(259, 308)
        Me.txtPassw.Name = "txtPassw"
        Me.txtPassw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassw.Size = New System.Drawing.Size(121, 20)
        Me.txtPassw.TabIndex = 4
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Location = New System.Drawing.Point(824, 148)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(106, 33)
        Me.btnLimpiar.TabIndex = 7
        Me.btnLimpiar.Text = "&LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(824, 269)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(106, 33)
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "&CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Location = New System.Drawing.Point(824, 207)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(106, 33)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "&GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Location = New System.Drawing.Point(824, 88)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(106, 33)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.Text = "&BUSCAR"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'frmUsuarios
        '
        Me.AcceptButton = Me.btnGuardar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(993, 507)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Name = "frmUsuarios"
        Me.Text = "Administracion Usuarios"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtPassw As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtApellido As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtMail As TextBox
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents cbNivel As ComboBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label8 As Label
End Class
