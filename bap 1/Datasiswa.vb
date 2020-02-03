Public Class Datasiswa
    Dim sqlnya As String
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_siswa", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_siswa")
        DataGridView1.DataSource = DS.Tables("tb_siswa")
        DataGridView1.Enabled = True
    End Sub
    Sub jalan()
        Dim objcmd As New System.Data.OleDb.OleDbCommand
        Call konek()
        objcmd.Connection = conn
        objcmd.CommandType = CommandType.Text
        objcmd.CommandText = sqlnya
        objcmd.ExecuteNonQuery()
        objcmd.Dispose()
        BunifuMaterialTextbox1.Text = ""
        BunifuMaterialTextbox2.Text = ""
        BunifuMaterialTextbox3.Text = ""
        BunifuMaterialTextbox7.Text = ""
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        TextBox1.Text = ""
        BunifuMaterialTextbox4.Text = ""
        PictureBox3.Image = Nothing
    End Sub
    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs)
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
        With ComboBox4.Items
            .Add("Laki-laki")
            .Add("Perempuan")
        End With
        With ComboBox1.Items
            .Add("Islam")
            .Add("Kristen")
            .Add("Katholik")
            .Add("Buddha")
            .Add("Hindu")
            .Add("Konghucu")
        End With
        With ComboBox2.Items
            .Add("OTKP")
            .Add("RPL")
            .Add("TKJ")
            .Add("MMD")
            .Add("BDP")
            .Add("TBG")
            .Add("HTL")
        End With
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        If i = DataGridView1.NewRowIndex Then
            MsgBox("Maaf, data tidak ada")
        Else
            BunifuMaterialTextbox1.Text = DataGridView1.Item(0, i).Value.ToString
            BunifuMaterialTextbox2.Text = DataGridView1.Item(1, i).Value.ToString
            ComboBox4.Text = DataGridView1.Item(2, i).Value.ToString
            BunifuMaterialTextbox3.Text = DataGridView1.Item(3, i).Value.ToString
            DateTimePicker1.Value = DataGridView1.Item(4, i).Value
            ComboBox1.Text = DataGridView1.Item(5, i).Value.ToString
            ComboBox2.Text = DataGridView1.Item(6, i).Value.ToString
            BunifuMaterialTextbox4.Text = DataGridView1.Item(7, i).Value.ToString
            BunifuMaterialTextbox7.Text = DataGridView1.Item(8, i).Value.ToString
            TextBox1.Text = DataGridView1.Item(9, i).Value.ToString
            PictureBox3.ImageLocation = DataGridView1.Item(9, i).Value.ToString
            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Title = "Image File"
        OpenFileDialog1.Filter = "PNG File |*.png| JPG File |*.jpg| AVI File |*.avi| MP4 File |*.mp4| MKV File |*.mkv| MOV File |*.mov| WMV File |*.wmv| FLV File |*.flv"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox3.Image = New Bitmap(OpenFileDialog1.FileName)
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = (Replace(TextBox1.Text, ";", "\"))
    End Sub

    Private Sub BunifuMaterialTextbox7_OnValueChanged(sender As Object, e As EventArgs) Handles BunifuMaterialTextbox7.OnValueChanged
        If Not IsNumeric(BunifuMaterialTextbox7.Text) Or BunifuMaterialTextbox7.Text = "" Then
            MsgBox("MAAF HARUS DIISI ANGKA")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If BunifuMaterialTextbox1.Text = "" Or BunifuMaterialTextbox2.Text = "" Or ComboBox4.Text = "" Or BunifuMaterialTextbox3.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or BunifuMaterialTextbox4.Text = "" Or BunifuMaterialTextbox7.Text = "" Or TextBox1.Text = "" Then
            MsgBox("Maaf, data anda kurang")
        Else
            sqlnya = "insert into tb_siswa(nis,nama,jk,alamat,ttl,agama,jurusan,kd_rayon,nohp_ortu,foto)values('" & BunifuMaterialTextbox1.Text & "','" & BunifuMaterialTextbox2.Text & "','" & ComboBox4.Text & "','" & BunifuMaterialTextbox3.Text & "','" & DateTimePicker1.Value & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & BunifuMaterialTextbox4.Text & "','" & BunifuMaterialTextbox7.Text & "','" & TextBox1.Text & "')"
            Call jalan()
            MsgBox("Data berhasil disimpan")
            Call panggildata()
        End If
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sqlnya = "DELETE from tb_siswa where nis=" & BunifuMaterialTextbox1.Text & ""
        Call jalan()
        MsgBox("Data berhasil terhapus")
        Call panggildata()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If BunifuMaterialTextbox1.Text = "" Or BunifuMaterialTextbox2.Text = "" Or ComboBox4.Text = "" Or BunifuMaterialTextbox3.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or BunifuMaterialTextbox4.Text = "" Or BunifuMaterialTextbox7.Text = "" Or TextBox1.Text = "" Then
            MsgBox("Maaf, data anda kurang")
        Else
            sqlnya = "UPDATE tb_siswa set nama='" & BunifuMaterialTextbox2.Text & "', jk='" & ComboBox4.Text & "',alamat='" & BunifuMaterialTextbox3.Text & "',ttl='" & DateTimePicker1.Value & "',agama='" & ComboBox1.Text & "',jurusan='" & ComboBox2.Text & "',kd_rayon='" & BunifuMaterialTextbox4.Text & "',nohp_ortu='" & BunifuMaterialTextbox7.Text & "',foto='" & TextBox1.Text & "' where nis=" & BunifuMaterialTextbox1.Text & ";"
            Call jalan()
            MsgBox("Data Berhasil Terubah")
            Call panggildata()
        End If
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub BunifuMaterialTextbox5_OnValueChanged(sender As Object, e As EventArgs) Handles BunifuMaterialTextbox5.OnValueChanged
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_kasus where nama like '%" & BunifuMaterialTextbox5.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_siswa")
        DataGridView1.DataSource = DS.Tables("tb_siswa")
        DataGridView1.Enabled = True
    End Sub

    Private Sub BunifuMaterialTextbox1_OnValueChanged(sender As Object, e As EventArgs) Handles BunifuMaterialTextbox1.OnValueChanged

    End Sub
End Class