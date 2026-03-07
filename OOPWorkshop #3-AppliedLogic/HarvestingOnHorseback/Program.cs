using Shared1;

class Program
{
    static void Main()
    {
        Dictionary<string, char> fruits = new Dictionary<string, char>();

        string fruitInput = ConsoleExtension.GetString("Ingrese ubicación de los frutos: ")!;
        string start = ConsoleExtension.GetString("Ingrese posición inicial del caballo: ")!;
        string movesInput = ConsoleExtension.GetString("Ingrese los movimientos del caballo: ")!;

        //Separate each fruit using comma
        var fruitsArray = fruitInput.Split(",");

        //Explore each fruit
        foreach (var f in fruitsArray)
        {
            string pos = f.Substring(0, 2).ToUpper();
            char fruit = f[2];
            fruits[pos] = fruit;
        }

        //Convert column (A,B,C..) to number
        int col = start[0] - 'A';
        //Convert row (1..8) to number
        int row = int.Parse(start[1].ToString()) - 1;

        //Separate movements with a comma
        var moves = movesInput.Split(",");

        //Ready to store picked fruit
        List<char> collected = new List<char>();

        foreach (var m in moves)
        {
            string move = m.Trim().ToUpper();

            // Evaluate what movement is
            switch (move)
            {
                //top left
                case "UL": 
                    row += 2; col -= 1;
                    break;

                //Top right
                case "UR":
                    row += 2; col += 1;
                    break;

                //Top left
                case "LU":
                    row += 1; col -= 2;
                    break;

                //Bottom left
                case "LD":
                    row -= 1; col -= 2;
                    break;

                //Right up
                case "RU":
                    row += 1; col += 2;
                    break;

                //Right down
                case "RD":
                    row -= 1; col += 2;
                    break;

                //Bottom left
                case "DL":
                    row -= 2; col -= 1;
                    break;

                //Bottom right
                case "DR":
                    row -= 2; col += 1;
                    break;
            }

            if (row >= 0 && row < 8 && col >= 0 && col < 8)
            {
                //Convert the position back to A1, B4, etc. format.
                string pos = $"{(char)(col + 'A')}{row + 1}";


                //Check if there is fruit in that position.
                if (fruits.ContainsKey(pos))
                {
                    //Save collected fruit
                    collected.Add(fruits[pos]);

                    //Remove fruit from the board
                    fruits.Remove(pos);
                }
            }
        }

        Console.WriteLine("Los frutos recogidos son: " + string.Join(" ", collected));
    }
}