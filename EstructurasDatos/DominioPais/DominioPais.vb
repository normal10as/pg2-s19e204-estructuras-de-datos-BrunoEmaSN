Module DominioPais

    Sub Main()
        Dim paises As Collection
        Dim nombre_de_dominio As String
        paises = New Collection
        paises.Add("Argentina", "ar")
        paises.Add("Brasil", "br")
        paises.Add("Paraguay", "py")
        paises.Add("Uruguay", "ur")
        paises.Add("Bolivia", "bo")
        paises.Add("Chile", "ch")
        Do
            Console.Write("Ingrese un nombre de Dominio: ")
            nombre_de_dominio = Console.ReadLine()
            If paises.Contains(nombre_de_dominio) Then
                Console.WriteLine("Pais: {0}", paises.Item(nombre_de_dominio))
            ElseIf nombre_de_dominio = "" Then
                Console.WriteLine("Salir")
            Else
                Console.WriteLine("¡ERROR! no existe un pais con ese dominio")
            End If

        Loop Until nombre_de_dominio = (Nothing)
    End Sub
End Module
