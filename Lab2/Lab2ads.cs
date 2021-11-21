using System;
using static System.Console;
namespace ads_lab2
{
    class Program
    {
        static int N, M, y, count = 0;
        static int[,] A = new int[N, M];
        static void GenerateMatrix()
        {
            A = new int[N, M];//ініціалізація массиву
            Random rnd = new Random();
            WriteLine("Згенерована матриця А:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (y == 1)
                    {
                        //Згенерування та виведення матриці з рандомними числами на консоль
                        A[i, j] = rnd.Next(1, 50);//Матриця заповниться числами від 1 до 49
                        Write(A[i, j].ToString() + "\t");
                    }
                    else if (y == 0)
                    {
                        //Генерування контрольної матриці
                        A[i, j] = count;
                        count++;
                        Write(A[i, j].ToString() + "\t");
                    }
                }
                WriteLine();
            }
        }
        static void Main()
        {
            //Блок зчитування даних з консолі
            Write("Введіть N - кількість рядків у нашій матриці = ");
            N = Convert.ToInt32(ReadLine());
            Write("Введіть M - кількість стовпців у нашій матриці = ");
            M = Convert.ToInt32(ReadLine());
            WriteLine("Виберіть, яку матрицю потрібно згенерувати. Введіть '1', якщо потрібно згенерувати псевдовипадкову матрицю, введіть '0', якщо потрібно згенерувати контрольну");
            y= Convert.ToInt32(ReadLine());  
            GenerateMatrix();//функція для генерування матриці
            double Min_value = int.MaxValue, Max_value = int.MinValue;  
            int Min_indexrow=0 , Max_indexrow=0,
                Min_indexcolon=0, Max_indexcolon=0;
            //Цикл, який проходиться по всім елементах, і виконує дії з тими, які підходять умову завдання
            for (int i = 0; i < N ; i++)          
                for (int j = 0; j < M  ; j++)
                    if ((i < j) && (i + j < M - 1))//Умова, за якої елементи знаходяться вище головної та побічнох діагоналі
                    {
                        if (A[i, j] > Max_value)
                        {
                            Max_value= A[i, j];
                            Max_indexrow=i;
                            Max_indexcolon=j;
                        }
                       if (A[i, j] < Min_value)
                        {
                             Min_value= A[i, j];
                            Min_indexrow = i;
                            Min_indexcolon = j;
                        }
                    }
            WriteLine($"Послідовність елементів відповідно до шляху обходу:");
            //Ініціалізую змінні
            int summ = N * M;  
            int l = 0, r = 0, u = 0, d = 0, k = 0, x = 1;
            //Цикл для обходу матриці по спіралі
              while (  k <summ )                   
                for (x =1; x <= 4; x++)
                {
                   if (x == 1)//Рухається вліво
                    {    
                            int i = N - 1 - l;
                            for (int j = M - 1 - l; j >= 0+ l; j--)
                            {
                            if (k == summ)//Цикл зупинеться, коли обійде повністю усі елементи
                                break;
                            Write($"{A[i, j]},");
                                k++;
                            }
                        l++;
                    }
                    else if (x == 2)//Рухається вниз
                    {
                        int j = 0 + d;
                        for (int i = N - 2 - d; i > 0 + d; i--)
                        {
                            if (k == summ)//Цикл зупинеться, коли обійде повністю усі елементи
                                break;
                            Write($"{A[i, j]},");
                            k++;
                        }
                        d++;
                    }
                    else if (x == 3)//Рухається вправо
                    {
                        int i = 0 + r;
                        for (int j = 0 + r; j < M - 1 - r; j++)
                        {
                            if (k == summ)//Цикл зупинеться, коли обійде повністю усі елементи
                                break;
                            Write($"{A[i, j]},");
                            k++;
                        }
                        r++;
                    }
                    else if (x == 4)//Рухається вверх
                    {
                        int j = M - 1 - u;
                        for (int i = 0 + u; i < N - 1 - u; i++)
                        {
                            if (k == summ)//Цикл зупинеться, коли обійде повністю усі елементи
                                break;
                            Write($"{A[i, j]},");
                            k++;
                        }
                        u++;
                    }
                }
            WriteLine();
            //Блок виведення в консоль результату обрахунків напівсуми і індексів мін та макс елементів
            WriteLine($"Напів сума мінімального та максимального елементів серед елементів, що лежать праворуч від головної діагоналі та ліворуч – від побічної : { (Max_value + Min_value) / 2}");
            WriteLine($"Максимальний елемент: {Max_value}, його індекси: {Max_indexrow},{Max_indexcolon}");
            WriteLine($"Мінімальний елемент :{Min_value}, його індекси: {Min_indexrow},{Min_indexcolon}");
        }   
    }
}