using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Cat
    {
        byte _hungryStatus;
        public event EventHandler HungryStatusChanged;
        public Cat(string name, DateTime birthday)

        {
            Name = name;
            BirthDay = birthday;
            Task.Run(LifeCircle);
        }

        public string Name
        {
            get;
            set;
        }
        public void MakeNoise()
        {
            Console.WriteLine($"{Name } мяукает");
        }
        public DateTime BirthDay
        {
            get; set;
        }
        public int GetAge()
        {
            return (DateTime.Today - BirthDay).Days / 365;
        }

        public sbyte HungryStatus
        {
            get { return (sbyte)_hungryStatus; }
            set
            {
                sbyte status = value;
                if (status < 0)
                {
                    status = 0;
                }
                else if (status > 100)
                {
                    status = 100;
                }
                else
                    _hungryStatus = (byte)(sbyte)value;
                if (_hungryStatus < status)
                {
                    HungryStatusChanged?.Invoke(this, null);
                }
                _hungryStatus = (byte)(sbyte)status;
            }
        }

        internal void Feed(byte needFood)
        {
            throw new NotImplementedException();
        }

        public bool HungryStatys { get; private set; }

        public void Feed(sbyte needFood)
        {
            HungryStatus += needFood;
        }

        public string GetStatus(string color)

        {
            string name = Name;
            string age = Convert.ToString(GetAge());
            string status = Convert.ToString(HungryStatys);
            if (HungryStatus < 10)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.DarkRed));
            }
            else if (HungryStatus > 10 && HungryStatus <= 40)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Red));
            }
            else if (HungryStatus > 40 && HungryStatus <= 70)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.DarkYellow));
            }
            else if (HungryStatus > 40 && HungryStatus <= 70)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Yellow));
            }
            else if (HungryStatus > 90)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Green));
            }
            string getStatus = $"{color}, {name}, {age}, {status}";
            return getStatus;
        }

        async Task LifeCircle()
        {

            await Task.Delay(100);
            HungryStatus -= 10;
            await LifeCircle();

        }

        public int Property
        {
            get => default;
            set
            {
            }
        }
    }
}