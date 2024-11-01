using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat
{
    class Program
    {
        static void Main(string[] args)
        {
            //Результат
            try
            {
                Console.WriteLine("Введите число котов");
                int count = int.Parse(Console.ReadLine());
                for(int i=0;i<count;i++)
                {
                    Console.WriteLine($"Введите имя {i + 1} кота");
                    string cats = Console.ReadLine();
                    Console.WriteLine($"Введите вес {i + 1} кота");
                    double ves = Convert.ToDouble(Console.ReadLine());
                    Cat cat = new Cat(cats, ves);
                    cat.Meow();
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("введите корректно");
                Console.ReadKey();
            }
        }
    }
}
