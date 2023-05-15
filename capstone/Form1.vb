Option Strict On
Option Explicit On
Option Infer Off

Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Public Class Form1
    Dim Spins As Integer = 0
    Dim Tiles As Integer = 1
    Dim Random As Single
    Dim TickCount As Integer
    Dim FileName As String
    Public Word As String
    Dim Final As String
    Dim Turn As Integer = 1
    Dim Player1 As Integer
    Dim Player2 As Integer
    Dim Done As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label2.BackColor = Color.Gold
        Label4.BackColor = Color.Transparent
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TimerMain.Enabled = True
        Random = Int((Rnd() * 25) + 1)
        Spins = 0
        TickCount = 0
        Tiles = 1
        picWheel.Image = My.Resources.chart
        lblBox.Text = String.Empty
        Done = False
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
            Done = True
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
            If TickCount = 127 Then
                If lblBox.Text = "Broke" Then
                    If Turn = 1 Then
                        Player1 = 0
                        ChangeTurn()
                    ElseIf Turn = 2 Then
                        Player2 = 0
                        ChangeTurn()
                    End If
                ElseIf lblBox.Text = "Skip" Then
                    ChangeTurn()
                End If
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
        'For y As Integer = 0 To 1 'Word.Count(Function(c As Char) c = Letter)
        Dim Start As String
        For x As Integer = 0 To Word.Length
            If Word.IndexOf(Letter) > x Then
                Start += lblWord.Text(x)
            End If
        Next
        Final = Replace(lblWord.Text, "-", Letter, Word.IndexOf(Letter) + 1, 1)
        lblWord.Text = Start + Final
        'Next
    End Sub
    Public Sub ChangeTurn()
        If Turn = 1 Then
            Turn = 2
            Label4.BackColor = Color.Gold
            Label2.BackColor = Color.Transparent
        ElseIf Turn = 2 Then
            Turn = 1
            Label2.BackColor = Color.Gold
            Label4.BackColor = Color.Transparent
        End If
    End Sub
    Public Sub CheckPrice()
        If lblBox.Text = "Broke" Then
            If Turn = 1 Then
                Player1 = 0
                ChangeTurn()
            ElseIf Turn = 2 Then
                Player2 = 0
                ChangeTurn()
            End If
        ElseIf lblBox.Text = "Skip" Then
            ChangeTurn()
        ElseIf lblBox.Text = "$1000" Then
            If Turn = 1 Then
                Player1 += 1000
            ElseIf Turn = 2 Then
                Player2 += 1000
            End If
        ElseIf lblBox.Text = "$2000" Then
            If Turn = 1 Then
                Player1 += 2000
            ElseIf Turn = 2 Then
                Player2 += 2000
            End If
        ElseIf lblBox.Text = "$5000" Then
            If Turn = 1 Then
                Player1 += 5000
            ElseIf Turn = 2 Then
                Player2 += 5000
            End If
        End If
        PLayer1box.Text = Player1.ToString("C2")
        Player2Box.Text = Player2.ToString("C2")
    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Visible = False
        Form2.Visible = True
    End Sub
    Private Sub btnW_Click(sender As Object, e As EventArgs) Handles btnW.Click
        If check("w") = True Then
            btnW.BackColor = Color.Green
            showletter("w")
            btnW.Enabled = False
            CheckPrice()
        Else
            btnW.Enabled = False
            btnW.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnE_Click(sender As Object, e As EventArgs) Handles btnE.Click
        If check("e") = True Then
            btnE.BackColor = Color.Green
            showletter("e")
            btnE.Enabled = False
            CheckPrice()
        Else
            btnE.Enabled = False
            btnE.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnR_Click(sender As Object, e As EventArgs) Handles btnR.Click
        If check("r") = True Then
            btnR.BackColor = Color.Green
            showletter("r")
            btnR.Enabled = False
            CheckPrice()
        Else
            btnR.Enabled = False
            btnR.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnT_Click(sender As Object, e As EventArgs) Handles btnT.Click
        If check("t") = True Then
            btnT.BackColor = Color.Green
            showletter("t")
            btnT.Enabled = False
            CheckPrice()
        Else
            btnT.Enabled = False
            btnT.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnY_Click(sender As Object, e As EventArgs) Handles btnY.Click
        If check("y") = True Then
            btnY.BackColor = Color.Green
            showletter("y")
            btnY.Enabled = False
            CheckPrice()
        Else
            btnY.Enabled = False
            btnY.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnU_Click(sender As Object, e As EventArgs) Handles btnU.Click
        If check("u") = True Then
            btnU.BackColor = Color.Green
            showletter("u")
            btnU.Enabled = False
            CheckPrice()
        Else
            btnU.Enabled = False
            btnU.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnI_Click(sender As Object, e As EventArgs) Handles btnI.Click
        If check("i") = True Then
            btnI.BackColor = Color.Green
            showletter("i")
            showletter("i")
            btnI.Enabled = False
            CheckPrice()
        Else
            btnI.Enabled = False
            btnI.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnO_Click(sender As Object, e As EventArgs) Handles btnO.Click
        If check("o") = True Then
            btnO.BackColor = Color.Green
            showletter("o")
            btnO.Enabled = False
            CheckPrice()
        Else
            btnO.Enabled = False
            btnO.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnP_Click(sender As Object, e As EventArgs) Handles btnP.Click
        If check("p") = True Then
            btnP.BackColor = Color.Green
            showletter("p")
            btnP.Enabled = False
            CheckPrice()
        Else
            btnP.Enabled = False
            btnP.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub


    Private Sub btnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        If check("s") = True Then
            btnS.BackColor = Color.Green
            btnS.Enabled = False
            showletter("s")
            btnS.Enabled = False
            CheckPrice()
        Else
            btnS.Enabled = False
            btnS.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnD_Click(sender As Object, e As EventArgs) Handles btnD.Click
        If check("d") = True Then
            btnD.BackColor = Color.Green
            showletter("d")
            btnD.Enabled = False
            CheckPrice()
        Else
            btnD.Enabled = False
            btnD.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnF_Click(sender As Object, e As EventArgs) Handles btnF.Click
        If check("f") = True Then
            btnF.BackColor = Color.Green
            showletter("f")
            btnF.Enabled = False
            CheckPrice()
        Else
            btnF.Enabled = False
            btnF.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnG_Click(sender As Object, e As EventArgs) Handles btnG.Click
        If check("g") = True Then
            btnG.BackColor = Color.Green
            showletter("g")
            btnG.Enabled = False
            CheckPrice()
        Else
            btnG.Enabled = False
            btnG.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnH_Click(sender As Object, e As EventArgs) Handles btnH.Click
        If check("h") = True Then
            btnH.BackColor = Color.Green
            showletter("h")
            btnH.Enabled = False
            CheckPrice()
        Else
            btnH.Enabled = False
            btnH.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnJ_Click(sender As Object, e As EventArgs) Handles btnJ.Click
        If check("j") = True Then
            btnJ.BackColor = Color.Green
            showletter("j")
            btnJ.Enabled = False
            CheckPrice()
        Else
            btnJ.Enabled = False
            btnJ.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnK_Click(sender As Object, e As EventArgs) Handles btnK.Click
        If check("k") = True Then
            btnK.BackColor = Color.Green
            showletter("k")
            btnK.Enabled = False
            CheckPrice()
        Else
            btnK.Enabled = False
            btnK.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnL_Click(sender As Object, e As EventArgs) Handles btnL.Click
        If check("l") = True Then
            btnL.BackColor = Color.Green
            showletter("l")
            btnL.Enabled = False
            CheckPrice()
        Else
            btnL.Enabled = False
            btnL.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        If check("x") = True Then
            btnX.BackColor = Color.Green
            showletter("x")
            btnX.Enabled = False
            CheckPrice()
        Else
            btnX.Enabled = False
            btnX.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        If check("c") = True Then
            btnC.BackColor = Color.Green
            showletter("c")
            btnC.Enabled = False
            CheckPrice()
        Else
            btnC.Enabled = False
            btnC.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnV_Click(sender As Object, e As EventArgs) Handles btnV.Click
        If check("v") = True Then
            btnV.BackColor = Color.Green
            showletter("v")
            btnV.Enabled = False
            CheckPrice()
        Else
            btnV.Enabled = False
            btnV.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        If check("b") = True Then
            btnB.BackColor = Color.Green
            showletter("b")
            btnB.Enabled = False
            CheckPrice()
        Else
            btnB.Enabled = False
            btnB.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnN_Click(sender As Object, e As EventArgs) Handles btnN.Click
        If check("n") = True Then
            btnN.BackColor = Color.Green
            showletter("n")
            btnN.Enabled = False
            CheckPrice()
        Else
            btnN.Enabled = False
            btnN.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub

    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        If check("m") = True Then
            btnM.BackColor = Color.Green
            showletter("m")
            btnM.Enabled = False
            CheckPrice()
        Else
            btnM.Enabled = False
            btnM.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub
    Private Sub btnAA_Click(sender As Object, e As EventArgs) Handles btnAA.Click
        If check("a") = True Then
            btnAA.BackColor = Color.Green
            showletter("a")
            btnAA.Enabled = False
            CheckPrice()
        Else
            btnAA.Enabled = False
            btnAA.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub
    Private Sub bntQQ_Click(sender As Object, e As EventArgs) Handles bntQQ.Click
        If check("q") = True Then
            bntQQ.BackColor = Color.Green
            showletter("q")
            bntQQ.Enabled = False
            CheckPrice()
        Else
            bntQQ.Enabled = False
            ChangeTurn()
        End If
    End Sub
    Private Sub btnZZ_Click(sender As Object, e As EventArgs) Handles btnZZ.Click
        If check("z") = True Then
            btnZZ.BackColor = Color.Green
            showletter("z")
            btnZZ.Enabled = False
            CheckPrice()
        Else
            btnZZ.Enabled = False
            btnZZ.BackColor = Color.Red
            ChangeTurn()
        End If
    End Sub
End Class