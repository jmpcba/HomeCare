<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisitas
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
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbMedico = New System.Windows.Forms.ComboBox()
        Me.MEDICOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HomeCareDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HomeCareDataSet = New HomeCare.HomeCareDataSet()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMat = New System.Windows.Forms.TextBox()
        Me.txtPrestador = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DTFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CBPrestacion = New System.Windows.Forms.ComboBox()
        Me.PRESTACIONESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEliminarVisita = New System.Windows.Forms.Button()
        Me.txtBeneficio = New System.Windows.Forms.TextBox()
        Me.txtDni = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbPaciente = New System.Windows.Forms.ComboBox()
        Me.PACIENTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PACIENTESTableAdapter = New HomeCare.HomeCareDataSetTableAdapters.PACIENTESTableAdapter()
        Me.MEDICOSTableAdapter = New HomeCare.HomeCareDataSetTableAdapters.MEDICOSTableAdapter()
        Me.PRESTACIONESTableAdapter = New HomeCare.HomeCareDataSetTableAdapters.PRESTACIONESTableAdapter()
        Me.tsLbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.MEDICOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HomeCareDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HomeCareDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRESTACIONESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PACIENTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(516, 753)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(106, 33)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLbl})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 791)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(634, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Paciente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 157)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 24)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Profesional"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Nombre y apellido"
        '
        'cbMedico
        '
        Me.cbMedico.DataSource = Me.MEDICOSBindingSource
        Me.cbMedico.DisplayMember = "NOMBRE"
        Me.cbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMedico.FormattingEnabled = True
        Me.cbMedico.Location = New System.Drawing.Point(113, 192)
        Me.cbMedico.Name = "cbMedico"
        Me.cbMedico.Size = New System.Drawing.Size(121, 21)
        Me.cbMedico.TabIndex = 8
        Me.cbMedico.ValueMember = "MATRICULA"
        '
        'MEDICOSBindingSource
        '
        Me.MEDICOSBindingSource.DataMember = "MEDICOS"
        Me.MEDICOSBindingSource.DataSource = Me.HomeCareDataSetBindingSource
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
        Me.Label4.Location = New System.Drawing.Point(15, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Matricula"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(262, 233)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Prestador"
        '
        'txtMat
        '
        Me.txtMat.Location = New System.Drawing.Point(113, 225)
        Me.txtMat.Name = "txtMat"
        Me.txtMat.ReadOnly = True
        Me.txtMat.Size = New System.Drawing.Size(121, 20)
        Me.txtMat.TabIndex = 11
        '
        'txtPrestador
        '
        Me.txtPrestador.Location = New System.Drawing.Point(338, 226)
        Me.txtPrestador.Name = "txtPrestador"
        Me.txtPrestador.ReadOnly = True
        Me.txtPrestador.Size = New System.Drawing.Size(121, 20)
        Me.txtPrestador.TabIndex = 12
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(18, 487)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(604, 260)
        Me.DataGridView1.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 307)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 24)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Prestacion"
        '
        'DTFecha
        '
        Me.DTFecha.Location = New System.Drawing.Point(338, 332)
        Me.DTFecha.Name = "DTFecha"
        Me.DTFecha.Size = New System.Drawing.Size(200, 20)
        Me.DTFecha.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(262, 338)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Fecha"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 339)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Tipo"
        '
        'CBPrestacion
        '
        Me.CBPrestacion.DataSource = Me.PRESTACIONESBindingSource
        Me.CBPrestacion.DisplayMember = "DESCRIPCCION"
        Me.CBPrestacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPrestacion.FormattingEnabled = True
        Me.CBPrestacion.Location = New System.Drawing.Point(48, 336)
        Me.CBPrestacion.Name = "CBPrestacion"
        Me.CBPrestacion.Size = New System.Drawing.Size(186, 21)
        Me.CBPrestacion.TabIndex = 18
        Me.CBPrestacion.ValueMember = "ID"
        '
        'PRESTACIONESBindingSource
        '
        Me.PRESTACIONESBindingSource.DataMember = "PRESTACIONES"
        Me.PRESTACIONESBindingSource.DataSource = Me.HomeCareDataSetBindingSource
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(18, 436)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(186, 33)
        Me.btnAgregar.TabIndex = 19
        Me.btnAgregar.Text = "A&gregar Visita"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnEliminarVisita
        '
        Me.btnEliminarVisita.Location = New System.Drawing.Point(436, 436)
        Me.btnEliminarVisita.Name = "btnEliminarVisita"
        Me.btnEliminarVisita.Size = New System.Drawing.Size(186, 33)
        Me.btnEliminarVisita.TabIndex = 20
        Me.btnEliminarVisita.Text = "&Eliminar Visita"
        Me.btnEliminarVisita.UseVisualStyleBackColor = True
        '
        'txtBeneficio
        '
        Me.txtBeneficio.Location = New System.Drawing.Point(338, 92)
        Me.txtBeneficio.Name = "txtBeneficio"
        Me.txtBeneficio.ReadOnly = True
        Me.txtBeneficio.Size = New System.Drawing.Size(121, 20)
        Me.txtBeneficio.TabIndex = 26
        '
        'txtDni
        '
        Me.txtDni.Location = New System.Drawing.Point(113, 91)
        Me.txtDni.Name = "txtDni"
        Me.txtDni.ReadOnly = True
        Me.txtDni.Size = New System.Drawing.Size(121, 20)
        Me.txtDni.TabIndex = 25
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
        Me.Label10.Location = New System.Drawing.Point(15, 99)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "DNI"
        '
        'cbPaciente
        '
        Me.cbPaciente.DataSource = Me.PACIENTESBindingSource
        Me.cbPaciente.DisplayMember = "NOMBRE"
        Me.cbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPaciente.FormattingEnabled = True
        Me.cbPaciente.Location = New System.Drawing.Point(113, 61)
        Me.cbPaciente.Name = "cbPaciente"
        Me.cbPaciente.Size = New System.Drawing.Size(121, 21)
        Me.cbPaciente.TabIndex = 22
        Me.cbPaciente.ValueMember = "DNI"
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
        'PACIENTESTableAdapter
        '
        Me.PACIENTESTableAdapter.ClearBeforeFill = True
        '
        'MEDICOSTableAdapter
        '
        Me.MEDICOSTableAdapter.ClearBeforeFill = True
        '
        'PRESTACIONESTableAdapter
        '
        Me.PRESTACIONESTableAdapter.ClearBeforeFill = True
        '
        'tsLbl
        '
        Me.tsLbl.Name = "tsLbl"
        Me.tsLbl.Size = New System.Drawing.Size(120, 17)
        Me.tsLbl.Text = "ToolStripStatusLabel1"
        '
        'frmVisitas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(634, 813)
        Me.Controls.Add(Me.txtBeneficio)
        Me.Controls.Add(Me.txtDni)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbPaciente)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnEliminarVisita)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.CBPrestacion)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DTFecha)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtPrestador)
        Me.Controls.Add(Me.txtMat)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbMedico)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Name = "frmVisitas"
        Me.Text = "Ingresar Visitas Paciente"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.MEDICOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HomeCareDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HomeCareDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRESTACIONESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PACIENTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents DTFecha As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents CBPrestacion As ComboBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnEliminarVisita As Button
    Friend WithEvents txtBeneficio As TextBox
    Friend WithEvents txtDni As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cbPaciente As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents HomeCareDataSetBindingSource As BindingSource
    Friend WithEvents HomeCareDataSet As HomeCareDataSet
    Friend WithEvents PACIENTESBindingSource As BindingSource
    Friend WithEvents PACIENTESTableAdapter As HomeCareDataSetTableAdapters.PACIENTESTableAdapter
    Friend WithEvents MEDICOSBindingSource As BindingSource
    Friend WithEvents MEDICOSTableAdapter As HomeCareDataSetTableAdapters.MEDICOSTableAdapter
    Friend WithEvents PRESTACIONESBindingSource As BindingSource
    Friend WithEvents PRESTACIONESTableAdapter As HomeCareDataSetTableAdapters.PRESTACIONESTableAdapter
    Friend WithEvents tsLbl As ToolStripStatusLabel
End Class
