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
        Me.components = New System.ComponentModel.Container()
        Me.tbReporte = New System.Windows.Forms.TabControl()
        Me.tabDetalle = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbPrestadores = New System.Windows.Forms.ComboBox()
        Me.PRESTADORESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HomeCareDataSet = New HomeCare.HomeCareDataSet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbPaciente = New System.Windows.Forms.ComboBox()
        Me.PACIENTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.dgDetalle = New System.Windows.Forms.DataGridView()
        Me.tabMedico = New System.Windows.Forms.TabPage()
        Me.tabPaciente = New System.Windows.Forms.TabPage()
        Me.PACIENTESTableAdapter = New HomeCare.HomeCareDataSetTableAdapters.PACIENTESTableAdapter()
        Me.PRESTADORESTableAdapter = New HomeCare.HomeCareDataSetTableAdapters.PRESTADORESTableAdapter()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbReporte.SuspendLayout()
        Me.tabDetalle.SuspendLayout()
        CType(Me.PRESTADORESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HomeCareDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PACIENTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbReporte
        '
        Me.tbReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.tabDetalle.BackColor = System.Drawing.Color.Transparent
        Me.tabDetalle.Controls.Add(Me.Button1)
        Me.tabDetalle.Controls.Add(Me.Label3)
        Me.tabDetalle.Controls.Add(Me.cbPrestadores)
        Me.tabDetalle.Controls.Add(Me.Label2)
        Me.tabDetalle.Controls.Add(Me.cbPaciente)
        Me.tabDetalle.Controls.Add(Me.Label1)
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(292, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Prestador"
        '
        'cbPrestadores
        '
        Me.cbPrestadores.DataSource = Me.PRESTADORESBindingSource
        Me.cbPrestadores.DisplayMember = "APELLIDO"
        Me.cbPrestadores.FormattingEnabled = True
        Me.cbPrestadores.Location = New System.Drawing.Point(363, 4)
        Me.cbPrestadores.Name = "cbPrestadores"
        Me.cbPrestadores.Size = New System.Drawing.Size(200, 24)
        Me.cbPrestadores.TabIndex = 5
        Me.cbPrestadores.ValueMember = "CUIT"
        '
        'PRESTADORESBindingSource
        '
        Me.PRESTADORESBindingSource.DataMember = "PRESTADORES"
        Me.PRESTADORESBindingSource.DataSource = Me.HomeCareDataSet
        '
        'HomeCareDataSet
        '
        Me.HomeCareDataSet.DataSetName = "HomeCareDataSet"
        Me.HomeCareDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Paciente"
        '
        'cbPaciente
        '
        Me.cbPaciente.DataSource = Me.PACIENTESBindingSource
        Me.cbPaciente.DisplayMember = "APELLIDO"
        Me.cbPaciente.FormattingEnabled = True
        Me.cbPaciente.Location = New System.Drawing.Point(77, 37)
        Me.cbPaciente.Name = "cbPaciente"
        Me.cbPaciente.Size = New System.Drawing.Size(200, 24)
        Me.cbPaciente.TabIndex = 3
        Me.cbPaciente.ValueMember = "AFILIADO"
        '
        'PACIENTESBindingSource
        '
        Me.PACIENTESBindingSource.DataMember = "PACIENTES"
        Me.PACIENTESBindingSource.DataSource = Me.HomeCareDataSet
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Mes"
        '
        'dtFecha
        '
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFecha.Location = New System.Drawing.Point(77, 7)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(200, 23)
        Me.dtFecha.TabIndex = 1
        '
        'dgDetalle
        '
        Me.dgDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetalle.Location = New System.Drawing.Point(0, 104)
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.ReadOnly = True
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
        'PACIENTESTableAdapter
        '
        Me.PACIENTESTableAdapter.ClearBeforeFill = True
        '
        'PRESTADORESTableAdapter
        '
        Me.PRESTADORESTableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(570, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(135, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "&Limpiar Filtros"
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.tabDetalle.PerformLayout()
        CType(Me.PRESTADORESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HomeCareDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PACIENTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tbReporte As TabControl
    Friend WithEvents tabDetalle As TabPage
    Friend WithEvents tabMedico As TabPage
    Friend WithEvents tabPaciente As TabPage
    Friend WithEvents dgDetalle As DataGridView
    Friend WithEvents dtFecha As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents cbPaciente As ComboBox
    Friend WithEvents HomeCareDataSet As HomeCareDataSet
    Friend WithEvents PACIENTESBindingSource As BindingSource
    Friend WithEvents PACIENTESTableAdapter As HomeCareDataSetTableAdapters.PACIENTESTableAdapter
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbPrestadores As ComboBox
    Friend WithEvents PRESTADORESBindingSource As BindingSource
    Friend WithEvents PRESTADORESTableAdapter As HomeCareDataSetTableAdapters.PRESTADORESTableAdapter
    Friend WithEvents Button1 As Button
End Class
