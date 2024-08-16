namespace Task3
{
  class Program
  {
    static void Main()
    {
      Phonebook phonebook = Phonebook.GetInstance();
      
      while (true)
      {
        Console.WriteLine("1.Вывести на экран все записи телефонной книги\n2.Добавить нового абонента\n3.Найти абонента по имени" +
                    "\n4.Найти абонента по номеру телефона\n5.Удаление абонента\n6.Выход");
        Console.Write("Введите команду: ");

        string input = Console.ReadLine();

        switch (input)
        {
          case "1":
            phonebook.Print();
            break;
          case "2":
            Console.WriteLine("Введите имя и номер телефона:");
            var name = Console.ReadLine();
            var number = Console.ReadLine();
            var abon = new Abonent(name, number);
            phonebook.AddAbon(abon);            
            break;
          case "3":
            Console.WriteLine("Введите имя:");
            var searchName = Console.ReadLine();
            phonebook.SearchName(searchName);
            break;
          case "4":
            Console.WriteLine("Введите номер:");
            var searchNumber = Console.ReadLine();
            phonebook.SearchNumber(searchNumber);
            break;
          case "5":
            Console.WriteLine("Введите имя или номер:");
            var item = Console.ReadLine();
            phonebook.DelAbon(item);
            break;
          case "6":
            return;
          default:
            Console.WriteLine("Неверная команда. Попробуйте еще раз.\n");
            break;
        }
      }
    }
  }
}