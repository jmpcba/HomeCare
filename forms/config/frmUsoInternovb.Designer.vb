<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsoInternovb
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
        Me.btnDrop = New System.Windows.Forms.Button()
        Me.btnInit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnDrop
        '
        Me.btnDrop.Location = New System.Drawing.Point(149, 77)
        Me.btnDrop.Name = "btnDrop"
        Me.btnDrop.Size = New System.Drawing.Size(75, 23)
        Me.btnDrop.TabIndex = 0
        Me.btnDrop.Text = "Drop"
        Me.btnDrop.UseVisualStyleBackColor = True
        '
        'btnInit
        '
        Me.btnInit.Location = New System.Drawing.Point(149, 132)
        Me.btnInit.Name = "btnInit"
        Me.btnInit.Size = New System.Drawing.Size(75, 23)
        Me.btnInit.TabIndex = 1
        Me.btnInit.Text = "Init"
        Me.btnInit.UseVisualStyleBackColor = True
        '
        'frmUsoInternovb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btnInit)
        Me.Controls.Add(Me.btnDrop)
        Me.Name = "frmUsoInternovb"
        Me.Text = "frmUsoInternovb"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnDrop As Button
    Friend WithEvents btnInit As Button
End Class
