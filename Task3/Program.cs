using System;
using System.IO;
using System.Reflection.PortableExecutable;
/// Phonebook, CRUD functionality, Singleton
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
        const string path = "C:\\GitHub\\CSharpEducation\\Task3\\phonebook.txt";

        static public List<Abonent> Read()//чтение списка аобонентов из файла
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
        static public void Print(List<Abonent> current) //вывод на экран сохраненной версии телефонной книги
        {
            foreach (var c in current)
                Console.WriteLine(c.name + " " + c.number);
        } 
        static public List<Abonent> SetAbon(Abonent abonent, List<Abonent> current) //добавление нового абонента
        {
            if(current.Contains(abonent) == true)
            {
                Console.WriteLine("Такой абонент уже есть в списке");
                return current;
            }
            else
            {
                current.Add(abonent);
                Console.WriteLine("Добавлен!");
                return current;
            }
        }
        static public Abonent GetAbon(string name) //поиск абонента по имени
        {
            return new Abonent(" ", "");
        }
        static public Abonent GetAbon(Int64 number) //поиск абонента по номеру телефона
        {
            return new Abonent(" ", "");
        }
        static public void DelAbon(Abonent abonent) //удаление абонента
        {

        }
        static public void Save (List<Abonent> abonents) //сохранение телефонной книги в файл
        {

        }
    }
    class Run
    {
        static void Main() 
        {
            List<Abonent> abonents = Phonebook.Read();

            while (true)
            {
                Console.WriteLine("1.Вывести на экран все записи телефонной книги\n2.Добавить нового абонента\n3.Найти абонента по имени" +
                    "\n4.Найти абонента по номеру телефона\n5.Удаление абонента\n6.Выход\n");
                Console.Write("Введите команду: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Phonebook.Print(abonents);
                        break;
                    case "2":
                        Console.WriteLine("Введите имя и номер телефона");
                        var abon = new Abonent(Console.ReadLine(), Console.ReadLine());
                        abonents = Phonebook.SetAbon(abon, abonents);
                        break;
                    case "3":
                        //GetAbon
                        break;
                    case "4":
                        //GetAbon
                        break;
                    case "5":
                        //DelAbon
                        break;
                    case "6":
                        //Save
                        return;    
                    default:
                        Console.WriteLine("Неверная команда. Попробуйте еще раз.\n");
                        break;
                }
            }
        }
    }
}