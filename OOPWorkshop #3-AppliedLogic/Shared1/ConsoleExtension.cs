namespace Shared1;

public class ConsoleExtension
{
    public static string? GetString(string message)
    {
       Console.Write(message);
       return Console.ReadLine();
    }

}