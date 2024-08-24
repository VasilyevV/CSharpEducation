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
    /// Адрес хранения телефонной книги.
    /// </summary>
    const string path = "phonebook.txt";

    /// <summary>
    /// Чтение перечня абонентов из файла.
    /// </summary>
    /// <returns>Список абонентов.</returns>
    internal List<Abonent> Read()
    {
      List<Abonent> abonents = new List<Abonent>();

      string[] text = File.ReadAllLines(path);

      for (int i = 0; i < text.Length; i++)
      {
        string[] s = text[i].Split(' ');
        var abon = new Abonent(s[0], s[1]);
        abonents.Add(abon);
      }
      return abonents;
    }

    /// <summary>
    /// Вывод на экран списка абонентов (телефонной книги).
    /// </summary>
    internal void Print()
    {
      List<Abonent> abonents = Read();
      foreach (var c in abonents)
        Console.WriteLine(c.name + " " + c.number);
    }

    /// <summary>
    /// Добавление нового абонента.
    /// </summary>
    /// <returns>Список с новым абонентом.</returns>
    internal void AddAbon(Abonent abonent)
    {
      List<Abonent> abonents = Read();
      int j = 0;
      for (int i = 0; i < abonents.Count; i++)
      {
        if (abonent.number == abonents[i].number && abonent.name == abonents[i].name)
          j++;
      }
      if (j == 0)
      {
        abonents.Add(abonent);
        Save(abonents);
      }
    }

    /// <summary>
    /// Поиск абонента по имени или номеру.
    /// </summary>
    internal bool Exists(string item)
    {
      List<Abonent> abonents = Read();      
      int j = 0;

      for (int i = 0; i < abonents.Count; i++)
      {
        if (item == abonents[i].name || item == abonents[i].number)
        {         
          j++;
          return true;
        }
      }

      if (j == 0)
        return false;
      return 
        true;
    }

    /// <summary>
    /// Удаление абонента.
    /// </summary>
    /// <returns>Список без удаленного абонента.</returns>
    internal void DelAbon(string item)
    {
      List<Abonent> abonents = Read();

      for (int i = 0; i < abonents.Count; i++)
      {
        if (item == abonents[i].number || item == abonents[i].name)
        { 
          abonents.RemoveAt(i);
          Save(abonents);
        }
      }
    }

    /// <summary>
    /// Сохранение телефонной книги в файл.
    /// </summary>
    internal void Save(List<Abonent> abonents)
    {
      string[] text = new string[abonents.Count];
      for (int i = 0; i < abonents.Count; i++)
        text[i] = abonents[i].name + " " + abonents[i].number;

      File.WriteAllLines(path, text);
    }
  }
}
