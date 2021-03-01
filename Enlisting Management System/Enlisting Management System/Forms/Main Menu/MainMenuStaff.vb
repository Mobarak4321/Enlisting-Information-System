Public Class MainMenuStaff

    Sub switchPanel(ByVal panel As Form)
        Panel3.Controls.Clear()
        Panel.TopLevel = False
        Panel3.Controls.Add(Panel)
        Panel.Show()
    End Sub

    Private Sub btnstudentinf_Click(sender As Object, e As EventArgs) Handles btnstudentinf.Click
        switchPanel(StudentInformation)
    End Sub

    Private Sub btnlisting_Click(sender As Object, e As EventArgs) Handles btnlisting.Click
        switchPanel(Listing)
    End Sub

    Private Sub btnarchived_Click(sender As Object, e As EventArgs) Handles btnarchived.Click
        switchPanel(Archived)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Dispose()
        Home.Show()
        Me.Hide()
    End Sub
End Class