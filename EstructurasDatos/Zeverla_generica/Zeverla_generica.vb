Module Zeverla_generica

    Sub Main()
        Dim frase_stack As New Stack(Of String)
        Dim palabra_frase As String
        Console.Write("Ingrese un palabra o frase: ")
        palabra_frase = Console.ReadLine()
        For x = 1 To Len(palabra_frase)
            frase_stack.Push(Mid(palabra_frase, x, 1))
        Next
        Console.WriteLine("Oreden invertido")
        For x = 0 To (frase_stack.Count - 1)
            Console.Write(frase_stack.Pop)
        Next
        Console.WriteLine("")
    End Sub

End Module
