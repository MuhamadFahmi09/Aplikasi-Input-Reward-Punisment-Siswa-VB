Public Class Datakejadian
    Dim sqlnya As String
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_kejadian", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_kejadian")
        DataGridView1.DataSource = DS.Tables("tb_kejadian")
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
        fahmi.Text = ""
        ComboBox2.SelectedIndex = -1
        TextBox4.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox2.SelectedIndex = -1
        TextBox3.Text = ""
        TextBox5.Text = ""
        PictureBox3.Image = Nothing
    End Sub
    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs)
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
        With ComboBox2.Items
            .Add("Reward")
            .Add("Punishment")
        End With
        Button3.Enabled = False
        Button4.Enabled = False

    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        If i = DataGridView1.NewRowIndex Then
            MsgBox("Maaf, data tidak ada")
        Else
            TextBox4.Text = DataGridView1.Item(0, i).Value.ToString
            fahmi.Text = DataGridView1.Item(1, i).Value.ToString
            TextBox2.Text = DataGridView1.Item(2, i).Value.ToString
            DateTimePicker1.Text = DataGridView1.Item(3, 1).Value
            ComboBox2.Text = DataGridView1.Item(4, i).Value.ToString
            TextBox1.Text = DataGridView1.Item(5, i).Value.ToString
            TextBox3.Text = DataGridView1.Item(6, i).Value.ToString
            TextBox5.Text = DataGridView1.Item(7, i).Value.ToString
            PictureBox3.ImageLocation = DataGridView1.Item(7, i).Value.ToString
        End If
        If i = DataGridView1.CurrentRow.Index Then
            Button2.Enabled = False
            Button3.Enabled = True
            Button4.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Title = "Image File"
        OpenFileDialog1.Filter = "PNG File |*.png| JPG File |*.jpg| AVI File |*.avi| MP4 File |*.mp4| MKV File |*.mkv| MOV File |*.mov| WMV File |*.wmv| FLV File |*.flv"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox3.Image = New Bitmap(OpenFileDialog1.FileName)
            TextBox5.Text = OpenFileDialog1.FileName
        End If
    End Sub
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        TextBox5.Text = (Replace(TextBox5.Text, ";", "\"))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If fahmi.Text = "" Or ComboBox2.Text = "" Or TextBox4.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Maaf, data kurang lengkap")
        Else
            sqlnya = "INSERT into tb_kejadian (kd_kejadian,nis,poin,tgl_kejadian,kategori,kasus,saksi,foto) values ('" & TextBox4.Text & "','" & fahmi.Text & "','" & TextBox2.Text & "','" & DateTimePicker1.Text & "','" & ComboBox2.Text & "','" & TextBox1.Text & "','" & TextBox3.Text & "', '" & TextBox5.Text & "')"
            Call jalan()
            MsgBox("Data Berhasil Tersimpan")
            Call panggildata()
        End If
        Button3.Enabled = False
        Button4.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If fahmi.Text = "" Or ComboBox2.Text = "" Or TextBox4.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Maaf, data kurang lengkap")
        Else
            sqlnya = "UPDATE tb_kejadian set kd_kejadian='" & TextBox4.Text & "', poin='" & TextBox2.Text & "',tgl_kejadian='" & DateTimePicker1.Text & "',kategori='" & ComboBox2.Text & "',kasus='" & TextBox1.Text & "',saksi='" & TextBox3.Text & "',foto='" & TextBox5.Text & "'where nis='" & fahmi.Text & "'"
            Call jalan()
            MsgBox("Data Berhasil Terubah")
            Call panggildata()
        End If
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        sqlnya = "DELETE from tb_kejadian where nis='" & fahmi.Text & "'"
        Call jalan()
        MsgBox("Data Berhasil Terhapus")
        Call panggildata()
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = False
    End Sub

    Private Sub BunifuMaterialTextbox1_OnValueChanged(sender As Object, e As EventArgs) Handles BunifuMaterialTextbox1.OnValueChanged
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_kejadian where nis like '%" & BunifuMaterialTextbox1.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_kejadian")
        DataGridView1.DataSource = DS.Tables("tb_kejadian")
        DataGridView1.Enabled = True
    End Sub

    Private Sub fahmi_OnValueChanged(sender As Object, e As EventArgs) Handles fahmi.OnValueChanged
        If Not IsNumeric(fahmi.Text) And fahmi.Text = "" Then
            MsgBox("Maaf harus diisi angka")
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If IsNumeric(TextBox3.Text) And TextBox3.Text = "" Then
            MsgBox("Saksi,Harus diisi huruf")

        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If IsNumeric(TextBox1.Text) And TextBox1.Text = "" Then
            MsgBox("Saksi,Harus diisi huruf")
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If Not IsNumeric(TextBox2.Text) And TextBox2.Text = "" Then
            MsgBox("Maaf harus diisi angka")
        End If
    End Sub
End Class