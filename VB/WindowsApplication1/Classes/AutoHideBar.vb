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
	<System.ComponentModel.DesignerCategory("")> _
	Public Class AutoHideBar
		Inherits Bar


		Private _EventSubscriber As EventSubscriber
		Public ReadOnly Property EventSubscriber() As EventSubscriber
			Get
				If _EventSubscriber Is Nothing Then
					_EventSubscriber = New EventSubscriber(Me)
				End If
				Return _EventSubscriber
			End Get
		End Property

		Private ReadOnly Overloads Property DockControl() As BarDockControl
			Get
				Return Manager.DockControls(DockStyle)
			End Get
		End Property
		Public Sub New(ByVal manager As BarManager, ByVal style As BarDockStyle)
			MyBase.New(manager)
			If style = BarDockStyle.Bottom Then
				DockStyle = BarDockStyle.Bottom
			Else
				DockStyle = BarDockStyle.Top
			End If
			OptionsBar.AllowCollapse = True
			OptionsBar.DrawDragBorder = False
			OptionsBar.AllowQuickCustomization = False
		End Sub

		Protected Overrides Function CalcBarEndSize() As Size
			If OptionsBar.BarState = BarState.Expanded Then
				Return MyBase.CalcBarEndSize()
			End If
			Dim size As Size = BarControl.Bounds.Size
			size.Height = 5
			Return size
		End Function

		Public Sub HideBar()
			OptionsBar.BarState = BarState.Collapsed
		End Sub

		Public Sub ShowBar()
			OptionsBar.BarState = BarState.Expanded
		End Sub

		Protected Overrides Sub OnBarChanged()
			MyBase.OnBarChanged()
			If (Not DesignMode) Then
				EventSubscriber.CheckChange(BarControl, DockControl)
			End If
		End Sub
	End Class
End Namespace