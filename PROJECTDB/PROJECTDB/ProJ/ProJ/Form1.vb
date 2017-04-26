Imports System.Data.SqlClient
Imports System.Data

Public Class Form1

    Dim Strconn As String = "Data Source=10.199.66.228; Initial Catalog=std5830211249; Uid=std5830211249; Pwd=std5830211249;"
    Public ObjConn As New SqlConnection(Strconn)
    Dim ds As DataSet
    Dim da As SqlDataAdapter
    Dim Strdel As String
    Public strcell As String

    'ส่วนเปลี่ยนสีเวลาคลิกปุ่ม
    Dim status As Integer = 1
    Dim price As Integer
    Dim Mn As String
    Public billst As Integer  'บิลจะแอดไปเรื่อยๆ 
    Dim desc As String



    Public Sub show_data()

        Dim Strquery As String
        Strquery = "Select bill_id,Bill_date,Bill_time,Amount,Menu_Name"
        Strquery += " FROM BILL_TABLE INNER JOIN Menu_TABLE ON(BILL_TABLE.bill_id = Menu_TABLE.Menu_id)"
        Strquery += "INNER JOIN BILLTYPE_TABLE ON (BILL_TABLE.BT_ID = BILLTYPE_TABLE.BT_ID) "
        da = New SqlClient.SqlDataAdapter(Strquery, ObjConn)
        ds = New DataSet
        da.Fill(ds, "BILL")
        DataGridView1.DataMember = "BILL"
        DataGridView1.DataSource = ds
    End Sub


    
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load





        Txtname.Text = ""
        TxtCar.Text = ""
        Txttel.Text = ""

        DataGridView1.ColumnCount = 5

        DataGridView1.Columns(0).Width = 50
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Width = 50
        DataGridView1.Columns(4).Width = 100

        DataGridView1.Columns(4).Name = "ทะเบียนรถ"
        DataGridView1.Columns(3).Name = "ชื่อ"
        DataGridView1.Columns(2).Name = "เบอร์โทรศัพท์"
        DataGridView1.Columns(1).Name = "รายละเอียด"
        DataGridView1.Columns(0).Name = "ราคา"

        ' DateTimePicker1.Format = DateTimePickerFormat.Custom
        ' DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        Label10.Text = DateTimePicker1.Value.ToLongDateString()


        Label11.Text = billst.ToString()



    End Sub





    'ส่วนเอาข้อมูลเข้า DATAGRIDVIEW

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Dim row As String() = New String() {price.ToString, desc, Txttel.Text, Txtname.Text, TxtCar.Text}
        DataGridView1.Rows.Add(row)
        Button1.BackColor = Color.White
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Button4.BackColor = Color.White
        Button5.BackColor = Color.White
        Dim a As Integer = 0
        Dim sum As Integer = 0
        For i As Integer = 1 To DataGridView1.RowCount() - 1
            'ส่วนคำนวณ datagridview 
            Txtprice.Text = DataGridView1.Rows(i - 1).Cells("ราคา").Value
            Dim str = Txtprice.Text
            a = CDbl(str)
            sum += a

            'โชว์ตัวเลข
            Txtprice.Text = sum.ToString()
        Next
       

    End Sub

    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If status = 1 Then
            Button1.BackColor = Color.LightGreen
            status = 0
        ElseIf status = 0 Then
            Button1.BackColor = Color.White
            status = 1
        End If

        price = 200
        Mn = "M01"
        desc = "ล้างสี-ดูดฝุ่น"

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If status = 1 Then
            Button2.BackColor = Color.LightGreen
            status = 0
        ElseIf status = 0 Then
            Button2.BackColor = Color.White
            status = 1
        End If
        price = 500
        Mn = "M02"
        desc = "ขัดเคลือบสีทั้งคัน"

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If status = 1 Then
            Button3.BackColor = Color.LightGreen
            status = 0
        ElseIf status = 0 Then
            Button3.BackColor = Color.White
            status = 1
        End If


        price = 60
        Mn = "M03"
        desc = "ล้างรถมอเตอร์ไซต์"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If status = 1 Then
            Button4.BackColor = Color.LightGreen
            status = 0
        ElseIf status = 0 Then
            Button4.BackColor = Color.White
            status = 1
        End If
        price = 200
        Mn = "M04"
        desc = "ล้างห้องเครือง"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If status = 1 Then
            Button5.BackColor = Color.LightGreen
            status = 0
        ElseIf status = 0 Then
            Button5.BackColor = Color.White
            status = 1
        End If
        price = 500
        Mn = "M05"
        desc = "ล้างยางมะตอย"
    End Sub

    'โชว์ FROM 2
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form2.Show()
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim CurRow As Integer
        CurRow = Me.DataGridView1.CurrentRow.Index
        If Me.DataGridView1.Rows.Count <> 1 Then
            Dim Result As MsgBoxResult
            Result = MessageBox.Show("ต้องการลบรายการนี้หรือไม่", "ยืนยัน", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                Me.DataGridView1.Rows.RemoveAt(CurRow)
            End If
        End If

    End Sub
    'ลบข้อมูลใน DATAGRIDVIEW
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim CurRow As Integer
        CurRow = Me.DataGridView1.CurrentRow.Index



    End Sub

    Private Sub Txtprice_TextChanged(sender As Object, e As EventArgs) Handles Txtprice.TextChanged
        TextBox4.Text = Txtprice.Text
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        
        If TextBox5.Text = "" Then

            MessageBox.Show("กรุณาใส่ส่วนลด", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim sum As Integer
            Dim str As String = TextBox5.Text
            Dim a As Integer
            a = CInt(str)
            Dim str2 As String = TextBox4.Text
            Dim b As Integer
            b = CInt(str2)
            sum = b * (a / 100)
            sum = b - sum
            TextBox6.Text = sum.ToString()
            Txtprice.Text = sum.ToString()
        End If
    End Sub
    'ส่วนเพิ่มเข้าฐานข้อมูล 
    Private Sub btnadddata_Click(sender As Object, e As EventArgs) Handles btnadddata.Click
        Dim str As String
        If ObjConn.State = ConnectionState.Closed Then

            ObjConn.Open()
        End If
        str = "Insert Into Customer_table values ('" + TxtCar.Text + "','" + Txtname.Text + "','" + Txttel.Text + "');"
        

        Dim cmd = New SqlClient.SqlCommand(str, ObjConn)

        Try
            cmd.ExecuteNonQuery()


            MessageBox.Show("เพิ่มข้อมูลได้สำเร็จ", "ผลการดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.ToString())

        End Try



        Dim strbill As String




        For i As Integer = 1 To DataGridView1.RowCount() - 1
            Dim price As String = DataGridView1.Rows(i - 1).Cells("ราคา").Value.ToString()

            If DataGridView1.Rows(i - 1).Cells("รายละเอียด").Value.ToString() = "ล้างสี-ดูดฝุ่น" Then
                Mn = "M01"
                strbill = "Insert Into BILL_TABLE values ('" + Label11.Text + "','" + Label10.Text + "','" + TimeOfDay.TimeOfDay.ToString() + "','" + price + "','" + TxtCar.Text + "','" + "BT01" + "','" + Mn + "','" + "000" + "');"
                Dim cmd2 = New SqlClient.SqlCommand(strbill, ObjConn)
                cmd2.ExecuteNonQuery()
                billst += 1
                Label11.Text = billst.ToString()
            ElseIf DataGridView1.Rows(i - 1).Cells("รายละเอียด").Value.ToString() = "ขัดเคลือบสีทั้งคัน" Then
                Mn = "M02"
                strbill = "Insert Into BILL_TABLE values ('" + Label11.Text + "','" + Label10.Text + "','" + TimeOfDay.TimeOfDay.ToString() + "','" + price + "','" + TxtCar.Text + "','" + "BT01" + "','" + Mn + "','" + "000" + "');"
                Dim cmd2 = New SqlClient.SqlCommand(strbill, ObjConn)
                cmd2.ExecuteNonQuery()
                billst += 1
                Label11.Text = billst.ToString()
            ElseIf DataGridView1.Rows(i - 1).Cells("รายละเอียด").Value.ToString() = "ล้างรถมอเตอร์ไซต์" Then
                Mn = "M03"
                strbill = "Insert Into BILL_TABLE values ('" + Label11.Text + "','" + Label10.Text + "','" + TimeOfDay.TimeOfDay.ToString() + "','" + price + "','" + TxtCar.Text + "','" + "BT01" + "','" + Mn + "','" + "000" + "');"
                Dim cmd2 = New SqlClient.SqlCommand(strbill, ObjConn)
                cmd2.ExecuteNonQuery()
                billst += 1
                Label11.Text = billst.ToString()
            ElseIf DataGridView1.Rows(i - 1).Cells("รายละเอียด").Value.ToString() = "ล้างห้องเครือง" Then
                Mn = "M04"
                strbill = "Insert Into BILL_TABLE values ('" + Label11.Text + "','" + Label10.Text + "','" + TimeOfDay.TimeOfDay.ToString() + "','" + price + "','" + TxtCar.Text + "','" + "BT01" + "','" + Mn + "','" + "000" + "');"
                Dim cmd2 = New SqlClient.SqlCommand(strbill, ObjConn)
                cmd2.ExecuteNonQuery()
                billst += 1
                Label11.Text = billst.ToString()
            ElseIf DataGridView1.Rows(i - 1).Cells("รายละเอียด").Value.ToString() = "ล้างยางมะตอย" Then
                Mn = "M05"
                strbill = "Insert Into BILL_TABLE values ('" + Label11.Text + "','" + Label10.Text + "','" + TimeOfDay.TimeOfDay.ToString() + "','" + price + "','" + TxtCar.Text + "','" + "BT01" + "','" + Mn + "','" + "000" + "');"
                Dim cmd2 = New SqlClient.SqlCommand(strbill, ObjConn)
                cmd2.ExecuteNonQuery()
                billst += 1
                Label11.Text = billst.ToString()
            End If


        Next


        MessageBox.Show("เพิ่มข้อมูลได้สำเร็จ", "ผลการดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        DataGridView1.Rows.Clear()
        Txtprice.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TxtCar.Text = ""
        Txtname.Text = ""
        Txttel.Text = ""
        ObjConn.Close()

        Me.Refresh()



    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form3.Show()
    End Sub

    Private Sub Label10_TextChanged(sender As Object, e As EventArgs) Handles Label10.TextChanged
        billst = 1
    End Sub
End Class
