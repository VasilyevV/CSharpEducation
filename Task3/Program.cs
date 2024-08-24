namespace Task3
{
  class Program
  {
    static void Main()
    {
      Phonebook phonebook = Phonebook.GetInstance();
      
      while (true)
      {
        Console.WriteLine("1.Вывести на экран все записи телефонной книги\n2.Добавить нового абонента\n3.Найти абонента по имени или номеру" +
                    "\n4.Удаление абонента\n5.Выход");
        Console.Write("Введите команду: ");

        string input = Console.ReadLine();

        switch (input)
        {
          case "1":
            phonebook.Print();
            Console.WriteLine();
            break;
          case "2":
            Console.WriteLine("Введите имя и номер телефона:");

            var name = Console.ReadLine();
            var number = Console.ReadLine();
            var abon = new Abonent(name, number);

            if (phonebook.Exists(name) || phonebook.Exists(number))
              Console.WriteLine("Такой абонент уже существует");
            else
            {
              phonebook.AddAbon(abon);
              Console.WriteLine($"Абонент {abon.name}  {abon.number}  добавлен.");
            }               
            Console.WriteLine("Файл сохранен.");
            Console.WriteLine();
            break;
          case "3":
            Console.WriteLine("Введите имя или номер:");
            var existString = Console.ReadLine();
            if (string.IsNullOrEmpty(existString))
            {
              Console.WriteLine("Неверный ввод");
              break;
            }

            if (phonebook.Exists(existString))
              Console.WriteLine("Есть такой абонент.");
            else
              Console.WriteLine("Такого абонента нет.");
            Console.WriteLine();
            break;
          case "4":
            Console.WriteLine("Введите имя или номер:");
            var item = Console.ReadLine();

            if (string.IsNullOrEmpty(item))
            {
              Console.WriteLine("Неверный ввод");
              Console.WriteLine();
              return;
            }

            if (phonebook.Exists(item))
            {
              phonebook.DelAbon(item);
              Console.WriteLine("Абонент удален.");
              Console.WriteLine("Файл сохранен.");
            }
            else
              Console.WriteLine("Абонента с такими данными не найдено.");
            Console.WriteLine();
            break;
          case "5":
            return;
          default:
            Console.WriteLine("Неверная команда. Попробуйте еще раз.\n");
            Console.WriteLine();
            break;
        }
      }
    }
  }
}