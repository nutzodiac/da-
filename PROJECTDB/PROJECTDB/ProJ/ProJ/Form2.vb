Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine

Public Class Form2
    Dim Strconn As String = "Data Source=10.199.66.228; Initial Catalog=std5830211249; Uid=std5830211249; Pwd=std5830211249;"
    Public ObjConn As New SqlConnection(Strconn)
    Dim ds As DataSet
    Dim da As SqlDataAdapter
    Dim Strdel As String
    Public strcell As String
    Dim bt As String



    Public Sub show_data()

        Dim Strquery As String
        Strquery = "Select bill_id,Bill_date,Bill_time,Menu_Name,Amount"
        Strquery += " FROM BILL_TABLE INNER JOIN Menu_TABLE ON(BILL_TABLE.Menu_id = Menu_TABLE.Menu_id)"
        Strquery += "INNER JOIN BILLTYPE_TABLE ON (BILL_TABLE.BT_ID = BILLTYPE_TABLE.BT_ID) "
        da = New SqlClient.SqlDataAdapter(Strquery, ObjConn)
        ds = New DataSet
        da.Fill(ds, "BILL_TABLE")
        DataGridView2.DataMember = "BILL_TABLE"
        DataGridView2.DataSource = ds

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ส่วน ใส่เลขที่บิล 
        Dim a As Integer = 1

        Label2.Text = DateTimePicker1.Value.ToLongDateString()
        a = a + 1

        show_data()

        DataGridView2.Columns(0).Width = 50
        DataGridView2.Columns(1).Width = 100
        DataGridView2.Columns(2).Width = 100
        DataGridView2.Columns(3).Width = 100
        DataGridView2.Columns(4).Width = 50

        DataGridView2.Columns(3).HeaderText = "รายละเอียด"
        DataGridView2.Columns(4).HeaderText = "ราคารวม"
        DataGridView2.Columns(2).HeaderText = "เวลา"
        DataGridView2.Columns(1).HeaderText = "วันที่"
        DataGridView2.Columns(0).HeaderText = "รายการบิลที่"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Strquery As String
       


        Strquery = "Select bill_id,Bill_date,Bill_time,Menu_Name,Amount"
        Strquery += " FROM BILL_TABLE INNER JOIN Menu_TABLE ON(BILL_TABLE.Menu_id = Menu_TABLE.Menu_id)"
        Strquery += "INNER JOIN BILLTYPE_TABLE ON (BILL_TABLE.BT_ID = BILLTYPE_TABLE.BT_ID) Where BILL_TABLE.BT_ID = '" + bt + "';  "
        da = New SqlClient.SqlDataAdapter(Strquery, ObjConn)
        ds = New DataSet
        da.Fill(ds, "BILL_TABLE")
        DataGridView2.DataMember = "BILL_TABLE"
        DataGridView2.DataSource = ds


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rpt As New ReportDocument()
        Dim directory As String = My.Application.Info.DirectoryPath

        rpt.Load("C:\Users\LUPANG\Desktop\PROJECTDB\PROJECTDB\ProJ\ProJ\Billreport.rpt")
        rpt.SetParameterValue("My parameter 2", bt)
        Me.CrystalReportViewer1.ReportSource = rpt
        Me.CrystalReportViewer1.Refresh()
    End Sub

    
    Private Sub rd1_CheckedChanged(sender As Object, e As EventArgs) Handles rd1.CheckedChanged
        bt = "BT01"

    End Sub

    Private Sub rd2_CheckedChanged(sender As Object, e As EventArgs) Handles rd2.CheckedChanged
        bt = "BT02"
    End Sub
End Class