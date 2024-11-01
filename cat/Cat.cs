using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat
{
    class Cat
    {
        private string name;
        private double ves;
        public string Name
        {
            // получение значения - просто возврат name
            get
            {
                return name;
            }
            // установка значения - используем проверку
            set
            {
                bool OnlyLetters = true;
                // ключ. слово value - это то, что хотят свойству присвоить
                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }

                if (OnlyLetters)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine($"{value} - неправильное имя!!!");
                }
            }
        }
        public double Ves
        {
            // получение значения - просто возврат name
            get
            {
                return ves;
            }
            // установка значения - используем проверку
            set
            {
                if (value > 0)
                {
                    ves = value;
                }
                else
                {
                    Console.WriteLine($"Вес {value} - неправельный вес!!!");
                }
            }
        }
        //конструктор
        public Cat(string CatName,double CatVes)
        {
            Name = CatName;
            Ves = CatVes;
        }
        //метод для опознания отдельно взятого кота
        public void Meow()
        {
            Console.WriteLine($"{name}: МЯЯЯЯУ!!!!");
            Console.WriteLine($"Вес:{ves} кг");
        }
        
    }
}
