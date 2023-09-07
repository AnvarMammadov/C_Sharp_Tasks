using System.Runtime.CompilerServices;

namespace C_Sharp_Task1_Operator_Overloading_Practice_
{

    class Car
    {
        public Car() { }

        public Car(string? model, string? brand, int horsePower, double engineDisplacement, string? fuelType, int year)
        {
            Model = model;
            Brand = brand;
            HorsePower = horsePower;
            EngineDisplacement = engineDisplacement;
            FuelType = fuelType;
            Year = year;
        }

        public string? Model { get; set; } = "No model";
        public string? Brand { get; set; } = "No brand";
        public int HorsePower { get; set; } = default;
        public double EngineDisplacement { get; set; } = default;
        public string? FuelType { get; set; } = "Gasoline";
        public int Year { get; set; } = default;

        public override string ToString()
        {
            return $"Model : {Model}\nBrand : {Brand}\nHorse Power : {HorsePower}\n" +
                $"Engine Displacement : {EngineDisplacement}\nFuel Type :{FuelType}\nYear : {Year}\n\n";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Car c) return c.Model == Model && c.Brand == Brand && c.HorsePower == HorsePower &&
                    c.EngineDisplacement == EngineDisplacement && c.FuelType == FuelType && c.Year == Year;
            return false;
        }

        public static bool operator ==(Car c1, Car c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Car c1, Car c2)
        {
            return !c1.Equals(c2);
        }


        public void ShowCarDetails()
        {
            if (Model != null)
            {
                Console.WriteLine($"Model : {Model}");
                Console.WriteLine($"Brand : {Brand}");
                Console.WriteLine($"Horse Power : {HorsePower}");
                Console.WriteLine($"Engine Displacement : {EngineDisplacement}");
                Console.WriteLine($"Fuel Type : {FuelType}");
                Console.WriteLine($"Year : {Year}");
                Console.WriteLine("\n\n");
            }
        }
    }

    class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        Point() { }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString() { return $"Point(X,Y) : ({X},{Y})"; }
        public override bool Equals(object? obj)
        {
            if (obj is Point p)
            {
                return p.X == X && p.Y == Y;
            }
            return false;
        }

        public static bool operator ==(Point p1, Point p2) { return p1.X == p2.X && p1.Y == p2.Y; }
        public static bool operator !=(Point p1, Point p2) { return p1.X != p2.X || p1.Y != p2.Y; }

        public static Point operator +(Point p1, Point p2) { return new Point { X = p1.X + p2.X, Y = p1.Y + p2.Y }; }
        public static Point operator -(Point p1, Point p2) { return new Point { X = p1.X - p2.X, Y = p1.Y - p2.Y }; }
        public static Point operator *(Point p1, Point p2) { return new Point { X = p1.X * p2.X, Y = p1.Y * p2.Y }; }
        public static Point operator /(Point p1, Point p2)
        {
            if (p2.X != 0 && p2.Y != 0) return new Point { X = p1.X / p2.X, Y = p1.Y / p2.Y };
            throw new DivideByZeroException("Can not devide by zero");
        }
        public static bool operator >(Point p1, Point p2) { return p1.X > p2.X && p1.Y > p2.Y; }
        public static bool operator <(Point p1, Point p2) { return p1.X < p2.X && p1.Y < p2.Y; }

        public static Point operator ++(Point p) { return new Point(p.X++, p.Y++); }
        public static Point operator --(Point p) { return new Point(p.X--, p.Y--); }
        public static bool operator <=(Point p1, Point p2) { return p1.X <= p2.X && p1.Y <= p2.Y; }
        public static bool operator >=(Point p1, Point p2) { return p1.X >= p2.X && p1.Y >= p2.Y; }





    }
    internal class Program
    {

        static void Main(string[] args)
        {
            #region Car Operations
            Car car1 = new Car("GLS", "Mercedes", 550, 3.2, "Gasoline", 2013);
            Car car2 = new Car("RAV-4", "Toyota", 200, 1.8, "Gasoline", 2010);
            Console.WriteLine(car1);
            Console.WriteLine(car1 == car2);
            #endregion

            #region Point Operations
            Point p1=new Point(1,2);
            Point p2=new Point(6,8);

            Console.WriteLine($"{p1}\n{p2}");
            Console.WriteLine(p1<p2);
            Console.WriteLine(p1==p2);
            Console.WriteLine(p1+p2);
            Console.WriteLine(p1-p2);
            Console.WriteLine(p1/p2);
            Console.WriteLine(p1*p2);
            #endregion

        }
    }

}