Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Localization
' ...

Namespace PageHeader
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Me.categoriesTableAdapter.Fill(Me.nwindDataSet.Categories)
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' The following syntax is recommended for use with localized applications.
			Dim leftColumn As String = "Pages: " & PreviewLocalizer.GetString(PreviewStringId.PageInfo_PageNumberOfTotal)
			Dim middleColumn As String = "User: " & PreviewLocalizer.GetString(PreviewStringId.PageInfo_PageUserName)
			Dim rightColumn As String = "Date: " & PreviewLocalizer.GetString(PreviewStringId.PageInfo_PageDate)

			' Create a PageHeaderFooter object and initializing it with
			' the link's PageHeaderFooter.
			Dim phf As PageHeaderFooter = TryCast(printableComponentLink1.PageHeaderFooter, PageHeaderFooter)

			' Clear the PageHeaderFooter's contents.
			phf.Header.Content.Clear()

			' Add custom information to the link's header.
			phf.Header.Content.AddRange(New String() { leftColumn, middleColumn, rightColumn })
			phf.Header.LineAlignment = BrickAlignment.Far

			' Show the document's preview.
			printableComponentLink1.ShowPreview()

		End Sub
	End Class
End Namespace