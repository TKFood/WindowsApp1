Public Class INFFM

    Private Sub INFFM_Load(sender As Object, e As EventArgs) Handles Me.Load

        ComboBox1.Items.Add("1.門市戰情中心")
        ComboBox1.Items.Add("2.門市預購中心")

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.TextBox1.Text = Now()
    End Sub

End Class