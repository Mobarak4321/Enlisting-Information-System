Imports System.Data.OleDb

Public Class ListingAdd

    Sub CollegeInsert()
        If lastnametxt.Text.Trim <> "Lastname" Or firstnametxt.Text.Trim <> "Firstname" Or middlenametxt.Text.Trim <> "Middlename" Then

            Dim existing As Boolean

            Call Connection()

            Try
                sql = "SELECT * from CollegeListingTbl where Lastname= '" & Lastname & "' OR Firstname= '" & Firstname & "' OR Middlename= '" & Middlename & "'"
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

                        sql = ("INSERT INTO CollegeListingTbl (Lastname, FirstName, Middlename, Address, Gender,Course,DateAndTime,Status) VALUES ('" & lastnametxt.Text.Trim & "', '" & firstnametxt.Text.Trim & "','" & middlenametxt.Text.Trim & "','" & addresstxt.Text.Trim & "','" & ComboBox1.Text.Trim & "','" & CourseOrStrandtxt.Text.Trim & "','" & Date.Now & "','" & "Incoming" & "')")
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
        If lastnametxt.Text.Trim <> "" Or firstnametxt.Text.Trim <> "" Or middlenametxt.Text.Trim <> "" Then

            Dim d As DateTime = Now
            Debug.WriteLine(d.ToLongDateString)

            Dim existing As Boolean

            Call Connection()

            Try
                sql = "SELECT * from SHSListingTbl where Lastname= '" & Lastname & "' OR Firstname= '" & Firstname & "' OR Middlename= '" & Middlename & "'"
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

                        sql = ("INSERT INTO SHSListingTbl (Lastname, FirstName, Middlename, Address, Gender,Course,DateAndTime,Status) VALUES ('" & lastnametxt.Text.Trim & "', '" & firstnametxt.Text.Trim & "','" & middlenametxt.Text.Trim & "','" & addresstxt.Text.Trim & "','" & ComboBox1.Text.Trim & "','" & CourseOrStrandtxt.Text.Trim & "','" & Label1.Text & "','" & "Incoming" & "')")
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

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        CourseOrStrandtxt.Text = "College"
        Button2.Enabled = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        CourseOrStrandtxt.Text = "Strand"
        Button2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RadioButton1.Enabled = True Then
            Call CollegeInsert()
        ElseIf RadioButton2.Enabled = True Then
            Call SHSInsert()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ListingAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = Format(Now, "MMM,d,yyyy")
    End Sub
End Class