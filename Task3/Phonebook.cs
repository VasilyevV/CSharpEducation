namespace Task3
{
  /// <summary>
  /// Содержит методы взаимодействия с телефонной книгой. Singleton.
  /// </summary>
  internal class Phonebook
  {
    private static Phonebook instance;
    private Phonebook() { }
    public static Phonebook GetInstance()
    {
      if (instance == null)
        instance = new Phonebook();
      return instance;
    }
    /// <summary>
    /// Вывод на экран списка абонентов (телефонной книги).
    /// </summary>
    internal void Print(List<Abonent> current)
    {
      foreach (var c in current)
        Console.WriteLine(c.name + " " + c.number);
      Console.WriteLine();
    }
    /// <summary>
    /// Добавление нового абонента.
    /// </summary>
    /// <returns>Список с новым абонентом.</returns>
    internal List<Abonent> AddAbon(Abonent abonent, List<Abonent> abonents)
    {
      int j = 0;
      for (int i = 0; i < abonents.Count; i++)
      {
        if (abonent.number == abonents[i].number && abonent.name == abonents[i].name)
        {
          Console.WriteLine("Такой абонент уже есть в списке");
          j++;
        }
      }
      if (j == 0)
      {
        abonents.Add(abonent);
        Console.WriteLine("Добавлен!");
        return abonents;
      }
      else
        return abonents;
    }
    /// <summary>
    /// Поиск абонента по имени.
    /// </summary>
    internal void SearchName(string name, List<Abonent> abonents)
    {
      if (string.IsNullOrEmpty(name))
      {
        Console.WriteLine("Неверный ввод");
        return;
      }
      int j = 0;
      for (int i = 0; i < abonents.Count; i++)
      {
        if (name == abonents[i].name)
        {
          Console.WriteLine("Найдено: " + abonents[i].name + " " + abonents[i].number);
          j++;
        }
      }
      if (j == 0)
        Console.WriteLine("Такого абонента нет.");
      Console.WriteLine();
    }
    /// <summary>
    /// Поиск абонента по номеру телефона.
    /// </summary>
    internal void SearchNumber(string number, List<Abonent> abonents)
    {
      if (string.IsNullOrEmpty(number))
      {
        Console.WriteLine("Неверный ввод");
        return;
      }
      int j = 0;
      for (int i = 0; i < abonents.Count; i++)
      {
        if (number == abonents[i].number)
        {
          Console.WriteLine("Найдено: " + abonents[i].name + " " + abonents[i].number);
          j++;
        }
      }
      if (j == 0)
        Console.WriteLine("Такого абонента нет.");
      Console.WriteLine();
    }
    /// <summary>
    /// Удаление абонента.
    /// </summary>
    /// <returns>Список без удаленного абонента.</returns>
    internal List<Abonent> DelAbon(string item, List<Abonent> abonents)
    {
      if (string.IsNullOrEmpty(item))
      {
        Console.WriteLine("Неверный ввод");
        return abonents;
      }

      for (int i = 0; i < abonents.Count; i++)
      {
        if (item == abonents[i].number || item == abonents[i].name)
        {
          Console.WriteLine("Удален " + abonents[i].name + " " + abonents[i].number);
          abonents.RemoveAt(i);
          return abonents;
        }
      }
      return abonents;
    }
    /// <summary>
    /// Сохранение телефонной книги в файл.
    /// </summary>
    internal void Save(List<Abonent> abonents)
    {
      string path = "phonebook.txt";
      string[] text = new string[abonents.Count];
      for (int i = 0; i < abonents.Count; i++)
        text[i] = abonents[i].name + " " + abonents[i].number;

      File.WriteAllLines(path, text);
      Console.WriteLine("Файл сохранен");
    }
  }
}
