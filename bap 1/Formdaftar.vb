Public Class Formdaftar
    Dim sqlnya As String
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_akun", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_akun")

    End Sub
    Sub oto()
        konek()
        CMD = New OleDb.OleDbCommand("select * from tb_akun order by kd_petugas Desc", conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            TextBox1.Text = "PTG" + "001"
        Else
            'TextBox1.Text = Val(Microsoft.VisualBasic.Mid(RD.Item("kd_petugas").ToString, 4, 3)) + 1
        End If
        If Len(TextBox1.Text) = 1 Then
            TextBox1.Text = "PTG00" & TextBox1.Text & ""
        ElseIf Len(TextBox1.Text) = 2 Then
            TextBox1.Text = "PTG0" & TextBox1.Text & ""
        ElseIf Len(TextBox1.Text) = 3 Then
            TextBox1.Text = "PTG" & TextBox1.Text & ""
        End If
    End Sub
    Sub jalan()
        Dim objcmd As New System.Data.OleDb.OleDbCommand
        Call konek()
        objcmd.Connection = conn
        objcmd.CommandType = CommandType.Text
        objcmd.CommandText = sqlnya
        objcmd.ExecuteNonQuery()
        objcmd.Dispose()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim jk As String
        jk = ""
        If RadioButton1.Checked = True Then
            jk = "Laki-laki"
        ElseIf RadioButton2.Checked = True Then
            jk = "Perempuan"
        End If
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or RadioButton1.Checked = False And RadioButton2.Checked = False Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MsgBox("Maaf Data yang Anda masukan masih kurang lengkap")
        Else
            Call konek()
            CMD = New OleDb.OleDbCommand("select * from tb_akun where username='" & TextBox4.Text & "'", conn)
            RD = CMD.ExecuteReader
            RD.Read()
            If Not RD.HasRows Then
                Label7.Text = "Password Matched"
                sqlnya = "insert into tb_akun([kd_petugas],[nama_petugas],[jk],[username],[password]) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & jk & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
                Call jalan()
                MsgBox("Akun Terdaftar")
                Form2.Show()
                Me.Hide()
            Else
                MsgBox("username sudah ada")
            End If
        End If

        Call oto()
    End Sub
End Class