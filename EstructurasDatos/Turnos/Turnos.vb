Imports System

Module Turnos
    Sub Main()
        Dim turnos_de_los_clientes As New Queue
        Dim nombes_de_los_clientes, turno As String
        Do
            Console.Write("Ingrese nombre del cliente(Fin=''): ")
            nombes_de_los_clientes = Console.ReadLine()
            If nombes_de_los_clientes <> "" Then
                turnos_de_los_clientes.Enqueue(nombes_de_los_clientes)
            End If
        Loop Until (nombes_de_los_clientes = "")
        For x = 0 To (turnos_de_los_clientes.Count - 1)
            Console.Write("Presione enter para continuar:")
            turno = Console.ReadLine()
            Console.WriteLine("el siguiente turno es de {0}", turnos_de_los_clientes.Dequeue)
            Console.WriteLine("{0} en espera", turnos_de_los_clientes.Count)
        Next
    End Sub
End Module