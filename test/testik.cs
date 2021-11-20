using System;
using static System.Console;
using static System.Math;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {//
            double a;
            int n;
            //
            Write("Input n :"); n = Convert.ToInt32(ReadLine());
            Write("Input a = "); a = Convert.ToInt32(ReadLine());
            double summ = 0;
            //цикл
            double a1 = 1;
            for (int i =0;i<=n;i++)
            {

                if (i <= 1)
                {
                    a1 *= (1 / a);
                    summ += a1;
                }
                else 
                {
                    a1 *= (1 / (a * a));

                    summ += a1;
                }
            }
            //Виведення результату на консоль
            WriteLine("Summ of this : " + summ.ToString());
            ReadKey();
        }
    }
}
