Imports System.Data.SqlClient
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms.DataVisualization.Charting

Public Class PoMo
    Public ConnString As String
    Public conn As New SqlConnection
    Public selectcmd As String
    Public da As New SqlDataAdapter
    Public dt As New DataTable
    Public dSS As New DataSet


    Public Function Chk_radiobt()
        ' 設計工具需要此呼叫。
        ' InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。
        For Each b As RadioButton In Me.GroupBox1.Controls.OfType(Of RadioButton)()
            If b.Checked = True Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.ComboBox1.DrawMode = DrawMode.OwnerDrawFixed
        Me.ComboBox2.DrawMode = DrawMode.OwnerDrawFixed
        Me.ComboBox3.DrawMode = DrawMode.OwnerDrawFixed
        Me.RadioButton10.Checked = True
        ConnString = "data source=192.168.1.105;UID=sa;PWD=dsc;initial catalog=TK;connect timeout=30"

        conn = New SqlConnection(ConnString)
        selectcmd = "Select MA001,MA002 FROM POSMA order by MA001 desc"

        ComboBox3.Enabled = False

        Try
            conn.Open()

            Dim da As New System.Data.SqlClient.SqlDataAdapter(selectcmd, ConnString)
            Dim ds As New DataSet
            da.Fill(ds, "POSMA")
            With Me.ComboBox1
                .DataSource = ds.Tables("POSMA")
                .DisplayMember = "MA001"
                .ValueMember = "MA001"
                .SelectedIndex = 0
            End With

        Catch ex As Exception
            Exit Sub
        End Try
        conn.Close()
        selectcmd = "Select MA001,MA002 FROM WSCMA order by MA001"
        Try
            conn.Open()
            Dim dk As New System.Data.SqlClient.SqlDataAdapter(selectcmd, ConnString)
            Dim dx As New DataSet
            dk.Fill(dx, "WSCMA")
            With Me.ComboBox3
                .DataSource = dx.Tables("WSCMA")
                .DisplayMember = "MA001"
                .ValueMember = "MA001"
                .SelectedIndex = 0
            End With
        Catch ex As Exception
            Exit Sub
        End Try
        conn.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Text = ComboBox1.SelectedItem(1)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Button1.Enabled = False


        Dim myadapter As New SqlDataAdapter()

        Dim DScmdsql As SqlCommand = New SqlCommand()

        '   ComboBox3.Enabled = False

        'If Chk_radiobt() = False Then
        'MsgBox("請先選擇促銷活動方案，謝謝!!")
        'Me.Button1.Enabled = True
        ' Exit Sub
        'End If

        '  If TextBox2.Text = "" Then
        '  MsgBox("請先選擇特價代號，謝謝!!")
        ' Me.Button1.Enabled = True
        ' Exit Sub
        '  End If


        DataGridView1.Columns.Clear()
        'DataGridView1.Refresh()

        conn = New SqlConnection(ConnString)

        With DScmdsql.Parameters
            .AddWithValue("@Sdate", DateTimePicker1.Value.ToString("yyyyMMdd"))
            .AddWithValue("@Edate", DateTimePicker2.Value.ToString("yyyyMMdd"))
            .AddWithValue("@MTB034", ComboBox1.SelectedItem(0))
            .AddWithValue("@MTB036", ComboBox2.SelectedItem(0))
        End With

        If RadioButton12.Checked = True Then
            With DScmdsql.Parameters
                .AddWithValue("@PSTATION", ComboBox3.SelectedItem(0))
            End With

        End If

        DScmdsql.CommandText = SQLSTRing()
        DScmdsql.Connection = conn
        DScmdsql.CommandTimeout = 0

        myadapter.SelectCommand = DScmdsql
        Try
            '	conn.Open()
            '   Dim da As New System.Data.SqlClient.SqlDataAdapter(selectcmd, ConnString)
            '   Dim DSS As New DataSet
            Dim dds As New DataSet
            myadapter.Fill(dds, "POSTB")
            dSS = dds
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DataGridView1.ColumnHeadersHeight = 30
            DataGridView1.DataSource = dds         '將DataSet的資料載入到GridView1內
            DataGridView1.DataMember = "POSTB"
            DataGridView1.Columns("活動代號").Visible = False
            DataGridView1.Columns("特價代號").Visible = False


            DataGridView1.Columns("活動品號").Width = 110


            DataGridView1.Columns("銷售總數量").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DataGridView1.Columns("銷售總數量").DefaultCellStyle.Format = "###,###,##0.00"
            DataGridView1.Columns("銷售總數量").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns("銷售總數量").Width = 100
            DataGridView1.Columns("原價銷售總額").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns("原價銷售總額").Width = 110
            DataGridView1.Columns("促銷折價總額").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns("促銷折價總額").Width = 110
            DataGridView1.Columns("促銷銷售總額").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns("促銷銷售總額").Width = 110
            DataGridView1.Columns("加購數量").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns("加購數量").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns("加購數量").Width = 80
            DataGridView1.Columns("加購折價金額").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns("加購折價金額").Width = 110
            DataGridView1.Columns("加購銷售總額").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns("加購銷售總額").Width = 110
            DataGridView1.Columns("贈品數量").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns("贈品數量").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns("贈品數量").Width = 80
            DataGridView1.Columns("贈品折價金額").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns("贈品折價金額").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns("贈品折價金額").Width = 110
            If Me.RadioButton11.Checked Or Me.RadioButton12.Checked Then
                DataGridView1.Columns("門市代號").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridView1.Columns("門市代號").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DataGridView1.Columns("門市代號").Width = 90
                DataGridView1.Columns("商品名稱").Width = 230
            Else
                DataGridView1.Columns("商品名稱").Width = 250

            End If

        Catch ex As Exception
            Exit Sub
        End Try
        '刷新圖表
        '============================================================================================================
        If Me.RadioButton11.Checked = False Then

            If Me.RadioButton12.Checked Then
                Me.Chart1.Titles("Title1").Text = ComboBox3.SelectedItem(1)
            Else
                Me.Chart1.Titles("Title1").Text = "門市促銷活動"
            End If

            Me.Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -45

            Me.Chart1.Series("產品銷售量").IsValueShownAsLabel = True
            Me.Chart1.Series("產品銷售量").Points.Clear()
            For Each row As DataRow In dSS.Tables("POSTB").Rows

                Me.Chart1.Series("產品銷售量").Points.AddXY(row("商品名稱").ToString(), row("銷售總數量").ToString())
            Next
        Else
            Me.Chart1.Series("產品銷售量").Points.Clear()
        End If

        '============================================================================================================
        conn.Close()
        Me.Button1.Enabled = True

    End Sub

    Private Sub ComboBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ComboBox1.DrawItem
        e.DrawBackground()
        Dim drv As DataRowView = CType(ComboBox1.Items(e.Index), DataRowView)
        Dim MA001 As Integer = drv("MA001").ToString()
        Dim MA002 As String = drv("MA002").ToString()
        Dim r1 As Rectangle = e.Bounds
        r1.Width = r1.Width / 2
        Using sb As SolidBrush = New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(MA001, e.Font, sb, r1)
        End Using


        Using p As Pen = New Pen(Color.Black)
            e.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom)
        End Using


        Dim r2 As Rectangle = e.Bounds
        r2.X = e.Bounds.Width / 2
        r2.Width = r2.Width / 2

        Using sb As SolidBrush = New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(MA002, e.Font, sb, r2)
        End Using
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        TextBox2.Text = ""
        conn = New SqlConnection(ConnString)
        selectcmd = "Select MB003,MB004 FROM POSMB where MB008='Y' and MB001='" + Me.ComboBox1.SelectedItem(0) + "'"

        Try
            conn.Open()
            Dim da As New System.Data.SqlClient.SqlDataAdapter(selectcmd, ConnString)
            Dim ds As New DataSet
            da.Fill(ds, "POSMB")
            With Me.ComboBox2
                .DataSource = ds.Tables("POSMB")
                .DisplayMember = "MB003"
                .ValueMember = "MB003"
                .SelectedIndex = 0
            End With
        Catch ex As Exception
            Exit Sub
        End Try
        conn.Close()
        ComboBox2.Refresh()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged

    End Sub

    Private Sub RadioButton4_Click(sender As Object, e As EventArgs) Handles RadioButton4.Click
        TextBox2.Text = ""
        conn = New SqlConnection(ConnString)
        selectcmd = "Select MI003,MI004 FROM POSMI where MI015='Y' and MI001='" + Me.ComboBox1.SelectedItem(0) + "'"

        Try
            conn.Open()
            Dim da As New System.Data.SqlClient.SqlDataAdapter(selectcmd, ConnString)
            Dim ds As New DataSet
            da.Fill(ds, "POSMI")
            With Me.ComboBox2
                .DataSource = ds.Tables("POSMI")
                .DisplayMember = "MI003"
                .ValueMember = "MI003"
                .SelectedIndex = 0
            End With
        Catch ex As Exception
            Exit Sub
        End Try
        conn.Close()
        ComboBox2.Refresh()

    End Sub

    Function SQLSTRing()
        Dim SQLTXT As String
        SQLTXT = ""
        If RadioButton10.Checked = True Then
            SQLTXT = "select  POSTB.TB034 as 活動代號,POSTB.TB036 as 特價代號,POSTB.TB010 as 活動品號,INVMB.MB002 as 商品名稱,ATB.銷售總數量,ATB.原價銷售總額,ATB.促銷折價總額 ,ATB.促銷銷售總額,JO2.加購數量 ,JO2.加購折價金額 ,JO2.加購銷售總額 ,JO1.贈品數量 ,JO1.贈品折價金額    from POSTB 
