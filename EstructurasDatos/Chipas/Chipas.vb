Imports System

Module Chipas
    Sub Main()
        Dim total_por_empleado As New SortedList(Of String, Single)
        Dim domingo, lunes, martes, miercoles, jueves, viernes, sabado As New List(Of Single)
        Dim empleados_sortedlist As New SortedList(Of String, String)
        Dim productos_sortedlist As New SortedList(Of Byte, String)
        Dim precio_sortedlist As New SortedList(Of String, Single)
        Dim cantidad As UInt16
        Dim precio, total As Single
        Dim bandera1, dia As Byte
        Dim empleado, producto As String

        agregar_productos(productos_sortedlist)
        agregar_precio(precio_sortedlist)
        agregar_empleados(empleados_sortedlist, total_por_empleado)

        Do
            Do
                Console.WriteLine("//////////////////////////////////////////////////")
                empleado = ingresar_empleado(empleados_sortedlist)
            Loop While (empleado = "")
            Do
                Console.WriteLine("//////////////////////////////////////////////////")
                producto = ingresar_producto(productos_sortedlist)
            Loop While (producto = "")
            precio = cargar_precio(precio_sortedlist, producto)
            cantidad = ingresar_cantidad()
            Do
                Console.WriteLine("//////////////////////////////////////////////////")
                Console.Write("Ingrese dia: ")
                dia = Console.ReadLine()
                If dia < 1 Or dia > 7 Then
                    Console.WriteLine("Error al ingresar dia")
                End If
            Loop Until (dia > 0 And dia < 8)
            totalizar_por_dia(domingo, lunes, martes, miercoles, jueves, viernes, sabado, (cantidad * precio), dia)
            totalizar_por_empleado(total_por_empleado, empleado, (cantidad * precio))
            total += (cantidad * precio)
            Console.WriteLine("//////////////////////////////////////////////////")

            Console.WriteLine("1. SI")
            Console.WriteLine("2. NO")
            Console.Write("Desea continuar: ")
            bandera1 = Console.ReadLine()

        Loop Until (bandera1 = 2)

        Console.WriteLine("//////////////////////////////////////////////////")
        Console.WriteLine("Total por Empleados")

        For Each clave In empleados_sortedlist.Values
            Console.WriteLine("{0}: {1}", clave, total_por_empleado.Item(clave))
        Next

        Console.WriteLine("//////////////////////////////////////////////////")

        Console.WriteLine("Total por Dia")

        mostrar_total_por_dia(domingo, "Domingo")
        mostrar_total_por_dia(lunes, "Lunes")
        mostrar_total_por_dia(martes, "Martes")
        mostrar_total_por_dia(miercoles, "Miercoles")
        mostrar_total_por_dia(jueves, "Jueves")
        mostrar_total_por_dia(viernes, "Viernes")
        mostrar_total_por_dia(sabado, "Sabado")
        Console.WriteLine("//////////////////////////////////////////////////")
    End Sub

    Sub agregar_productos(productos_sortedlist As SortedList(Of Byte, String))
        productos_sortedlist.Add(1, "Cabure")
        productos_sortedlist.Add(2, "Chipa")
        productos_sortedlist.Add(3, "Sopa Paraguaya")
    End Sub

    Sub agregar_precio(precio_sortedlist As SortedList(Of String, Single))
        precio_sortedlist.Add("Cabure", 15.3)
        precio_sortedlist.Add("Chipa", 10.5)
        precio_sortedlist.Add("Sopa Paraguaya", 35.9)
    End Sub

    Sub agregar_empleados(empleados_sortedlist As SortedList(Of String, String), total_por_empleado As SortedList(Of String, Single))
        empleados_sortedlist.Add("sss", "Sisto Samuel Suarez")
        empleados_sortedlist.Add("fas", "Fernando Ariel Suarez")
        empleados_sortedlist.Add("pis", "Pablo Ivan Suarez")
        empleados_sortedlist.Add("sasn", "Santiago Abel Sanchez Negrete")
        empleados_sortedlist.Add("besn", "Bruno Emanuel Sanchez Negrete")

        total_por_empleado.Add("Sisto Samuel Suarez", 0)
        total_por_empleado.Add("Fernando Ariel Suarez", 0)
        total_por_empleado.Add("Pablo Ivan Suarez", 0)
        total_por_empleado.Add("Santiago Abel Sanchez Negrete", 0)
        total_por_empleado.Add("Bruno Emanuel Sanchez Negrete", 0)
    End Sub

    Function ingresar_empleado(empleados_sortedlist As SortedList(Of String, String)) As String
        Dim id As String
        Console.Write("Ingrese clave de empleado: ")
        id = Console.ReadLine()
        If empleados_sortedlist.ContainsKey(id) Then
            Return empleados_sortedlist.Item(id)
        Else
            Console.WriteLine("Error no Existe empleado con tal id")
            Return ""
        End If
    End Function

    Sub totalizar_por_dia(domingo As List(Of Single), lunes As List(Of Single), martes As List(Of Single), miercoles As List(Of Single), jueves As List(Of Single),
                     viernes As List(Of Single), sabado As List(Of Single), precio As Single, dia As Byte)
        Select Case dia
            Case 1
                domingo.Add(precio)
            Case 2
                lunes.Add(precio)
            Case 3
                martes.Add(precio)
            Case 4
                miercoles.Add(precio)
            Case 5
                jueves.Add(precio)
            Case 6
                viernes.Add(precio)
            Case 7
                sabado.Add(precio)
        End Select
    End Sub

    Sub totalizar_por_empleado(total_por_empleado As SortedList(Of String, Single), empleado As String, precio As Single)
        total_por_empleado(empleado) += precio
    End Sub

    Function ingresar_producto(productos_sortedlist As SortedList(Of Byte, String)) As String
        Dim id As Byte
        Console.Write("Ingrese id de producto: ")
        id = Console.ReadLine()
        If productos_sortedlist.ContainsKey(id) Then
            Return productos_sortedlist.Item(id)
        Else
            Console.WriteLine("Error no Existe producto con tal id")
            Return ""
        End If
    End Function

    Function cargar_precio(precio_sortedlist As SortedList(Of String, Single), id As String) As Single
        Return precio_sortedlist.Item(id)
    End Function

    Function ingresar_cantidad() As UInt16
        Console.Write("Ingrese cantidad: ")
        Return Console.ReadLine()
    End Function

    Sub mostrar_total_por_dia(dia_list As List(Of Single), dia_string As String)
        Dim total_dia As Single
        For x = 0 To dia_list.Count - 1
            total_dia += dia_list.Item(x)
        Next
        Console.WriteLine("{0}: {1}", dia_string, total_dia)
    End Sub
End Module
