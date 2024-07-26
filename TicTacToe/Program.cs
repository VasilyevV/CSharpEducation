using System;

class Task2_TicTacToe
{
    static void Main()
    {
        char[] matrix = new char[] {'1','2','3','4','5','6','7','8','9'};

        Console.WriteLine("Играем в игру <Крестики-Нолики>, хотите сыграть с другим игроком? (y/n)");

        ConsoleKeyInfo key = Console.ReadKey();
        while (true)
        {
            if (key.Key == ConsoleKey.N)
            {
                Console.WriteLine("\nПока");
                Console.ReadLine();
                return;
            }
            else if (key.Key == ConsoleKey.Y)
                break;
            else
            {
                Console.WriteLine("\nЧто? Не понятно. Пока.");
                Console.ReadLine();
                return;
            }
        }
        
        Console.WriteLine();
        TicTacToe.UI(matrix);

        for (int i = 0; ; i++)
        {
          TicTacToe.Move(matrix);
          
        }

        Console.ReadLine();
    }
    static void UI(char[] matrix)
        {
            var line = "-------------";           
            Console.WriteLine(line);

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.Write("| " + matrix[i] + " ");
                if (i == 2 || i == 5 || i == 8)
                  Console.WriteLine("|\n" + line);
            }
            return;
        }
    static void Move(char[] matrix)
    {
        Console.Write("Ход игрока Х: ");
        string s1 = Console.ReadLine();
        var move1 = int.Parse(s1);
        for (int i = 0; i < 9; i++)
            if (move1 - 1 == i)
            {
                matrix[i] = 'X';
            }
        TicTacToe.UI(matrix);

        int counter = 0;
        for (int j = 0; j < 9; j++)
        {
            if (char.IsDigit(matrix[j]))
                counter++;
        }
        if (counter == 0)
        {
            Console.WriteLine("That's all, Folks!");
            Console.ReadLine();
            return;
        }

        Console.Write("Ход игрока O: ");
        string s2 = Console.ReadLine();
        var move2 = int.Parse(s2);
        for (int i = 0; i < 9; i++)
            if (move2 - 1 == i)
            {
                matrix[i] = 'O';
            }
        TicTacToe.UI(matrix);

        counter = 0;
        for (int j = 0; j < 9; j++)
        {
            if (char.IsDigit(matrix[j]))
                counter++;
        }
        if (counter == 0)
        {
            Console.WriteLine("That's all, Folks!");
            Console.ReadLine();
            return;
        }

        return;
    }
}