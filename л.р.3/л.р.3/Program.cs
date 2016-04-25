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
            set { if (value > 1000 && value <= DateTime.Today.Year) year = value; }
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
            bool flag = true;
            // Car
            try
            {
                Car C = new Car();
                C.Price = 0; C.Year = 0; C.MaxSpeed = 0; C.CurrentSpeed = 0;
                Console.WriteLine(" \t\t\t МАШИНА!!!!!!!! \t\t\t ");
                while (flag)
                {
                    try
                    {
                        Console.WriteLine("Введите год выпуска: ");
                        C.Year = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат ввода");
                    }
                }
                while(flag)
                {
                    try
                    {
                        Console.WriteLine("Введите стоимость: ");
                        C.Price = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат ввода");
                    }
                }
                while (flag)
                {
                    try
                    {
                        Console.WriteLine("Введите максимальную скорость: ");
                        C.MaxSpeed = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат ввода");
                    }
                }
                Console.WriteLine("Введите текущую скорость: ");
                C.CurrentSpeed = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Характеристики автомобиля:");
                Console.WriteLine("Год выпуска: {0}", C.Year.ToString().PadLeft(15));
                Console.WriteLine("Стоимость: {0} $", C.Price.ToString().PadLeft(19));
                Console.WriteLine("Макс. скорость: {0} км/час", C.MaxSpeed.ToString().PadLeft(11));
                Console.WriteLine("Текущая скорость: {0} км/час", C.CurrentSpeed.ToString().PadLeft(9));
                Console.WriteLine("Ускоряемся ...");
                C.SpeedUp(); // а метод SpeedUp() дает прирост скорости, что в сумме привысит максимальную скорость, и приведет к исключению
                Console.WriteLine("Текущая скорость: {0} км/час", C.CurrentSpeed.ToString().PadLeft(9));
                Console.WriteLine("".PadLeft(18, '*'));
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            /*************************************************************************************************************************/
            // Plane
            try
            {
                Plane P = new Plane(400);
                int h = 0;
                P.MaxSpeed = 0; P.Price = 0; P.Year = 0; P.CurrentSpeed = 0;
                P.SetCurrentPassengers(300);   // посадили 300 человек на рейс
                P.SetCurrentHeight(h);
                Console.WriteLine(" \t\t\t САМОЛЕТ!!!!!!!! \t\t\t ");
                while(flag)
                {
                    try
                    {
                        Console.WriteLine("Введите год выпуска: ");
                        P.Year = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат ввода");
                    }
                }
                while (flag)
                {
                    try
                    {
                        Console.WriteLine("Введите стоимость: ");
                        P.Price = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат ввода");
                    }
                }
                while (flag)
                {
                    try
                    {
                        Console.WriteLine("Введите высоту полета: ");
                        h = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат ввода");
                    }
                }
                while (flag)
                {
                    try
                    {
                        Console.WriteLine("Введите максимальную скорость: ");
                        P.MaxSpeed = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат ввода");
                    }
                }
                while(flag)
                {
                    try
                    {
                        Console.WriteLine("Введите текущую скорость: ");
                        P.CurrentSpeed = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат ввода");
                    }
                }
                Console.WriteLine("Характеристики самолета:");
                Console.WriteLine("Год выпуска: {0}", P.Year.ToString().PadLeft(15));
                Console.WriteLine("Стоимость: {0} $", P.Price.ToString().PadLeft(18));
                Console.WriteLine("Высота полета:" + h +" км", P.GetCurrentHeight().ToString().PadLeft(13));
                Console.WriteLine("Посадочных мест: {0}", P.MaxPassengers.ToString().PadLeft(10));
                Console.WriteLine("Поссажиров на борту: {0}", P.GetCurrentPassengers().ToString().PadLeft(6));
                Console.WriteLine("Макс. скорость: {0} км/час", P.MaxSpeed.ToString().PadLeft(12));
                Console.WriteLine("Текущая скорость: {0} км/час", P.CurrentSpeed.ToString().PadLeft(9));
                Console.WriteLine("Ускоряемся ...");
                P.SpeedUp();
                Console.WriteLine("Текущая скорость: {0} км/час", P.CurrentSpeed.ToString().PadLeft(9));
                Console.WriteLine("".PadLeft(19, '*'));
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
          /*************************************************************************************************************************/
            // Ship
            try
            {
                Ship S = new Ship(2000);
                S.Year = 0; S.Price = 0; S.MaxSpeed = 0; S.CurrentSpeed = 0;
                S.SetCurrentPassengers(55);
                S.SetPort("Одесса"); // порт 
                Console.WriteLine(" \t\t\t КОРАБЛЬ!!!!!!! \t\t\t ");
                while (flag)
                {
                    try
                    {
                        Console.WriteLine("Введите год выпуска: ");
                        S.Year = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат ввода");
                    }
                }
                while (flag)
                {
                    try
                    {
                        Console.WriteLine("Введите стоимость: ");
                        S.Price = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат ввода");
                    }
                }
                while (flag)
                {
                    try
                    {
                        Console.WriteLine("Введите максимальную скорость: ");
                        S.MaxSpeed = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат ввода");
                    }
                }
                while (flag)
                {
                    try
                    {
                        Console.WriteLine("Введите текущую скорость: ");
                        S.CurrentSpeed = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат ввода");
                    }
                }
                Console.WriteLine("Характеристики корабля");
                Console.WriteLine("Год выпуска: {0}", S.Year.ToString().PadLeft(16));
                Console.WriteLine("Стоимость: {0} $", S.Price.ToString().PadLeft(20));
                Console.WriteLine("Порт приписки: {0}", S.GetPort().ToString().PadLeft(21));
                Console.WriteLine("Посадочных мест: {0}", S.MaxPassengers.ToString().PadLeft(10));
                Console.WriteLine("Поссажиров на борту: {0}", S.GetCurrentPassengers().ToString().PadLeft(6));
                Console.WriteLine("Макс. скорость: {0} узлов", S.MaxSpeed.ToString().PadLeft(11));
                Console.WriteLine("Текущая скорость: {0} узлов", S.CurrentSpeed.ToString().PadLeft(9));
                Console.WriteLine("Замедляемся ...");
                S.SpeedDown();
                Console.WriteLine("Текущая скорость: {0} узлов", S.CurrentSpeed.ToString().PadLeft(9));
                Console.WriteLine("".PadLeft(19, '*'));
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
