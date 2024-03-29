﻿using System;
using static System.Console;
namespace adslab5Test
{
    class Program
    {
        static int N, M, K,controlexample,buf=0;//загальні сталі змінні
        static int[,] Arrray = new int[N, M];//Основна матриця
        static int[,] ControlArray = new int[4,3] { { 1, 2,3 }, { 4, 5,6 }, { 7, 8,9 }, { 10, 11,12 } };
        static bool process = true;
        static void Main()//Реалізація користувацького мень тут
        {
            Console.WriteLine("***** Quick Sort Lomuto *****");
            Console.WriteLine("Сортування наскрізне ПО РЯДКАМ!");
            Console.WriteLine("According to my Variant(15), user should only choose size of it. Elements are generated by Random.");
            Console.WriteLine("Червоний колі- кратні К, сині- некратні;");
            while (process)
            {
                if (buf == 0)//коли перший раз запускається програма
                {
                    Console.WriteLine("Введіть 1 - для завантаження конкретного прикладу, прописаного у коді;");
                    Console.WriteLine("Введіть 0 - для завантаження псевдовипадкового прикладу: ");
                    controlexample = Convert.ToInt32(ReadLine());
                    buf++;
                }
                else
                {
                    int control ;
                    WriteLine("Write 0, if you want to stop programm!| Write any number(exept 0) to continue program");
                    control = Convert.ToInt32(ReadLine());
                    if(control==0)
                        break;
                    else
                    {
                        Console.WriteLine("Введіть 1 - для завантаження конкретного прикладу, прописаного у коді;");
                        Console.WriteLine("Введіть 0 - для завантаження псевдовипадкового прикладу: ");
                        controlexample = Convert.ToInt32(ReadLine());
                    }    
                }
                if (controlexample == 0)//коли користувач обрав завантажити псевдовипадковий приклад
                {
                    Console.WriteLine("Choose Size of Matrix:");
                    Console.Write("Input N(Lines):");
                    N = Convert.ToInt32(ReadLine());
                    Console.Write("Input M(Columns):");
                    M = Convert.ToInt32(ReadLine());
                    Console.Write("Input K:");
                    K = Convert.ToInt32(ReadLine());
                    Console.WriteLine("Start's Matrix:");
                    Matrix();
                    PrintMatrix(Arrray);
                    Console.WriteLine("End's Matrix:");
                    Sorting(Arrray, N, M);
                    PrintMatrix(Arrray);
                }
                else//користувач обра встановлений у коді приклад
                {
                    Console.WriteLine("Control Matrix is looked: { { 1, 2,3 }, { 4, 5,6 }, { 7, 8,9 }, { 10, 11,12 } }; ");
                    Console.WriteLine("Control K=2;");
                    Console.WriteLine("Start's Control Matrix:");
                    K = 2;
                    N = 4;
                    M = 3;
                    PrintMatrix(ControlArray);
                    Sorting(ControlArray, N, M);
                    Console.WriteLine("End's Control Matrix:");
                    PrintMatrix(ControlArray);
                }
            }
        }
        static void Matrix()//Функція для генерації Матриці псевдовипадковим чином
        {
            Random rnd = new Random();
            Arrray = new int[N, M];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    Arrray[i, j] = rnd.Next(0, 50);
        }
        static void Sorting(int [,]array,int N, int M)//
        {
            int numk=0,numnonk=0;
            for (int ii = 0; ii < N; ii++)//Порахую кількість елементів кратних К і непарних
            {
                for (int jj = 0; jj < M; jj++)
                {
                    if(array[ii,jj]%K==0)
                        numk++;//кількість кратних К
                    else
                        numnonk++;//кількість кратних К
                }
            }
            int[] numK = new int[numk];//масив з елементів кратних К
            int[] numnonK = new int[numnonk];//масив з елементами некратних К
            int lll = 0, kkk = 0;
            for (int ii = 0; ii < N; ii++)// Запишемо елементи в відповідні масиви
            {
                for (int jj = 0; jj < M; jj++)
                {
                    if (array[ii,jj] % K == 0)//1-(%K==0)
                    {
                        numK[lll] = array[ii,jj];
                        array[ii,jj] = 1;//елементи кратні К замінюємо на 1
                        lll++;
                    }
                    else//0 - %K!=0
                    {
                        numnonK[kkk] = array[ii,jj];
                        array[ii,jj] = 0;//Елементи некратні К замінюємо на 0
                        kkk++;
                    }
                }
            }
            int start = 0, end = numk-1,endnonk=numnonk-1;
            QuickSort(numK, start, end);//Сортування для масиву з кратних К елементів(за спаданням)
            spadzrost = 1;//зміна значення змінної, адже далі будемо сортувати за зростанням
            QuickSort(numnonK, start, endnonk);//Сортування для масиву з некратних К елементів(за зростанням)
            int ll = 0, kk = 0;
            for (int ii = 0; ii < N ; ii++)//Записування елементів назад у початкову матрицю після сортування
            {
                for (int jj = 0; jj < M; jj++)
                {
                    if (array[ii,jj] == 1)
                    {
                        array[ii,jj] = numK[ll];
                        ll++;
                    }
                    else
                    {
                        array[ii,jj] = numnonK[kk];
                        kk++;
                    }
                }
            }
            spadzrost = 0;
        }
        static void PrintMatrix(int [,]array)//Вивід матриці в консоль
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if(array[i,j]%K==0)
                        BackgroundColor = ConsoleColor.DarkRed;//Червоним - ті елементи, які кратні К і мають бути відсортовані за спаданням
                    
