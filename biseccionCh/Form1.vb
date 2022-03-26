Imports info.lundin.math
Public Class Form1
    Dim a As Single
    Dim b As Single
    Dim c As Integer
    Dim x(50) As Single
    Dim err(50) As Single
    Dim ec As Single
    Dim i As Integer
    Dim redon As Integer
    Dim g As Graphics
    Dim j As Single
    Dim a1 As Single
    Dim b1 As Single
    Dim a2 As Single
    Dim b2 As Single
    Function f(x As Single) As Single
        Dim parser As ExpressionParser
        parser = New ExpressionParser
        parser.values.Clear()
        parser.values.Add("x", x)
        Return parser.Parse(tf.Text)
    End Function

    Private Sub Salir_Click(sender As Object, e As EventArgs) Handles Salir.Click
        End
    End Sub
    Private Sub Calcular_Click(sender As Object, e As EventArgs) Handles Calcular.Click
        a = ta.Text
        b = tb.Text
        a1 = a - 1
        b1 = b + 1
        c = tc.Text
        ec = 0.5 * 10 ^ (-c)
        redon = c + 2
        x(i) = (a + b) / 2
        err(i) = 1
        If f(x(i)) = 0 Then
            err(i) = 0
        End If
        Salida.Rows.Add(i, Math.Round(a, redon), Math.Round(x(i), redon),
            Math.Round(b, redon),
            Math.Round(f(a), redon), Math.Round(f(x(i)), redon), Math.Round(f(b), redon),
            "----")
        Do While err(i) > ec
            If f(a) * f(x(i)) < 0 Then
                b = x(i)
            Else
                a = x(i)
            End If
            i = i + 1
            x(i) = (a + b) / 2
            err(i) = Math.Abs((x(i) - x(i - 1)) / x(i))
            Salida.Rows.Add(i, Math.Round(a, redon), Math.Round(x(i), redon),
           Math.Round(b, redon),
            Math.Round(f(a), redon), Math.Round(f(x(i)), redon), Math.Round(f(b), redon),
           Math.Round(err(i), redon))
        Loop
        tr.Text = Math.Round(x(i), redon)
    End Sub

    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click
        i = 0
        tf.Clear()
        ta.Clear()
        tb.Clear()
        tc.Clear()
        Salida.Rows.Clear()
        tr.Clear()
    End Sub

    Private Sub Graficar_Click(sender As Object, e As EventArgs) Handles Graficar.Click
        g = Graf.CreateGraphics()
        j = a1
        Do While j <= b1
            Graf.Series(0).Points.AddXY(Math.Round(j, 1), f(j))
            j = j + 0.1
        Loop
        Graf.Series(1).Points.AddXY(Math.Round(x(i), 1), f(x(i)))
    End Sub
End Class
