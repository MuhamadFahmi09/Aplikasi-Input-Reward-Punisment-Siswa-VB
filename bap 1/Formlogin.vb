Public Class Formlogin


    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Dim objcmd As New System.Data.OleDb.OleDbCommand
        Call konek()
        objcmd.Connection = conn
        objcmd.CommandType = CommandType.Text
        objcmd.CommandText = "select * from tb_login where username='" & fahmi.Text & "' and password='" & hai.Text & "'"
        RD = objcmd.ExecuteReader()
        If RD.HasRows Then
            MsgBox("Login Berhasil", vbInformation, "Aplikasi Input Data Siswa")
            Form2.Show()
            Me.Hide()
        Else
            MsgBox("Maaf Username atau Password yang Anda masukan salah")
        End If
    End Sub
    Private Sub BunifuCustomTextbox1_TextChanged(sender As Object, e As EventArgs) Handles hai.TextChanged
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs)
        Dim a As String
        a = MsgBox("Apakah Anda Yakin ingin menutup aplikasi", vbYesNo, "Aplikasi Input Data Siswa")
        If a = vbYes Then
            Application.Exit()
        End If
    End Sub
    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        fahmi.Text = ""
        hai.Text = ""
        MsgBox("Data berhasil terhapus")
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Formdaftar.Show()
    End Sub
End Class
