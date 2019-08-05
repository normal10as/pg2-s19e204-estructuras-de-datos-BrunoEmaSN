Module DominioHashTable

    Sub Main()
        Dim paises As Hashtable
        paises = New Hashtable
        paises.Add("ar", "Argentina")
        paises.Add("br", "Brasil")
        paises.Add("py", "Paraguay")
        paises.Add("ur", "Uruguay")
        paises.Add("bo", "Bolivia")
        paises.Add("ch", "Chile")
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
                    paises.Add(agregar("Agregar", "Clave"), agregar("Agregar", "Pais"))
                Case 2
                    paises.Remove(eliminar(paises, "Eliminar"))
                Case 3
                    paises.Remove(eliminar(paises, "Modificar"))
                    paises.Add(agregar("Modificar", "Clave"), agregar("Modificar", "Pais"))
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
    Function eliminar(paises, item1) As String
        For Each elemento As DictionaryEntry In paises
            Console.WriteLine("{0} {1}", elemento.Key, elemento.Value)
        Next
        Console.WriteLine("------------------------------------")
        Console.WriteLine("Para {0} Ingrese la key del pais", item1)
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
                Console.WriteLine("Pais: {0}", paises.item(nombre_de_dominio))
            ElseIf nombre_de_dominio = "" Then
                Console.WriteLine("Salir")
            Else
                Console.WriteLine("¡ERROR! no existe un pais con ese dominio")
                Console.WriteLine("------------------------------------")
            End If
        Loop Until nombre_de_dominio = (Nothing)
    End Sub
    Sub ver_todos_los_paises(paises)
        For Each elemento As DictionaryEntry In paises
            Console.WriteLine("{0}", elemento.Value)
        Next
        Console.WriteLine("------------------------------------")
        Console.WriteLine("Total de paises cargados: {0}", paises.count)
    End Sub

End Module
