﻿using System;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
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
            Console.WriteLine();
        } 
        static public List<Abonent> SetAbon(Abonent abonent, List<Abonent> abonents) //добавление нового абонента
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
        static public void SearchName(string name, List<Abonent> abonents) //поиск абонента по имени
        {
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
        static public void SearchNumber(string number, List<Abonent> abonents) //поиск абонента по номеру телефона
        {
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
                        Console.WriteLine("Введите имя и номер телефона:");
                        var name = Console.ReadLine();
                        var number = Console.ReadLine();
                        var abon = new Abonent(name, number);
                        abonents = Phonebook.SetAbon(abon, abonents);
                        break;
                    case "3":
                        Console.WriteLine("Введите имя:");
                        var searchName = Console.ReadLine();
                        Phonebook.SearchName(searchName, abonents);
                        break;
                    case "4":
                        Console.WriteLine("Введите номер:");
                        var searchNumber = Console.ReadLine();
                        Phonebook.SearchNumber(searchNumber, abonents);
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