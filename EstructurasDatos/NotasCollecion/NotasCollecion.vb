Module NotasCollecion


    Sub main()
        Dim cantidad_de_alumnos, cantidad_de_notas, bandera, x, y As Int16
        Dim nombre, promedio As String
        Dim notas As Single
        Dim alumnos_arraylist, notas_arraylist, promedio_arraylist As ArrayList
        alumnos_arraylist = New ArrayList
        notas_arraylist = New ArrayList
        promedio_arraylist = New ArrayList
        cantidad_de_alumnos = cantidad_de_valores_correcta(40, 1, "Alumnos")
        Console.WriteLine("--------------------------------")
        cantidad_de_notas = cantidad_de_valores_correcta(4, 1, "Notas")
        Console.WriteLine("--------------------------------")
        For x = 0 To (cantidad_de_alumnos - 1)
            promedio = 0
            Do
                Console.Write("Ingrese nombre del Alumno: ")
                nombre = Console.ReadLine()
                bandera = validar_el_nombre(nombre, alumnos_arraylist, cantidad_de_alumnos, x)
            Loop Until bandera = 1
            Console.WriteLine("--------------------------------")
            alumnos_arraylist.Insert(x, nombre)
            For y = 0 To (cantidad_de_notas - 1)
                Do
                    Console.Write("Ingrese Nota del Alumno: ")
                    notas = Console.ReadLine()
                    bandera = validar_el_rango_de_la_nota(notas)
                Loop While bandera = 1
                notas_arraylist.Insert(y, notas)
            Next
            Console.WriteLine("--------------------------------")
            promedio_arraylist.Insert(x, determinar_el_promedio(promedio, notas_arraylist, cantidad_de_notas))
        Next
        For x = 0 To (cantidad_de_alumnos - 1)
            Console.WriteLine("{0} {1}", alumnos_arraylist.Item(x), el_alumno_aprobo_o_no(promedio_arraylist, x))
        Next
        Console.WriteLine("--------------------------------")
        lista_de_mejores_alumnos(cantidad_de_alumnos, promedio_arraylist, alumnos_arraylist)
        Console.WriteLine("--------------------------------")
    End Sub
    Function cantidad_de_valores_correcta(maximo As Int16, minimo As Int16, tipo As String) As Int16
        Dim cantidad_correcta As Int16
        Do
            Console.Write("Ingrese cantidad de {0}: ", tipo)
            cantidad_correcta = Console.ReadLine()
            If (cantidad_correcta > maximo Or cantidad_correcta < minimo) Then
                Console.WriteLine("¡ERROR!: Cantida De {0} Invalida", tipo)
            End If
        Loop Until (cantidad_correcta <= maximo And cantidad_correcta >= minimo)
        Return cantidad_correcta
    End Function
    Function validar_el_nombre(nombre, alumnos_arraylist, cantidad_alumnos, x) As Integer
        If Len(nombre) < 3 Then
            Console.WriteLine("¡ERROR! nombre de alumno muy corto")
            Return 0
        Else
            Return validar_la_inexistencia_de_un_nombre_igual(nombre, alumnos_arraylist, cantidad_alumnos, x)
        End If
    End Function
    Function validar_la_inexistencia_de_un_nombre_igual(nombres, alumnos_arraylist, cantidad_alumnos, x) As Integer
        Dim y As Int16
        For y = 0 To (x - 1)
            If nombres = alumnos_arraylist.item(y) Then
                Console.WriteLine("¡ERROR! existe un alumno con el mismo nombre")
                Return 0
            End If
        Next
        Return 1
    End Function
    Function validar_el_rango_de_la_nota(nota) As Integer
        If (nota <= 10 And nota >= 1) Then
            Return 0
        Else
            Return 1
        End If
    End Function
    Function determinar_el_promedio(promedio, notas, cantidad_notas) As Single
        For y = 0 To (cantidad_notas - 1)
            promedio += notas.item(y)
        Next
        promedio /= cantidad_notas
        Return promedio
    End Function
    Function el_alumno_aprobo_o_no(promedio_arraylist, x) As String
        If promedio_arraylist.item(x) >= 6 Then
            Return "Aprobo"
        Else
            Return "Desaprobo"
        End If
    End Function
    Sub lista_de_mejores_alumnos(cantidad_de_alumnos, promedio_arraylist, alumnos_arraylist)
        Dim mejor_promedio As Single
        mejor_promedio = promedio_mas_alto(cantidad_de_alumnos, promedio_arraylist)
        Console.WriteLine("Lista de Mejores Alumnos")
        For x = 0 To (cantidad_de_alumnos - 1)
            If (promedio_arraylist.item(x)) = mejor_promedio Then
                Console.WriteLine("{0}", alumnos_arraylist(x))
            End If
        Next
        Console.WriteLine("Con un promedio de {0}", mejor_promedio)
    End Sub
    Function promedio_mas_alto(cantidad_alumnos, promedio_arraylist) As Single
        Dim mejor_promedio As Single
        mejor_promedio = 0.0
        For x = 0 To (cantidad_alumnos - 1)
            If promedio_arraylist.item(x) > mejor_promedio Then
                mejor_promedio = promedio_arraylist(x)
            End If
        Next
        Return mejor_promedio
    End Function
End Module
