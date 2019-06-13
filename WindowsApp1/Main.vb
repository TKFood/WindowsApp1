Public Class Main
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
End Class