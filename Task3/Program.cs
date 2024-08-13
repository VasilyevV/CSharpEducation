using System;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
/// Phonebook
namespace Task3
{
    class Abonent
    {
        public string name;
        public string number;
        public Abonent(string Name, string Number)
        {
            this.name = Name;
            this.number = Number;
        }
    }
    class Phonebook
    {
        private static Phonebook instance;
        private Phonebook() { }
        public static Phonebook GetInstance()
        {
            if (instance == null)
                instance = new Phonebook();
            return instance;
        }
        const string path = "phonebook.txt";
        internal List<Abonent> Read()//чтение списка аобонентов из файла
        {
            List<Abonent> abonents = new List<Abonent>();
            
            string[] text = File.ReadAllLines(path);
 
            for(int i = 0; i < text.Length; i++)
            {
                string[] s = text[i].Split(' ');
                var abon = new Abonent(s[0], s[1]);
                abonents.Add(abon);
            }

            return abonents;
        }
        internal void Print(List<Abonent> current) //вывод на экран сохраненной версии телефонной книги
        {
            foreach (var c in current)
                Console.WriteLine(c.name + " " + c.number);
            Console.WriteLine();
        }
        internal List<Abonent> SetAbon(Abonent abonent, List<Abonent> abonents) //добавление нового абонента
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
            if(j == 0)
            {
                abonents.Add(abonent);
                Console.WriteLine("Добавлен!");
                return abonents;
            }
            else
                return abonents;
        }
        internal void SearchName(string name, List<Abonent> abonents) //поиск абонента по имени
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
        internal void SearchNumber(string number, List<Abonent> abonents) //поиск абонента по номеру телефона
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
        internal List<Abonent> DelAbon(string item, List<Abonent> abonents) //удаление абонента
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
        internal void Save (List<Abonent> abonents) //сохранение телефонной книги в файл
        {
            string[] text = new string[abonents.Count]; 
            for(int i = 0; i < abonents.Count; i++)
                text[i] = abonents[i].name + " " + abonents[i].number;

            File.WriteAllLines(path, text);
            Console.WriteLine("Файл сохранен");
        }
    }
    class Run
    {
        static void Main() 
        {
            Phonebook phonebook = Phonebook.GetInstance();
            List<Abonent> abonents = phonebook.Read();

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
                        abonents = phonebook.SetAbon(abon, abonents);
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