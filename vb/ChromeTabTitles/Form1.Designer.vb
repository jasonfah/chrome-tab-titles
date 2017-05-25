<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnListTabTitles = New System.Windows.Forms.Button()
        Me.lstTabTitles = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnListTabTitles
        '
        Me.btnListTabTitles.Location = New System.Drawing.Point(12, 828)
        Me.btnListTabTitles.Name = "btnListTabTitles"
        Me.btnListTabTitles.Size = New System.Drawing.Size(979, 80)
        Me.btnListTabTitles.TabIndex = 0
        Me.btnListTabTitles.Text = "Show Tab Titles"
        Me.btnListTabTitles.UseVisualStyleBackColor = True
        '
        'lstTabTitles
        '
        Me.lstTabTitles.FormattingEnabled = True
        Me.lstTabTitles.ItemHeight = 25
        Me.lstTabTitles.Location = New System.Drawing.Point(12, 12)
        Me.lstTabTitles.Name = "lstTabTitles"
        Me.lstTabTitles.Size = New System.Drawing.Size(979, 804)
        Me.lstTabTitles.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 920)
        Me.Controls.Add(Me.lstTabTitles)
        Me.Controls.Add(Me.btnListTabTitles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Chrome Tab Titles"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnListTabTitles As Button
    Friend WithEvents lstTabTitles As ListBox
End Class