inner join INVMB on POSTB.TB010=INVMB.MB001                                      
left join (Select POSTB.TB034,POSTB.TB036,POSTB.TB049,POSTB.TB010,CONVERT(NVARCHAR(20),CAST(sum(TB019) AS Money),1) as 銷售總數量, CONVERT(NVARCHAR(20),CAST(sum(TB016*TB019) AS Money),1) as 原價銷售總額,CONVERT(NVARCHAR(20),CAST(sum(TB025) AS Money),1)  as 促銷折價總額,  CONVERT(NVARCHAR(20),CAST(sum(TB033) AS Money),1)  as 促銷銷售總額  from POSTB  where (TB042='1' or TB042='2') and TB049='' and POSTB.TB034=@MTB034 and POSTB.TB036=@MTB036   and ( POSTB.TB001>=@Sdate and TB001<=@Edate)  group by TB034,TB036,TB049,TB010  ) as ATB on  POSTB.TB034=ATB.TB034 and  POSTB.TB036=ATB.TB036  and  POSTB.TB010=ATB.TB010 

left join (Select TB034,TB036,TB010 ,CONVERT(NVARCHAR(20),CAST(sum(TB019) AS Money),1) as 加購數量, sum(TB033) as 加購銷售總額,sum(TB025) as 加購折價金額 FROM POSTB  where (TB042='1' or TB042='2') and TB049='2' and TB034=@MTB034  and TB036=@MTB036 and ( TB001>=@Sdate and TB001<=@Edate) group by TB034,TB036,TB010,TB036) as JO2 on POSTB.TB034=JO2.TB034 and  POSTB.TB036=JO2.TB036  and  POSTB.TB010=JO2.TB010 

