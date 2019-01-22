<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsF
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PositionCB = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SettingsBOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'PositionCB
        '
        Me.PositionCB.FormattingEnabled = True
        Me.PositionCB.Location = New System.Drawing.Point(12, 29)
        Me.PositionCB.Name = "PositionCB"
        Me.PositionCB.Size = New System.Drawing.Size(121, 21)
        Me.PositionCB.TabIndex = 0
        Me.PositionCB.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "AppBar Position:"
        '
        'SettingsBOk
        '
        Me.SettingsBOk.Location = New System.Drawing.Point(12, 71)
        Me.SettingsBOk.Name = "SettingsBOk"
        Me.SettingsBOk.Size = New System.Drawing.Size(75, 23)
        Me.SettingsBOk.TabIndex = 2
        Me.SettingsBOk.Text = "OK"
        Me.SettingsBOk.UseVisualStyleBackColor = True
        '
        'SettingsF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(184, 108)
        Me.Controls.Add(Me.SettingsBOk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PositionCB)
        Me.Name = "SettingsF"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PositionCB As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SettingsBOk As Button
End Class
