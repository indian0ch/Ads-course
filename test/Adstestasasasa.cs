using System;
using static System.Console;
using static System.Math;
namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Вводжу змінні
            int n;
            double a, a1=0;
            Random rnd = new Random();
            //Блок зчитування даних з консолі
            Write("Input n :"); n = Convert.ToInt32(ReadLine());
            
            //
            WriteLine("Послідовність матиме такий вигляд:");
            for (int i = 1; i <= n; i++)
            {
                a = rnd.Next(0, 100) + rnd.NextDouble();

                a1 += a;
                Write("{0};", a1) ;
            }
        }
    }
}
