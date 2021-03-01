Imports System.Data.OleDb

Public Class CourseAdd

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox34.Text.Trim <> "" Or TextBox35.Text.Trim <> "" Then

            Dim existing As Boolean

            Call Connection()

            Try
                sql = "SELECT * from StudentTbl where StudentID= '" & TextBox35.Text.Trim & "'"
                cmd = New OleDbCommand(sql, cnn)
                cnn.Open()

                reader = cmd.ExecuteReader

                If reader.Read Then

                    If reader.HasRows Then

                        existing = True

                    Else

                        existing = False

                    End If

                End If

            Catch ex As Exception
                MsgBox("error found ;" & ex.Message & ex.StackTrace)
            Finally

                cnn.Close()

                If existing = False Then

                    Try

                        sql = ("INSERT INTO CourseTbl (CourseCode, Description) VALUES ('" & TextBox34.Text.Trim & "', '" & TextBox35.Text.Trim & "')")
                        cmd = New OleDbCommand(sql, cnn)
                        cnn.Open()

                        cmd.ExecuteNonQuery()

                        MsgBox("Successfully Added")
                        Me.Close()

                    Catch ex As SystemException

                        MsgBox("error " & ex.Message & " " & ex.StackTrace)

                        cnn.Close()

                    Finally

                        cnn.Close()
                        cmd.Dispose()
                        'Call Clear()

                    End Try

                Else

                    MsgBox("already registered")

                End If

            End Try

        Else

            MsgBox("fill all the blanks")

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
        Me.Hide()
    End Sub
End Class