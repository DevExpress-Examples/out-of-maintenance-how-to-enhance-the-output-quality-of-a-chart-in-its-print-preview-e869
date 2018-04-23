Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraPrinting

Namespace dxKB17093
	Public Partial Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private mf As System.Drawing.Imaging.Metafile
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim ms As MemoryStream = New MemoryStream()
			Try
				chartControl1.ExportToImage(ms, System.Drawing.Imaging.ImageFormat.Wmf)
				ms.Seek(0, SeekOrigin.Begin)
				mf = New System.Drawing.Imaging.Metafile(ms)
			Finally
				ms.Close()
			End Try

			Dim l As Link = New Link(New PrintingSystem())
			AddHandler l.CreateDetailArea, AddressOf l_CreateDetailArea
			l.ShowPreview()
		End Sub

		Private Sub l_CreateDetailArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
			Dim l As Link = TryCast(sender, Link)
			Dim ib As ImageBrick = New ImageBrick()
			ib.Rect = New RectangleF(0, 0,chartControl1.Width, chartControl1.Height)
			ib.Image = mf
			e.Graph.DrawBrick(ib)
		End Sub
	End Class
End Namespace