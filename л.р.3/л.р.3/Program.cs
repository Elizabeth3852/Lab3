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

        public int Price // свойство Стоимости
        {
            get { return price; }
            set { if (value > 0) price = value; }
        }
        public int YearOfCreation // свойство Года выпуска
        {
            get { return year; }
            set { if (value > 1900 && value <= DateTime.Today.Year) year = value; }
        }
        public int MaxSpeed // свойство Максимальной скорости
        {
            get { return maxspeed; }
            set { if (value > 0) maxspeed = value; }
        }
        public int CurrentSpeed
        {
            get { return curspeed; }
            set { if (value > maxspeed) throw OutOfMaxBorder; curspeed = value; }
        }
        public virtual void SpeedUp()   // метод увеличивает текущую скорость, может переопределятся
        {
            CurrentSpeed++;
        }
        public virtual void SpeedDown() // метод уменьшает текущую скорость, может переопределятся
        {
            CurrentSpeed--;
        }
        // исключения для классов наследников:
        protected Exception NonBellowZero = new Exception("Исключение, введенное значение не может быть отрицательным!");
        protected Exception OutOfMaxBorder = new Exception("Исключение, превышена максимальна граница!");

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
                CurrentSpeed -= 50;
            }
            public override void SpeedUp()
            {
                CurrentSpeed += 50;
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

    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
