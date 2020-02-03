Public Class Dataguru
    Dim sqlnya As String
    Sub otomatis()
        konek()
        CMD = New OleDb.OleDbCommand("select * from tb_guru order by kd_guru Desc", conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            fahmi1.Text = "G" + "0001"
        Else
            fahmi1.Text = Val(Microsoft.VisualBasic.Mid(RD.Item("kd_guru").ToString, 4, 3)) + 1
            If Len(fahmi1.Text) = 1 Then
                fahmi1.Text = "G000" & fahmi1.Text & ""
            ElseIf Len(fahmi1.Text) = 2 Then
                fahmi1.Text = "G00" & fahmi1.Text & ""
            ElseIf Len(fahmi1.Text) = 3 Then
                fahmi1.Text = "G0" & fahmi1.Text & ""
            End If
        End If
    End Sub
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_guru", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_guru")
        DataGridView1.DataSource = DS.Tables("tb_guru")
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
        fahmi4.Text = ""
        fahmi2.Text = ""
        fahmi3.Text = ""
        ComboBox1.SelectedIndex = -1
    End Sub
    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs)
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
        Call otomatis()

        With ComboBox1.Items
            .Add("Laki-laki")
            .Add("Perempuan")
        End With
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        If i = DataGridView1.NewRowIndex Then
            MsgBox("Maaf, tidak ada data")
        Else
            fahmi1.Text = DataGridView1.Item(0, i).Value.ToString
            fahmi2.Text = DataGridView1.Item(1, i).Value.ToString
            ComboBox1.Text = DataGridView1.Item(2, i).Value.ToString
            fahmi3.Text = DataGridView1.Item(3, i).Value.ToString
            fahmi4.Text = DataGridView1.Item(4, i).Value.ToString
        End If
        If i = DataGridView1.CurrentRow.Index Then
            Button2.Enabled = True
            Button3.Enabled = True
            Button1.Enabled = False
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If fahmi1.Text = "" Or fahmi2.Text = "" Or ComboBox1.Text = "" Or fahmi3.Text = "" Or fahmi4.Text = "" Then
            MsgBox("Maaf,Data belum lengkap")
        Else
            sqlnya = "insert into tb_guru(kd_guru,nama,jk,alamat,nohp)values ('" & fahmi1.Text & "','" & fahmi2.Text & "','" & ComboBox1.Text & "','" & fahmi3.Text & "','" & fahmi4.Text & "')"
            Call jalan()
            MsgBox("Data berhasil tersimpan")
            Call panggildata()
        End If
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If fahmi1.Text = "" Or fahmi2.Text = "" Or ComboBox1.Text = "" Or fahmi3.Text = "" Or fahmi4.Text = "" Then
            MsgBox("Maaf, data kurang lengkap")
        Else
            sqlnya = "UPDATE tb_guru set  nama='" & fahmi2.Text & "',jk='" & ComboBox1.Text & "',alamat='" & fahmi3.Text & "',nohp=  '" & fahmi4.Text & "' where kd_guru='" & fahmi1.Text & "'"
            Call jalan()
            MsgBox("Data Berhasil Terubah")
            Call panggildata()
        End If
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sqlnya = "DELETE from tb_guru where kd_guru='" & fahmi1.Text & "'"
        Call jalan()
        MsgBox("Data berhasil terhapus")
        Call panggildata()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Text1_OnValueChanged(sender As Object, e As EventArgs) Handles text1.OnValueChanged
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_guru where nama like '%" & text1.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_guru")
        DataGridView1.DataSource = DS.Tables("tb_guru")
        DataGridView1.Enabled = True
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class