using System;

namespace VariantB
{
    class Program
    {
        static void Main(string[] args)
        {
            (int CoordX, int CoordY)[] Points = new[] { (3, 7), (10, 2), (11, 4) };
            MaxMinDistance(Points);
            FindLine(Points);
        }
        static void MaxMinDistance((int CoordX, int CoordY)[] Points)
        {
            (int X,int Y) Point, MaxResult = (0,0), MinResult = (0, 0);
            Console.WriteLine($"Введите координату Х точки А");
            Point.X = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите координату Y точки А");
            Point.Y = int.Parse(Console.ReadLine());
            double MaxDistance = Math.Sqrt(Math.Pow(Points[0].CoordX - Point.X, 2) + Math.Pow(Points[0].CoordY - Point.Y, 2));
            Double MinDistance = MaxDistance; 
            foreach (var item in Points)
            {
                if (Math.Sqrt(Math.Pow(item.CoordX - Point.X, 2) + Math.Pow(item.CoordY - Point.Y, 2)) > MaxDistance)
                {
                    MaxDistance = Math.Sqrt(Math.Pow(item.CoordX - Point.X, 2) + Math.Pow(item.CoordY - Point.Y, 2));
                    MaxResult.X = item.CoordX;
                    MaxResult.Y = item.CoordY;
                }
                if (Math.Sqrt(Math.Pow(item.CoordX - Point.X, 2) + Math.Pow(item.CoordY - Point.Y, 2)) < MinDistance)
                {
                    MinDistance = Math.Sqrt(Math.Pow(item.CoordX - Point.X, 2) + Math.Pow(item.CoordY - Point.Y, 2));
                    MinResult.X = item.CoordX;
                    MinResult.Y = item.CoordY;
                }
            }
            Console.WriteLine($"Точка, наиболее удаленная от заданной: {MaxResult} ");
            Console.WriteLine($"Точка, наиболее приблеженная к заданной: {MinResult} ");
        }
        static void FindLine((int CoordX, int CoordY)[] Points)
        {
            (int X, int Y) PointA, PointB;
            Console.WriteLine($"Введите координату Х точки А");
            PointA.X = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите координату Y точки А");
            PointA.Y = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите координату Х точки B");
            PointB.X = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите координату Y точки B");
            PointB.Y = int.Parse(Console.ReadLine());
            decimal Distance = (decimal)Math.Sqrt(Math.Pow(PointB.X - PointA.X, 2) + Math.Pow(PointB.Y - PointA.Y, 2));
            foreach (var item in Points)
            {
                decimal AX = (decimal)Math.Sqrt(Math.Pow(PointA.X - item.CoordX, 2) + Math.Pow(PointA.Y - item.CoordY, 2));
                decimal BX = (decimal)Math.Sqrt(Math.Pow(PointB.X - item.CoordX, 2) + Math.Pow(PointB.Y - item.CoordY, 2));
                if (AX + BX == Distance)
                    Console.WriteLine($"{item} ");
            }
        }
    }   
}
