Module Notas

    Sub Main()
        Dim cantidad_alumnos, cantidad_notas, bandera As Int16
        Console.WriteLine("--------------------------------")
        cantidad_alumnos = cantidad_de_valores_correcta(40, 1, "Alumnos")
        Console.WriteLine("--------------------------------")
        cantidad_notas = cantidad_de_valores_correcta(4, 1, "Notas")
        Console.WriteLine("--------------------------------")
        Dim notas((cantidad_alumnos - 1), (cantidad_notas - 1)) As Single
        Dim promedio(cantidad_alumnos - 1) As Single
        Dim nombres_de_alumnos(cantidad_alumnos - 1) As String
        For x = 0 To (cantidad_alumnos - 1)
            Do
                Console.Write("Ingrese nombre del Alumno: ")
                nombres_de_alumnos(x) = Console.ReadLine()
                bandera = validar_el_nombre(nombres_de_alumnos, cantidad_alumnos, x)
            Loop Until bandera = 1
            Console.WriteLine("--------------------------------")
            For y = 0 To (cantidad_notas - 1)
                Do
                    Console.Write("Ingrese Nota del Alumno: ")
                    notas(x, y) = Console.ReadLine()
                    bandera = validar_el_rango_de_la_nota(notas, x, y)
                Loop While bandera = 1
            Next
            Console.WriteLine("--------------------------------")
            promedio(x) = determinar_el_promedio(promedio, notas, x, cantidad_notas)
        Next
        For x = 0 To (cantidad_alumnos - 1)
            Console.WriteLine("{0} {1}", nombres_de_alumnos(x), el_alumno_aprobo_o_no(promedio, x))
        Next
        Console.WriteLine("--------------------------------")
        lista_de_mejores_alumnos(cantidad_alumnos, promedio, nombres_de_alumnos)
        Console.WriteLine("--------------------------------")
    End Sub
    Function cantidad_de_valores_correcta(maximo As Int16, minimo As Int16, nombre As String) As Int16
        Dim cantidad_correcta As Int16
        Do
            Console.Write("Ingrese cantidad de {0}: ", nombre)
            cantidad_correcta = Console.ReadLine()
            If (cantidad_correcta > maximo Or cantidad_correcta < minimo) Then
                Console.WriteLine("¡ERROR!: Cantida De {0} Invalida", nombre)
            End If
        Loop Until (cantidad_correcta <= maximo And cantidad_correcta >= minimo)
        Return cantidad_correcta
    End Function
    Function validar_el_nombre(nombres_de_alumnos, cantidad_alumnos, x) As Integer
        If Len(nombres_de_alumnos(x)) < 3 Then
            Console.WriteLine("¡ERROR! nombre de alumno muy corto")
            Return 0
        Else
            Return validar_la_inexistencia_de_un_nombre_igual(nombres_de_alumnos, cantidad_alumnos, x)
        End If
    End Function
    Function validar_la_inexistencia_de_un_nombre_igual(nombres_de_alumnos, cantidad_alumnos, x) As Integer
        Dim y As Int16
        For y = 0 To (x - 1)
            If nombres_de_alumnos(y) = nombres_de_alumnos(x) Then
                Console.WriteLine("¡ERROR! existe un alumno con el mismo nombre")
                Return 0
            End If
        Next
        Return 1
    End Function
    Function validar_el_rango_de_la_nota(nota, x, y) As Integer
        If (nota(x, y) <= 10 And nota(x, y) >= 1) Then
            Return 0
        Else
            Return 1
        End If
    End Function
    Function determinar_el_promedio(promedio, notas, x, cantidad_notas) As Single
        For y = 0 To (cantidad_notas - 1)
            promedio(x) += notas(x, y)
        Next
        promedio(x) /= cantidad_notas
        Return promedio(x)
    End Function
    Function el_alumno_aprobo_o_no(promedio, x) As String
        If promedio(x) >= 6 Then
            Return "Aprobo"
        Else
            Return "Desaprobo"
        End If
    End Function
    Sub lista_de_mejores_alumnos(cantidad_alumnos, promedio, nombres_de_alumnos)
        Dim mejor_promedio As Single
        mejor_promedio = promedio_mas_alto(cantidad_alumnos, promedio)
        Console.WriteLine("Lista de Mejores Alumnos")
        For x = 0 To (cantidad_alumnos - 1)
            If (promedio(x)) = mejor_promedio Then
                Console.WriteLine("{0}", nombres_de_alumnos(x))
            End If
        Next
        Console.WriteLine("Con un promedio de {0}", mejor_promedio)
    End Sub
    Function promedio_mas_alto(cantidad_alumnos, promedio) As Single
        Dim mejor_promedio As Single
        mejor_promedio = 0.0
        For x = 0 To (cantidad_alumnos - 1)
            If promedio(x) > mejor_promedio Then
                mejor_promedio = promedio(x)
            End If
        Next
        Return mejor_promedio
    End Function
End Module
