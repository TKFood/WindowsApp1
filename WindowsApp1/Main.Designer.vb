<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.POS門市ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.門市促銷活動查詢ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.戰情中心ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.門市戰情分析ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.POS門市ToolStripMenuItem, Me.戰情中心ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1178, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'POS門市ToolStripMenuItem
        '
        Me.POS門市ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.門市促銷活動查詢ToolStripMenuItem})
        Me.POS門市ToolStripMenuItem.Name = "POS門市ToolStripMenuItem"
        Me.POS門市ToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.POS門市ToolStripMenuItem.Text = "POS門市"
        '
        '門市促銷活動查詢ToolStripMenuItem
        '
        Me.門市促銷活動查詢ToolStripMenuItem.Name = "門市促銷活動查詢ToolStripMenuItem"
        Me.門市促銷活動查詢ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.門市促銷活動查詢ToolStripMenuItem.Text = "門市促銷活動查詢"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 553)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1178, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        '戰情中心ToolStripMenuItem
        '
        Me.戰情中心ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.門市戰情分析ToolStripMenuItem})
        Me.戰情中心ToolStripMenuItem.Name = "戰情中心ToolStripMenuItem"
        Me.戰情中心ToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.戰情中心ToolStripMenuItem.Text = "監控室"
        '
        '門市戰情分析ToolStripMenuItem
        '
        Me.門市戰情分析ToolStripMenuItem.Name = "門市戰情分析ToolStripMenuItem"
        Me.門市戰情分析ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.門市戰情分析ToolStripMenuItem.Text = "門市戰情分析"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1178, 575)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Main"
        Me.Text = " "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents POS門市ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 門市促銷活動查詢ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 戰情中心ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 門市戰情分析ToolStripMenuItem As ToolStripMenuItem
End Class
