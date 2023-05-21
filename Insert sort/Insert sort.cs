using System;
using static System.Console;
namespace ads_lab3
{
    class Program
    {
        static int[] A;
        static Random rnd = new Random();
        static void GenerateMatrix(int m)//Функція для генерації масиву
        {
            int count = 0;
            A = new int[m];
            for(int i=0;i<m;i++)//Оскільки обов'зковою умовою для мого завдання є "унікальність кожного елемента", то заповнення масиву реалізував таким чином. Функція рандом не використовувалась, адже числа можуть пвторюватись
            {
                count++;
                A[i] = count;
            }
            //Цикл, завдяки якому числа перемішуються
            for (int S = 0; S < 1000; S++)
            {
                int i1 = rnd.Next(0, m);
                int i2 = rnd.Next(0, m);
                int temp = A[i1];
                A[i1] = A[i2];
                A[i2] = temp;
            }  
        }
        static void PrintMatrix(int n)//Функція для виведення початкової матриців консоль
        {
            for (int i = 0; i < n; i++)
            {
                if (A[i] % 2 == 0)
                {
                    BackgroundColor = ConsoleColor.Black;
                    Write($" {A[i]};");      
                }
                else
                {
                    BackgroundColor = ConsoleColor.DarkRed;//нехай елементи,які не підлягають сортуванню виділимо червоним кольором
                    Write($" {A[i]};");
                }  
            }
            BackgroundColor = ConsoleColor.Black;
        }
        static void Main(string[] args)
        {
            int key, mid,  high, low, count = 0,N;
            Write("Введіть розмір нашого одновимірного масиву(N):"); N = Convert.ToInt32(ReadLine());
            GenerateMatrix(N);
            PrintMatrix(N);
            //Цикл, за допомогою якого усі непарні елементи(які нам не потрібно сортувати) будуть переміщенні в кінець нашого масиву
            for(int i=N-1;i>=0;i--)
            {
                if (A[i] % 2 == 1)
                {
                    int temp = A[i];
                    A[i] = A[N - 1 - count];
                    A[N - 1 - count] = temp;
                    count++;//кількість непарних елементів
                }
            }
            //оскільки у нас в масиві усі непарні елементи уже розташовані в кінці, сортувати бінарними вставками ми будемо лише парні елементи як і передбачено умовою нашого завдання
            for (int i = 1; i < N-count; i++)//Власне "Сортування встакою"(позицію для вставки ми будемо шукати за допомогою алгоритму бінарного пошуку)
            {
                key = A[i];
                low = 0; high = i;
                while (low < high)
                {
                    mid = (low + high) / 2;
                    if (key > A[mid])
                        high = mid;
                    else
                        low = mid + 1;
                }
                for (int j = i; j > low; j--)
                {
                    A[j] = A[j - 1];
                }
                A[low] = key;
            }
            PrintMatrix2(N);
        }
        static void PrintMatrix2(int N)
        {
            WriteLine();
            WriteLine("Відсортований згідно з завданням масив:");
            for (int i = 0; i < N; i++)//Виведення на консоль відсортованого згідно з завданням масиву
            {
                if (A[i] % 2 == 0)
                {
                    BackgroundColor = ConsoleColor.Black;
                    Write($" {A[i]};");
                }
                else
                {
                    BackgroundColor = ConsoleColor.DarkRed;
                    Write($" {A[i]};");
                }
            }
        }
    }
}
