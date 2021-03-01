Imports System.Data.OleDb

Public Class AdminLogin

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim provider As String
        Dim datafile As String
        Dim connstring As String
        Dim myconnection As OleDbConnection = New OleDbConnection

        provider = "Provider=Microsoft.JET.OLEDB.4.0; Data Source="
        datafile = "/../SystemDb.mdb"
        connstring = provider & CurDir() & datafile
        myconnection.ConnectionString = connstring

        myconnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM UserTbl WHERE [Status] = 'Activate' AND [Position] = 'Admin' AND [Username] = '" & TextBox1.Text & "' AND [Password] = '" & TextBox2.Text & "'", myconnection)
        Dim dr As OleDbDataReader = cmd.ExecuteReader

        Dim userFound As Boolean = False

        Dim Username As String = ""
        Dim Password As String = ""
        Dim Position As String = ""
        Dim Status As String = ""

        While dr.Read
            userFound = True

            Username = dr("Username").ToString
            Password = dr("Password").ToString
            Position = dr("Position").ToString
            Status = dr("Status").ToString
        End While

        If userFound = True Then
            Home.Hide()
            Me.Hide()
            MainMenuAdmin.Show()

            myconnection.Close()

        Else
            MsgBox("Sorry, Username or Password not found", MsgBoxStyle.OkOnly, "Invalid Login")
            myconnection.Close()
        End If

        TextBox1.Text = "Username"
        TextBox2.Text = "Password"

    End Sub
End Class