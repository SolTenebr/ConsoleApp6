using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat c = new Cat("ALKATRAZ-Z01Y78", new DateTime(2009, 06, 26));
            c.MakeNoise();
            Console.WriteLine($"Кошке по имени {c.Name} уже {c.GatAge()} лет");
            c.HungryStatus = 150;

            Console.ReadLine();
        }
    }
}
