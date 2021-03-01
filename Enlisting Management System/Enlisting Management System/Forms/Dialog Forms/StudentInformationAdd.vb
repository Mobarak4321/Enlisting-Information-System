Imports System.Data.OleDb

Public Class StudentInformationAdd

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Dispose()
        Me.Close()
    End Sub

    Sub CollegeInsert()
        If lastnametxt.Text.Trim <> "" Or firstnametxt.Text.Trim <> "" Or middletxt.Text.Trim <> "" Then


            Dim existing As Boolean

            Call Connection()

            Try
                sql = "SELECT * from StudentTbl where StudentID= '" & idtxt.Text.Trim & "'"
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

                        sql = ("INSERT INTO StudentTbl (Lastname, FirstName, Middlename, Address, Gender,CourseOrStrand,YearAndSection,CollegeOrSHS) VALUES ('" & lastnametxt.Text.Trim & "', '" & firstnametxt.Text.Trim & "','" & middletxt.Text.Trim & "','" & addresstxt.Text.Trim & "','" & ComboBox1.Text.Trim & "','" & courseOrStrandtxt.Text.Trim & "','" & yeartxt.Text & "','" & "College" & "')")
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

    Sub SHSInsert()
        If lastnametxt.Text.Trim <> "Lastname" Or firstnametxt.Text.Trim <> "Firstname" Or middletxt.Text.Trim <> "Middlename" Then

            Dim existing As Boolean

            Call Connection()

            Try
                sql = "SELECT * from StudentTbl where StudentID= '" & idtxt.Text.Trim & "'"
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

                        sql = ("INSERT INTO StudentTbl (Lastname, FirstName, Middlename, Address, Gender,CourseOrStrand,YearAndSection,CollegeOrSHS) VALUES ('" & lastnametxt.Text.Trim & "', '" & firstnametxt.Text.Trim & "','" & middletxt.Text.Trim & "','" & addresstxt.Text.Trim & "','" & ComboBox1.Text.Trim & "','" & courseOrStrandtxt.Text.Trim & "','" & yeartxt.Text & "','" & "SHS" & "')")
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RadioButton1.Enabled = True Then
            Call CollegeInsert()
        ElseIf RadioButton2.Enabled = True Then
            Call SHSInsert()

        End If
    End Sub
End Class