<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenKeys
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenKeys))
        Me.sfdKeyFile = New System.Windows.Forms.SaveFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtKeyFile = New System.Windows.Forms.TextBox()
        Me.btnGenKeyFile = New System.Windows.Forms.Button()
        Me.btnSaveKeyFileAs = New System.Windows.Forms.Button()
        Me.lblKeyFileName = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pgbStatus = New System.Windows.Forms.ProgressBar()
        Me.ddlKeySize = New System.Windows.Forms.ComboBox()
        Me.lblKeySize = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'sfdKeyFile
        '
        Me.sfdKeyFile.DefaultExt = "xml"
        Me.sfdKeyFile.Filter = "XML files|*.xml"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Save Key File as:"
        '
        'txtKeyFile
        '
        Me.txtKeyFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtKeyFile.Location = New System.Drawing.Point(216, 19)
        Me.txtKeyFile.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtKeyFile.Name = "txtKeyFile"
        Me.txtKeyFile.Size = New System.Drawing.Size(769, 31)
        Me.txtKeyFile.TabIndex = 1
        '
        'btnGenKeyFile
        '
        Me.btnGenKeyFile.Location = New System.Drawing.Point(216, 88)
        Me.btnGenKeyFile.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnGenKeyFile.Name = "btnGenKeyFile"
        Me.btnGenKeyFile.Size = New System.Drawing.Size(248, 65)
        Me.btnGenKeyFile.TabIndex = 2
        Me.btnGenKeyFile.Text = "Generate Key Files"
        Me.btnGenKeyFile.UseVisualStyleBackColor = True
        '
        'btnSaveKeyFileAs
        '
        Me.btnSaveKeyFileAs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveKeyFileAs.Location = New System.Drawing.Point(1001, 19)
        Me.btnSaveKeyFileAs.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnSaveKeyFileAs.Name = "btnSaveKeyFileAs"
        Me.btnSaveKeyFileAs.Size = New System.Drawing.Size(72, 44)
        Me.btnSaveKeyFileAs.TabIndex = 4
        Me.btnSaveKeyFileAs.Text = "..."
        Me.btnSaveKeyFileAs.UseVisualStyleBackColor = True
        '
        'lblKeyFileName
        '
        Me.lblKeyFileName.AutoSize = True
        Me.lblKeyFileName.Location = New System.Drawing.Point(42, 281)
        Me.lblKeyFileName.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblKeyFileName.Name = "lblKeyFileName"
        Me.lblKeyFileName.Size = New System.Drawing.Size(149, 25)
        Me.lblKeyFileName.TabIndex = 5
        Me.lblKeyFileName.Text = "KeyFile name:"
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(26, 344)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(165, 25)
        Me.lblStatus.TabIndex = 6
        Me.lblStatus.Text = "Status: Ready..."
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnClose.Location = New System.Drawing.Point(478, 87)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(184, 67)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close Key Generator"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'pgbStatus
        '
        Me.pgbStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgbStatus.Location = New System.Drawing.Point(-4, 375)
        Me.pgbStatus.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.pgbStatus.Name = "pgbStatus"
        Me.pgbStatus.Size = New System.Drawing.Size(1097, 44)
        Me.pgbStatus.TabIndex = 8
        '
        'ddlKeySize
        '
        Me.ddlKeySize.FormattingEnabled = True
        Me.ddlKeySize.Items.AddRange(New Object() {"1024", "2048", "3072", "4096", "5120", "6144", "7168", "8192", "9216", "10240", "11264", "12288", "13312", "14336", "15360", "16384"})
        Me.ddlKeySize.Location = New System.Drawing.Point(216, 188)
        Me.ddlKeySize.Name = "ddlKeySize"
        Me.ddlKeySize.Size = New System.Drawing.Size(195, 33)
        Me.ddlKeySize.TabIndex = 9
        Me.ddlKeySize.Visible = False
        '
        'lblKeySize
        '
        Me.lblKeySize.AutoSize = True
        Me.lblKeySize.Location = New System.Drawing.Point(88, 191)
        Me.lblKeySize.Name = "lblKeySize"
        Me.lblKeySize.Size = New System.Drawing.Size(103, 25)
        Me.lblKeySize.TabIndex = 10
        Me.lblKeySize.Text = "Key Size:"
        Me.lblKeySize.Visible = False
        '
        'frmGenKeys
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1091, 417)
        Me.Controls.Add(Me.lblKeySize)
        Me.Controls.Add(Me.ddlKeySize)
        Me.Controls.Add(Me.pgbStatus)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblKeyFileName)
        Me.Controls.Add(Me.btnSaveKeyFileAs)
        Me.Controls.Add(Me.btnGenKeyFile)
        Me.Controls.Add(Me.txtKeyFile)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "frmGenKeys"
        Me.Text = "Create New 10d Keys"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sfdKeyFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtKeyFile As System.Windows.Forms.TextBox
    Friend WithEvents btnGenKeyFile As System.Windows.Forms.Button
    Friend WithEvents btnSaveKeyFileAs As System.Windows.Forms.Button
    Friend WithEvents lblKeyFileName As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pgbStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents ddlKeySize As ComboBox
    Friend WithEvents lblKeySize As Label
End Class
