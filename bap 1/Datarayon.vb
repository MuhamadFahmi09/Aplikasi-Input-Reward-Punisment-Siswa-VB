Public Class Datarayon
    Dim sqlnya As String
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_rayon", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_rayon")
        DataGridView1.DataSource = DS.Tables("tb_rayon")
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
        fahmi1.Text = ""
        fahmi2.Text = ""
        acel.Text = ""
    End Sub
    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs)
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        If i = DataGridView1.NewRowIndex Then
            MsgBox("Maaf, data tidak ada")
        Else
            acel.Text = DataGridView1.Item(0, i).Value.ToString
            fahmi1.Text = DataGridView1.Item(1, i).Value.ToString
            fahmi2.Text = DataGridView1.Item(2, i).Value.ToString
        End If
        If i = DataGridView1.CurrentRow.Index Then
            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sqlnya = "insert into tb_rayon(nama_rayon,pembimbing,ruangan)values ('" & acel.Text & "','" & fahmi1.Text & "','" & fahmi2.Text & "')"
        Call jalan()
        MsgBox("Data berhasil tersimpan")
        Call panggildata()
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If acel.Text = "" Or fahmi1.Text = "" Or fahmi2.Text = "" Then
            MsgBox("Maaf, data kurang lengkap")
        Else
            sqlnya = "UPDATE tb_rayon set pembimbing ='" & fahmi1.Text & "',ruangan='" & fahmi2.Text & "'where nama_rayon='" & acel.Text & "'"
            Call jalan()
            MsgBox("Data berhasil terubah")
            Call panggildata()
        End If
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sqlnya = "delete from tb_rayon where nama_rayon='" & acel.Text & "'"
        Call jalan()
        MsgBox("Data berhasil terhapus")
        Call panggildata()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub BunifuMaterialTextbox1_OnValueChanged(sender As Object, e As EventArgs) Handles BunifuMaterialTextbox1.OnValueChanged
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_rayon where rayon like '%" & BunifuMaterialTextbox1.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_rayon")
        DataGridView1.DataSource = DS.Tables("tb_rayon")
        DataGridView1.Enabled = True
    End Sub
End Class