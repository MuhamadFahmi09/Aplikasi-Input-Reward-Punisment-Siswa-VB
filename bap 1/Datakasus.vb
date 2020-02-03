Public Class Datakasus
    Dim sqlnya As String
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_kasus", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_kasus")
        DataGridView1.DataSource = DS.Tables("tb_kasus")
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
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.SelectedIndex = -1
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
        With ComboBox1.Items
            .Add("Punishment")
            .Add("Reward")
        End With
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        If i = DataGridView1.NewRowIndex Then
            MsgBox("Maaf, data tidak ada")
        Else
            TextBox1.Text = DataGridView1.Item(0, i).Value
            ComboBox1.Text = DataGridView1.Item(1, i).Value
            TextBox2.Text = DataGridView1.Item(2, i).Value
            TextBox3.Text = DataGridView1.Item(3, i).Value
        End If
        If i = DataGridView1.CurrentRow.Index Then
            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Maaf, data kurang lengkap")
        Else
            sqlnya = "insert into tb_kasus (kd_kasus,kategori,kasus,poin) values ('" & TextBox1.Text & "', '" & ComboBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "')"
            Call jalan()
            MsgBox("Data Berhasil Tersimpan")
            Call panggildata()
        End If
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sqlnya = "DELETE from tb_kasus where kd_kasus='" & TextBox1.Text & "'"
        Call jalan()
        MsgBox("Data Berhasil Terhapus")
        Call panggildata()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Maaf, data kurang lengkap")
        Else
            sqlnya = "UPDATE tb_kasus set kategori='" & ComboBox1.Text & "',kasus='" & TextBox2.Text & "',poin='" & TextBox3.Text & "' where kd_kasus='" & TextBox1.Text & "'"
            Call jalan()
            MsgBox("Data Berhasil Terubah")
            Call panggildata()
        End If
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_kasus where kasus like '%" & TextBox4.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_kasus")
        DataGridView1.DataSource = DS.Tables("tb_kasus")
        DataGridView1.Enabled = True
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs)
        Form2.Show()
        Me.Hide()
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Reward" Then
            Label6.Text = "H"
        End If
        If ComboBox1.Text = "Punishment" Then
            Label6.Text = "P"
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If Not IsNumeric(TextBox3.Text) And TextBox3.Text = "" Then
            MsgBox("Maaf harus diisi angka")
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If IsNumeric(TextBox2.Text) And TextBox2.Text = "" Then
            MsgBox("Maaf harus diisi angka")
        End If
    End Sub
End Class