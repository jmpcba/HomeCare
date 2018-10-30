<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPracticas
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
        Me.components = New System.ComponentModel.Container()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsLbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbMedico = New System.Windows.Forms.ComboBox()
        Me.PRESTADORESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HomeCareDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HomeCareDataSet = New HomeCare.HomeCareDataSet()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMat = New System.Windows.Forms.TextBox()
        Me.txtPrestador = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DTFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CBPrestacion = New System.Windows.Forms.ComboBox()
        Me.PRESTACIONESBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PRESTACIONESBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PRESTACIONESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtBeneficio = New System.Windows.Forms.TextBox()
        Me.txtAfiliado = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbPaciente = New System.Windows.Forms.ComboBox()
        Me.PACIENTESBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PACIENTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PRESTACIONESTableAdapter = New HomeCare.HomeCareDataSetTableAdapters.PRESTACIONESTableAdapter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.cbSubModulo = New System.Windows.Forms.ComboBox()
        Me.SUBMODULOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbModulo = New System.Windows.Forms.ComboBox()
        Me.MODULOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PACIENTESTableAdapter = New HomeCare.HomeCareDataSetTableAdapters.PACIENTESTableAdapter()
        Me.PRESTADORESTableAdapter = New HomeCare.HomeCareDataSetTableAdapters.PRESTADORESTableAdapter()
        Me.MODULOTableAdapter = New HomeCare.HomeCareDataSetTableAdapters.MODULOTableAdapter()
        Me.SUBMODULOTableAdapter = New HomeCare.HomeCareDataSetTableAdapters.SUBMODULOTableAdapter()
        Me.dgFechas = New System.Windows.Forms.DataGridView()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.btnLimpiarGrilla = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblHoras = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PRESTADORESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HomeCareDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HomeCareDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRESTACIONESBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRESTACIONESBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRESTACIONESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PACIENTESBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PACIENTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.SUBMODULOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MODULOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(889, 592)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(106, 33)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLbl})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 638)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1051, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsLbl
        '
        Me.tsLbl.Name = "tsLbl"
        Me.tsLbl.Size = New System.Drawing.Size(120, 17)
        Me.tsLbl.Text = "ToolStripStatusLabel1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(13, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "PACIENTE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 24)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "PROFESIONAL"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Nombre y apellido"
        '
        'cbMedico
        '
        Me.cbMedico.DataSource = Me.PRESTADORESBindingSource
        Me.cbMedico.DisplayMember = "APELLIDO"
        Me.cbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMedico.FormattingEnabled = True
        Me.cbMedico.Location = New System.Drawing.Point(100, 39)
        Me.cbMedico.Name = "cbMedico"
        Me.cbMedico.Size = New System.Drawing.Size(121, 21)
        Me.cbMedico.TabIndex = 1
        Me.cbMedico.ValueMember = "CUIT"
        '
        'PRESTADORESBindingSource
        '
        Me.PRESTADORESBindingSource.DataMember = "PRESTADORES"
        Me.PRESTADORESBindingSource.DataSource = Me.HomeCareDataSetBindingSource
        '
        'HomeCareDataSetBindingSource
        '
        Me.HomeCareDataSetBindingSource.DataSource = Me.HomeCareDataSet
        Me.HomeCareDataSetBindingSource.Position = 0
        '
        'HomeCareDataSet
        '
        Me.HomeCareDataSet.DataSetName = "HomeCareDataSet"
        Me.HomeCareDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "CUIT"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(249, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Especialidad"
        '
        'txtMat
        '
        Me.txtMat.Location = New System.Drawing.Point(100, 72)
        Me.txtMat.Name = "txtMat"
        Me.txtMat.ReadOnly = True
        Me.txtMat.Size = New System.Drawing.Size(121, 20)
        Me.txtMat.TabIndex = 11
        '
        'txtPrestador
        '
        Me.txtPrestador.Location = New System.Drawing.Point(325, 72)
        Me.txtPrestador.Name = "txtPrestador"
        Me.txtPrestador.ReadOnly = True
        Me.txtPrestador.Size = New System.Drawing.Size(121, 20)
        Me.txtPrestador.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 24)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "PRESTACION"
        '
        'DTFecha
        '
        Me.DTFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTFecha.Location = New System.Drawing.Point(100, 132)
        Me.DTFecha.Name = "DTFecha"
        Me.DTFecha.ShowUpDown = True
        Me.DTFecha.Size = New System.Drawing.Size(346, 20)
        Me.DTFecha.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Prestacion"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 132)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Fecha"
        '
        'CBPrestacion
        '
        Me.CBPrestacion.DataSource = Me.PRESTACIONESBindingSource2
        Me.CBPrestacion.DisplayMember = "DESCRIPCION"
        Me.CBPrestacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPrestacion.FormattingEnabled = True
        Me.CBPrestacion.Location = New System.Drawing.Point(100, 100)
        Me.CBPrestacion.Name = "CBPrestacion"
        Me.CBPrestacion.Size = New System.Drawing.Size(346, 21)
        Me.CBPrestacion.TabIndex = 4
        Me.CBPrestacion.ValueMember = "CODIGO"
        '
        'PRESTACIONESBindingSource2
        '
        Me.PRESTACIONESBindingSource2.DataMember = "PRESTACIONES"
        Me.PRESTACIONESBindingSource2.DataSource = Me.HomeCareDataSetBindingSource
        '
        'PRESTACIONESBindingSource1
        '
        Me.PRESTACIONESBindingSource1.DataMember = "PRESTACIONES"
        Me.PRESTACIONESBindingSource1.DataSource = Me.HomeCareDataSetBindingSource
        '
        'PRESTACIONESBindingSource
        '
        Me.PRESTACIONESBindingSource.DataMember = "PRESTACIONES"
        Me.PRESTACIONESBindingSource.DataSource = Me.HomeCareDataSetBindingSource
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Location = New System.Drawing.Point(777, 592)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(106, 33)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtBeneficio
        '
        Me.txtBeneficio.Location = New System.Drawing.Point(338, 92)
        Me.txtBeneficio.Name = "txtBeneficio"
        Me.txtBeneficio.ReadOnly = True
        Me.txtBeneficio.Size = New System.Drawing.Size(121, 20)
        Me.txtBeneficio.TabIndex = 26
        '
        'txtAfiliado
        '
        Me.txtAfiliado.Location = New System.Drawing.Point(113, 91)
        Me.txtAfiliado.Name = "txtAfiliado"
        Me.txtAfiliado.ReadOnly = True
        Me.txtAfiliado.Size = New System.Drawing.Size(121, 20)
        Me.txtAfiliado.TabIndex = 25
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(262, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Beneficio"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "N° Afiliado"
        '
        'cbPaciente
        '
        Me.cbPaciente.DataSource = Me.PACIENTESBindingSource1
        Me.cbPaciente.DisplayMember = "APELLIDO"
        Me.cbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPaciente.FormattingEnabled = True
        Me.cbPaciente.Location = New System.Drawing.Point(113, 59)
        Me.cbPaciente.Name = "cbPaciente"
        Me.cbPaciente.Size = New System.Drawing.Size(121, 21)
        Me.cbPaciente.TabIndex = 0
        Me.cbPaciente.ValueMember = "AFILIADO"
        '
        'PACIENTESBindingSource1
        '
        Me.PACIENTESBindingSource1.DataMember = "PACIENTES"
        Me.PACIENTESBindingSource1.DataSource = Me.HomeCareDataSetBindingSource
        '
        'PACIENTESBindingSource
        '
        Me.PACIENTESBindingSource.DataMember = "PACIENTES"
        Me.PACIENTESBindingSource.DataSource = Me.HomeCareDataSetBindingSource
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Nombre y apellido"
        '
        'PRESTACIONESTableAdapter
        '
        Me.PRESTACIONESTableAdapter.ClearBeforeFill = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Location = New System.Drawing.Point(12, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(482, 108)
        Me.Panel1.TabIndex = 27
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cbMedico)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtMat)
        Me.Panel2.Controls.Add(Me.txtPrestador)
        Me.Panel2.Location = New System.Drawing.Point(12, 138)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(482, 108)
        Me.Panel2.TabIndex = 28
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.txtObservaciones)
        Me.Panel3.Controls.Add(Me.cbSubModulo)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.cbModulo)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.CBPrestacion)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.DTFecha)
        Me.Panel3.Location = New System.Drawing.Point(12, 252)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(482, 334)
        Me.Panel3.TabIndex = 29
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(1, 193)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 13)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(100, 193)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(346, 117)
        Me.txtObservaciones.TabIndex = 5
        '
        'cbSubModulo
        '
        Me.cbSubModulo.DataSource = Me.SUBMODULOBindingSource
        Me.cbSubModulo.DisplayMember = "DESCRIPCION"
        Me.cbSubModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSubModulo.FormattingEnabled = True
        Me.cbSubModulo.Location = New System.Drawing.Point(100, 68)
        Me.cbSubModulo.Name = "cbSubModulo"
        Me.cbSubModulo.Size = New System.Drawing.Size(346, 21)
        Me.cbSubModulo.TabIndex = 3
        Me.cbSubModulo.ValueMember = "CODIGO"
        '
        'SUBMODULOBindingSource
        '
        Me.SUBMODULOBindingSource.DataMember = "SUBMODULO"
        Me.SUBMODULOBindingSource.DataSource = Me.HomeCareDataSetBindingSource
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 76)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Sub-Modulo"
        '
        'cbModulo
        '
        Me.cbModulo.DataSource = Me.MODULOBindingSource
        Me.cbModulo.DisplayMember = "CODIGO"
        Me.cbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbModulo.FormattingEnabled = True
        Me.cbModulo.Location = New System.Drawing.Point(100, 37)
        Me.cbModulo.Name = "cbModulo"
        Me.cbModulo.Size = New System.Drawing.Size(346, 21)
        Me.cbModulo.TabIndex = 2
        Me.cbModulo.ValueMember = "CODIGO"
        '
        'MODULOBindingSource
        '
        Me.MODULOBindingSource.DataMember = "MODULO"
        Me.MODULOBindingSource.DataSource = Me.HomeCareDataSetBindingSource
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Modulo"
        '
        'PACIENTESTableAdapter
        '
        Me.PACIENTESTableAdapter.ClearBeforeFill = True
        '
        'PRESTADORESTableAdapter
        '
        Me.PRESTADORESTableAdapter.ClearBeforeFill = True
        '
        'MODULOTableAdapter
        '
        Me.MODULOTableAdapter.ClearBeforeFill = True
        '
        'SUBMODULOTableAdapter
        '
        Me.SUBMODULOTableAdapter.ClearBeforeFill = True
        '
        'dgFechas
        '
        Me.dgFechas.AllowUserToAddRows = False
        Me.dgFechas.AllowUserToDeleteRows = False
        Me.dgFechas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgFechas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgFechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFechas.Location = New System.Drawing.Point(7, 34)
        Me.dgFechas.Name = "dgFechas"
        Me.dgFechas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgFechas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgFechas.Size = New System.Drawing.Size(355, 504)
        Me.dgFechas.TabIndex = 6
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMes.ForeColor = System.Drawing.Color.Red
        Me.lblMes.Location = New System.Drawing.Point(91, 7)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(54, 24)
        Me.lblMes.TabIndex = 14
        Me.lblMes.Text = "MES"
        '
        'btnLimpiarGrilla
        '
        Me.btnLimpiarGrilla.Location = New System.Drawing.Point(368, 146)
        Me.btnLimpiarGrilla.Name = "btnLimpiarGrilla"
        Me.btnLimpiarGrilla.Size = New System.Drawing.Size(75, 23)
        Me.btnLimpiarGrilla.TabIndex = 15
        Me.btnLimpiarGrilla.Text = "&Limpiar"
        Me.btnLimpiarGrilla.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(364, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(111, 24)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Total Horas:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(364, 74)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(114, 24)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Monto Total:"
        '
        'lblHoras
        '
        Me.lblHoras.AutoSize = True
        Me.lblHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoras.Location = New System.Drawing.Point(459, 44)
        Me.lblHoras.Name = "lblHoras"
        Me.lblHoras.Size = New System.Drawing.Size(16, 17)
        Me.lblHoras.TabIndex = 21
        Me.lblHoras.Text = "0"
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.Location = New System.Drawing.Point(462, 111)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(16, 17)
        Me.lblMonto.TabIndex = 22
        Me.lblMonto.Text = "0"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.lblMes)
        Me.Panel4.Controls.Add(Me.lblMonto)
        Me.Panel4.Controls.Add(Me.lblHoras)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.btnLimpiarGrilla)
        Me.Panel4.Controls.Add(Me.dgFechas)
        Me.Panel4.Location = New System.Drawing.Point(513, 24)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(482, 562)
        Me.Panel4.TabIndex = 30
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(3, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 24)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "HORAS"
        '
        'frmPracticas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(1051, 660)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.txtBeneficio)
        Me.Controls.Add(Me.txtAfiliado)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbPaciente)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Name = "frmPracticas"
        Me.Text = "Ingresar Visitas Paciente"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PRESTADORESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HomeCareDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HomeCareDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRESTACIONESBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRESTACIONESBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRESTACIONESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PACIENTESBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PACIENTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.SUBMODULOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MODULOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCerrar As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbMedico As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtMat As TextBox
    Friend WithEvents txtPrestador As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents DTFecha As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents CBPrestacion As ComboBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents txtBeneficio As TextBox
    Friend WithEvents txtAfiliado As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cbPaciente As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents HomeCareDataSetBindingSource As BindingSource
    Friend WithEvents HomeCareDataSet As HomeCareDataSet
    Friend WithEvents PACIENTESBindingSource As BindingSource
    Friend WithEvents PRESTACIONESBindingSource As BindingSource
    Friend WithEvents PRESTACIONESTableAdapter As HomeCareDataSetTableAdapters.PRESTACIONESTableAdapter
    Friend WithEvents tsLbl As ToolStripStatusLabel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cbSubModulo As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cbModulo As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PACIENTESBindingSource1 As BindingSource
    Friend WithEvents PACIENTESTableAdapter As HomeCareDataSetTableAdapters.PACIENTESTableAdapter
    Friend WithEvents PRESTACIONESBindingSource1 As BindingSource
    Friend WithEvents PRESTADORESBindingSource As BindingSource
    Friend WithEvents PRESTADORESTableAdapter As HomeCareDataSetTableAdapters.PRESTADORESTableAdapter
    Friend WithEvents Label15 As Label
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents MODULOBindingSource As BindingSource
    Friend WithEvents MODULOTableAdapter As HomeCareDataSetTableAdapters.MODULOTableAdapter
    Friend WithEvents SUBMODULOBindingSource As BindingSource
    Friend WithEvents SUBMODULOTableAdapter As HomeCareDataSetTableAdapters.SUBMODULOTableAdapter
    Friend WithEvents PRESTACIONESBindingSource2 As BindingSource
    Friend WithEvents dgFechas As DataGridView
    Friend WithEvents lblMes As Label
    Friend WithEvents btnLimpiarGrilla As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblHoras As Label
    Friend WithEvents lblMonto As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label14 As Label
End Class
