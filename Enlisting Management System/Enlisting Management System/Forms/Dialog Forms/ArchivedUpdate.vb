Imports System.Data.OleDb

Public Class ArchivedUpdate

    Private Sub ArchivedUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        idtxt.Text = ID
        lastnametxt.Text = Lastname
        firstnametxt.Text = Firstname
        middletxt.Text = Middlename
        addresstxt.Text = Address
        ComboBox1.Text = Gender
        courseOrStrandtxt.Text = CourseOrStrand
        ComboBox2.Text = Status
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Archived.RadioButton1.Checked = True Then
            Call CollegeArchives()
        ElseIf Archived.RadioButton2.Checked = True Then
            Call SHSArchives()
        End If
    End Sub
End Class