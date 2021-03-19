Public Class Form1

    Dim SourceFilePath As String = ""
    Dim DestinationFilePath As String = ""
    Dim imgFormat As Imaging.ImageFormat
    Dim Imagesize As Image
    Private draggable As Boolean
    Private mouseY As Integer
    Private mouseX As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbImageFormat.Items.Add("Select")
        cmbImageFormat.Items.Add("Bmp")
        cmbImageFormat.Items.Add("Jpeg")
        cmbImageFormat.Items.Add("Png")
        cmbImageFormat.Items.Add("Gif")
        cmbImageFormat.Items.Add("Ico")
        cmbImageFormat.Items.Add("Tiff")
        cmbImageFormat.Items.Add("Exif")
        cmbImageFormat.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With OpenFileDialog1
            .Title = "Select Image"
            .Filter = "Image files|*.bmp;*.gif;*.jpg;*.png;*.jpeg;*.ico;*.tiff;*.exif;*.wmf;*.jif"
            .FileName = String.Empty
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                SourceFilePath = .FileName
                TextBox1.Text = SourceFilePath
                PictureBox1.Image = Image.FromFile(SourceFilePath)
            End If
        End With

        Label8.Text = PictureBox1.Image.Width
        Label9.Text = PictureBox1.Image.Height


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbImageFormat.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim folderDlg As New FolderBrowserDialog
        If folderDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            DestinationFilePath = folderDlg.SelectedPath
            TextBox2.Text = DestinationFilePath
        End If



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If SourceFilePath.Trim = "" Then
            MessageBox.Show("Please enter source file path")
            Return
        ElseIf DestinationFilePath.Trim = "" Then
            MessageBox.Show("Please enter destination file path")
            Return
        ElseIf TextBox3.Text.Trim = "" Then
            MessageBox.Show("Please enter file name")
            Return
        ElseIf cmbImageFormat.SelectedIndex = 0 Then
            MessageBox.Show("Please select image format")
            Return
        Else
            Dim LocatioFile As String = DestinationFilePath & "\" & TextBox3.Text
            Dim strformat As String = cmbImageFormat.Text
            Select Case strformat
                Case "Bmp"
                    imgFormat = Imaging.ImageFormat.Bmp
                    LocatioFile = LocatioFile & ".bmp"
                Case "Jpeg"
                    imgFormat = Imaging.ImageFormat.Jpeg
                    LocatioFile = LocatioFile & ".jpeg"
                Case "Png"
                    imgFormat = Imaging.ImageFormat.Png
                    LocatioFile = LocatioFile & ".png"
                Case "Gif"
                    imgFormat = Imaging.ImageFormat.Gif
                    LocatioFile = LocatioFile & ".gif"
                Case "Ico"
                    imgFormat = Imaging.ImageFormat.Icon
                    LocatioFile = LocatioFile & ".ico"
                Case "Tiff"
                    imgFormat = Imaging.ImageFormat.Tiff
                    LocatioFile = LocatioFile & ".tiff"
                Case "Exif"
                    imgFormat = Imaging.ImageFormat.Exif
                    LocatioFile = LocatioFile & ".exif"
            End Select
            Dim SourceImg As Image
            SourceImg = Image.FromFile(SourceFilePath)

            SourceImg.Save(LocatioFile, imgFormat)
            MessageBox.Show("Convert image successfully")
            PictureBox1.Image = Nothing
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            Label8.Text = ("")
            Label9.Text = ("")
            cmbImageFormat.SelectedIndex = 0
        End If
    End Sub
    Private Sub Close_app_Click(sender As Object, e As EventArgs) Handles Close_app.Click
        Close()
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        draggable = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If draggable Then
            Me.Top = Cursor.Position.Y - mouseY
            Me.Left = Cursor.Position.X - mouseX
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        draggable = False
    End Sub

    Private Sub Label5_MouseDown(sender As Object, e As MouseEventArgs) Handles Label5.MouseDown
        draggable = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Label5_MouseMove(sender As Object, e As MouseEventArgs) Handles Label5.MouseMove
        If draggable Then
            Me.Top = Cursor.Position.Y - mouseY
            Me.Left = Cursor.Position.X - mouseX
        End If
    End Sub

    Private Sub Label5_MouseUp(sender As Object, e As MouseEventArgs) Handles Label5.MouseUp
        draggable = False
    End Sub

    Private Sub PictureBox2_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseDown
        draggable = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub PictureBox2_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseMove
        If draggable Then
            Me.Top = Cursor.Position.Y - mouseY
            Me.Left = Cursor.Position.X - mouseX
        End If
    End Sub

    Private Sub PictureBox2_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseUp
        draggable = False
    End Sub
End Class
