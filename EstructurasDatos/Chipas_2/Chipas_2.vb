Imports System

Module Chipas_2
    Sub Main()
        Dim nombres_de_bebidas As New SortedList(Of Byte, String)
        Dim precios_de_bebidas As New SortedList(Of Byte, Single)
        Dim opcion As Byte
        Do
            Console.WriteLine("////////////MENU////////////")
            Console.WriteLine("1. Agregar")
            Console.WriteLine("2. Editar")
            Console.WriteLine("3. Eliminar")
            Console.WriteLine("4. Listar")
            Console.WriteLine("5. Salir")
            Console.Write("Elija una opcion: ")
            opcion = Console.ReadLine()
            Console.WriteLine("////////////////////////////")
            Select Case opcion
                Case 1
                    agregar_bebidas(nombres_de_bebidas, precios_de_bebidas)
                    Console.WriteLine("")
                Case 2
                    editar_bebidas(nombres_de_bebidas, precios_de_bebidas)
                    Console.WriteLine("////////////////////////////")
                Case 3
                    eliminar_bebida(nombres_de_bebidas, precios_de_bebidas)
                    Console.WriteLine("////////////////////////////")
                Case 4
                    listar_bebidas(nombres_de_bebidas, precios_de_bebidas)
                    Console.WriteLine("////////////////////////////")
                Case 5
                    Console.WriteLine("[SALIR]")
            End Select
        Loop Until (opcion = 5)
    End Sub
    Sub agregar_bebidas(nombres_de_bebidas As SortedList(Of Byte, String), precios_de_bebidas As SortedList(Of Byte, Single))
        Dim clave, bandera As Byte
        Dim nombre As String
        Dim precio As Single
        bandera = 0
        Do
            Console.Write("Ingrese el codigo(Numeros): ")
            clave = Console.ReadLine()
            If precios_de_bebidas.ContainsKey(clave) Then
                Console.WriteLine("Error clave ya existe")
            Else
                bandera = 1
            End If
        Loop While (bandera = 0)
        Do
            Console.Write("Ingrese Nombre: ")
            nombre = Console.ReadLine()
            If nombres_de_bebidas.ContainsValue(nombre) Then
                Console.WriteLine("Error nombre ya existe")
            Else
                bandera = 0
            End If
        Loop While (bandera = 1)
        Console.Write("Ingrese Precio: ")
        precio = Console.ReadLine()
        nombres_de_bebidas.Add(clave, nombre)
        precios_de_bebidas.Add(clave, precio)
    End Sub
    Sub editar_bebidas(nombres_de_bebidas As SortedList(Of Byte, String), precios_de_bebidas As SortedList(Of Byte, Single))
        Dim bandera, opcion, clave, continuar As Byte
        Do
            Console.Write("Ingrese la Clave de la bebida: ")
            clave = Console.ReadLine()
            If precios_de_bebidas.ContainsKey(clave) Then
                Do
                    Console.WriteLine("Que desea modificar")
                    Console.WriteLine("1. nombre")
                    Console.WriteLine("2. precio")
                    Console.Write("Elija una opcion: ")
                    opcion = Console.ReadLine()
                    Select Case opcion
                        Case 1
                            nombres_de_bebidas(clave) = editar_nombre()
                        Case 2
                            precios_de_bebidas(clave) = editar_precio()
                        Case Else
                            Console.WriteLine("Error Preste Atencion")
                    End Select
                    Do
                        Console.WriteLine("Desea continuar Modificando la bebida")
                        Console.WriteLine("1. SI")
                        Console.WriteLine("2. NO")
                        continuar = Console.ReadLine()
                        Select Case continuar
                            Case 1
                                bandera = 0
                            Case 2
                                bandera = 1
                            Case Else
                                Console.WriteLine("Error Preste Atencion")
                        End Select
                    Loop Until (continuar = 2)
                Loop Until (bandera = 1)
            Else
                Console.WriteLine("Error clave no existe")
            End If
        Loop Until (precios_de_bebidas.ContainsKey(clave))
    End Sub
    Function editar_nombre() As String
        Console.Write("Nombre Nuevo: ")
        Return Console.ReadLine()
    End Function
    Function editar_precio() As Single
        Console.Write("Precio Nuevo: ")
        Return Console.ReadLine()
    End Function
    Sub eliminar_bebida(nombres_de_bebidas As SortedList(Of Byte, String), precios_de_bebidas As SortedList(Of Byte, Single))
        Dim clave, bandera As Byte
        bandera = 0
        Do
            Console.Write("Ingrese la Clave de la bebida: ")
            clave = Console.ReadLine()
            If precios_de_bebidas.ContainsKey(clave) Then
                nombres_de_bebidas.Remove(clave)
                precios_de_bebidas.Remove(clave)
                bandera = 1
            Else
                Console.WriteLine("Error Clave no existe")
            End If
        Loop Until (bandera = 1)
    End Sub
    Sub listar_bebidas(nombres_de_bebidas As SortedList(Of Byte, String), precios_de_bebidas As SortedList(Of Byte, Single))
        For Each key In nombres_de_bebidas.Keys
            Console.WriteLine("{0}: {1}", nombres_de_bebidas(key), precios_de_bebidas(key))
        Next
    End Sub
End Module
