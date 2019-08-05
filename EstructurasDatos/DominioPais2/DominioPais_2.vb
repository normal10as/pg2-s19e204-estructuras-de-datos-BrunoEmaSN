Module DominioPais_2

    Sub Main()
        Dim paises As Collection
        paises = New Collection
        paises.Add("Argentina", "ar")
        paises.Add("Brasil", "br")
        paises.Add("Paraguay", "py")
        paises.Add("Uruguay", "ur")
        paises.Add("Bolivia", "bo")
        paises.Add("Chile", "ch")
        opciones(paises)
    End Sub
    Sub opciones(paises)
        Dim opcion As Int16
        Do
            Console.WriteLine("------------------------------------")
            Console.WriteLine(" Presione 1(agregar                )")
            Console.WriteLine(" Presione 2(eliminar               )")
            Console.WriteLine(" Presione 3(editar                 )")
            Console.WriteLine(" Presione 4(ver un pais por dominio)")
            Console.WriteLine(" Presione 5(ver todos los paises   )")
            Console.WriteLine(" Presione 0(salir                  )")
            Console.WriteLine("------------------------------------")
            Console.Write(" elija una opcion: ")
            opcion = Console.ReadLine()
            Console.WriteLine("------------------------------------")
            Select Case opcion
                Case 1
                    paises.Add(agregar("Agregar", "Pais"), agregar("Agregar", "Clave"))
                Case 2
                    paises.Remove(eliminar(paises, "Eliminar"))
                Case 3
                    paises.Remove(eliminar(paises, "Modificar"))
                    paises.Add(agregar("Modificar", "Pais"), agregar("Modificar", "Clave"))
                Case 4
                    ver_un_pais_por_dominio(paises)
                Case 5
                    ver_todos_los_paises(paises)
                Case Else
                    If opcion = 0 Then
                        Console.WriteLine("Salir")
                    Else
                        Console.WriteLine("¡ERROR! opcion invalida")
                    End If
            End Select
            Console.WriteLine("------------------------------------")
        Loop Until (opcion = 0)
    End Sub
    Function agregar(item1, item2) As String
        Console.Write("{0} {1}: ", item1, item2)
        Return Console.ReadLine()
    End Function
    Function eliminar(paises, item1) As Integer
        For x = 1 To paises.count
            Console.WriteLine("{0} {1}", x, paises.item(x))
        Next
        Console.WriteLine("------------------------------------")
        Console.WriteLine("Para {0} Ingrese el indice del pais", item1)
        Console.Write("{0}: ", item1)
        Return Console.ReadLine()
    End Function
    Sub ver_un_pais_por_dominio(paises)
        Dim nombre_de_dominio As String
        Do
            Console.Write("Ingrese un nombre de Dominio: ")
            nombre_de_dominio = Console.ReadLine()
            Console.WriteLine("------------------------------------")
            If paises.Contains(nombre_de_dominio) Then
                Console.WriteLine("Pais: {0}", paises.Item(nombre_de_dominio))
            ElseIf nombre_de_dominio = "" Then
                Console.WriteLine("Salir")
            Else
                Console.WriteLine("¡ERROR! no existe un pais con ese dominio")
                Console.WriteLine("------------------------------------")
            End If
        Loop Until nombre_de_dominio = (Nothing)
    End Sub
    Sub ver_todos_los_paises(paises)
        For x = 1 To paises.count
            Console.WriteLine("{0} {1}", x, paises.item(x))
        Next
        Console.WriteLine("------------------------------------")
        Console.WriteLine("Total de paises cargados: {0}", paises.count)
    End Sub
End Module
