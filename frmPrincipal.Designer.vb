<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
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
        Me.btnVisita = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnVisita
        '
        Me.btnVisita.Location = New System.Drawing.Point(12, 48)
        Me.btnVisita.Name = "btnVisita"
        Me.btnVisita.Size = New System.Drawing.Size(260, 53)
        Me.btnVisita.TabIndex = 0
        Me.btnVisita.Text = "Cargar Visita"
        Me.btnVisita.UseVisualStyleBackColor = True
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btnVisita)
        Me.Name = "frmPrincipal"
        Me.Text = "frmPrincipal"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnVisita As Button
End Class
