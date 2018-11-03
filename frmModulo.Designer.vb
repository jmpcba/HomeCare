<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModulo
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
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.numMedico = New System.Windows.Forms.TextBox()
        Me.numEnfermeria = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numKinesio = New System.Windows.Forms.TextBox()
        Me.numFono = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numCuidador = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCerrar.Location = New System.Drawing.Point(687, 258)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(106, 33)
        Me.btnCerrar.TabIndex = 22
        Me.btnCerrar.Text = "&CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Location = New System.Drawing.Point(687, 182)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(106, 33)
        Me.btnGuardar.TabIndex = 21
        Me.btnGuardar.Text = "&GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Location = New System.Drawing.Point(687, 104)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(106, 33)
        Me.btnBuscar.TabIndex = 20
        Me.btnBuscar.Text = "&BUSCAR"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'numMedico
        '
        Me.numMedico.Location = New System.Drawing.Point(239, 255)
        Me.numMedico.Name = "numMedico"
        Me.numMedico.Size = New System.Drawing.Size(121, 20)
        Me.numMedico.TabIndex = 2
        '
        'numEnfermeria
        '
        Me.numEnfermeria.Location = New System.Drawing.Point(239, 294)
        Me.numEnfermeria.Name = "numEnfermeria"
        Me.numEnfermeria.Size = New System.Drawing.Size(121, 20)
        Me.numEnfermeria.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(118, 258)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "MEDICO"
        '
        'numKinesio
        '
        Me.numKinesio.Location = New System.Drawing.Point(239, 331)
        Me.numKinesio.Name = "numKinesio"
        Me.numKinesio.Size = New System.Drawing.Size(121, 20)
        Me.numKinesio.TabIndex = 4
        '
        'numFono
        '
        Me.numFono.Location = New System.Drawing.Point(239, 365)
        Me.numFono.Name = "numFono"
        Me.numFono.Size = New System.Drawing.Size(121, 20)
        Me.numFono.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(117, 297)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "ENFERMERIA"
        '
        'numCuidador
        '
        Me.numCuidador.Location = New System.Drawing.Point(239, 401)
        Me.numCuidador.Name = "numCuidador"
        Me.numCuidador.Size = New System.Drawing.Size(121, 20)
        Me.numCuidador.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(118, 334)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "KINESIOLOGIA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(117, 368)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "FONOAUDIOLOGIA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(117, 404)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "CUIDADOR"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(23, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 24)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "MODULOS"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(140, 149)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(235, 20)
        Me.txtDescripcion.TabIndex = 1
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(140, 104)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(43, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 120
        Me.Label8.Text = "DESCRIPCION"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "CODIGO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(168, 206)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(180, 18)
        Me.Label9.TabIndex = 122
        Me.Label9.Text = "TOPES   MENSUALES"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Location = New System.Drawing.Point(12, 22)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(518, 474)
        Me.Panel2.TabIndex = 123
        '
        'frmModulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 542)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.numMedico)
        Me.Controls.Add(Me.numEnfermeria)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numKinesio)
        Me.Controls.Add(Me.numFono)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numCuidador)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmModulo"
        Me.Text = "frmPrestadores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents numMedico As TextBox
    Friend WithEvents numEnfermeria As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents numKinesio As TextBox
    Friend WithEvents numFono As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents numCuidador As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel2 As Panel
End Class
