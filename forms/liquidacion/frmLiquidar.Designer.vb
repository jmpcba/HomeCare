<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiquidar
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
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gridLiqui = New System.Windows.Forms.DataGridView()
        Me.HomeCareDataSet = New HomeCare.HomeCareDataSet()
        Me.HomeCareDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.dtMes = New System.Windows.Forms.DateTimePicker()
        Me.btnSelec = New System.Windows.Forms.Button()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResumenDePrestadoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TodasLasPracticasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CierreLiquidacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.pb = New System.Windows.Forms.ToolStripProgressBar()
        CType(Me.gridLiqui, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HomeCareDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HomeCareDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.Red
        Me.lblTitulo.Location = New System.Drawing.Point(12, 35)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(139, 24)
        Me.lblTitulo.TabIndex = 107
        Me.lblTitulo.Text = "LIQUIDACION"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(161, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 109
        Me.Label8.Text = "MES"
        '
        'gridLiqui
        '
        Me.gridLiqui.AllowUserToAddRows = False
        Me.gridLiqui.AllowUserToDeleteRows = False
        Me.gridLiqui.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridLiqui.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridLiqui.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.gridLiqui.Location = New System.Drawing.Point(16, 140)
        Me.gridLiqui.MultiSelect = False
        Me.gridLiqui.Name = "gridLiqui"
        Me.gridLiqui.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridLiqui.Size = New System.Drawing.Size(909, 344)
        Me.gridLiqui.TabIndex = 1
        '
        'HomeCareDataSet
        '
        Me.HomeCareDataSet.DataSetName = "HomeCareDataSet"
        Me.HomeCareDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'HomeCareDataSetBindingSource
        '
        Me.HomeCareDataSetBindingSource.DataSource = Me.HomeCareDataSet
        Me.HomeCareDataSetBindingSource.Position = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Location = New System.Drawing.Point(707, 70)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(106, 33)
        Me.btnGuardar.TabIndex = 40
        Me.btnGuardar.Text = "&ENVIAR"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(819, 70)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(106, 33)
        Me.btnCerrar.TabIndex = 41
        Me.btnCerrar.Text = "&CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'dtMes
        '
        Me.dtMes.CustomFormat = " MMMM - yyyy"
        Me.dtMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtMes.Location = New System.Drawing.Point(197, 83)
        Me.dtMes.Name = "dtMes"
        Me.dtMes.Size = New System.Drawing.Size(200, 20)
        Me.dtMes.TabIndex = 110
        '
        'btnSelec
        '
        Me.btnSelec.Location = New System.Drawing.Point(16, 82)
        Me.btnSelec.Name = "btnSelec"
        Me.btnSelec.Size = New System.Drawing.Size(135, 23)
        Me.btnSelec.TabIndex = 111
        Me.btnSelec.Text = "Seleccionar Todos"
        Me.btnSelec.UseVisualStyleBackColor = True
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(403, 87)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(98, 13)
        Me.lblObservaciones.TabIndex = 112
        Me.lblObservaciones.Text = "OBSERVACIONES"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.Location = New System.Drawing.Point(507, 83)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(194, 20)
        Me.txtObservaciones.TabIndex = 113
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(937, 29)
        Me.MenuStrip1.TabIndex = 114
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResumenDePrestadoresToolStripMenuItem, Me.TodasLasPracticasToolStripMenuItem, Me.CierreLiquidacionToolStripMenuItem})
        Me.ExportarToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(80, 25)
        Me.ExportarToolStripMenuItem.Text = "&Exportar"
        '
        'ResumenDePrestadoresToolStripMenuItem
        '
        Me.ResumenDePrestadoresToolStripMenuItem.Name = "ResumenDePrestadoresToolStripMenuItem"
        Me.ResumenDePrestadoresToolStripMenuItem.Size = New System.Drawing.Size(271, 26)
        Me.ResumenDePrestadoresToolStripMenuItem.Text = "&Resumen De Prestadores"
        '
        'TodasLasPracticasToolStripMenuItem
        '
        Me.TodasLasPracticasToolStripMenuItem.Name = "TodasLasPracticasToolStripMenuItem"
        Me.TodasLasPracticasToolStripMenuItem.Size = New System.Drawing.Size(271, 26)
        Me.TodasLasPracticasToolStripMenuItem.Text = "&Todas Las Practicas Del Mes"
        '
        'CierreLiquidacionToolStripMenuItem
        '
        Me.CierreLiquidacionToolStripMenuItem.Name = "CierreLiquidacionToolStripMenuItem"
        Me.CierreLiquidacionToolStripMenuItem.Size = New System.Drawing.Size(271, 26)
        Me.CierreLiquidacionToolStripMenuItem.Text = "&Todos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(146, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "FILTRO"
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(197, 111)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(200, 20)
        Me.txtFiltro.TabIndex = 116
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pb})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 479)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(937, 22)
        Me.StatusStrip1.TabIndex = 117
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'pb
        '
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(100, 16)
        Me.pb.Visible = False
        '
        'frmLiquidar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(937, 501)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.lblObservaciones)
        Me.Controls.Add(Me.btnSelec)
        Me.Controls.Add(Me.dtMes)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.gridLiqui)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmLiquidar"
        Me.Text = "LIQUIDACION"
        CType(Me.gridLiqui, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HomeCareDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HomeCareDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents gridLiqui As DataGridView
    Friend WithEvents HomeCareDataSet As HomeCareDataSet
    Friend WithEvents HomeCareDataSetBindingSource As BindingSource
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents dtMes As DateTimePicker
    Friend WithEvents btnSelec As Button
    Friend WithEvents lblObservaciones As Label
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ExportarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResumenDePrestadoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TodasLasPracticasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents CierreLiquidacionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents pb As ToolStripProgressBar
End Class
