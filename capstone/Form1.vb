Option Strict On
Option Explicit On
Option Infer Off

Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Public Class Form1
    Dim Spins As Integer = 0
    Dim Tiles As Integer = 1
    Dim Random As Single
    Dim TickCount As Integer
    Dim FileName As String
    Public Word As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TimerMain.Enabled = True
        Random = Int((Rnd() * 25) + 1)

        Spins = 0
        TickCount = 0
        Tiles = 1
        picWheel.Image = My.Resources.chart
        lblBox.Text = String.Empty
    End Sub

    Private Sub TimerMain_Tick(sender As Object, e As EventArgs) Handles TimerMain.Tick
        TickCount += 1

        If Spins < 1 Then
            If TickCount = Tiles * 5 Then
                picWheel.Image = CType(My.Resources.ResourceManager.GetObject("chart__" + Tiles.ToString + "_"), Image)
                Tiles += 1
            End If
            If Tiles > 25 Then
                Spins += 1
                Tiles = 1
                TickCount = 0
            End If
        ElseIf Spins >= 1 Then
            If TickCount = Tiles * 5 Then
                picWheel.Image = CType(My.Resources.ResourceManager.GetObject("chart__" + Tiles.ToString + "_"), Image)
                If Random = Tiles Then
                    TickCount = 126
                End If
                Tiles += 1
            End If
        End If

        If TickCount > 126 Then
            If Random = 1 Or Random = 4 Or Random = 7 Or Random = 10 Or Random = 13 Or Random = 16 Or Random = 19 Or Random = 22 Or Random = 25 Then
                lblBox.Text = "$1000"
            ElseIf Random = 2 Or Random = 3 Or Random = 12 Or Random = 14 Or Random = 21 Then
                lblBox.Text = "$5000"
            ElseIf Random = 5 Or Random = 8 Or Random = 11 Or Random = 17 Or Random = 20 Or Random = 23 Then
                lblBox.Text = "$2000"
            ElseIf Random = 6 Or Random = 15 Or Random = 24 Then
                lblBox.Text = "Skip"
            ElseIf Random = 9 Or Random = 18 Then
                lblBox.Text = "Broke"
            End If
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Word = String.Empty
        lblWord.Text = Word
        lstRandom.Items.Clear()

        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            FileName = OpenFileDialog1.FileName
        End If

        Dim File As StreamReader
        File = IO.File.OpenText(FileName)

        Do Until File.Peek = -1
            lstRandom.Items.Add(File.ReadLine())
        Loop

        lstRandom.SelectedIndex = CInt(Int(Rnd() * lstRandom.Items.Count))
        Word = lstRandom.Text
        For Each c As Char In Word
            If c <> " " Then
                lblWord.Text += "-"
            Else
                lblWord.Text += " "
            End If
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub lblWord_Click(sender As Object, e As EventArgs) Handles lblWord.Click

    End Sub

    Private Sub btnW_Click(sender As Object, e As EventArgs) Handles btnW.Click
        btnW.Enabled = False
    End Sub

    Private Sub btnE_Click(sender As Object, e As EventArgs) Handles btnE.Click
        btnE.Enabled = False
    End Sub

    Private Sub btnR_Click(sender As Object, e As EventArgs) Handles btnR.Click
        btnR.Enabled = False
    End Sub

    Private Sub btnT_Click(sender As Object, e As EventArgs) Handles btnT.Click
        btnT.Enabled = False
    End Sub

    Private Sub btnY_Click(sender As Object, e As EventArgs) Handles btnY.Click
        btnY.Enabled = False
    End Sub

    Private Sub btnU_Click(sender As Object, e As EventArgs) Handles btnU.Click
        btnU.Enabled = False
    End Sub

    Private Sub btnI_Click(sender As Object, e As EventArgs) Handles btnI.Click
        btnI.Enabled = False
    End Sub

    Private Sub btnO_Click(sender As Object, e As EventArgs) Handles btnO.Click
        btnO.Enabled = False
    End Sub

    Private Sub btnP_Click(sender As Object, e As EventArgs) Handles btnP.Click
        btnP.Enabled = False
    End Sub

    Private Sub btnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        btnS.Enabled = False
    End Sub

    Private Sub btnD_Click(sender As Object, e As EventArgs) Handles btnD.Click
        btnD.Enabled = False
    End Sub

    Private Sub btnF_Click(sender As Object, e As EventArgs) Handles btnF.Click
        btnF.Enabled = False
    End Sub

    Private Sub btnG_Click(sender As Object, e As EventArgs) Handles btnG.Click
        btnG.Enabled = False
    End Sub

    Private Sub btnH_Click(sender As Object, e As EventArgs) Handles btnH.Click
        btnH.Enabled = False
    End Sub

    Private Sub btnJ_Click(sender As Object, e As EventArgs) Handles btnJ.Click
        btnJ.Enabled = False
    End Sub

    Private Sub btnK_Click(sender As Object, e As EventArgs) Handles btnK.Click
        btnK.Enabled = False
    End Sub

    Private Sub btnL_Click(sender As Object, e As EventArgs) Handles btnL.Click
        btnL.Enabled = False
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        btnX.Enabled = False
    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        btnC.Enabled = False
    End Sub

    Private Sub btnV_Click(sender As Object, e As EventArgs) Handles btnV.Click
        btnV.Enabled = False
    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        btnB.Enabled = False
    End Sub

    Private Sub btnN_Click(sender As Object, e As EventArgs) Handles btnN.Click
        btnB.Enabled = False
    End Sub

    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        btnM.Enabled = False
    End Sub
End Class
