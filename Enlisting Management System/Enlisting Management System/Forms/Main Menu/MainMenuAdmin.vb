Public Class MainMenuAdmin

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Dispose()
        Me.Hide()
        Home.Show()
    End Sub

    Sub switchPanel(ByVal panel As Form)
        Panel3.Controls.Clear()
        panel.TopLevel = False
        Panel3.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub btnstudentinf_Click(sender As Object, e As EventArgs) Handles btnstudentinf.Click
        switchPanel(StudentInformation)
    End Sub

    Private Sub btnlisting_Click(sender As Object, e As EventArgs) Handles btnlisting.Click
        switchPanel(listing)
    End Sub

    Private Sub btncourse_Click(sender As Object, e As EventArgs) Handles btncourse.Click
        switchPanel(Course)
    End Sub

    Private Sub btnarchived_Click(sender As Object, e As EventArgs) Handles btnarchived.Click
        switchPanel(Archived)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        switchPanel(ContactMe)
    End Sub
End Class