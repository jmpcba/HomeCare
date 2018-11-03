<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFeriados
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtFeriado = New System.Windows.Forms.DateTimePicker()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgFechas = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.dgFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(75, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "MES"
        '
        'dtFeriado
        '
        Me.dtFeriado.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFeriado.Location = New System.Drawing.Point(78, 157)
        Me.dtFeriado.Name = "dtFeriado"
        Me.dtFeriado.ShowUpDown = True
        Me.dtFeriado.Size = New System.Drawing.Size(165, 20)
        Me.dtFeriado.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCerrar.Location = New System.Drawing.Point(743, 348)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(106, 33)
        Me.btnCerrar.TabIndex = 42
        Me.btnCerrar.Text = "&CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Location = New System.Drawing.Point(743, 286)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(106, 33)
        Me.btnGuardar.TabIndex = 41
        Me.btnGuardar.Text = "&GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Location = New System.Drawing.Point(743, 227)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(106, 33)
        Me.btnBuscar.TabIndex = 40
        Me.btnBuscar.Text = "&BUSCAR"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(31, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 24)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "CARGA  DE  FERIADOS"
        '
        'dgFechas
        '
        Me.dgFechas.AllowUserToAddRows = False
        Me.dgFechas.AllowUserToDeleteRows = False
        Me.dgFechas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgFechas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgFechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFechas.Location = New System.Drawing.Point(331, 37)
        Me.dgFechas.Name = "dgFechas"
        Me.dgFechas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgFechas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgFechas.Size = New System.Drawing.Size(355, 488)
        Me.dgFechas.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(23, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(697, 519)
        Me.Panel1.TabIndex = 44
        '
        'FrmFeriados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 537)
        Me.Controls.Add(Me.dgFechas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtFeriado)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmFeriados"
        Me.Text = "FrmFeriados"
        CType(Me.dgFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents dtFeriado As DateTimePicker
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dgFechas As DataGridView
    Friend WithEvents Panel1 As Panel
End Class
