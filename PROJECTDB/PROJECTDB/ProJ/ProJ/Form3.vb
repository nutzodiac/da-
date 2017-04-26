Imports System.Data.SqlClient
Imports System.Data


Public Class Form3



    Dim Strconn As String = "Data Source=10.199.66.228; Initial Catalog=std5830211249; Uid=std5830211249; Pwd=std5830211249;"
    Public ObjConn As New SqlConnection(Strconn)
    Dim ds As DataSet
    Dim da As SqlDataAdapter


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd/MM/yyyy"

        Label4.Text = DateTimePicker1.Value.ToLongDateString()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String
        If ObjConn.State = ConnectionState.Closed Then

            ObjConn.Open()
        End If
        str = "Insert Into Bill_Table (Bill_ID, Bill_date,Bill_time,Amount,BT_ID,Emp_ID) Values ('" + Form1.billst.ToString() + "','" + Label4.Text + "','" + TimeOfDay.TimeOfDay.ToString() + "','" + TextBox3.Text + "','" + "BT02" + "','" + txtemp.Text + "');"


        'INSERT INTO table_name (column1, column2, column3, ...)
        '           VALUES (value1, value2, value3, ...);
        Dim cmd = New SqlClient.SqlCommand(str, ObjConn)

        Try
            cmd.ExecuteNonQuery()


            MessageBox.Show("เพิ่มข้อมูลได้สำเร็จ", "ผลการดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.ToString())

        End Try


    End Sub
End Class