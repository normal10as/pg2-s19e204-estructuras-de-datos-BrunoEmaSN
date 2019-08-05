Imports System

Module Turnos_LinkedList
    Sub Main()
        Dim nombres_clientes As New LinkedList(Of String)
        Dim nombre, ultimo_anciano, ultima_embarazada, turno As String
        Dim prioridad As Byte
        ultimo_anciano = "/"
        ultima_embarazada = "/"
        Do
            Console.Write("Ingrese nombre del cliente(Fin=''):")
            nombre = Console.ReadLine()
            If nombre <> "" Then
                Console.WriteLine("1. cliente normal")
                Console.WriteLine("2. cliente embarazada")
                Console.WriteLine("3. cliente de edad avanzada")
                Console.Write("Ingrese prioridad: ")
                prioridad = Console.ReadLine()
                Select Case prioridad
                    Case 1
                        cliente_normal(nombres_clientes, nombre)
                    Case 2
                        cliente_embarazada(nombres_clientes, nombre, ultimo_anciano, ultima_embarazada)
                        ultima_embarazada = nombre
                    Case 3
                        cliente_de_edad_avanzada(nombres_clientes, nombre, ultimo_anciano, ultima_embarazada)
                        ultimo_anciano = nombre
                End Select

            End If
        Loop Until (nombre = "")

        Do
            Console.Write("Presione enter para continuar:")
            turno = Console.ReadLine()
            el_siguiente_turno(nombres_clientes)
        Loop Until (nombres_clientes.Count = 0)
    End Sub
    Sub cliente_normal(nombres_clientes As LinkedList(Of String), nombre As String)
        nombres_clientes.AddLast(nombre)
    End Sub
    Sub cliente_embarazada(nombres_clientes As LinkedList(Of String), nombre As String, ultimo_anciano As String, ultima_embarazada As String)
        If nombres_clientes.Contains(ultimo_anciano) Then
            If nombres_clientes.Contains(ultima_embarazada) Then
                nombres_clientes.AddAfter(nombres_clientes.FindLast(ultima_embarazada), nombre)
            Else
                nombres_clientes.AddAfter(nombres_clientes.FindLast(ultimo_anciano), nombre)
            End If
        Else
            If nombres_clientes.Contains(ultima_embarazada) Then
                nombres_clientes.AddAfter(nombres_clientes.FindLast(ultima_embarazada), nombre)
            Else
                nombres_clientes.AddFirst(nombre)
            End If
        End If

    End Sub
    Sub cliente_de_edad_avanzada(nombres_clientes As LinkedList(Of String), nombre As String, ultimo_anciano As String, ultima_embarazada As String)
        If nombres_clientes.Contains(ultimo_anciano) Then
            nombres_clientes.AddAfter(nombres_clientes.FindLast(ultimo_anciano), nombre)
        Else
            nombres_clientes.AddFirst(nombre)
        End If
    End Sub
    Sub el_siguiente_turno(nombres_clientes As LinkedList(Of String))
        Console.WriteLine("El turno es de {0}", nombres_clientes(0))
        nombres_clientes.RemoveFirst()
        If nombres_clientes.Count > 0 Then
            Console.WriteLine("En {0} espera", nombres_clientes.Count)
        Else
            Console.WriteLine("Sin clientes")
        End If

    End Sub
End Module
