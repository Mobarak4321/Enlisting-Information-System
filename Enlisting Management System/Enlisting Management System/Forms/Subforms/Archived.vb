Imports System.Data.OleDb

Public Class Archived

    Sub CollegeSearch()
        Call Connection()

        ListView1.Items.Clear()

        Try
            sql = "SELECT * from CollegeListingTbl WHERE [Status] = 'Archived' AND Lastname like '%" & TextBox6.Text.Trim & "%' or FirstName like '%" & TextBox6.Text.Trim & "%' or Middlename like '%" & TextBox6.Text.Trim & "%'"
            cmd = New OleDbCommand(sql, cnn)
            cnn.Open()

            reader = cmd.ExecuteReader

            While reader.Read

                Dim lv As ListViewItem = ListView1.Items.Add(reader.Item(0).ToString)
                lv.SubItems.Add(reader.Item(1).ToString)
                lv.SubItems.Add(reader.Item(2).ToString)
                lv.SubItems.Add(reader.Item(3).ToString)
                lv.SubItems.Add(reader.Item(4).ToString)
                lv.SubItems.Add(reader.Item(5).ToString)
                lv.SubItems.Add(reader.Item(6).ToString)
                lv.SubItems.Add(reader.Item(7).ToString)
                lv.SubItems.Add(reader.Item(8).ToString)
            End While
            Label1.Text = "Total Items: " & ListView1.Items.Count

        Catch ex As Exception
            MsgBox("error found ;" & ex.Message & ex.StackTrace)
            cnn.Close()
        Finally
            cnn.Close()
        End Try
    End Sub

    Sub SHSSearch()
        Call Connection()

        ListView1.Items.Clear()

        Try
            sql = "SELECT * from SHSListingTbl WHERE [Status] = 'Archived' AND Lastname like '%" & TextBox6.Text.Trim & "%' or FirstName like '%" & TextBox6.Text.Trim & "%' or Middlename like '%" & TextBox6.Text.Trim & "%'"
            cmd = New OleDbCommand(sql, cnn)
            cnn.Open()

            reader = cmd.ExecuteReader

            While reader.Read

                Dim lv As ListViewItem = ListView1.Items.Add(reader.Item(0).ToString)
                lv.SubItems.Add(reader.Item(1).ToString)
                lv.SubItems.Add(reader.Item(2).ToString)
                lv.SubItems.Add(reader.Item(3).ToString)
                lv.SubItems.Add(reader.Item(4).ToString)
                lv.SubItems.Add(reader.Item(5).ToString)
                lv.SubItems.Add(reader.Item(6).ToString)
                lv.SubItems.Add(reader.Item(7).ToString)
                lv.SubItems.Add(reader.Item(8).ToString)

            End While
            Label1.Text = "Total Items: " & ListView1.Items.Count

        Catch ex As Exception
            MsgBox("error found ;" & ex.Message & ex.StackTrace)
            cnn.Close()
        Finally
            cnn.Close()
        End Try
    End Sub


    Sub Load_list()

        Call Connection()

        ListView1.Items.Clear()

        Try
            sql = "SELECT ID,Lastname,Firstname,Middlename,Address,Gender,Course,DateAndTime,Status FROM CollegeListingTbl WHERE Status = 'Archived' "
            cmd = New OleDbCommand(sql, cnn)
            cnn.Open()

            reader = cmd.ExecuteReader

            While reader.Read

                Dim lv As ListViewItem = ListView1.Items.Add(reader.Item(0).ToString)
                lv.SubItems.Add(reader.Item(1).ToString)
                lv.SubItems.Add(reader.Item(2).ToString)
                lv.SubItems.Add(reader.Item(3).ToString)
                lv.SubItems.Add(reader.Item(4).ToString)
                lv.SubItems.Add(reader.Item(5).ToString)
                lv.SubItems.Add(reader.Item(6).ToString)
                lv.SubItems.Add(reader.Item(7).ToString)
                lv.SubItems.Add(reader.Item(8).ToString)


            End While
            Label1.Text = "Total Items: " & ListView1.Items.Count

        Catch ex As Exception
            MsgBox("error found ;" & ex.Message & ex.StackTrace)
            cnn.Close()
        Finally
            cnn.Close()
        End Try

    End Sub

    Sub Load_list2()

        Call Connection()

        ListView1.Items.Clear()

        Try
            sql = "SELECT ID,Lastname,Firstname,Middlename,Address,Gender,Strand,DateAndTime,Status FROM SHSListingTbl WHERE Status = 'Archived' "
            cmd = New OleDbCommand(sql, cnn)
            cnn.Open()

            reader = cmd.ExecuteReader

            While reader.Read

                Dim lv As ListViewItem = ListView1.Items.Add(reader.Item(0).ToString)
                lv.SubItems.Add(reader.Item(1).ToString)
                lv.SubItems.Add(reader.Item(2).ToString)
                lv.SubItems.Add(reader.Item(3).ToString)
                lv.SubItems.Add(reader.Item(4).ToString)
                lv.SubItems.Add(reader.Item(5).ToString)
                lv.SubItems.Add(reader.Item(6).ToString)
                lv.SubItems.Add(reader.Item(7).ToString)
                lv.SubItems.Add(reader.Item(8).ToString)



            End While
            Label1.Text = "Total Items: " & ListView1.Items.Count

        Catch ex As Exception
            MsgBox("error found ;" & ex.Message & ex.StackTrace)
            cnn.Close()
        Finally
            cnn.Close()
        End Try

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Button2.Enabled = True
        Call Load_list()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Button2.Enabled = True
        Call Load_list2()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If ListView1.Items.Count > 0 Then

            ID = ListView1.FocusedItem.Text
            Lastname = ListView1.FocusedItem.SubItems(1).Text
            Firstname = ListView1.FocusedItem.SubItems(2).Text
            Middlename = ListView1.FocusedItem.SubItems(3).Text
            Address = ListView1.FocusedItem.SubItems(4).Text
            Gender = ListView1.FocusedItem.SubItems(5).Text
            CourseOrStrand = ListView1.FocusedItem.SubItems(6).Text
            Status = ListView1.FocusedItem.SubItems(8).Text
            ArchivedUpdate.ShowDialog()
            Call Load_list()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If RadioButton1.Checked = True Then
            Call CollegeSearch()
        ElseIf RadioButton2.Checked = True Then
            Call SHSSearch()
        End If
    End Sub

    Private Sub Archived_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class