Imports neXt_Motion_Engine

Public Class TestForm

    Dim _on As Boolean = False

    Private Async Sub Accel_Button_Click(sender As Object, e As EventArgs) Handles Accel_Button.Click
        Dim player As New XME
        Await player.MotionAcceleration(70, 70, 300, 0, 100)
    End Sub

    Private Async Sub Decel_Button_Click(sender As Object, e As EventArgs) Handles Decel_Button.Click
        Dim player As New XME
        Await player.MotionAcceleration(70, 70, 300, 100, 0)
    End Sub

    Private Async Sub Dot_Button_Click(sender As Object, e As EventArgs) Handles Dot_Button.Click
        Dim player As New XME
        Await player.MotionDot(70, 100, 100, 4, 30)
    End Sub

    Private Async Sub Standard_Button_Click(sender As Object, e As EventArgs) Handles Standard_Button.Click
        Dim player As New XME
        Await player.Motion(70, 100, 100)
    End Sub

    Private Async Sub Peak_Button_Click(sender As Object, e As EventArgs) Handles Peak_Button.Click
        Dim player As New XME
        Await player.MotionPeak(60, 60, 120, 120, 800)
    End Sub

    Private Sub Accel_Button_MouseHover(sender As Object, e As EventArgs) Handles Accel_Button.MouseHover
        MouseOver()
    End Sub

    Private Sub Decel_Button_MouseHover(sender As Object, e As EventArgs) Handles Decel_Button.MouseHover
        MouseOver()
    End Sub

    Private Sub Dot_MouseHover_MouseHover(sender As Object, e As EventArgs) Handles Dot_Button.MouseHover
        MouseOver()
    End Sub

    Private Sub Standard_Button_MouseHover(sender As Object, e As EventArgs) Handles Standard_Button.MouseHover
        MouseOver()
    End Sub

    Private Sub Peak_Button_HouseHover(sender As Object, e As EventArgs) Handles Peak_Button.MouseHover
        MouseOver()
    End Sub

    Private Async Sub MouseOver()
        If _on Then
            Dim player As New XME
            Await player.MotionAcceleration(70, 70, 300, 100, 0)
        End If
    End Sub

    Private Sub MO_Check_CheckedChanged(sender As Object, e As EventArgs) Handles MO_Check.CheckedChanged
        If MO_Check.Checked Then
            _on = True
        Else
            _on = False
        End If
    End Sub
End Class
