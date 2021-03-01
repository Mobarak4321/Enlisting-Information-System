Imports System.Data.OleDb

Public Class Course



    Private Sub Course_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_list()
    End Sub

    Sub Load_list()

        Call Connection()

        ListView1.Items.Clear()

        Try
            sql = "SELECT * from CourseTbl"
            cmd = New OleDbCommand(sql, cnn)
            cnn.Open()

            reader = cmd.ExecuteReader

            While reader.Read

                Dim lv As ListViewItem = ListView1.Items.Add(reader.Item(0).ToString)
                lv.SubItems.Add(reader.Item(1).ToString)
                lv.SubItems.Add(reader.Item(2).ToString)



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
        CourseAdd.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListView1.Items.Count > 0 Then

            IDCourse = ListView1.FocusedItem.Text
            CourseCode = ListView1.FocusedItem.SubItems(1).Text
            Description = ListView1.FocusedItem.SubItems(2).Text
            CourseUpdate.ShowDialog()
            Call Load_list()

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ListView1.Items.Count > 0 Then

            IDCourse = ListView1.FocusedItem.Text

            Dim a = MsgBox("Do you really want to Remove this record ? " & IDCourse, MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System")

            If a = vbYes Then

                sql = "DELETE from CourseTbl WHERE ID = " & IDCourse & ""
                cnn.Open()
                cmd = New OleDbCommand(sql, cnn)

                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cnn.Close()
                MsgBox("User " & IDCourse & " Successfully Removed to the Database", MsgBoxStyle.Information)

            End If

        End If

        Call Load_list()
    End Sub
End Class