left join (Select TB034,TB036,TB010 ,CONVERT(NVARCHAR(20),CAST(sum(TB019) AS Money),1) as 贈品數量, sum(TB025) as 贈品折價金額 FROM POSTB  where TB042='3' and TB049='1' and TB034=@MTB034 and TB036=@MTB036  and ( TB001>=@Sdate and TB001<=@Edate) group by TB034,TB036,TB010) as JO1 on POSTB.TB034=JO1.TB034 and  POSTB.TB036=JO1.TB036 and  POSTB.TB010=JO1.TB010 

where POSTB.TB034=@MTB034 and POSTB.TB036=@MTB036 and ( POSTB.TB001>=@Sdate and POSTB.TB001<=@Edate) group by POSTB.TB034 ,POSTB.TB036 ,POSTB.TB010 ,INVMB.MB002 ,ATB.銷售總數量,ATB.原價銷售總額,ATB.促銷折價總額 ,ATB.促銷銷售總額,JO2.加購數量 ,JO2.加購折價金額 ,JO2.加購銷售總額 ,JO1.贈品數量 ,JO1.贈品折價金額 "

        End If

        If RadioButton11.Checked = True Then
            SQLTXT = "select POSTB.TB034 as 活動代號,POSTB.TB036 as 特價代號,POSTB.TB010 as 活動品號,INVMB.MB002 as 商品名稱,ATB.門市代號,ATB.銷售總數量,ATB.原價銷售總額,ATB.促銷折價總額 ,ATB.促銷銷售總額,JO2.加購數量 ,JO2.加購折價金額 ,JO2.加購銷售總額 ,JO1.贈品數量 ,JO1.贈品折價金額    from POSTB 
