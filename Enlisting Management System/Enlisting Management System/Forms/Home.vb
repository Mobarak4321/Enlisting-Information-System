Public Class Home

    Sub switchPanel(ByVal panel As Form)
        Panel2.Controls.Clear()
        panel.TopLevel = False
        Panel2.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Staff" Then
            switchPanel(StaffLogin)
        ElseIf ComboBox1.Text = "Admin" Then
            switchPanel(AdminLogin)
        End If
    End Sub
End Class