Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms
Public Class PRTFM
    Private Sub PRTFM_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim rpt As New ReportDocument

        If PoMo.RadioButton10.Checked Then
            rpt.Load("CrystalReport1.rpt")
        End If
        If PoMo.RadioButton11.Checked Then
            rpt.Load("CrystalReport2.rpt")
        End If
        If PoMo.RadioButton12.Checked Then
            rpt.Load("D:\TKSOURCE\WindowsApp1\WindowsApp1\CrystalReport2.rpt")
        End If
        Dim TxtNo1 As TextObject = rpt.ReportDefinition.ReportObjects("TxtNo1")
        Dim TxtNo2 As TextObject = rpt.ReportDefinition.ReportObjects("TxtNo2")
        Dim TxtDt1 As TextObject = rpt.ReportDefinition.ReportObjects("TxtDt1")
        Dim TxtDt2 As TextObject = rpt.ReportDefinition.ReportObjects("TxtDt2")
        TxtNo1.Text = PoMo.ComboBox1.SelectedItem(0) + " - " + PoMo.ComboBox1.SelectedItem(1)
        TxtNo2.Text = PoMo.ComboBox2.SelectedItem(0) + " - " + PoMo.ComboBox2.SelectedItem(1)
        TxtDt1.Text = PoMo.DateTimePicker1.Value.ToString("yyyy/MM/dd")
        TxtDt2.Text = PoMo.DateTimePicker2.Value.ToString("yyyy/MM/dd")
        rpt.SetDataSource(Main.Dss.Tables("POSTB"))

        CrystalReportViewer1.ReportSource = rpt

        CrystalReportViewer1.Zoom(1)
    End Sub

    Private Sub PRTFM_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Main.PRTOPENED = False
        PoMo.Button1.Enabled = True
    End Sub
End Class