inner join INVMB on POSTB.TB010=INVMB.MB001                                      
left join (Select POSTB.TB034,POSTB.TB036,POSTB.TB049,POSTB.TB002 as 門市代號,POSTB.TB010,CONVERT(NVARCHAR(20),CAST(sum(TB019) AS Money),1) as 銷售總數量, CONVERT(NVARCHAR(20),CAST(sum(TB016*TB019) AS Money),1) as 原價銷售總額,CONVERT(NVARCHAR(20),CAST(sum(TB025) AS Money),1)  as 促銷折價總額,  CONVERT(NVARCHAR(20),CAST(sum(TB033) AS Money),1)  as 促銷銷售總額  from POSTB  where TB042 in ('1','2') and TB049='' and POSTB.TB034=@MTB034 and POSTB.TB036=@MTB036   and ( POSTB.TB001>=@Sdate and TB001<=@Edate)  group by TB034,TB036,TB049,TB010,TB002  ) as ATB on  POSTB.TB034=ATB.TB034 and  POSTB.TB036=ATB.TB036  and  POSTB.TB010=ATB.TB010 

left join (Select TB034,TB036,TB010 ,CONVERT(NVARCHAR(20),CAST(sum(TB019) AS Money),1) as 加購數量, sum(TB033) as 加購銷售總額,sum(TB025) as 加購折價金額 FROM POSTB  where TB042 in('1','2') and TB049='2' and TB034=@MTB034  and TB036=@MTB036 and ( TB001>=@Sdate and TB001<=@Edate) group by TB034,TB036,TB010,TB036) as JO2 on POSTB.TB034=JO2.TB034 and  POSTB.TB036=JO2.TB036  and  POSTB.TB010=JO2.TB010 

left join (Select TB034,TB036,TB010 ,CONVERT(NVARCHAR(20),CAST(sum(TB019) AS Money),1) as 贈品數量, sum(TB025) as 贈品折價金額 FROM POSTB  where TB042='3' and TB049='1' and TB034=@MTB034 and TB036=@MTB036  and ( TB001>=@Sdate and TB001<=@Edate) group by TB034,TB036,TB010) as JO1 on POSTB.TB034=JO1.TB034 and  POSTB.TB036=JO1.TB036 and  POSTB.TB010=JO1.TB010 

where POSTB.TB034=@MTB034 and POSTB.TB036=@MTB036 and ( POSTB.TB001>=@Sdate and POSTB.TB001<=@Edate) group by POSTB.TB034 ,POSTB.TB036 ,POSTB.TB010 ,INVMB.MB002,ATB.門市代號 ,ATB.銷售總數量,ATB.原價銷售總額,ATB.促銷折價總額 ,ATB.促銷銷售總額,JO2.加購數量 ,JO2.加購折價金額 ,JO2.加購銷售總額 ,JO1.贈品數量 ,JO1.贈品折價金額"
        End If
        If RadioButton12.Checked = True Then
            SQLTXT = "select POSTB.TB034 as 活動代號,POSTB.TB036 as 特價代號,POSTB.TB010 as 活動品號,INVMB.MB002 as 商品名稱,ATB.門市代號,ATB.銷售總數量,ATB.原價銷售總額,ATB.促銷折價總額 ,ATB.促銷銷售總額,JO2.加購數量 ,JO2.加購折價金額 ,JO2.加購銷售總額 ,JO1.贈品數量 ,JO1.贈品折價金額    from POSTB 
