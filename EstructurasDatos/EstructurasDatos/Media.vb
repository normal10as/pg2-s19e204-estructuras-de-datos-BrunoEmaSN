Imports System

Module Media
    Sub Main()
        Dim arreglo(4), sumatoria, media As Single
        Dim index As Int32
        sumatoria = 0
        For index = 0 To arreglo.Length() - 1
            Console.Write("Ingrese un valor({0}): ", index + 1)
            arreglo(index) = Console.ReadLine()
        Next

        For index = 0 To arreglo.Length() - 1
            media += arreglo(index)
        Next
        media /= arreglo.Length()

        For index = 0 To arreglo.Length() - 1
            Console.WriteLine("Elemento del Arreglo({0}) = {1}      Desviacion = {2}", index + 1, arreglo(index), arreglo(index) - media)
        Next
    End Sub
End Module
