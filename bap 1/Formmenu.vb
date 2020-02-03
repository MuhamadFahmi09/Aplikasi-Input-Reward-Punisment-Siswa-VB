Public Class Form2
    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Datakejadian.Show()
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BunifuFlatButton2_Click_1(sender As Object, e As EventArgs)


    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Datasiswa.Show()
    End Sub

    Private Sub BunifuFlatButton2_Click_2(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Dataguru.Show()
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Datarayon.Show()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label5.Text = Formlogin.fahmi.Text + " !"
        Label5.Text = Formlogin.fahmi.Text
        Label5.TextAlign = ContentAlignment.MiddleCenter
    End Sub
    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Datakasus.Show()
    End Sub
End Class