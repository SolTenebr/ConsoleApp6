using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
   public class Cat
    {
        byte _hungryStatus;

        public Cat(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
            Task.Run(LifeCircle);
        }

        public string Name
        {
            get;
            set;
        }

        public void MakeNoise()
        {
            Console.WriteLine($"{Name} мяукает");
        }

        public DateTime Birthday
        {
            get;
            set;
        }

        public int GatAge()
        {
            return (DateTime.Today - Birthday).Days / 365;
        }

        public byte HungryStatus
        {
            get { return _hungryStatus; }
            set
            {
                if (value < 0)
                {
                    _hungryStatus = 0;
                }
                else if (value > 100)
                {
                    _hungryStatus = 100;
                }
                else
                    _hungryStatus = value;
            }

        }

        public void GetStatus()
        {
            Console.WriteLine(Name);
            Console.WriteLine($"Возраст: {GatAge()}");
            if (HungryStatus <= 10)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Кошка умирает от голода");
            }
            else if (HungryStatus > 10 && HungryStatus <= 40)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Кошка очень голодна");
            }
            else if (HungryStatus > 70 && HungryStatus <= 90)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Кошка не против перекусить");
            }
            else if(HungryStatus > 90)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Кошка не голодна");
            }
            Console.ResetColor();
        }

        async Task LifeCircle()
        {
            await Task.Delay(1000);
            HungryStatus -= 10;
            GetStatus();
            if (HungryStatus == 0)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Кошка умерла :(");
            }
            else await LifeCircle();

        }
    }
}
