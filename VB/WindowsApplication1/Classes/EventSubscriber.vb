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
Imports DevExpress.XtraBars.Controls

Namespace WindowsApplication1
	Public Class EventSubscriber
		Private _BarControl As CustomBarControl
		Private _DockControl As BarDockControl
		Private _Bar As AutoHideBar


		Public Sub New(ByVal bar As AutoHideBar)
			_Bar = bar

		End Sub

		Public Sub CheckChange(ByVal barControl As CustomBarControl, ByVal barDockControl As BarDockControl)
			If BarControlChanged(barControl) Then
				OnBarControlChanged(barControl)
			End If

			If BarDockControlChanged(barDockControl) Then
				OnBarDockControlChanged(barDockControl)
			End If
		End Sub

		Private Function BarControlChanged(ByVal barControl As CustomBarControl) As Boolean
			Return barControl IsNot _BarControl
		End Function
		Private Sub OnBarControlChanged(ByVal barControl As CustomBarControl)
			If _BarControl IsNot Nothing Then
				RemoveHandler _BarControl.MouseEnter, AddressOf OnMouseEnter
				RemoveHandler _BarControl.MouseLeave, AddressOf OnMouseLeave
				RemoveHandler _BarControl.SizeChanged, AddressOf _BarControl_SizeChanged
			End If
			_BarControl = barControl
			If _BarControl IsNot Nothing Then
				AddHandler _BarControl.MouseEnter, AddressOf OnMouseEnter
				AddHandler _BarControl.MouseLeave, AddressOf OnMouseLeave
				AddHandler _BarControl.SizeChanged, AddressOf _BarControl_SizeChanged
			End If
		End Sub

		Private Sub _BarControl_SizeChanged(ByVal sender As Object, ByVal e As EventArgs)
			'Control control = sender as Control;
			'if (control.Height == 0)
			'    control.Height = 13;
		End Sub


		Private Function BarDockControlChanged(ByVal barDockControl As BarDockControl) As Boolean
			Return barDockControl IsNot _DockControl
		End Function
		Private Sub OnBarDockControlChanged(ByVal barDockControl As BarDockControl)
			If _DockControl IsNot Nothing Then
				RemoveHandler _DockControl.MouseEnter, AddressOf OnMouseEnter
				RemoveHandler _DockControl.MouseLeave, AddressOf OnMouseLeave
			End If
			_DockControl = barDockControl
			If barDockControl IsNot Nothing Then
				AddHandler _DockControl.MouseEnter, AddressOf OnMouseEnter
				AddHandler _DockControl.MouseLeave, AddressOf OnMouseLeave
			End If
		End Sub


		Private Sub OnMouseLeave(ByVal sender As Object, ByVal e As EventArgs)
			Console.WriteLine("Leave")
			_Bar.HideBar()
		End Sub

		Private Sub OnMouseEnter(ByVal sender As Object, ByVal e As EventArgs)
			Console.WriteLine("Enter")
			_Bar.ShowBar()
		End Sub


	End Class
End Namespace
