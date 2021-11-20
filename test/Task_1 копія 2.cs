using System;
using static System.Console;
using static System.Math;
namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Вводжу змінні
            int n;
            double a;

            //Блок зчитування даних з консолі
            Write("Input n :"); n = Convert.ToInt32(ReadLine());
            double summ = 0;
            //loop
            for (double k = 1; k <= n; k++)
            {
                if (k % 2 == 0)//parne
                {
                    a = (1 / ((2 * k*k) + k) );
                    
                }
                else
                {
                    a = (-1 / ((2 * k*k) + k) );
                    
                }
                summ += a;

            }
            //export result in console
            WriteLine("Summ is{0}", summ);
        }
    }
}

