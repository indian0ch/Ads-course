using System;
using static System.Console;
using static System.Math;
namespace ex2ads
{
    class Program
    {
        static void Main(string[] args)
        {

            int n, m;
            Write("n = ");
            n = Convert.ToInt32(ReadLine());
            Write("m = ");
            m = Convert.ToInt32(ReadLine());
            int summ1,summ2;
            for (int z = n; z <= m; z++)
            {
                summ1 = 0;
                for (int i = 1; i < z; i++)
                {
                    if (z % i == 0)
                        summ1 += i;
                }

                summ2 = 0;
                for (int k = 1; k < summ1; k++)
                {
                    if (summ1 % k == 0)
                        summ2 += k;
                }
                if (summ2 == z && summ1 != z && summ1 > z)
                    WriteLine("Числа {0} i {1} дружнi",z,summ1);;


            }
        }
    }
}
