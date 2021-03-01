Imports System.Data.OleDb

Module SystemModule
    Public cnn As New OleDbConnection
    Public cmd As New OleDbCommand
    Public da As OleDbDataAdapter
    Public reader As OleDbDataReader
    Public conn_status As String
    Public sql As String
    Public UserName As String
    Public ID, Lastname, Firstname, Middlename, Address, Gender, CourseOrStrand, DateAndTime, Status As String
    Public ID2, Lastname2, Firstname2, Middlename2, Address2, Gender2, CourseOrStrand2, YearAndSection, CollegeOrSHS As String
    Public IDCourse, CourseCode, Description As String
    Public UpdateStatus As String

    Public Sub Connection()

        Try

            cnn.ConnectionString = "provider=Microsoft.JET.OLEDB.4.0; Data Source=" & CurDir() & "/../SystemDb.mdb"
            cmd.Connection = cnn
            cnn.Open()

        Catch ex As Exception

            MsgBox("Critical Error the System will shutdown error found:" & ex.Message & " Please Contact System Administrator", MsgBoxStyle.Critical)
            conn_status = "Offline"
            cnn.Close()
            End

        Finally

            cnn.Close()
            conn_status = "Online"
            MsgBox(conn_status)

        End Try

    End Sub

    Public Sub CollegeArchives()
        Call Connection()


        sql = "UPDATE CollegeListing SET [Status] = '" & ArchivedUpdate.ComboBox2.Text & "' WHERE [ID] = " & ArchivedUpdate.idtxt.Text & ""
        cmd = New OleDbCommand(sql, cnn)
        cnn.Open()

        Try

            cmd.ExecuteNonQuery()
            cmd.Dispose()
            MsgBox("Successfully Updated")
            cnn.Close()
            ArchivedUpdate.Close()

        Catch ex As Exception
            MsgBox("error found ;" & ex.Message & ex.StackTrace)
        Finally
            cnn.Close()
        End Try

    End Sub

    Public Sub SHSArchives()
        Call Connection()


        sql = "UPDATE SHSListingTbl SET [Status] = '" & ArchivedUpdate.ComboBox2.Text & "' WHERE [ID] = " & ArchivedUpdate.idtxt.Text & ""
        cmd = New OleDbCommand(sql, cnn)
        cnn.Open()

        Try

            cmd.ExecuteNonQuery()
            cmd.Dispose()
            MsgBox("Successfully Updated")
            cnn.Close()
            ArchivedUpdate.Close()

        Catch ex As Exception
            MsgBox("error found ;" & ex.Message & ex.StackTrace)
        Finally
            cnn.Close()
        End Try

    End Sub

    Public Sub CollegeSendingArchives()
        If Listing.ListView1.Items.Count > 0 Then

            ID = Listing.ListView1.FocusedItem.Text

            Dim a = MsgBox("Do you really want to move this record into Archive ? " & ID, MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System")

            If a = vbYes Then

                sql = "UPDATE CollegeListingTbl SET [Status] = 'Archived' WHERE [ID] = " & ID & ""
                cnn.Open()
                cmd = New OleDbCommand(sql, cnn)

                cmd.ExecuteNonQuery()

                cmd.Dispose()
                cnn.Close()
                MsgBox("The ID number '" & ID & "' Successfully moved to the Archives", MsgBoxStyle.Information)

                Try

                Catch ex As Exception

                End Try

            End If

        End If
    End Sub

    Public Sub SHSSendingArchives()

        If Listing.ListView1.Items.Count > 0 Then

            ID = Listing.ListView1.FocusedItem.Text

            Dim a = MsgBox("Do you really want to move this record into Archive ? " & ID, MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System")

            If a = vbYes Then

                sql = "UPDATE SHSListingTbl SET [Status] = 'Archived' WHERE [ID] = " & ID & ""
                cnn.Open()
                cmd = New OleDbCommand(sql, cnn)

                cmd.ExecuteNonQuery()

                cmd.Dispose()
                cnn.Close()
                MsgBox("The ID number '" & ID & "' Successfully moved to the Archives", MsgBoxStyle.Information)

                Try

                Catch ex As Exception

                End Try

            End If

        End If
    End Sub

End Module