inner join INVMB on POSTB.TB010=INVMB.MB001                                      
left join (Select POSTB.TB034,POSTB.TB036,POSTB.TB049,POSTB.TB002 as 門市代號,POSTB.TB010,CONVERT(NVARCHAR(20),CAST(sum(TB019) AS Money),1) as 銷售總數量, CONVERT(NVARCHAR(20),CAST(sum(TB016*TB019) AS Money),1) as 原價銷售總額,CONVERT(NVARCHAR(20),CAST(sum(TB025) AS Money),1)  as 促銷折價總額,  CONVERT(NVARCHAR(20),CAST(sum(TB033) AS Money),1)  as 促銷銷售總額  from POSTB  where TB042 in ('1','2') and TB049='' and POSTB.TB034=@MTB034 and POSTB.TB036=@MTB036 and POSTB.TB002=@PSTATION  and ( POSTB.TB001>=@Sdate and TB001<=@Edate)  group by TB034,TB036,TB049,TB010,TB002  ) as ATB on  POSTB.TB034=ATB.TB034 and  POSTB.TB036=ATB.TB036  and  POSTB.TB010=ATB.TB010 

left join (Select TB034,TB036,TB010 ,CONVERT(NVARCHAR(20),CAST(sum(TB019) AS Money),1) as 加購數量, sum(TB033) as 加購銷售總額,sum(TB025) as 加購折價金額 FROM POSTB  where TB042 in('1','2') and TB049='2' and TB034=@MTB034  and TB036=@MTB036 and ( TB001>=@Sdate and TB001<=@Edate) group by TB034,TB036,TB010,TB036) as JO2 on POSTB.TB034=JO2.TB034 and  POSTB.TB036=JO2.TB036  and  POSTB.TB010=JO2.TB010 

left join (Select TB034,TB036,TB010 ,CONVERT(NVARCHAR(20),CAST(sum(TB019) AS Money),1) as 贈品數量, sum(TB025) as 贈品折價金額 FROM POSTB  where TB042='3' and TB049='1' and TB034=@MTB034 and TB036=@MTB036 and TB002=@PSTATION and ( TB001>=@Sdate and TB001<=@Edate) group by TB034,TB036,TB010) as JO1 on POSTB.TB034=JO1.TB034 and  POSTB.TB036=JO1.TB036 and  POSTB.TB010=JO1.TB010 

