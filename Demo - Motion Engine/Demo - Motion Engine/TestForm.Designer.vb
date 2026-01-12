<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TestForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Accel_Button = New Button()
        Decel_Button = New Button()
        Dot_Button = New Button()
        Standard_Button = New Button()
        MO_Check = New CheckBox()
        Peak_Button = New Button()
        SuspendLayout()
        ' 
        ' Accel_Button
        ' 
        Accel_Button.Location = New Point(12, 12)
        Accel_Button.Name = "Accel_Button"
        Accel_Button.Size = New Size(120, 40)
        Accel_Button.TabIndex = 0
        Accel_Button.Text = "Accelerate"
        Accel_Button.UseVisualStyleBackColor = True
        ' 
        ' Decel_Button
        ' 
        Decel_Button.Location = New Point(138, 12)
        Decel_Button.Name = "Decel_Button"
        Decel_Button.Size = New Size(120, 40)
        Decel_Button.TabIndex = 1
        Decel_Button.Text = "Decelerate"
        Decel_Button.UseVisualStyleBackColor = True
        ' 
        ' Dot_Button
        ' 
        Dot_Button.Location = New Point(264, 12)
        Dot_Button.Name = "Dot_Button"
        Dot_Button.Size = New Size(120, 40)
        Dot_Button.TabIndex = 2
        Dot_Button.Text = "Dots"
        Dot_Button.UseVisualStyleBackColor = True
        ' 
        ' Standard_Button
        ' 
        Standard_Button.Location = New Point(390, 12)
        Standard_Button.Name = "Standard_Button"
        Standard_Button.Size = New Size(120, 40)
        Standard_Button.TabIndex = 3
        Standard_Button.Text = "Standard"
        Standard_Button.UseVisualStyleBackColor = True
        ' 
        ' MO_Check
        ' 
        MO_Check.AutoSize = True
        MO_Check.Location = New Point(15, 60)
        MO_Check.Name = "MO_Check"
        MO_Check.Size = New Size(163, 19)
        MO_Check.TabIndex = 4
        MO_Check.Text = "Vibration on mouse hover"
        MO_Check.UseVisualStyleBackColor = True
        ' 
        ' Peak_Button
        ' 
        Peak_Button.Location = New Point(516, 12)
        Peak_Button.Name = "Peak_Button"
        Peak_Button.Size = New Size(120, 40)
        Peak_Button.TabIndex = 5
        Peak_Button.Text = "Peak"
        Peak_Button.UseVisualStyleBackColor = True
        ' 
        ' TestForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(649, 88)
        Controls.Add(Peak_Button)
        Controls.Add(MO_Check)
        Controls.Add(Standard_Button)
        Controls.Add(Dot_Button)
        Controls.Add(Decel_Button)
        Controls.Add(Accel_Button)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "TestForm"
        Text = "Demo - Motion Engine"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Accel_Button As Button
    Friend WithEvents Decel_Button As Button
    Friend WithEvents Dot_Button As Button
    Friend WithEvents Standard_Button As Button
    Friend WithEvents MO_Check As CheckBox
    Friend WithEvents Peak_Button As Button

End Class
