Imports System

Module Ventas
    Sub Main()
        Dim codigo1 = New Int16() {1, 2, 3, 4, 5}
        Dim nombre1 = New String() {"coca cola", "milanesa de carne", "pizza de mozzarella", "hamburguesa", "empanadas de Don Juan'Ma"}
        Dim precio1 = New Single() {100.0, 40.5, 170.8, 38.75, 20.0}
        Dim codigo2, cantidad, bandera As Int16
        Dim nombre2 As String
        Dim precio2, total As Single
        total = 0
        codigo2 = 1
        Do While codigo2 <> 0
            bandera = 0
            Do
                Console.Write("Ingrese codigo de Producto: ")
                codigo2 = Console.ReadLine()
                For index = 0 To codigo1.Length() - 1
                    If codigo1(index) = codigo2 Then
                        nombre2 = nombre1(index)
                        precio2 = precio1(index)
                        bandera = 1
                    ElseIf codigo2 = 0 Then
                        bandera = 1
                    End If
                Next
                If bandera <> 1 Then
                    Console.WriteLine("¡PRESTE ATENCION INGRESE OTRO CODIGO, GRACIAS!")
                End If
            Loop Until (bandera = 1)
            If codigo2 <> 0 Then
                Console.WriteLine("{0}: ${1}", nombre2, precio2)
                Console.Write("Ingrese cantidad: ")
                cantidad = Console.ReadLine()
                total += cantidad * precio2
            End If

        Loop
        Console.WriteLine("Total: ${0}", total)
    End Sub
End Module
