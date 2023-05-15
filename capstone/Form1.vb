Option Strict On
Option Explicit On
Option Infer Off

Imports System.IO
Imports System.Security.Cryptography.X509Certificates
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
        Button1.Text = Replace("hello", "l", "x", 2, 1)
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
    Public Function check(Letter As String) As Boolean
        For Each c As Char In Word
            If c = Letter Then
                Return True
            End If
        Next
    End Function
    Public Sub showletter(Letter As String)
        Replace(lblWord.Text, "-", "x", 3, -1)
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Visible = False
        Form2.Visible = True
    End Sub
    Private Sub btnW_Click(sender As Object, e As EventArgs) Handles btnW.Click
        If check("w") = True Then
            btnW.BackColor = Color.Green
            showletter("w")
        Else
            btnW.Enabled = False
        End If
    End Sub

    Private Sub btnE_Click(sender As Object, e As EventArgs) Handles btnE.Click
        If check("e") = True Then
            btnE.BackColor = Color.Green
            showletter("e")
        Else
            btnE.Enabled = False
        End If
    End Sub

    Private Sub btnR_Click(sender As Object, e As EventArgs) Handles btnR.Click
        If check("r") = True Then
            btnR.BackColor = Color.Green
            showletter("r")
        Else
            btnR.Enabled = False
        End If
    End Sub

    Private Sub btnT_Click(sender As Object, e As EventArgs) Handles btnT.Click
        If check("t") = True Then
            btnT.BackColor = Color.Green
            showletter("t")
        Else
            btnT.Enabled = False
        End If
    End Sub

    Private Sub btnY_Click(sender As Object, e As EventArgs) Handles btnY.Click
        If check("y") = True Then
            btnY.BackColor = Color.Green
            showletter("y")
        Else
            btnY.Enabled = False
        End If
    End Sub

    Private Sub btnU_Click(sender As Object, e As EventArgs) Handles btnU.Click
        If check("u") = True Then
            btnU.BackColor = Color.Green
            showletter("u")
        Else
            btnU.Enabled = False
        End If
    End Sub

    Private Sub btnI_Click(sender As Object, e As EventArgs) Handles btnI.Click
        If check("i") = True Then
            btnI.BackColor = Color.Green
            showletter("i")
        Else
            btnI.Enabled = False
        End If
    End Sub

    Private Sub btnO_Click(sender As Object, e As EventArgs) Handles btnO.Click
        If check("o") = True Then
            btnO.BackColor = Color.Green
            showletter("o")
        Else
            btnO.Enabled = False
        End If
    End Sub

    Private Sub btnP_Click(sender As Object, e As EventArgs) Handles btnP.Click
        If check("p") = True Then
            btnP.BackColor = Color.Green
            showletter("p")
        Else
            btnP.Enabled = False
        End If
    End Sub

    Private Sub btnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        If check("s") = True Then
            btnS.BackColor = Color.Green
            showletter("s")
        Else
            btnS.Enabled = False
        End If
    End Sub

    Private Sub btnD_Click(sender As Object, e As EventArgs) Handles btnD.Click
        If check("d") = True Then
            btnD.BackColor = Color.Green
            showletter("d")
        Else
            btnD.Enabled = False
        End If
    End Sub

    Private Sub btnF_Click(sender As Object, e As EventArgs) Handles btnF.Click
        If check("f") = True Then
            btnF.BackColor = Color.Green
            showletter("f")
        Else
            btnF.Enabled = False
        End If
    End Sub

    Private Sub btnG_Click(sender As Object, e As EventArgs) Handles btnG.Click
        If check("g") = True Then
            btnG.BackColor = Color.Green
            showletter("g")
        Else
            btnG.Enabled = False
        End If
    End Sub

    Private Sub btnH_Click(sender As Object, e As EventArgs) Handles btnH.Click
        If check("h") = True Then
            btnH.BackColor = Color.Green
            showletter("h")
        Else
            btnH.Enabled = False
        End If
    End Sub

    Private Sub btnJ_Click(sender As Object, e As EventArgs) Handles btnJ.Click
        If check("j") = True Then
            btnJ.BackColor = Color.Green
            showletter("j")
        Else
            btnJ.Enabled = False
        End If
    End Sub

    Private Sub btnK_Click(sender As Object, e As EventArgs) Handles btnK.Click
        If check("k") = True Then
            btnK.BackColor = Color.Green
            showletter("k")
        Else
            btnK.Enabled = False
        End If
    End Sub

    Private Sub btnL_Click(sender As Object, e As EventArgs) Handles btnL.Click
        If check("l") = True Then
            btnL.BackColor = Color.Green
            showletter("l")
        Else
            btnL.Enabled = False
        End If
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        If check("x") = True Then
            btnX.BackColor = Color.Green
            showletter("x")
        Else
            btnX.Enabled = False
        End If
    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        If check("c") = True Then
            btnC.BackColor = Color.Green
            showletter("c")
        Else
            btnC.Enabled = False
        End If
    End Sub

    Private Sub btnV_Click(sender As Object, e As EventArgs) Handles btnV.Click
        If check("v") = True Then
            btnV.BackColor = Color.Green
            showletter("v")
        Else
            btnV.Enabled = False
        End If
    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        If check("b") = True Then
            btnB.BackColor = Color.Green
            showletter("b")
        Else
            btnB.Enabled = False
        End If
    End Sub

    Private Sub btnN_Click(sender As Object, e As EventArgs) Handles btnN.Click
        If check("n") = True Then
            btnN.BackColor = Color.Green
            showletter("n")
        Else
            btnN.Enabled = False
        End If
    End Sub

    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        If check("m") = True Then
            btnM.BackColor = Color.Green
            showletter("m")
        Else
            btnM.Enabled = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
    End Sub
End Class