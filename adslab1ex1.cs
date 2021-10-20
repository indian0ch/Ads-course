using System;
using static System.Math;
using static System.Console;

namespace adslab1ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Вводжу змінні
            double x, y, z;
            double a, b;
            //блок зчитування даних з консолі
            Console.Write("Input x :");
            x = double.Parse(Console.ReadLine());
            Console.Write("Input y:");
            y = double.Parse(Console.ReadLine());
            Console.Write("Input z :");
            z = double.Parse(Console.ReadLine());
            //Обрахунок результату в залежності від вхідних даних
            if ((z == 0) || (y * z == 0) || (x == 0) || (x % PI == 0))//Перевірка на ОДЗ
                WriteLine("Помилка!На нуль ділити не можна!");
            else
            {
                //Обрахунок результату для виразів
                a = ((1 / (2 * Sin(PI + x))) + Pow(Sin((x + y) / z), 2));
                b = (Cos (Pow(a,2) * x) )/ (2 * y * z);
                //виведення результату обрахунків на консоль
                Console.WriteLine("Result of a is:" + a.ToString());
                Console.WriteLine("Result of b is:" + b.ToString());
            }
        }
    }
}
