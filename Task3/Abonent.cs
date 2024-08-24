namespace Task3
{
  /// <summary>
  /// Класс абонента.
  /// </summary>
  internal class Abonent
  {
    /// <summary>
    /// Имя абонента.
    /// </summary>
    public string name;

    /// <summary>
    /// Номер телефона абонента.
    /// </summary>
    public string number;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="Name">Имя</param>
    /// <param number="Number">Номер</param>
    public Abonent(string Name, string Number)
      {
        this.name = Name;
        this.number = Number;
      }
  }
}
