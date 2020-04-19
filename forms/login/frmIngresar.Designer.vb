<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresar
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
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtVerificacion = New System.Windows.Forms.TextBox()
        Me.lblVerificacion = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassw = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numDni = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblExplicacionVerCode = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(644, 166)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(106, 33)
        Me.btnGuardar.TabIndex = 104
        Me.btnGuardar.Text = "&INGRESAR"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCerrar.Location = New System.Drawing.Point(644, 244)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(106, 33)
        Me.BtnCerrar.TabIndex = 105
        Me.BtnCerrar.Text = "&SALIR"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblExplicacionVerCode)
        Me.Panel1.Controls.Add(Me.txtVerificacion)
        Me.Panel1.Controls.Add(Me.lblVerificacion)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtPassw)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.numDni)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(51, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(550, 371)
        Me.Panel1.TabIndex = 103
        '
        'txtVerificacion
        '
        Me.txtVerificacion.Location = New System.Drawing.Point(249, 276)
        Me.txtVerificacion.Name = "txtVerificacion"
        Me.txtVerificacion.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtVerificacion.Size = New System.Drawing.Size(121, 20)
        Me.txtVerificacion.TabIndex = 46
        Me.txtVerificacion.Visible = False
        '
        'lblVerificacion
        '
        Me.lblVerificacion.AutoSize = True
        Me.lblVerificacion.Location = New System.Drawing.Point(85, 279)
        Me.lblVerificacion.Name = "lblVerificacion"
        Me.lblVerificacion.Size = New System.Drawing.Size(144, 13)
        Me.lblVerificacion.TabIndex = 45
        Me.lblVerificacion.Text = "CODIGO DE VERIFICACION"
        Me.lblVerificacion.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(225, 233)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(199, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Distingue entre mayusculas y minusculas"
        '
        'txtPassw
        '
        Me.txtPassw.Location = New System.Drawing.Point(249, 200)
        Me.txtPassw.Name = "txtPassw"
        Me.txtPassw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassw.Size = New System.Drawing.Size(121, 20)
        Me.txtPassw.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(84, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(365, 24)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "INGRESO  APLICACION  HOMECARE"
        '
        'numDni
        '
        Me.numDni.Location = New System.Drawing.Point(249, 125)
        Me.numDni.Name = "numDni"
        Me.numDni.Size = New System.Drawing.Size(121, 20)
        Me.numDni.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(144, 203)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "PASSWORD"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(179, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "D.N.I."
        '
        'lblExplicacionVerCode
        '
        Me.lblExplicacionVerCode.AutoSize = True
        Me.lblExplicacionVerCode.Location = New System.Drawing.Point(225, 315)
        Me.lblExplicacionVerCode.Name = "lblExplicacionVerCode"
        Me.lblExplicacionVerCode.Size = New System.Drawing.Size(184, 13)
        Me.lblExplicacionVerCode.TabIndex = 47
        Me.lblExplicacionVerCode.Text = "Codigo de verificacion enviado por ail"
        Me.lblExplicacionVerCode.Visible = False
        '
        'frmIngresar
        '
        Me.AcceptButton = Me.btnGuardar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCerrar
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.BtnCerrar)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmIngresar"
        Me.Text = "Ingreso Aplicacion"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnGuardar As Button
    Friend WithEvents BtnCerrar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPassw As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents numDni As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtVerificacion As TextBox
    Friend WithEvents lblVerificacion As Label
    Friend WithEvents lblExplicacionVerCode As Label
End Class
