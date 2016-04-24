using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace л.р._3
{
    // Класс транспортное средство
    abstract class Vehicle
    {
        private int price;      // стоимость тр. средства
        private int year;       // год выпуска
        private int maxspeed;   // максимальная скорость
        private int curspeed;   // текущая скорость

        public int Price // свойство стоимости
        {
            get { return price; }
            set { if (value > 0) price = value; }
        }
        public int Year // свойство года выпуска
        {
            get { return year; }
            set { if (value > 1900 && value <= DateTime.Today.Year) year = value; }
        }
        public int MaxSpeed // свойство максимальной скорости
        {
            get { return maxspeed; }
            set { if (value > 0) maxspeed = value; }
        }
        public int CurrentSpeed // cвойство текущей скорости
        {
            get { return curspeed; }
            set { if (value > maxspeed) throw OutOfMaxBorder; curspeed = value; }
        }
        public virtual void SpeedUp()   // метод увеличения текущей скорости
        {
            CurrentSpeed++;
        }
        public virtual void SpeedDown() // метод уменьшения текущей скорости
        {
            CurrentSpeed--;
        }
        // исключения для классов наследников:
        protected Exception NonBellowZero = new Exception("Исключение, введенное значение не может быть отрицательным!");
        protected Exception OutOfMaxBorder = new Exception("Исключение, превышена максимальна граница!");
    }
        class Plane : Vehicle // класс самолет
        {
            private int height; // высота
            private int passengers; // пассажиры
            public int MaxPassengers { get; set; }
            public Plane(int maxpassengers)
            {
                MaxPassengers = maxpassengers;
            }
            public override void SpeedDown()
            {
                CurrentSpeed -= 75;
            }
            public override void SpeedUp()
            {
                CurrentSpeed += 75;
            }
            public int GetCurrentPassengers()
            {
                return passengers;
            }
            public void SetCurrentPassengers(int n)
            {
                if (n > MaxPassengers)
                {
                    throw OutOfMaxBorder;
                }
                else if (n < 0)
                {
                    throw NonBellowZero;
                }
                passengers = n;
            }
            public int GetCurrentHeight()
            {
                return height;
            }
            public void SetCurrentHeight(int _height)
            {
                if (height < 0)
                {
                    throw NonBellowZero;
                }
                height = _height;
            }
        }
        class Ship : Vehicle
        {
            private string port;
            private int passengers;

            public int MaxPassengers { get; set; }
            public Ship(int maxpassengers)
            {
                MaxPassengers = maxpassengers;
            }
            public int GetCurrentPassengers()
            {
                return passengers;
            }
            public void SetCurrentPassengers(int n)
            {

                if (n > MaxPassengers)
                {
                    throw OutOfMaxBorder;
                }
                else if (n < 0)
                {
                    throw NonBellowZero;
                }
                passengers = n;
            }
            public string GetPort()
            {
                return port;
            }
            public void SetPort(string _port)
            {
                port = _port;
            }
        }
        class Car : Vehicle
        {
            public override void SpeedDown()
            {
                CurrentSpeed -= 15;
            }
            public override void SpeedUp()
            {
                CurrentSpeed += 15;
            }
        }
    class Program
    {
        static void Main(string[] args)
        {
            // Plane
            try
            {
                Plane P1 = new Plane(400) { MaxSpeed = 1000, Price = 2000000, Year = 2008 };
                P1.SetCurrentPassengers(300);   // посадили 300 человек на рейс
                P1.SetCurrentHeight(8000);      // взлетаем на высоту 8км
                P1.CurrentSpeed = 700;           // разгоняемся до 800 км/час
                Console.WriteLine(" \t\t\t САМОЛЕТ!!!!!!!! \t\t\t ");
                Console.WriteLine("Характеристики самолета:");
                Console.WriteLine("Год выпуска: {0}", P1.Year.ToString().PadLeft(15));
                Console.WriteLine("Стоимость: {0} $", P1.Price.ToString().PadLeft(20));
                Console.WriteLine("Высота полета: {0} км", P1.GetCurrentHeight().ToString().PadLeft(13));
                Console.WriteLine("Посадочных мест: {0}", P1.MaxPassengers.ToString().PadLeft(10));
                Console.WriteLine("Поссажиров на борту: {0}", P1.GetCurrentPassengers().ToString().PadLeft(6));
                Console.WriteLine("Макс. скорость: {0} км/час", P1.MaxSpeed.ToString().PadLeft(12));
                Console.WriteLine("Текущая скорость: {0} км/час", P1.CurrentSpeed.ToString().PadLeft(9));
                Console.WriteLine("Ускоряемся ...");
                P1.SpeedUp();
                Console.WriteLine("Текущая скорость: {0} км/час", P1.CurrentSpeed.ToString().PadLeft(9));
                Console.WriteLine("".PadLeft(19, '*'));
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Ship
            try
            {
                Ship S1 = new Ship(70) { MaxSpeed = 30, Price = 300000, Year = 2002 };
                S1.SetCurrentPassengers(55);    // посадили 55 в корабль
                S1.SetPort("Симферополь");      // порт назначения Симферополь
                S1.CurrentSpeed = 20;           // скорость 20 узло
                Console.WriteLine(" \t\t\t КОРАБЛЬ!!!!!!! \t\t\t ");
                Console.WriteLine("Характеристики корабля");
                Console.WriteLine("Год выпуска: {0}", S1.Year.ToString().PadLeft(16));
                Console.WriteLine("Стоимость: {0} $", S1.Price.ToString().PadLeft(20));
                Console.WriteLine("Порт приписки: {0}", S1.GetPort().ToString().PadLeft(21));
                Console.WriteLine("Посадочных мест: {0}", S1.MaxPassengers.ToString().PadLeft(10));
                Console.WriteLine("Поссажиров на борту: {0}", S1.GetCurrentPassengers().ToString().PadLeft(6));
                Console.WriteLine("Макс. скорость: {0} узлов", S1.MaxSpeed.ToString().PadLeft(11));
                Console.WriteLine("Текущая скорость: {0} узлов", S1.CurrentSpeed.ToString().PadLeft(9));
                Console.WriteLine("Замедляемся ...");
                S1.SpeedDown();
                Console.WriteLine("Текущая скорость: {0} узлов", S1.CurrentSpeed.ToString().PadLeft(9));
                Console.WriteLine("".PadLeft(19, '*'));
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Car
            try
            {
                Car C1 = new Car() { Price = 30000, Year = 2006, MaxSpeed = 180 };
                C1.CurrentSpeed = 170;          // машина едит на скорости 170 км/час
                Console.WriteLine(" \t\t\t МАШИНА!!!!!!!! \t\t\t ");
                Console.WriteLine("Характеристики автомобиля:");
                Console.WriteLine("Год выпуска: {0}", C1.Year.ToString().PadLeft(15));
                Console.WriteLine("Стоимость: {0} $", C1.Price.ToString().PadLeft(18));
                Console.WriteLine("Макс. скорость: {0} км/час", C1.MaxSpeed.ToString().PadLeft(11));
                Console.WriteLine("Текущая скорость: {0} км/час", C1.CurrentSpeed.ToString().PadLeft(9));
                Console.WriteLine("Ускоряемся ...");
                // так-как текущая скорость машины 170 км/час
                // а метод SpeedUp() дает прирост скорости на 25 км/час
                // что в сумме привысит максимальную скорость, и приведет к исключению
                C1.SpeedUp();
                Console.WriteLine("Текущая скорость: {0} узлов", C1.CurrentSpeed.ToString().PadLeft(9));
                Console.WriteLine("".PadLeft(18, '*'));
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
