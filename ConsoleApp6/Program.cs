using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("ALKATRAZ", new DateTime(2005, 8, 7));
            Console.WriteLine($"Коту по имени {cat.Name} уже {cat.GetAge()} лет");
            cat.HungryStatus = 150;
            cat.HungryStatusChanged += Cat_HungryStatusChanged;
            Cat cat2 = new Cat("Kit", new DateTime(2005, 8, 7));
            Console.WriteLine($"Коту по имени {cat2.Name} уже {cat2.GetAge()} лет");
            cat2.HungryStatusChanged += Cat2_HungryStatusChanged;
            Console.ReadLine();

        }

        public static void Cat_HungryStatusChanged(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Cat cat = (Cat)sender;
            if (cat.HungryStatus < 20 && rnd.Next(0, 10) < 5)
                cat.Feed();
            else
                cat.GetStatus();
        }
        public static void Cat2_HungryStatusChanged(object sender, EventArgs e)

        {
            Random rnd = new Random();
            Cat cat = (Cat)sender;
            if (cat.HungryStatus < 20 && rnd.Next(0, 10) < 5)
                cat.Feed();
            else
                cat.GetStatus();


        }

    }
}