<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporte
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.dtFiltro = New System.Windows.Forms.DateTimePicker()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.HomeCareDataSet = New HomeCare.HomeCareDataSet()
        Me.PRACTICASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PRACTICASTableAdapter = New HomeCare.HomeCareDataSetTableAdapters.PRACTICASTableAdapter()
        Me.CUITDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AFILIADODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUBMODULODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MODULODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRESTACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HSNORMALESDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HSFERIADODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAPRACTICADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAINICIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OBSERVACIONESDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CARGOUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHACARGADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MODIFICOUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAMODIFICACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HomeCareDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRACTICASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CUITDataGridViewTextBoxColumn, Me.AFILIADODataGridViewTextBoxColumn, Me.SUBMODULODataGridViewTextBoxColumn, Me.MODULODataGridViewTextBoxColumn, Me.CODPRESTACIONDataGridViewTextBoxColumn, Me.HSNORMALESDataGridViewTextBoxColumn, Me.HSFERIADODataGridViewTextBoxColumn, Me.FECHAPRACTICADataGridViewTextBoxColumn, Me.FECHAINICIODataGridViewTextBoxColumn, Me.OBSERVACIONESDataGridViewTextBoxColumn, Me.CARGOUSUARIODataGridViewTextBoxColumn, Me.FECHACARGADataGridViewTextBoxColumn, Me.MODIFICOUSUARIODataGridViewTextBoxColumn, Me.FECHAMODIFICACIONDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.PRACTICASBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(12, 67)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(643, 391)
        Me.DataGridView1.TabIndex = 0
        '
        'dtFiltro
        '
        Me.dtFiltro.Location = New System.Drawing.Point(374, 38)
        Me.dtFiltro.Name = "dtFiltro"
        Me.dtFiltro.Size = New System.Drawing.Size(200, 20)
        Me.dtFiltro.TabIndex = 1
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(580, 38)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnActualizar.TabIndex = 2
        Me.btnActualizar.Text = "Filtrar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'HomeCareDataSet
        '
        Me.HomeCareDataSet.DataSetName = "HomeCareDataSet"
        Me.HomeCareDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PRACTICASBindingSource
        '
        Me.PRACTICASBindingSource.DataMember = "PRACTICAS"
        Me.PRACTICASBindingSource.DataSource = Me.HomeCareDataSet
        '
        'PRACTICASTableAdapter
        '
        Me.PRACTICASTableAdapter.ClearBeforeFill = True
        '
        'CUITDataGridViewTextBoxColumn
        '
        Me.CUITDataGridViewTextBoxColumn.DataPropertyName = "CUIT"
        Me.CUITDataGridViewTextBoxColumn.HeaderText = "CUIT"
        Me.CUITDataGridViewTextBoxColumn.Name = "CUITDataGridViewTextBoxColumn"
        '
        'AFILIADODataGridViewTextBoxColumn
        '
        Me.AFILIADODataGridViewTextBoxColumn.DataPropertyName = "AFILIADO"
        Me.AFILIADODataGridViewTextBoxColumn.HeaderText = "AFILIADO"
        Me.AFILIADODataGridViewTextBoxColumn.Name = "AFILIADODataGridViewTextBoxColumn"
        '
        'SUBMODULODataGridViewTextBoxColumn
        '
        Me.SUBMODULODataGridViewTextBoxColumn.DataPropertyName = "SUB_MODULO"
        Me.SUBMODULODataGridViewTextBoxColumn.HeaderText = "SUB_MODULO"
        Me.SUBMODULODataGridViewTextBoxColumn.Name = "SUBMODULODataGridViewTextBoxColumn"
        '
        'MODULODataGridViewTextBoxColumn
        '
        Me.MODULODataGridViewTextBoxColumn.DataPropertyName = "MODULO"
        Me.MODULODataGridViewTextBoxColumn.HeaderText = "MODULO"
        Me.MODULODataGridViewTextBoxColumn.Name = "MODULODataGridViewTextBoxColumn"
        '
        'CODPRESTACIONDataGridViewTextBoxColumn
        '
        Me.CODPRESTACIONDataGridViewTextBoxColumn.DataPropertyName = "COD_PRESTACION"
        Me.CODPRESTACIONDataGridViewTextBoxColumn.HeaderText = "COD_PRESTACION"
        Me.CODPRESTACIONDataGridViewTextBoxColumn.Name = "CODPRESTACIONDataGridViewTextBoxColumn"
        '
        'HSNORMALESDataGridViewTextBoxColumn
        '
        Me.HSNORMALESDataGridViewTextBoxColumn.DataPropertyName = "HS_NORMALES"
        Me.HSNORMALESDataGridViewTextBoxColumn.HeaderText = "HS_NORMALES"
        Me.HSNORMALESDataGridViewTextBoxColumn.Name = "HSNORMALESDataGridViewTextBoxColumn"
        '
        'HSFERIADODataGridViewTextBoxColumn
        '
        Me.HSFERIADODataGridViewTextBoxColumn.DataPropertyName = "HS_FERIADO"
        Me.HSFERIADODataGridViewTextBoxColumn.HeaderText = "HS_FERIADO"
        Me.HSFERIADODataGridViewTextBoxColumn.Name = "HSFERIADODataGridViewTextBoxColumn"
        '
        'FECHAPRACTICADataGridViewTextBoxColumn
        '
        Me.FECHAPRACTICADataGridViewTextBoxColumn.DataPropertyName = "FECHA_PRACTICA"
        Me.FECHAPRACTICADataGridViewTextBoxColumn.HeaderText = "FECHA_PRACTICA"
        Me.FECHAPRACTICADataGridViewTextBoxColumn.Name = "FECHAPRACTICADataGridViewTextBoxColumn"
        '
        'FECHAINICIODataGridViewTextBoxColumn
        '
        Me.FECHAINICIODataGridViewTextBoxColumn.DataPropertyName = "FECHA_INICIO"
        Me.FECHAINICIODataGridViewTextBoxColumn.HeaderText = "FECHA_INICIO"
        Me.FECHAINICIODataGridViewTextBoxColumn.Name = "FECHAINICIODataGridViewTextBoxColumn"
        '
        'OBSERVACIONESDataGridViewTextBoxColumn
        '
        Me.OBSERVACIONESDataGridViewTextBoxColumn.DataPropertyName = "OBSERVACIONES"
        Me.OBSERVACIONESDataGridViewTextBoxColumn.HeaderText = "OBSERVACIONES"
        Me.OBSERVACIONESDataGridViewTextBoxColumn.Name = "OBSERVACIONESDataGridViewTextBoxColumn"
        '
        'CARGOUSUARIODataGridViewTextBoxColumn
        '
        Me.CARGOUSUARIODataGridViewTextBoxColumn.DataPropertyName = "CARGO_USUARIO"
        Me.CARGOUSUARIODataGridViewTextBoxColumn.HeaderText = "CARGO_USUARIO"
        Me.CARGOUSUARIODataGridViewTextBoxColumn.Name = "CARGOUSUARIODataGridViewTextBoxColumn"
        '
        'FECHACARGADataGridViewTextBoxColumn
        '
        Me.FECHACARGADataGridViewTextBoxColumn.DataPropertyName = "FECHA_CARGA"
        Me.FECHACARGADataGridViewTextBoxColumn.HeaderText = "FECHA_CARGA"
        Me.FECHACARGADataGridViewTextBoxColumn.Name = "FECHACARGADataGridViewTextBoxColumn"
        '
        'MODIFICOUSUARIODataGridViewTextBoxColumn
        '
        Me.MODIFICOUSUARIODataGridViewTextBoxColumn.DataPropertyName = "MODIFICO_USUARIO"
        Me.MODIFICOUSUARIODataGridViewTextBoxColumn.HeaderText = "MODIFICO_USUARIO"
        Me.MODIFICOUSUARIODataGridViewTextBoxColumn.Name = "MODIFICOUSUARIODataGridViewTextBoxColumn"
        '
        'FECHAMODIFICACIONDataGridViewTextBoxColumn
        '
        Me.FECHAMODIFICACIONDataGridViewTextBoxColumn.DataPropertyName = "FECHA_MODIFICACION"
        Me.FECHAMODIFICACIONDataGridViewTextBoxColumn.HeaderText = "FECHA_MODIFICACION"
        Me.FECHAMODIFICACIONDataGridViewTextBoxColumn.Name = "FECHAMODIFICACIONDataGridViewTextBoxColumn"
        '
        'frmReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 470)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.dtFiltro)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmReporte"
        Me.Text = "frmReporte"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HomeCareDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRACTICASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents dtFiltro As DateTimePicker
    Friend WithEvents btnActualizar As Button
    Friend WithEvents HomeCareDataSet As HomeCareDataSet
    Friend WithEvents PRACTICASBindingSource As BindingSource
    Friend WithEvents PRACTICASTableAdapter As HomeCareDataSetTableAdapters.PRACTICASTableAdapter
    Friend WithEvents CUITDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AFILIADODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SUBMODULODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MODULODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODPRESTACIONDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HSNORMALESDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HSFERIADODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FECHAPRACTICADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FECHAINICIODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents OBSERVACIONESDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CARGOUSUARIODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FECHACARGADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MODIFICOUSUARIODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FECHAMODIFICACIONDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
