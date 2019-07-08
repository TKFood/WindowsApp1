

Public Class Main
    Public Dss As New DataSet
    Public PRTOPENED As Boolean
    Private Sub 門市促銷活動查詢ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 門市促銷活動查詢ToolStripMenuItem.Click
        Dim POM As PoMo = New PoMo()
        If POM.Created = True Then
            'MsgBox("Form2已经在运行！")
        Else
            If PoMo.Created = True Then
                '    MsgBox("Form2已经在运行！")
            Else
                PoMo.MdiParent = Me
                PoMo.Show()
            End If
        End If
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dss = Nothing
        PRTOPENED = False
    End Sub

    Private Sub 門市戰情分析ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 門市戰情分析ToolStripMenuItem.Click
        Dim INFM As INFFM = New INFFM()
        If INFM.Created = True Then
            'MsgBox("Form2已经在运行！")
        Else
            If INFM.Created = True Then
                '    MsgBox("Form2已经在运行！")
            Else
                INFM.MdiParent = Me
                INFM.Show()
            End If
        End If
    End Sub
End Class