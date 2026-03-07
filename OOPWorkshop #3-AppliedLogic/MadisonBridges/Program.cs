using Shared1;

class Program
{
    static void Main()
    {

        while (true)
        {
            Console.WriteLine();

            string bridge = ConsoleExtension.GetString("Ingrese el puente: ")!;

            // Verify if the bridge complies with the rules
            if (IsValid(bridge))
                Console.WriteLine("VALIDO");
            else
                Console.WriteLine("INVALIDO");

            static bool IsValid(string bridge)
            {
                // If the bridge has less than 2 characters, it cannot be valid.
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
          