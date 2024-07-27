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
        Task2_TicTacToe.UI(matrix, 0);

        for (int i = 0; ; i++)
        {
            Task2_TicTacToe.Move(matrix);

            
        }

        Console.ReadLine();
    }
    static void UI(char[] matrix, int color)
        {
            var line = "-------------";           
            Console.WriteLine(line);

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.Write("| ");
                if (color == 1 && matrix[i] == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(matrix[i] + " ");
                    Console.ResetColor();
                }
                else if (color == 2 && matrix[i] == 'O')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(matrix[i] + " ");
                    Console.ResetColor();
                }
                else
                Console.Write(matrix[i] + " ");

                if (i == 2 || i == 5 || i == 8)
                  Console.WriteLine("|\n" + line);
            }
            return;
        }
    static void Move(char[] matrix)
    {
        Console.Write("Ход игрока Х: ");
        string s1 = Console.ReadLine();  // ход первого игрока
        var move1 = int.Parse(s1);
        for (int i = 0; i < 9; i++)
            if (move1 - 1 == i)
            {
                matrix[i] = 'X';
            }
        Task2_TicTacToe.UI(matrix, 1);
        if (Task2_TicTacToe.Win(matrix) == true)  // проверка на победу
            return;

        int counter = 0;  // проверка пустых клеток
        for (int j = 0; j < 9; j++)
        {
            if (char.IsDigit(matrix[j]))
                counter++;
        }
        if (counter == 0)
        {
            Console.WriteLine("That's all, Folks! Ничья!");
            Console.ReadLine();
            return;
        }

        Console.Write("Ход игрока O: ");
        string s2 = Console.ReadLine(); // ход второго игрока
        var move2 = int.Parse(s2);
        for (int i = 0; i < 9; i++)
            if (move2 - 1 == i)
            {
                matrix[i] = 'O';
            }
        Task2_TicTacToe.UI(matrix, 2);
        if(Task2_TicTacToe.Win(matrix) == true)     // проверка на победу
            return;

        return;
    }

    static bool Win (char[] matrix)
    {
        if (matrix[0] == matrix[1] && matrix[1] == matrix[2])
        {
            if (matrix[0] == 'X')
            {
                Console.WriteLine("Победил игрок Х");
                return true;
            }
            else if (matrix[0] == 'O')
            {
                Console.WriteLine("Победил игрок O");
                return true;
            }
        }

        if (matrix[3] == matrix[4] && matrix[4] == matrix[5])
        {
            if (matrix[3] == 'X')
            {
                Console.WriteLine("Победил игрок Х");
                return true;
            }
            else if (matrix[3] == 'O')
            {
                Console.WriteLine("Победил игрок O");
                return true;
            }
        }

        if (matrix[6] == matrix[7] && matrix[7] == matrix[8])
        {
            if (matrix[6] == 'X')
            {
                Console.WriteLine("Победил игрок Х");
                return true;
            }
            else if (matrix[6] == 'O')
            {
                Console.WriteLine("Победил игрок O");
                return true;
            }
        }

        if (matrix[0] == matrix[3] && matrix[3] == matrix[6])
        {
            if (matrix[0] == 'X')
            {
                Console.WriteLine("Победил игрок Х");
                return true;
            }
            else if (matrix[0] == 'O')
            {
                Console.WriteLine("Победил игрок O");
                return true;
            }
        }

        if (matrix[1] == matrix[4] && matrix[4] == matrix[7])
        {
            if (matrix[1] == 'X')
            {
                Console.WriteLine("Победил игрок Х");
                return true;
            }
            else if (matrix[1] == 'O')
            {
                Console.WriteLine("Победил игрок O");
                return true;
            }
        }

        if (matrix[2] == matrix[5] && matrix[5] == matrix[8])
        {
            if (matrix[2] == 'X')
            {
                Console.WriteLine("Победил игрок Х");
                return true;
            }
            else if (matrix[2] == 'O')
            {
                Console.WriteLine("Победил игрок O");
                return true;
            }
        }

        if (matrix[0] == matrix[4] && matrix[4] == matrix[8])
        {
            if (matrix[0] == 'X')
            {
                Console.WriteLine("Победил игрок Х");
                return true;
            }
            else if (matrix[0] == 'O')
            {
                Console.WriteLine("Победил игрок O");
                return true;
            }
        }

        if (matrix[2] == matrix[4] && matrix[4] == matrix[6])
        {
            if (matrix[2] == 'X')
            {
                Console.WriteLine("Победил игрок Х");
                return true;
            }
            else if (matrix[2] == 'O')
            {
                Console.WriteLine("Победил игрок O");
                return true;
            }
        }

        return false;
    }
}