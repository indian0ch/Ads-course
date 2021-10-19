using System;
using static System.Console;
using static System.Math;
namespace ex1ads
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
            if ((z == 0) || (y * z == 0))//Перевірка на ОДЗ
                WriteLine("Помилка!На нуль ділити не можна!");
            else
            {
                //Обрахунок результату для виразів
                a = ((1 / (2 * Sin(PI + (x / 180 * PI))))+Pow(Sin((x+y)/z),2));
                b = ((Cos(Pow(a, 2) * x) / 180 * PI)) / (2 * y * z);
                //виведення результату обрахунків на консоль
                Console.WriteLine("Result of a is:" + a.ToString());
                Console.WriteLine("Result of b is:" + b.ToString());
            }
            
            
            Console.ReadKey();
        }
    }
}
