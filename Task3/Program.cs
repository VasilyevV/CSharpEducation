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
            break;
          case "2":
            Console.WriteLine("Введите имя и номер телефона:");
            var name = Console.ReadLine();
            var number = Console.ReadLine();
            var abon = new Abonent(name, number);
            phonebook.AddAbon(abon);            
            break;
          case "3":
            Console.WriteLine("Введите имя или номер:");
            var existString = Console.ReadLine();
            if (string.IsNullOrEmpty(existString))
            {
              Console.WriteLine("Неверный ввод");
              break;
            }
            Console.WriteLine(phonebook.Exists(existString));            
            break;
          case "4":
            Console.WriteLine("Введите имя или номер:");
            var item = Console.ReadLine();
            phonebook.DelAbon(item);
            break;
          case "5":
            return;
          default:
            Console.WriteLine("Неверная команда. Попробуйте еще раз.\n");
            break;
        }
      }
    }
  }
}