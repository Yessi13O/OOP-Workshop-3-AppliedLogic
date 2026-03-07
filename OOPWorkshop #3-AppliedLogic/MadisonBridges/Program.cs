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

                // It must begin and end with *
                if (bridge[0] != '*' || bridge[bridge.Length - 1] != '*')
                    return false;

                // There cannot be a * in the center
                for (int i = 1; i < bridge.Length - 1; i++)
                {
                    if (bridge[i] == '*')
                        return false;
                }

                // Check symmetry
                for (int i = 0; i < bridge.Length / 2; i++)
                {
                    if (bridge[i] != bridge[bridge.Length - 1 - i])
                        return false;
                }

                // There cannot be more than 3 '=' in a row
                if (bridge.Contains("===="))
                    return false;

                return true;
            }
        }
    }
}
          