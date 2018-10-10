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
        Me.VISITASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PACIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MEDICODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRESTACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHACARGADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HomeCareDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VISITASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.PACIENTEDataGridViewTextBoxColumn, Me.MEDICODataGridViewTextBoxColumn, Me.PRESTACIONDataGridViewTextBoxColumn, Me.FECHADataGridViewTextBoxColumn, Me.FECHACARGADataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.VISITASBindingSource
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
        'VISITASBindingSource
        '
        Me.VISITASBindingSource.DataMember = "VISITAS"
        Me.VISITASBindingSource.DataSource = Me.HomeCareDataSet
        '
        'VISITASTableAdapter
        '
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PACIENTEDataGridViewTextBoxColumn
        '
        Me.PACIENTEDataGridViewTextBoxColumn.DataPropertyName = "PACIENTE"
        Me.PACIENTEDataGridViewTextBoxColumn.HeaderText = "PACIENTE"
        Me.PACIENTEDataGridViewTextBoxColumn.Name = "PACIENTEDataGridViewTextBoxColumn"
        Me.PACIENTEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MEDICODataGridViewTextBoxColumn
        '
        Me.MEDICODataGridViewTextBoxColumn.DataPropertyName = "MEDICO"
        Me.MEDICODataGridViewTextBoxColumn.HeaderText = "MEDICO"
        Me.MEDICODataGridViewTextBoxColumn.Name = "MEDICODataGridViewTextBoxColumn"
        Me.MEDICODataGridViewTextBoxColumn.ReadOnly = True
        '
        'PRESTACIONDataGridViewTextBoxColumn
        '
        Me.PRESTACIONDataGridViewTextBoxColumn.DataPropertyName = "PRESTACION"
        Me.PRESTACIONDataGridViewTextBoxColumn.HeaderText = "PRESTACION"
        Me.PRESTACIONDataGridViewTextBoxColumn.Name = "PRESTACIONDataGridViewTextBoxColumn"
        Me.PRESTACIONDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FECHADataGridViewTextBoxColumn
        '
        Me.FECHADataGridViewTextBoxColumn.DataPropertyName = "FECHA"
        Me.FECHADataGridViewTextBoxColumn.HeaderText = "FECHA"
        Me.FECHADataGridViewTextBoxColumn.Name = "FECHADataGridViewTextBoxColumn"
        Me.FECHADataGridViewTextBoxColumn.ReadOnly = True
        '
        'FECHACARGADataGridViewTextBoxColumn
        '
        Me.FECHACARGADataGridViewTextBoxColumn.DataPropertyName = "FECHA_CARGA"
        Me.FECHACARGADataGridViewTextBoxColumn.HeaderText = "FECHA_CARGA"
        Me.FECHACARGADataGridViewTextBoxColumn.Name = "FECHACARGADataGridViewTextBoxColumn"
        Me.FECHACARGADataGridViewTextBoxColumn.ReadOnly = True
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
        CType(Me.VISITASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents dtFiltro As DateTimePicker
    Friend WithEvents btnActualizar As Button
    Friend WithEvents HomeCareDataSet As HomeCareDataSet
    Friend WithEvents VISITASBindingSource As BindingSource
    Friend WithEvents IDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PACIENTEDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MEDICODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PRESTACIONDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FECHADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FECHACARGADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
