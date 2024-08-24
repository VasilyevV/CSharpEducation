using System;
using System.Security.Cryptography;
namespace Task2
{
  class Program
  {
    static void Main()
    {
      char[] matrix = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

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
      UI(matrix, 0);

      for (int i = 0; ; i++)
      {
        Move(matrix);
        if (Win(matrix) == true)
        {
          Console.ReadLine();
          return;
        }
      }


    }
    static void UI(char[] matrix, int color)            //вывод игрового поля
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
    static void Move(char[] matrix)             //
    {
      string s1 = string.Empty;    // ход первого игрока
      Console.Write("Ход игрока Х: ");
      do
      {
        s1 = Console.ReadLine();
        if (Char.IsDigit(s1, 0) == false)
          Console.Write("Неверный ход, еще раз: ");
      } while (Char.IsDigit(s1, 0) == false);

      var move1 = int.Parse(s1);
      for (int i = 0; i < 9; i++)
        if (move1 - 1 == i)
        {

          if (Char.IsDigit(matrix[i]) == false)
          {
            Console.WriteLine("Неверный ход, еще раз: ");
            break;
          }
          matrix[i] = 'X';
        }
      UI(matrix, 1);
      if (Win(matrix) == true)
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

      string s2 = string.Empty;    // ход второго игрока
      Console.Write("Ход игрока О: ");
      do
      {
        s2 = Console.ReadLine();
        if (Char.IsDigit(s2, 0) == false)
          Console.Write("Неверный ход, еще раз: ");
      } while (Char.IsDigit(s2, 0) == false);

      var move2 = int.Parse(s2);
      for (int i = 0; i < 9; i++)
        if (move2 - 1 == i)
        {
          matrix[i] = 'O';
        }
      UI(matrix, 2);
      if (Win(matrix) == true)
        return;

      return;
    }

    static bool Win(char[] matrix)       // проверка на победу
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
}