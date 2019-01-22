<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button_Top = New System.Windows.Forms.Button()
        Me.Button_Bottom = New System.Windows.Forms.Button()
        Me.Button_Left = New System.Windows.Forms.Button()
        Me.Button_Right = New System.Windows.Forms.Button()
        Me.Button_Close = New System.Windows.Forms.Button()
        Me.Button_Right2 = New System.Windows.Forms.Button()
        Me.Button_Left2 = New System.Windows.Forms.Button()
        Me.Button_Bottom2 = New System.Windows.Forms.Button()
        Me.Button_Top2 = New System.Windows.Forms.Button()
        Me.SettingsPB = New System.Windows.Forms.PictureBox()
        CType(Me.SettingsPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_Top
        '
        Me.Button_Top.Location = New System.Drawing.Point(12, 12)
        Me.Button_Top.Name = "Button_Top"
        Me.Button_Top.Size = New System.Drawing.Size(70, 25)
        Me.Button_Top.TabIndex = 0
        Me.Button_Top.Text = "Top1"
        Me.Button_Top.UseVisualStyleBackColor = True
        '
        'Button_Bottom
        '
        Me.Button_Bottom.Location = New System.Drawing.Point(12, 43)
        Me.Button_Bottom.Name = "Button_Bottom"
        Me.Button_Bottom.Size = New System.Drawing.Size(70, 25)
        Me.Button_Bottom.TabIndex = 1
        Me.Button_Bottom.Text = "Bottom1"
        Me.Button_Bottom.UseVisualStyleBackColor = True
        '
        'Button_Left
        '
        Me.Button_Left.Location = New System.Drawing.Point(12, 74)
        Me.Button_Left.Name = "Button_Left"
        Me.Button_Left.Size = New System.Drawing.Size(70, 25)
        Me.Button_Left.TabIndex = 2
        Me.Button_Left.Text = "Left1"
        Me.Button_Left.UseVisualStyleBackColor = True
        '
        'Button_Right
        '
        Me.Button_Right.Location = New System.Drawing.Point(12, 105)
        Me.Button_Right.Name = "Button_Right"
        Me.Button_Right.Size = New System.Drawing.Size(70, 25)
        Me.Button_Right.TabIndex = 3
        Me.Button_Right.Text = "Right1"
        Me.Button_Right.UseVisualStyleBackColor = True
        '
        'Button_Close
        '
        Me.Button_Close.Location = New System.Drawing.Point(12, 260)
        Me.Button_Close.Name = "Button_Close"
        Me.Button_Close.Size = New System.Drawing.Size(70, 25)
        Me.Button_Close.TabIndex = 4
        Me.Button_Close.Text = "Close"
        Me.Button_Close.UseVisualStyleBackColor = True
        '
        'Button_Right2
        '
        Me.Button_Right2.Location = New System.Drawing.Point(12, 229)
        Me.Button_Right2.Name = "Button_Right2"
        Me.Button_Right2.Size = New System.Drawing.Size(70, 25)
        Me.Button_Right2.TabIndex = 8
        Me.Button_Right2.Text = "Right2"
        Me.Button_Right2.UseVisualStyleBackColor = True
        '
        'Button_Left2
        '
        Me.Button_Left2.Location = New System.Drawing.Point(12, 198)
        Me.Button_Left2.Name = "Button_Left2"
        Me.Button_Left2.Size = New System.Drawing.Size(70, 25)
        Me.Button_Left2.TabIndex = 7
        Me.Button_Left2.Text = "Left2"
        Me.Button_Left2.UseVisualStyleBackColor = True
        '
        'Button_Bottom2
        '
        Me.Button_Bottom2.Location = New System.Drawing.Point(12, 167)
        Me.Button_Bottom2.Name = "Button_Bottom2"
        Me.Button_Bottom2.Size = New System.Drawing.Size(70, 25)
        Me.Button_Bottom2.TabIndex = 6
        Me.Button_Bottom2.Text = "Bottom2"
        Me.Button_Bottom2.UseVisualStyleBackColor = True
        '
        'Button_Top2
        '
        Me.Button_Top2.Location = New System.Drawing.Point(12, 136)
        Me.Button_Top2.Name = "Button_Top2"
        Me.Button_Top2.Size = New System.Drawing.Size(70, 25)
        Me.Button_Top2.TabIndex = 5
        Me.Button_Top2.Text = "Top2"
        Me.Button_Top2.UseVisualStyleBackColor = True
        '
        'SettingsPB
        '
        Me.SettingsPB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SettingsPB.Image = Global.LameBar.My.Resources.Resources.Settings
        Me.SettingsPB.Location = New System.Drawing.Point(72, 320)
        Me.SettingsPB.Name = "SettingsPB"
        Me.SettingsPB.Size = New System.Drawing.Size(33, 32)
        Me.SettingsPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.SettingsPB.TabIndex = 9
        Me.SettingsPB.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(117, 364)
        Me.Controls.Add(Me.SettingsPB)
        Me.Controls.Add(Me.Button_Right2)
        Me.Controls.Add(Me.Button_Left2)
        Me.Controls.Add(Me.Button_Bottom2)
        Me.Controls.Add(Me.Button_Top2)
        Me.Controls.Add(Me.Button_Close)
        Me.Controls.Add(Me.Button_Right)
        Me.Controls.Add(Me.Button_Left)
        Me.Controls.Add(Me.Button_Bottom)
        Me.Controls.Add(Me.Button_Top)
        Me.Name = "Form1"
        Me.Text = "LameBar"
        CType(Me.SettingsPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button_Top As Button
    Friend WithEvents Button_Bottom As Button
    Friend WithEvents Button_Left As Button
    Friend WithEvents Button_Right As Button
    Friend WithEvents Button_Close As Button
    Friend WithEvents Button_Right2 As Button
    Friend WithEvents Button_Left2 As Button
    Friend WithEvents Button_Bottom2 As Button
    Friend WithEvents Button_Top2 As Button
    Friend WithEvents SettingsPB As PictureBox
End Class
