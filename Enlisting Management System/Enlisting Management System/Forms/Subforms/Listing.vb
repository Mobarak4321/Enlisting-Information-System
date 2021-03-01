Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class Listing

    Dim H As Integer
    Dim LineNumber As Integer
    Dim Lineperpage As Integer
    Dim I_Start As Integer
    Dim I_Counter As Integer

    Sub CollegeSearch()
        Call Connection()

        ListView1.Items.Clear()

        Try
            sql = "SELECT * from CollegeListingTbl WHERE [Status] = 'Incoming' AND Lastname like '%" & TextBox6.Text.Trim & "%' or FirstName like '%" & TextBox6.Text.Trim & "%' or Middlename like '%" & TextBox6.Text.Trim & "%'"
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
            sql = "SELECT * from SHSListingTbl WHERE [Status] = 'Incoming' AND Lastname like '%" & TextBox6.Text.Trim & "%' or FirstName like '%" & TextBox6.Text.Trim & "%' or Middlename like '%" & TextBox6.Text.Trim & "%'"
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
            sql = "SELECT ID,Lastname,Firstname,Middlename,Address,Course,DateAndTime from CollegeListingTbl WHERE Status = 'Incoming'"
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
            sql = "SELECT ID,Lastname,Firstname,Middlename,Address,Strand,DateAndTime from SHSListingTbl WHERE Status = 'Incoming'"
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
        Button1.Enabled = True
        Button4.Enabled = True
        Call Load_list()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Button1.Enabled = True
        Button4.Enabled = True
        Call Load_list2()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListingAdd.ShowDialog()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If RadioButton1.Checked = True Then
            Call CollegeSearch()
        ElseIf RadioButton2.Checked = True Then
            Call SHSSearch()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            Call CollegeSendingArchives()
            Call Load_list()
        ElseIf RadioButton2.Checked = True Then
            Call SHSSendingArchives()
            Call Load_list2()
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PrintDialog1.Document = PrintDocument1
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings

            Dim New_Paper As New PaperSize("", 800, 800)

            New_Paper.PaperName = PaperKind.Custom
            Dim New_Margin As New Margins
            New_Margin.Left = 0
            New_Margin.Top = 50

            With PrintDocument1
                .DefaultPageSettings.PaperSize = New_Paper
                .DefaultPageSettings.Margins = New_Margin

                .PrinterSettings.DefaultPageSettings.Landscape = False
                .Print()
            End With
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        If RadioButton1.Checked = True Then
            H = 50
            e.Graphics.DrawString("Listed for College", New Drawing.Font("Times New Roman", 12), Brushes.Blue, 320, H)

            H += 30
            e.Graphics.DrawString(Label1.Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 20, H)

            H += 20
            Dim NN As Integer = H
            e.Graphics.DrawLine(Pens.Red, 7, NN, 800, NN)

            H += 30

            e.Graphics.DrawString("Lastname", New Drawing.Font("Times New Roman", 12), Brushes.Black, 10, H)
            e.Graphics.DrawString("Firstname", New Drawing.Font("Times New Roman", 12), Brushes.Black, 120, H)
            e.Graphics.DrawString("Middlename", New Drawing.Font("Times New Roman", 12), Brushes.Black, 220, H)
            e.Graphics.DrawString("Address", New Drawing.Font("Times New Roman", 12), Brushes.Black, 340, H)
            e.Graphics.DrawString("Course", New Drawing.Font("Times New Roman", 12), Brushes.Black, 480, H)
            e.Graphics.DrawString("Date", New Drawing.Font("Times New Roman", 12), Brushes.Black, 580, H)

            H += 50

            'For Each Itm As ListViewItem In ListView1.Items
            For Me.I_Counter = I_Start To ListView1.Items.Count - 1

                'e.Graphics.DrawString(Itm.Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 50, H)
                e.Graphics.DrawString(ListView1.Items(I_Counter).SubItems(1).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 10, H)
                e.Graphics.DrawString(ListView1.Items(I_Counter).SubItems(2).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 120, H)
                e.Graphics.DrawString(ListView1.Items(I_Counter).SubItems(3).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 220, H)
                e.Graphics.DrawString(ListView1.Items(I_Counter).SubItems(4).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 340, H)
                e.Graphics.DrawString(ListView1.Items(I_Counter).SubItems(5).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 480, H)
                e.Graphics.DrawString(ListView1.Items(I_Counter).SubItems(6).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 580, H)
                H += 20

                LineNumber += 1
                If LineNumber = Lineperpage Then
                    LineNumber = 0
                    I_Start = I_Counter + 1
                    H = 50

                    e.HasMorePages = True
                    Exit For
                End If
            Next

        ElseIf RadioButton2.Checked = True Then
            H = 50
            e.Graphics.DrawString("Listed for SHS", New Drawing.Font("Times New Roman", 12), Brushes.Blue, 320, H)

            H += 30
            e.Graphics.DrawString(Label1.Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 20, H)

            H += 20
            Dim NN As Integer = H
            e.Graphics.DrawLine(Pens.Red, 7, NN, 800, NN)

            H += 30

            e.Graphics.DrawString("Lastname", New Drawing.Font("Times New Roman", 12), Brushes.Black, 10, H)
            e.Graphics.DrawString("Firstname", New Drawing.Font("Times New Roman", 12), Brushes.Black, 120, H)
            e.Graphics.DrawString("Middlename", New Drawing.Font("Times New Roman", 12), Brushes.Black, 220, H)
            e.Graphics.DrawString("Address", New Drawing.Font("Times New Roman", 12), Brushes.Black, 340, H)
            e.Graphics.DrawString("Course", New Drawing.Font("Times New Roman", 12), Brushes.Black, 480, H)
            e.Graphics.DrawString("Date", New Drawing.Font("Times New Roman", 12), Brushes.Black, 580, H)

            H += 50

            'For Each Itm As ListViewItem In ListView1.Items
            For Me.I_Counter = I_Start To ListView1.Items.Count - 1

                'e.Graphics.DrawString(Itm.Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 50, H)
                e.Graphics.DrawString(ListView1.Items(I_Counter).SubItems(1).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 10, H)
                e.Graphics.DrawString(ListView1.Items(I_Counter).SubItems(2).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 120, H)
                e.Graphics.DrawString(ListView1.Items(I_Counter).SubItems(3).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 220, H)
                e.Graphics.DrawString(ListView1.Items(I_Counter).SubItems(4).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 340, H)
                e.Graphics.DrawString(ListView1.Items(I_Counter).SubItems(5).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 480, H)
                e.Graphics.DrawString(ListView1.Items(I_Counter).SubItems(6).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 580, H)
                H += 20

                LineNumber += 1
                If LineNumber = Lineperpage Then
                    LineNumber = 0
                    I_Start = I_Counter + 1
                    H = 50

                    e.HasMorePages = True
                    Exit For
                End If
            Next

        End If
    End Sub

    Private Sub Listing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lineperpage = 30
    End Sub
End Class