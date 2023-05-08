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
        Button1.Text = Random.ToString
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
End Class
