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
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMat = New System.Windows.Forms.TextBox()
        Me.txtLocalidadPrest = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DTFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtBeneficio = New System.Windows.Forms.TextBox()
        Me.txtAfiliado = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbPaciente = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtLocalidadPac = New System.Windows.Forms.TextBox()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtOS = New System.Windows.Forms.TextBox()
        Me.lblMed = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtServicio = New System.Windows.Forms.TextBox()
        Me.cbMedico = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtEspecialidad = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.cbSubModulo = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbModulo = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dgFechas = New System.Windows.Forms.DataGridView()
        Me.btnLimpiarGrilla = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblHoras = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblPrecioDif = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblPrecioLaV = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblPrecioFeriado = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnSelec = New System.Windows.Forms.Button()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.VerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PracticasPacienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PracticasPrestadorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(526, 632)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(106, 33)
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "&CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PACIENTE:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(3, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 24)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "PROFESIONAL:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(147, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(256, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "NOMBRE/ESPECIALIDAD/LOCALIDAD/SERVICIO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "CUIT"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(214, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "LOCALIDAD"
        '
        'txtMat
        '
        Me.txtMat.Location = New System.Drawing.Point(87, 107)
        Me.txtMat.Name = "txtMat"
        Me.txtMat.ReadOnly = True
        Me.txtMat.Size = New System.Drawing.Size(121, 20)
        Me.txtMat.TabIndex = 11
        '
        'txtLocalidadPrest
        '
        Me.txtLocalidadPrest.Location = New System.Drawing.Point(304, 107)
        Me.txtLocalidadPrest.Name = "txtLocalidadPrest"
        Me.txtLocalidadPrest.ReadOnly = True
        Me.txtLocalidadPrest.Size = New System.Drawing.Size(239, 20)
        Me.txtLocalidadPrest.TabIndex = 12
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
        Me.DTFecha.Location = New System.Drawing.Point(100, 105)
        Me.DTFecha.Name = "DTFecha"
        Me.DTFecha.ShowUpDown = True
        Me.DTFecha.Size = New System.Drawing.Size(165, 20)
        Me.DTFecha.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 109)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "FECHA"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Location = New System.Drawing.Point(526, 586)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(106, 33)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "&GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtBeneficio
        '
        Me.txtBeneficio.Location = New System.Drawing.Point(338, 74)
        Me.txtBeneficio.Name = "txtBeneficio"
        Me.txtBeneficio.ReadOnly = True
        Me.txtBeneficio.Size = New System.Drawing.Size(149, 20)
        Me.txtBeneficio.TabIndex = 26
        '
        'txtAfiliado
        '
        Me.txtAfiliado.Location = New System.Drawing.Point(127, 74)
        Me.txtAfiliado.Name = "txtAfiliado"
        Me.txtAfiliado.ReadOnly = True
        Me.txtAfiliado.Size = New System.Drawing.Size(121, 20)
        Me.txtAfiliado.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(254, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "OBRA SOCIAL"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 81)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "N° AFILIADO"
        '
        'cbPaciente
        '
        Me.cbPaciente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbPaciente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbPaciente.FormattingEnabled = True
        Me.cbPaciente.Location = New System.Drawing.Point(127, 42)
        Me.cbPaciente.Name = "cbPaciente"
        Me.cbPaciente.Size = New System.Drawing.Size(360, 21)
        Me.cbPaciente.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "NOMBRE Y APELLIDO"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.txtLocalidadPac)
        Me.Panel1.Controls.Add(Me.lblPaciente)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtAfiliado)
        Me.Panel1.Controls.Add(Me.cbPaciente)
        Me.Panel1.Controls.Add(Me.txtBeneficio)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(12, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(556, 135)
        Me.Panel1.TabIndex = 27
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(3, 114)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(67, 13)
        Me.Label23.TabIndex = 29
        Me.Label23.Text = "LOCALIDAD"
        '
        'txtLocalidadPac
        '
        Me.txtLocalidadPac.Location = New System.Drawing.Point(127, 107)
        Me.txtLocalidadPac.Name = "txtLocalidadPac"
        Me.txtLocalidadPac.ReadOnly = True
        Me.txtLocalidadPac.Size = New System.Drawing.Size(121, 20)
        Me.txtLocalidadPac.TabIndex = 28
        '
        'lblPaciente
        '
        Me.lblPaciente.AutoSize = True
        Me.lblPaciente.Location = New System.Drawing.Point(124, 11)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(60, 13)
        Me.lblPaciente.TabIndex = 27
        Me.lblPaciente.Text = "lblPAciente"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.txtOS)
        Me.Panel2.Controls.Add(Me.lblMed)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtServicio)
        Me.Panel2.Controls.Add(Me.cbMedico)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txtEspecialidad)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtMat)
        Me.Panel2.Controls.Add(Me.txtLocalidadPrest)
        Me.Panel2.Location = New System.Drawing.Point(12, 164)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(556, 207)
        Me.Panel2.TabIndex = 28
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(3, 174)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(78, 13)
        Me.Label22.TabIndex = 29
        Me.Label22.Text = "OBRA SOCIAL"
        '
        'txtOS
        '
        Me.txtOS.Location = New System.Drawing.Point(87, 171)
        Me.txtOS.Name = "txtOS"
        Me.txtOS.ReadOnly = True
        Me.txtOS.Size = New System.Drawing.Size(121, 20)
        Me.txtOS.TabIndex = 30
        '
        'lblMed
        '
        Me.lblMed.AutoSize = True
        Me.lblMed.Location = New System.Drawing.Point(169, 13)
        Me.lblMed.Name = "lblMed"
        Me.lblMed.Size = New System.Drawing.Size(38, 13)
        Me.lblMed.TabIndex = 28
        Me.lblMed.Text = "lblMed"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 140)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "SERVICIO"
        '
        'txtServicio
        '
        Me.txtServicio.Location = New System.Drawing.Point(87, 136)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.ReadOnly = True
        Me.txtServicio.Size = New System.Drawing.Size(121, 20)
        Me.txtServicio.TabIndex = 16
        '
        'cbMedico
        '
        Me.cbMedico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbMedico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbMedico.FormattingEnabled = True
        Me.cbMedico.Location = New System.Drawing.Point(7, 70)
        Me.cbMedico.Name = "cbMedico"
        Me.cbMedico.Size = New System.Drawing.Size(536, 21)
        Me.cbMedico.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(214, 140)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 13)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "ESPECIALIDAD"
        '
        'txtEspecialidad
        '
        Me.txtEspecialidad.Location = New System.Drawing.Point(304, 136)
        Me.txtEspecialidad.Name = "txtEspecialidad"
        Me.txtEspecialidad.ReadOnly = True
        Me.txtEspecialidad.Size = New System.Drawing.Size(239, 20)
        Me.txtEspecialidad.TabIndex = 13
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
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.DTFecha)
        Me.Panel3.Location = New System.Drawing.Point(12, 377)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(556, 319)
        Me.Panel3.TabIndex = 29
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(4, 144)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 13)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "OBSERVACIONES"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(34, 160)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(413, 117)
        Me.txtObservaciones.TabIndex = 6
        '
        'cbSubModulo
        '
        Me.cbSubModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSubModulo.FormattingEnabled = True
        Me.cbSubModulo.Location = New System.Drawing.Point(100, 70)
        Me.cbSubModulo.Name = "cbSubModulo"
        Me.cbSubModulo.Size = New System.Drawing.Size(346, 21)
        Me.cbSubModulo.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "SUB-MODULO"
        '
        'cbModulo
        '
        Me.cbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbModulo.FormattingEnabled = True
        Me.cbModulo.Location = New System.Drawing.Point(100, 40)
        Me.cbModulo.Name = "cbModulo"
        Me.cbModulo.Size = New System.Drawing.Size(346, 21)
        Me.cbModulo.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "MODULO"
        '
        'dgFechas
        '
        Me.dgFechas.AllowUserToAddRows = False
        Me.dgFechas.AllowUserToDeleteRows = False
        Me.dgFechas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgFechas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgFechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFechas.Location = New System.Drawing.Point(32, 26)
        Me.dgFechas.MultiSelect = False
        Me.dgFechas.Name = "dgFechas"
        Me.dgFechas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgFechas.Size = New System.Drawing.Size(445, 647)
        Me.dgFechas.TabIndex = 6
        '
        'btnLimpiarGrilla
        '
        Me.btnLimpiarGrilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiarGrilla.Location = New System.Drawing.Point(526, 540)
        Me.btnLimpiarGrilla.Name = "btnLimpiarGrilla"
        Me.btnLimpiarGrilla.Size = New System.Drawing.Size(106, 33)
        Me.btnLimpiarGrilla.TabIndex = 15
        Me.btnLimpiarGrilla.Text = "&LIMPIAR"
        Me.btnLimpiarGrilla.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(481, 205)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(154, 20)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "TOTAL PRACTICAS"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(481, 251)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(124, 20)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "MONTO TOTAL:"
        '
        'lblHoras
        '
        Me.lblHoras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHoras.AutoSize = True
        Me.lblHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoras.Location = New System.Drawing.Point(533, 224)
        Me.lblHoras.Name = "lblHoras"
        Me.lblHoras.Size = New System.Drawing.Size(16, 17)
        Me.lblHoras.TabIndex = 21
        Me.lblHoras.Text = "0"
        '
        'lblMonto
        '
        Me.lblMonto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.Location = New System.Drawing.Point(533, 271)
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
        Me.Panel4.Controls.Add(Me.lblPrecioDif)
        Me.Panel4.Controls.Add(Me.Label24)
        Me.Panel4.Controls.Add(Me.lblPrecioLaV)
        Me.Panel4.Controls.Add(Me.Label21)
        Me.Panel4.Controls.Add(Me.lblPrecioFeriado)
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Controls.Add(Me.btnSelec)
        Me.Panel4.Controls.Add(Me.lblMes)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.lblMonto)
        Me.Panel4.Controls.Add(Me.btnCerrar)
        Me.Panel4.Controls.Add(Me.btnGuardar)
        Me.Panel4.Controls.Add(Me.lblHoras)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.btnLimpiarGrilla)
        Me.Panel4.Controls.Add(Me.dgFechas)
        Me.Panel4.Location = New System.Drawing.Point(574, 22)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(637, 678)
        Me.Panel4.TabIndex = 30
        '
        'lblPrecioDif
        '
        Me.lblPrecioDif.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrecioDif.AutoSize = True
        Me.lblPrecioDif.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioDif.Location = New System.Drawing.Point(533, 132)
        Me.lblPrecioDif.Name = "lblPrecioDif"
        Me.lblPrecioDif.Size = New System.Drawing.Size(16, 17)
        Me.lblPrecioDif.TabIndex = 118
        Me.lblPrecioDif.Text = "0"
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(481, 112)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(101, 20)
        Me.Label24.TabIndex = 117
        Me.Label24.Text = "PRECIO DIF"
        '
        'lblPrecioLaV
        '
        Me.lblPrecioLaV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrecioLaV.AutoSize = True
        Me.lblPrecioLaV.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioLaV.Location = New System.Drawing.Point(533, 47)
        Me.lblPrecioLaV.Name = "lblPrecioLaV"
        Me.lblPrecioLaV.Size = New System.Drawing.Size(16, 17)
        Me.lblPrecioLaV.TabIndex = 116
        Me.lblPrecioLaV.Text = "0"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(481, 26)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(103, 20)
        Me.Label21.TabIndex = 115
        Me.Label21.Text = "PRECIO LaV"
        '
        'lblPrecioFeriado
        '
        Me.lblPrecioFeriado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrecioFeriado.AutoSize = True
        Me.lblPrecioFeriado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioFeriado.Location = New System.Drawing.Point(533, 89)
        Me.lblPrecioFeriado.Name = "lblPrecioFeriado"
        Me.lblPrecioFeriado.Size = New System.Drawing.Size(16, 17)
        Me.lblPrecioFeriado.TabIndex = 114
        Me.lblPrecioFeriado.Text = "0"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(481, 69)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(147, 20)
        Me.Label20.TabIndex = 113
        Me.Label20.Text = "PRECIO FERIADO"
        '
        'btnSelec
        '
        Me.btnSelec.Location = New System.Drawing.Point(32, 1)
        Me.btnSelec.Name = "btnSelec"
        Me.btnSelec.Size = New System.Drawing.Size(58, 23)
        Me.btnSelec.TabIndex = 112
        Me.btnSelec.Text = "&TODOS"
        Me.btnSelec.UseVisualStyleBackColor = True
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMes.ForeColor = System.Drawing.Color.Red
        Me.lblMes.Location = New System.Drawing.Point(364, 0)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(54, 24)
        Me.lblMes.TabIndex = 24
        Me.lblMes.Text = "MES"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(144, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(214, 24)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "PRACTICAS / HORAS"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1252, 24)
        Me.MenuStrip1.TabIndex = 31
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'VerToolStripMenuItem
        '
        Me.VerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PracticasPacienteToolStripMenuItem, Me.PracticasPrestadorToolStripMenuItem})
        Me.VerToolStripMenuItem.Name = "VerToolStripMenuItem"
        Me.VerToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.VerToolStripMenuItem.Text = "&VER"
        '
        'PracticasPacienteToolStripMenuItem
        '
        Me.PracticasPacienteToolStripMenuItem.Name = "PracticasPacienteToolStripMenuItem"
        Me.PracticasPacienteToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.PracticasPacienteToolStripMenuItem.Text = "Practicas p&aciente"
        '
        'PracticasPrestadorToolStripMenuItem
        '
        Me.PracticasPrestadorToolStripMenuItem.Name = "PracticasPrestadorToolStripMenuItem"
        Me.PracticasPrestadorToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.PracticasPrestadorToolStripMenuItem.Text = "Practicas pr&estador"
        '
        'frmPracticas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(1252, 712)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmPracticas"
        Me.Text = "Administrar Practicas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCerrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtMat As TextBox
    Friend WithEvents txtLocalidadPrest As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents DTFecha As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents txtBeneficio As TextBox
    Friend WithEvents txtAfiliado As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cbPaciente As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cbSubModulo As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cbModulo As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents dgFechas As DataGridView
    Friend WithEvents btnLimpiarGrilla As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblHoras As Label
    Friend WithEvents lblMonto As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents lblMes As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtEspecialidad As TextBox
    Friend WithEvents cbMedico As ComboBox
    Friend WithEvents btnSelec As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtServicio As TextBox
    Friend WithEvents lblPrecioLaV As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents lblPrecioFeriado As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtLocalidadPac As TextBox
    Friend WithEvents lblPaciente As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtOS As TextBox
    Friend WithEvents lblMed As Label
    Friend WithEvents lblPrecioDif As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents VerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PracticasPacienteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PracticasPrestadorToolStripMenuItem As ToolStripMenuItem
End Class
