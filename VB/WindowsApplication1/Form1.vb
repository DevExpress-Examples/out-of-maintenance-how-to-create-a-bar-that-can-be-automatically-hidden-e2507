Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraBars
Imports DevExpress.Utils.Drawing.Animation

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Private bar1 As AutoHideBar
		Private bar2 As AutoHideBar
		Public Sub New()
			InitializeComponent()
			bar1 = New AutoHideBar(barManager1, BarDockStyle.Top)
			bar2 = New AutoHideBar(barManager1, BarDockStyle.Bottom)
			For i As Integer = 0 To 9
				bar1.AddItem(New BarButtonItem(barManager1, "Test"))
				bar2.AddItem(New BarButtonItem(barManager1, "Test"))
			Next i

		End Sub

		Private Sub Form1_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
			bar1.HideBar()
			bar2.HideBar()
		End Sub
	End Class
End Namespace