where POSTB.TB034=@MTB034 and POSTB.TB036=@MTB036 and ( POSTB.TB001>=@Sdate and POSTB.TB001<=@Edate) group by POSTB.TB034 ,POSTB.TB036 ,POSTB.TB010 ,INVMB.MB002,ATB.門市代號,ATB.銷售總數量,ATB.原價銷售總額,ATB.促銷折價總額 ,ATB.促銷銷售總額,JO2.加購數量 ,JO2.加購折價金額 ,JO2.加購銷售總額 ,JO1.贈品數量 ,JO1.贈品折價金額"
        End If


        Return SQLTXT

    End Function

    Private Sub ComboBox3_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ComboBox3.DrawItem
        e.DrawBackground()
        Dim drv As DataRowView = CType(ComboBox3.Items(e.Index), DataRowView)
        Dim MA001 As Integer = drv("MA001").ToString()
        Dim MA002 As String = drv("MA002").ToString()
        Dim r1 As Rectangle = e.Bounds
        r1.Width = r1.Width - Int(r1.Width / 3) * 2
        Using sb As SolidBrush = New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(MA001, e.Font, sb, r1)
        End Using


        Using p As Pen = New Pen(Color.Black)
            e.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom)
        End Using


        Dim r2 As Rectangle = e.Bounds
        r2.X = Int(e.Bounds.Width / 3)
        r2.Width = Int(r2.Width / 3) * 2

        Using sb As SolidBrush = New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(MA002, e.Font, sb, r2)
        End Using
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        TextBox3.Text = ComboBox3.SelectedItem(1)
    End Sub


    Private Sub RadioButton10_Click(sender As Object, e As EventArgs) Handles RadioButton10.Click
        ComboBox3.Enabled = False
    End Sub

    Private Sub RadioButton11_Click(sender As Object, e As EventArgs) Handles RadioButton11.Click
        ComboBox3.Enabled = False
    End Sub

    Private Sub RadioButton12_Click(sender As Object, e As EventArgs) Handles RadioButton12.Click
        ComboBox3.Enabled = True
    End Sub


    Private Sub RadioButton5_Click(sender As Object, e As EventArgs) Handles RadioButton5.Click
        conn = New SqlConnection(ConnString)
        TextBox2.Text = ""
        selectcmd = "Select MO003,MO004 FROM POSMO where MO008='Y' and MO001='" + Me.ComboBox1.SelectedItem(0) + "'"

        Try
            conn.Open()
            Dim da As New System.Data.SqlClient.SqlDataAdapter(selectcmd, ConnString)
            Dim ds As New DataSet
            da.Fill(ds, "POSMO")
            With Me.ComboBox2
                .DataSource = ds.Tables("POSMO")
                .DisplayMember = "MO003"
                .ValueMember = "MO003"
                .SelectedIndex = 0
            End With
        Catch ex As Exception
            Exit Sub
        End Try
        conn.Close()
        ComboBox2.Refresh()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        TextBox2.Text = ComboBox2.SelectedItem(1)
    End Sub

    Private Sub ComboBox2_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ComboBox2.DrawItem
        e.DrawBackground()
        Dim drv As DataRowView = CType(ComboBox2.Items(e.Index), DataRowView)
        If Me.RadioButton1.Checked Then
            Dim MB003 As String = drv("MB003").ToString()
            Dim MB004 As String = drv("MB004").ToString()
            'Dim MB003 As String = drv("MB003").ToString()
            Dim r1 As Rectangle = e.Bounds
            r1.Width = r1.Width - Int(r1.Width / 3) * 2
            Using sb As SolidBrush = New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(MB003, e.Font, sb, r1)
            End Using

            Using p As Pen = New Pen(Color.Black)
                e.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom)
            End Using

            Dim r2 As Rectangle = e.Bounds
            r2.X = Int(e.Bounds.Width / 3)
            r2.Width = Int(r2.Width / 3) * 2

            Using sb As SolidBrush = New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(MB004, e.Font, sb, r2)
            End Using

            'Dim r3 As Rectangle = e.Bounds
            'r3.X = e.Bounds.Width / 3
            'r3.Width = r3.Width / 3

            'Using sb As SolidBrush = New SolidBrush(e.ForeColor)
            'e.Graphics.DrawString(MC003, e.Font, sb, r3)
            'End Using

        End If

        If Me.RadioButton4.Checked Then
            Dim MI003 As String = drv("MI003").ToString()
            Dim MI004 As String = drv("MI004").ToString()
            'Dim MB003 As String = drv("MB003").ToString()
            Dim r1 As Rectangle = e.Bounds
            r1.Width = r1.Width - Int(r1.Width / 3) * 2
            Using sb As SolidBrush = New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(MI003, e.Font, sb, r1)
            End Using

            Using p As Pen = New Pen(Color.Black)
                e.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom)
            End Using

            Dim r2 As Rectangle = e.Bounds
            r2.X = Int(e.Bounds.Width / 3)
            r2.Width = Int(r2.Width / 3) * 2

            Using sb As SolidBrush = New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(MI004, e.Font, sb, r2)
            End Using

            'Dim r3 As Rectangle = e.Bounds
            'r3.X = e.Bounds.Width / 3
            'r3.Width = r3.Width / 3

            'Using sb As SolidBrush = New SolidBrush(e.ForeColor)
            'e.Graphics.DrawString(MC003, e.Font, sb, r3)
            'End Using

        End If

        If Me.RadioButton5.Checked Then
            Dim MO003 As String = drv("MO003").ToString()
            Dim MO004 As String = drv("MO004").ToString()
            'Dim MB003 As String = drv("MB003").ToString()
            Dim r1 As Rectangle = e.Bounds
            r1.Width = r1.Width - Int(r1.Width / 3) * 2
            Using sb As SolidBrush = New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(MO003, e.Font, sb, r1)
            End Using

            Using p As Pen = New Pen(Color.Black)
                e.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom)
            End Using

            Dim r2 As Rectangle = e.Bounds
            r2.X = Int(e.Bounds.Width / 3)
            r2.Width = Int(r2.Width / 3) * 2

            Using sb As SolidBrush = New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(MO004, e.Font, sb, r2)
            End Using

            'Dim r3 As Rectangle = e.Bounds
            'r3.X = e.Bounds.Width / 3
            'r3.Width = r3.Width / 3

            'Using sb As SolidBrush = New SolidBrush(e.ForeColor)
            'e.Graphics.DrawString(MC003, e.Font, sb, r3)
            'End Using

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = ComboBox2.SelectedItem(1)
    End Sub
End Class
