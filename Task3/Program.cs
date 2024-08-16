namespace Task3
{
  class Program
  {
    /// <summary>
    /// Чтение перечня абонентов из файла.
    /// </summary>
    /// <returns>Список абонентов.</returns>
    static List<Abonent> Read()
    {
      List<Abonent> abonents = new List<Abonent>();
      string path = "phonebook.txt";

      string[] text = File.ReadAllLines(path);

      for (int i = 0; i < text.Length; i++)
      {
        string[] s = text[i].Split(' ');
        var abon = new Abonent(s[0], s[1]);
        abonents.Add(abon);
      }
      return abonents;
    }
    static void Main()
    {
      Phonebook phonebook = Phonebook.GetInstance();
      List<Abonent> abonents = Read();

      while (true)
      {
        Console.WriteLine("1.Вывести на экран все записи телефонной книги\n2.Добавить нового абонента\n3.Найти абонента по имени" +
                    "\n4.Найти абонента по номеру телефона\n5.Удаление абонента\n6.Сохранить изменения\n7.Выход");
        Console.Write("Введите команду: ");

        string input = Console.ReadLine();

        switch (input)
        {
          case "1":
            phonebook.Print(abonents);
            break;
          case "2":
            Console.WriteLine("Введите имя и номер телефона:");
            var name = Console.ReadLine();
            var number = Console.ReadLine();
            var abon = new Abonent(name, number);
            abonents = phonebook.AddAbon(abon, abonents);
            phonebook.Save(abonents);
            break;
          case "3":
            Console.WriteLine("Введите имя:");
            var searchName = Console.ReadLine();
            phonebook.SearchName(searchName, abonents);
            break;
          case "4":
            Console.WriteLine("Введите номер:");
            var searchNumber = Console.ReadLine();
            phonebook.SearchNumber(searchNumber, abonents);
            break;
          case "5":
            Console.WriteLine("Введите имя или номер:");
            var item = Console.ReadLine();
            abonents = phonebook.DelAbon(item, abonents);
            break;
          case "6":
            phonebook.Save(abonents);
            break;
          case "7":
            phonebook.Save(abonents);
            return;
          default:
            Console.WriteLine("Неверная команда. Попробуйте еще раз.\n");
            break;
        }
      }
    }
  }
}