                    else if(array[i, j] % K != 0)
                        BackgroundColor = ConsoleColor.DarkBlue;//Синім - ті елементи, які некратні К і мають бути відсортовані за зростанням
                    Write(array[i, j].ToString() + "\t");
                    BackgroundColor = ConsoleColor.Black;
                }
                WriteLine();
            }
        }
        public static void SortAdd(int[] array, int startIndex, int endIndex)//Функція для сортування вставкою
        {
            if (spadzrost == 1)//Сортування вставкою за зростанням
            {
                int key = 0, j=0;
                for (int i = startIndex+1; i <=endIndex; i++)
                {
                    key = array[i];
                    j = i - 1;
                    while (j >= 0 && array[j] > key)
                    {
                        array[j + 1] = array[j];
                        j = j - 1;
                    }
                    array[j + 1] = key;
                }
            }
            else//Сортування вставкою за спаданням
            {
                int kkey = 0, jj=0;
                for (int i = startIndex+1; i <=endIndex; i++)
                {
                    kkey = array[i];
                    jj = i - 1;
                    while (jj >= 0 && array[jj] < kkey)
                    {
                        array[jj + 1] = array[jj];
                        jj = jj - 1;
                    }
                    array[jj + 1] = kkey;
                }
            }
        }
        public static void QuickSort(int[] array, int startIndex, int endIndex)// Рекурсивна функція для реалізації швидкого сортування(розбиттям Ломуто)
        {
            int MMM = 0;
            for (int i = startIndex; i <=endIndex; i++)//рахуємо кількість елементів у підпослідовностях, які ми будемо відсортовувати
                MMM++;
            if (MMM < M)//Якщо кількість елементів менша, ніж М, то сортувємо сортуванням вставкою
                SortAdd(array, startIndex, endIndex);
            else//Якщо елементів більше, ніж М, сортуємо швидким сортуванням з розбиттям Ломуто
            {
                if (startIndex < endIndex)
                {
                    int pivotIndex = Lomuto(array, startIndex, endIndex);
                    //відсортовуємо знову ліву від опорного елементу(pivot) підпослідовність
                    QuickSort(array, startIndex, pivotIndex - 1);
                    //відсортовуємо праву від опорного елементу підпослідовність 
                    QuickSort(array, pivotIndex + 1, endIndex);
                }
            }
        }
        public static int Lomuto(int[] array, int startIndex, int endIndex)//
        {
            int temp;
            int Pivot = array[endIndex];//знаходимо опорний елемент(за алгоритмом з лекцій - це останній елемент у послідовності)
            int i = startIndex;//

            for (int j = startIndex; j < endIndex; j++)
            {
                if(spadzrost==0)//коли потрібно відсортувати за спаданням
                {
                    if (array[j] > Pivot)
                    {
                        temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                        i++;
                    }
                }
                else//коли потрібно відсортувати за зростанням
                {
                    if (array[j] <= Pivot)
                    {
                        temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                        i++;
                    }
                } 
            }
            temp = array[endIndex];//Коли вказівник досягає опорного елементу, міняємо місцями A[i] та опорний елемент
            array[endIndex] = array[i];
            array[i] = temp;

            return i;
        }
        static int spadzrost = 0;//змінна, для того,щоб програма могла розуміти як ми сортуємо(за зростанням чи спаданням), 0-спадання, 1-зростання
    }
}

