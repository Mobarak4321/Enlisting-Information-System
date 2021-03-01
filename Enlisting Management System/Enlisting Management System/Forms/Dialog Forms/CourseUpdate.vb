Imports System.Data.OleDb

Public Class CourseUpdate

    Private Sub CourseUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox33.Text = IDCourse
        TextBox34.Text = CourseCode
        TextBox35.Text = Description
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox34.Text.Trim <> "" Or TextBox35.Text.Trim <> "" Then

            Call Connection()


            sql = "UPDATE CourseTbl SET [CourseCode] = '" & TextBox34.Text & "', [Description] = '" & TextBox35.Text & "' WHERE [ID] = " & TextBox33.Text & ""
            cmd = New OleDbCommand(sql, cnn)
            cnn.Open()

            Try

                cmd.ExecuteNonQuery()
                cmd.Dispose()
                MsgBox("Successfully Updated")
                cnn.Close()
                Me.Close()

            Catch ex As Exception
                MsgBox("error found ;" & ex.Message & ex.StackTrace)
            Finally
                cnn.Close()
            End Try

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Dispose()
        Me.Hide()
    End Sub
End Class