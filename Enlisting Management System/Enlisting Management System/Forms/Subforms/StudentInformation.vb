Imports System.Data.OleDb

Public Class StudentInformation



    Sub Load_list()

        Call Connection()

        ListView1.Items.Clear()

        Try
            sql = "SELECT StudentID,Lastname,Firstname,Middlename,CourseOrStrand,YearAndSection from StudentTbl WHERE CollegeOrSHS ='College' "
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
            sql = "SELECT StudentID,Lastname,Firstname,Middlename,CourseOrStrand,YearAndSection from StudentTbl WHERE CollegeOrSHS ='SHS' "
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
        Call Load_list()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Call Load_list2()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Call Connection()

        ListView1.Items.Clear()

        Try
            sql = "SELECT * from StudentTbl  where StudentID like '%" & searchbtn1.Text.Trim & "%' or FirstName like '%" & searchbtn1.Text.Trim & "%' or LastName like '%" & searchbtn1.Text.Trim & "%' or MiddleName like '%" & searchbtn1.Text.Trim & "%'"
            cmd = New OleDbCommand(sql, cnn)
            cnn.Open()

            reader = cmd.ExecuteReader

            While reader.Read

                Dim lv As ListViewItem = ListView1.Items.Add(reader.Item(0).ToString)
                lv.SubItems.Add(reader.Item(1).ToString)
                lv.SubItems.Add(reader.Item(2).ToString)
                lv.SubItems.Add(reader.Item(3).ToString)
                lv.SubItems.Add(reader.Item(4).ToString)

            End While
            Label1.Text = "Total Items: " & ListView1.Items.Count

        Catch ex As Exception
            MsgBox("error found ;" & ex.Message & ex.StackTrace)
            cnn.Close()
        Finally
            cnn.Close()
        End Try

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        StudentInformationAdd.ShowDialog()
        Call Load_list()
        Call Load_list2()
    End Sub

    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListView1.Items.Count > 0 Then

            ID2 = ListView1.FocusedItem.Text
            Lastname2 = ListView1.FocusedItem.SubItems(1).Text
            Firstname2 = ListView1.FocusedItem.SubItems(2).Text
            Middlename2 = ListView1.FocusedItem.SubItems(3).Text
            CourseOrStrand2 = ListView1.FocusedItem.SubItems(4).Text
            YearAndSection = ListView1.FocusedItem.SubItems(5).Text
            StudentInformationUpdate.ShowDialog()
            Call Load_list()

        End If
    End Sub
End Class