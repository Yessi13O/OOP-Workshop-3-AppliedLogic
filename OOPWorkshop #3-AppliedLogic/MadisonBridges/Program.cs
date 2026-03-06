using System;
using Shared1;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese puentes para validar.");
        Console.WriteLine("Presione Ctrl + C para salir.");

        while (true)
        {
            Console.WriteLine();

            string bridge = ConsoleExtension.GetString("Ingrese el puente: ")!;

            if (IsValid(bridge))
                Console.WriteLine("VALIDO");
            else
                Console.WriteLine("INVALIDO");

            static bool IsValid(string bridge)
            {
                if (bridge.Length < 2)
                    return false;

                // Debe empezar y terminar con *
                if (bridge[0] != '*' || bridge[bridge.Length - 1] != '*')
                    return false;

                // No puede haber * en el centro
                for (int i = 1; i < bridge.Length - 1; i++)
                {
                    if (bridge[i] == '*')
                        return false;
                }

                // Verificar simetría
                for (int i = 0; i < bridge.Length / 2; i++)
                {
                    if (bridge[i] != bridge[bridge.Length - 1 - i])
                        return false;
                }

                // No puede haber más de 3 '=' seguidos
                if (bridge.Contains("===="))
                    return false;

                return true;
            }
        }
    }
}
          