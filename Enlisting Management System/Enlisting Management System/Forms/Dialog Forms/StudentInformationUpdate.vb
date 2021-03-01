Imports System.Data.OleDb

Public Class StudentInformationUpdate

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If idtxt.Text.Trim <> "" Then

            Call Connection()

            Try
                sql = ("UPDATE StudentTbl SET Lastname= '" & lastnametxt.Text.Trim & "', Firstname= '" & firstnametxt.Text.Trim & "', MiddleName= '" & middletxt.Text.Trim & "',Course = '" & courseOrStrandtxt.Text.Trim & "',YearAndSection = '" & yeartxt.Text.Trim & "', WHERE StudentID= '" & idtxt.Text.Trim & "'")
                cmd = New OleDbCommand(sql, cnn)
                cnn.Open()

                cmd.ExecuteNonQuery()

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

    Private Sub StudentInformationUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        idtxt.Text = ID2
        lastnametxt.Text = Lastname2
        firstnametxt.Text = Firstname2
        middletxt.Text = Middlename2
        courseOrStrandtxt.Text = CourseOrStrand2
        yeartxt.Text = YearAndSection
    End Sub
End Class