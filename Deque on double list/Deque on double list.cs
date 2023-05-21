using System;
using static System.Console;
namespace adslab6test
{
    class Program
    {
        public class Node
        {
           public int data;
            public Node next;
            public Node previous;
            public Node(int data)
            {
                this.data = data;
                this.next = null;
                this.previous = null;
            }
        }
        public class Deque
        {
            public Node head;
            public Node tail;

            public int count;
            public Deque()
            {
                this.head = null;
                this.tail = null;
                this.count = 0;
            }
            public Boolean isDequeEmpty()//Функція, для перевірки чи є дек пустий
            {
                if (count == 0)
                    return true;
                else
                    return false;
            }
            public int isSize()//Повертає число елементів у деку
            {
                return count;
            }
            public   void insertTail(int num)//Додає елемент у хвіст деку
            {
                Node element = new Node(num) ;
                if(head==null)
                {
                    this.head = element;
                    this.tail = element;
                }
                else
                {
                    this.tail.next = element;
                    element.previous = this.tail;
                    this.tail = element;
                }
                count++;
            }
            public void insertHead(int num)//Додає елемент на початок деку
            {
                Node element = new Node(num);
                if(this.head==null)
                {
                   this.head = element;
                   this.tail = head;
                }
                else
                {
                   
                    this.head.previous = element;
                    element.next = this.head;
                    this.head = element;
                }
                count++;
            }
            public  void removeTail()//видаляє елемент з кінця деку
             {
                if (this.isDequeEmpty() == true)
                    return;
                else
                {
                    if(this.isSize()>1)
                    {
                        Node element = tail;
                        tail = tail.previous;
                        tail.next = null;
                        element = null;
                    }
                    else
                    {
                        this.head = null;
                        tail = null;
                    }
                    count--;
                }
            }
            public  void removeHead()//видаляє елемент з початку списку
            {
                if (this.isDequeEmpty() == true)
                    return;
                else
                {
                    if(this.isSize()>1)
                    {
                        Node element = head;
                        head = head.next;
                        head.previous = null;
                        element = null;
                        count--;
                    }
                    else
                    {
                        head.next = null;
                        head = null;
                        count = 0;
                    }
                }
            }
            public int Tail()//виводить елемент, що знаходиться в кінці дека("хвіст")
            {
                    return tail.data;
            }
            public int Head()//виводить елемент, що знаходиться на початку дека("голова")
            {
                    return head.data;
            }
            public void PrintDeque()//Виводить елементи деку на консоль
            {
                Node node = this.head;
                Write($"Поточний вміст деку:");
                while (node!=null)
                {
                    Write(" " + node.data);
                    node = node.next;
                }
                Write("\n");
            }
        }
        public  static void Main()//Головна функція програми
        {
            Deque deq = new Deque();
            int n,m,nn,temp,temp1;
            WriteLine("Введіть,будь ласка\n 1-якщо хоче завантажити контрольний приклад на прикладі числа (123456),\n 0- якщо хоче ввести власне число,");
            nn = Convert.ToInt32(ReadLine());
            if (nn == 0)
            {
                Write("Введіть,будь ласка, ціле додатнє число : "); n = Convert.ToInt32(ReadLine());
                if (Perev(n) == true)
                {
                    m = GetLength(n);
                    temp1 = n;
                    bool buf = PerevPal(n);
                    for (int i = 0; i < m; i++)
                    {
                        temp = n % 10;
                        n /= 10;
                        deq.insertHead(temp);
                        deq.PrintDeque();
                    }
                    if (buf == true)//Якщо елемент є паліндромом, то ми просто виводимо дек у консоль і завершуємо роботу програми
                    {
                        WriteLine("Число є паліндромом!");
                        BackgroundColor = ConsoleColor.Black;
                        WriteLine("Остаточний вміст деку матиме такий вигляд:");
                        BackgroundColor = ConsoleColor.Red;
                        deq.PrintDeque();
                    }
                    else//Якщо елемент не є паліндромом, то програма виконує завдання згідно з варіанту 6 Лаболаторної роботи №6
                    {
                        for (int i = 0; i < m; i++)
                        {
                            temp = temp1 % 10;
                            temp1 /= 10;
                            deq.insertTail(temp);
                            deq.PrintDeque();
                        }
                        WriteLine("Число не було паліндромом, утворили його додаванням інвертованого числа до хвоста деку");
                        BackgroundColor = ConsoleColor.Black;
                        WriteLine("Остаточний вміст деку матиме такий вигляд:");
                        BackgroundColor = ConsoleColor.Red;
                        deq.PrintDeque();
                        BackgroundColor = ConsoleColor.Black;
                    }
                }
                else
                    WriteLine("Введене Вами число не є цілим додатнім!\n Ведіть будь ласка щераз: "); n = Convert.ToInt32(ReadLine());
            }
            else if (nn == 1)
            {
                m = 6;//Оскільки це контрольний приклад, деякі значення тут уже відомі
                n = 123456; temp1 = n;
                for (int i = 0; i < m; i++)//додаємо введе користувачем число у дек
                {
                    temp = n % 10;
                    deq.insertHead(temp);
                    n /= 10;
                    deq.PrintDeque();
                }
                for (int i = 0; i < m; i++)
                {
                    temp = temp1 % 10;
                    temp1 /= 10;
                    deq.insertTail(temp);
                    deq.PrintDeque();
                }
                BackgroundColor = ConsoleColor.Black;
                WriteLine("Остаточний вміст деку матиме такий вигляд:");
                BackgroundColor = ConsoleColor.Red;
                deq.PrintDeque();
                BackgroundColor = ConsoleColor.Black;
            }
            else
                WriteLine("Error");
            
        }
        static bool Perev(int num)//Перевірка корректності введеного користувачем числа
        {
            if (num <= 0)
                return false;
            return true;
        }

        static bool PerevPal (int n)//перевірка того, чи є число паліндроном
        {
            Deque deq = new Deque();//
            int m, temp;
            m = GetLength(n);
            for (int i = 0; i < m; i++)//додаємо введе користувачем число у дек
            {
                temp = n % 10;
                deq.insertHead(temp);
                 n /= 10;
            }
            while (deq.isSize()!=0)//
            {
                if (deq.Head() == deq.Tail())//
                {
                    if (deq.isSize()== 1)//якщо останній елемент дорівнює першому, при тому що еле
                    {
                        return true;
                    }
                    else if (deq.isSize() == 2)//якщо останній елемент дорівнює першому, при тому що числа залишилось два, то цей елемент паліндром
                    {
                        return true;
                    }
                    else
                    {
                        deq.removeHead();//якщо перше і останнє число однакове, то ми видаляємо їх і продовжуємо нашу перевірку 
                        deq.removeTail();
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        static int GetLength(int num)//отримання довжини числа(кількості розрядів, якщо так можна сказати)
        {
            int nm= 0;
            while(num>0)
            {
                num /= 10;
                nm++;
            }
            return nm;
        }
    }
}
