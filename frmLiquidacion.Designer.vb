﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.cbPrestadorPrestador = New System.Windows.Forms.ComboBox()
        Me.PRESTADORESBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnLimpiarPrestador = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtPrestador = New System.Windows.Forms.DateTimePicker()
        Me.dgPrestador = New System.Windows.Forms.DataGridView()
        Me.tabPaciente = New System.Windows.Forms.TabPage()
        Me.cbPacientePaciente = New System.Windows.Forms.ComboBox()
        Me.PACIENTESBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbPacientePrestador = New System.Windows.Forms.ComboBox()
        Me.PRESTADORESBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnPacienteLimpiar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtPaciente = New System.Windows.Forms.DateTimePicker()
        Me.dgPaciente = New System.Windows.Forms.DataGridView()
        Me.PACIENTESTableAdapter = New HomeCare.HomeCareDataSetTableAdapters.PACIENTESTableAdapter()
        Me.PRESTADORESTableAdapter = New HomeCare.HomeCareDataSetTableAdapters.PRESTADORESTableAdapter()
        Me.tbReporte.SuspendLayout()
        Me.tabDetalle.SuspendLayout()
        CType(Me.PRESTADORESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HomeCareDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PACIENTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMedico.SuspendLayout()
        CType(Me.PRESTADORESBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPrestador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPaciente.SuspendLayout()
        CType(Me.PACIENTESBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRESTADORESBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPaciente, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(570, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(135, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "&Limpiar Filtros"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(292, 16)
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
        Me.cbPrestadores.Location = New System.Drawing.Point(363, 12)
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
        Me.Label2.Location = New System.Drawing.Point(6, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Afiliado"
        '
        'cbPaciente
        '
        Me.cbPaciente.DataSource = Me.PACIENTESBindingSource
        Me.cbPaciente.DisplayMember = "APELLIDO"
        Me.cbPaciente.FormattingEnabled = True
        Me.cbPaciente.Location = New System.Drawing.Point(77, 45)
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
        Me.Label1.Location = New System.Drawing.Point(7, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Mes"
        '
        'dtFecha
        '
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFecha.Location = New System.Drawing.Point(77, 13)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(200, 23)
        Me.dtFecha.TabIndex = 1
        '
        'dgDetalle
        '
        Me.dgDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetalle.Location = New System.Drawing.Point(0, 104)
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.ReadOnly = True
        Me.dgDetalle.Size = New System.Drawing.Size(1147, 620)
        Me.dgDetalle.TabIndex = 0
        '
        'tabMedico
        '
        Me.tabMedico.BackColor = System.Drawing.Color.Transparent
        Me.tabMedico.Controls.Add(Me.cbPrestadorPrestador)
        Me.tabMedico.Controls.Add(Me.btnLimpiarPrestador)
        Me.tabMedico.Controls.Add(Me.Label4)
        Me.tabMedico.Controls.Add(Me.Label6)
        Me.tabMedico.Controls.Add(Me.dtPrestador)
        Me.tabMedico.Controls.Add(Me.dgPrestador)
        Me.tabMedico.Location = New System.Drawing.Point(4, 22)
        Me.tabMedico.Name = "tabMedico"
        Me.tabMedico.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMedico.Size = New System.Drawing.Size(1147, 727)
        Me.tabMedico.TabIndex = 1
        Me.tabMedico.Text = "TOTAL POR PRESTADOR"
        '
        'cbPrestadorPrestador
        '
        Me.cbPrestadorPrestador.DataSource = Me.PRESTADORESBindingSource1
        Me.cbPrestadorPrestador.DisplayMember = "APELLIDO"
        Me.cbPrestadorPrestador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPrestadorPrestador.FormattingEnabled = True
        Me.cbPrestadorPrestador.Location = New System.Drawing.Point(368, 12)
        Me.cbPrestadorPrestador.Name = "cbPrestadorPrestador"
        Me.cbPrestadorPrestador.Size = New System.Drawing.Size(200, 24)
        Me.cbPrestadorPrestador.TabIndex = 15
        Me.cbPrestadorPrestador.ValueMember = "CUIT"
        '
        'PRESTADORESBindingSource1
        '
        Me.PRESTADORESBindingSource1.DataMember = "PRESTADORES"
        Me.PRESTADORESBindingSource1.DataSource = Me.HomeCareDataSet
        '
        'btnLimpiarPrestador
        '
        Me.btnLimpiarPrestador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarPrestador.Location = New System.Drawing.Point(584, 13)
        Me.btnLimpiarPrestador.Name = "btnLimpiarPrestador"
        Me.btnLimpiarPrestador.Size = New System.Drawing.Size(135, 23)
        Me.btnLimpiarPrestador.TabIndex = 14
        Me.btnLimpiarPrestador.Text = "&Limpiar Filtros"
        Me.btnLimpiarPrestador.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(291, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Prestador"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 16)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Mes"
        '
        'dtPrestador
        '
        Me.dtPrestador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtPrestador.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPrestador.Location = New System.Drawing.Point(76, 13)
        Me.dtPrestador.Name = "dtPrestador"
        Me.dtPrestador.Size = New System.Drawing.Size(200, 22)
        Me.dtPrestador.TabIndex = 8
        '
        'dgPrestador
        '
        Me.dgPrestador.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPrestador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgPrestador.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgPrestador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPrestador.Location = New System.Drawing.Point(0, 107)
        Me.dgPrestador.Name = "dgPrestador"
        Me.dgPrestador.ReadOnly = True
        Me.dgPrestador.Size = New System.Drawing.Size(1147, 620)
        Me.dgPrestador.TabIndex = 1
        '
        'tabPaciente
        '
        Me.tabPaciente.BackColor = System.Drawing.Color.Transparent
        Me.tabPaciente.Controls.Add(Me.cbPacientePaciente)
        Me.tabPaciente.Controls.Add(Me.cbPacientePrestador)
        Me.tabPaciente.Controls.Add(Me.btnPacienteLimpiar)
        Me.tabPaciente.Controls.Add(Me.Label5)
        Me.tabPaciente.Controls.Add(Me.Label7)
        Me.tabPaciente.Controls.Add(Me.Label8)
        Me.tabPaciente.Controls.Add(Me.dtPaciente)
        Me.tabPaciente.Controls.Add(Me.dgPaciente)
        Me.tabPaciente.Location = New System.Drawing.Point(4, 22)
        Me.tabPaciente.Name = "tabPaciente"
        Me.tabPaciente.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPaciente.Size = New System.Drawing.Size(1147, 727)
        Me.tabPaciente.TabIndex = 2
        Me.tabPaciente.Text = "TOTAL POR AFILIADO"
        '
        'cbPacientePaciente
        '
        Me.cbPacientePaciente.DataSource = Me.PACIENTESBindingSource1
        Me.cbPacientePaciente.DisplayMember = "APELLIDO"
        Me.cbPacientePaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPacientePaciente.FormattingEnabled = True
        Me.cbPacientePaciente.Location = New System.Drawing.Point(76, 43)
        Me.cbPacientePaciente.Name = "cbPacientePaciente"
        Me.cbPacientePaciente.Size = New System.Drawing.Size(200, 24)
        Me.cbPacientePaciente.TabIndex = 16
        Me.cbPacientePaciente.ValueMember = "AFILIADO"
        '
        'PACIENTESBindingSource1
        '
        Me.PACIENTESBindingSource1.DataMember = "PACIENTES"
        Me.PACIENTESBindingSource1.DataSource = Me.HomeCareDataSet
        '
        'cbPacientePrestador
        '
        Me.cbPacientePrestador.DataSource = Me.PRESTADORESBindingSource2
        Me.cbPacientePrestador.DisplayMember = "APELLIDO"
        Me.cbPacientePrestador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPacientePrestador.FormattingEnabled = True
        Me.cbPacientePrestador.Location = New System.Drawing.Point(366, 12)
        Me.cbPacientePrestador.Name = "cbPacientePrestador"
        Me.cbPacientePrestador.Size = New System.Drawing.Size(200, 24)
        Me.cbPacientePrestador.TabIndex = 15
        Me.cbPacientePrestador.ValueMember = "CUIT"
        '
        'PRESTADORESBindingSource2
        '
        Me.PRESTADORESBindingSource2.DataMember = "PRESTADORES"
        Me.PRESTADORESBindingSource2.DataSource = Me.HomeCareDataSet
        '
        'btnPacienteLimpiar
        '
        Me.btnPacienteLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPacienteLimpiar.Location = New System.Drawing.Point(591, 13)
        Me.btnPacienteLimpiar.Name = "btnPacienteLimpiar"
        Me.btnPacienteLimpiar.Size = New System.Drawing.Size(135, 23)
        Me.btnPacienteLimpiar.TabIndex = 14
        Me.btnPacienteLimpiar.Text = "&Limpiar Filtros"
        Me.btnPacienteLimpiar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(291, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Prestador"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Afiliado"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Mes"
        '
        'dtPaciente
        '
        Me.dtPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtPaciente.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPaciente.Location = New System.Drawing.Point(76, 13)
        Me.dtPaciente.Name = "dtPaciente"
        Me.dtPaciente.Size = New System.Drawing.Size(200, 22)
        Me.dtPaciente.TabIndex = 8
        '
        'dgPaciente
        '
        Me.dgPaciente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPaciente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgPaciente.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgPaciente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPaciente.Location = New System.Drawing.Point(0, 106)
        Me.dgPaciente.Name = "dgPaciente"
        Me.dgPaciente.ReadOnly = True
        Me.dgPaciente.Size = New System.Drawing.Size(1147, 620)
        Me.dgPaciente.TabIndex = 1
        '
        'PACIENTESTableAdapter
        '
        Me.PACIENTESTableAdapter.ClearBeforeFill = True
        '
        'PRESTADORESTableAdapter
        '
        Me.PRESTADORESTableAdapter.ClearBeforeFill = True
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
        Me.tabMedico.ResumeLayout(False)
        Me.tabMedico.PerformLayout()
        CType(Me.PRESTADORESBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPrestador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPaciente.ResumeLayout(False)
        Me.tabPaciente.PerformLayout()
        CType(Me.PACIENTESBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRESTADORESBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPaciente, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnLimpiarPrestador As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dtPrestador As DateTimePicker
    Friend WithEvents dgPrestador As DataGridView
    Friend WithEvents btnPacienteLimpiar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dtPaciente As DateTimePicker
    Friend WithEvents dgPaciente As DataGridView
    Friend WithEvents cbPrestadorPrestador As ComboBox
    Friend WithEvents PRESTADORESBindingSource1 As BindingSource
    Friend WithEvents cbPacientePrestador As ComboBox
    Friend WithEvents cbPacientePaciente As ComboBox
    Friend WithEvents PACIENTESBindingSource1 As BindingSource
    Friend WithEvents PRESTADORESBindingSource2 As BindingSource
End Class
