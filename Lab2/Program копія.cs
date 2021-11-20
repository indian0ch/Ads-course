using System;
using static System.Console;

class Test
{
    public static void Main()
    {
        //Користувач вводить рядок в консоль
        string s;
        WriteLine("Enter strings:");
        s = Console.ReadLine();
        string phrase =  $"{s}" ;
        string sym = "abcd";
        //Додаємо рядок до масиву
        char[] Array = phrase.ToCharArray();
        char[] Array2 = sym.ToCharArray();//масив з 4 літерами:abcd,який використаю під час знаходження цих літер
        WriteLine("Рядок після вилучення abcd, якщо вони наявні:");
        //Проходження по масиву і якщо наявні вказані в умові літери- пропускаю їх
        for(int i=0;i<Array.Length;i++)
        {
            if ((Array[i] == Array2[0]) && (Array[i + 1] == Array2[1]) && (Array[i + 2] == Array2[2]) && (Array[i + 3] == Array2[3]))
                i += 3;
            else
                Write(Array[i]);
        }
        

       
    }
}
