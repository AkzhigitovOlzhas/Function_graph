Public Class Form1
    Private a, b, c, d As Double
    Private paper As Graphics
    Private mypen As Pen = New Pen(Color.Black)

    ' Прописываем  методы:
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        paper = PictureBox1.CreateGraphics()
        DrawGraph()
    End Sub
    Private Sub DrawGraph()
        a = CDbl(textbox1.text)
        b = CDbl(textbox2.text)
        c = CDbl(textbox3.text)
        d = CDbl(textbox4.text)
        paper.Clear(Color.White)
        Draw()
    End Sub
    Private Sub Draw()
        Dim x, y, nextX, nextY As Double
        Dim xpixel, ypixel, nextXPixeL, nextYPixel As Integer
        For xpixel = 0 To PictureBox1.Width
            x = ScaleX(xpixel)
            y = TheFunction(x)

            ypixel = ScaleY(y)
            nextXPixeL = xpixel + 1
            nextX = ScaleX(nextXPixeL)
            nextY = TheFunction(nextX)
            nextYPixel = ScaleY(nextY)
            paper.DrawLine(mypen, xpixel,
            ypixel, nextXPixeL, nextYPixel)

            'paper.DrawLine(mypen, xpixel, _
            '            100, nextXPixeL, 100)
            '            paper.DrawLine(mypen, 100, _
            '             ypixel, 100, nextYPixel)
        Next
    End Sub

    Private Function TheFunction(ByVal x As Double) As Double
        Return a * x * x * x + b * x * x + c * x + d
    End Function
    Private Function ScaleX(ByVal xPixel As Integer) As Double
        Dim xStart As Double = -7, xEnd As Double = 7
        Dim xScale As Double = PictureBox1.Width / (xEnd - xStart)
        Return (xPixel - (PictureBox1.Width / 2)) / xScale
    End Function
    Private Function ScaleY(ByVal y As Double) As Integer
        Dim yStart As Double = -7, yEnd As Double = 7
        Dim pixelCoord As Integer
        Dim yScale As Double = PictureBox1.Height / (yEnd - yStart)
        pixelCoord = CInt(-y * yScale) + CInt(PictureBox1.Height / 2)
        Return pixelCoord

    End Function
End Class
