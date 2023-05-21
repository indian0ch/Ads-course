using System;
using static System.Console;
namespace ads_lab4
{
    public class DLList
    {
        public int countnodes = 1;//змінна для підрахунку кількості вузлів у списку
        public DLNode tail;
        public class DLNode
        {
            public int data;
            public DLNode next;
            public DLNode previous;
            public DLNode(int data)
            {
                this.data = data;
            }
            public DLNode(int data, DLNode next, DLNode previous)
            {
                this.data = data;
                this.next = next;
                this.previous = previous;
            }
        }
        public DLList(int data)
        {
            tail = new DLNode(data);
            tail.next = tail;
            tail.previous = tail;
        }
        public void AddFirst(int data)//Функція для встановлення на початок
        {
            DLNode current = new DLNode(data);
            DLNode temp = tail.next;
            current.previous = tail;
            current.next = temp;
            temp.previous = current;
            tail.next = current;
            countnodes++; 
        }
        public void AddToPosition(int data, int position)//Функція для встановлення елемента на задану користувачем позицію
        {
            if (position>countnodes)//Якщо операція вставки вузла не може бути здійснена відповідно до умови, то вузол додається у голову списку незалежно від варіанту.
            {
                DLNode current = new DLNode(data);
                DLNode temp = tail.next;
                current.previous = tail;
                current.next = temp;
                temp.previous = current;
                tail.next = current;
                countnodes++;
            }
            else
            {
                DLNode current = new DLNode(data);
                DLNode temp = tail.next;
                while (position > 2)
                {
                    temp = temp.next;
                    position--;
                }
                current.previous = temp;
                current.next = temp.next;
                temp.next.previous = current;
                temp.next = current;
                if (temp == tail)
                    tail = tail.next;
                countnodes++;
            }
        }
        public void AddLast(int data)//Функція для додавання в кінець списку
        {
            DLNode current = new DLNode(data);
            DLNode temp = tail.next;
            current.next = tail.next;
            current.previous = tail;
            tail.next = current;
            temp.previous = current;
            tail = current;
            countnodes++;
        }
        public void DeleteFirst()//Функція для видалення першого елемента
        {
            if (countnodes == 1)
                WriteLine("Оберіть, будь ласка, іншу функцію для виконання!");
            else
            {
                DLNode current;
                current = tail.next;
                tail.next = current.next;
                current.next.previous = tail;
                current.next = null;
                countnodes--;
            }
        }
        public void DeleteFromPosition(int position)//Функція для видалення з вказаної позиції
        {
            if (countnodes != 1)
            {
                DLNode current, temp;
                temp = tail;
                current = tail.next;
                int count = 1;
                while (count < position)
                {
                    current = current.next;
                    temp = temp.next;
                    count++;
                }
                temp.next = current.next;
                current.next.previous = temp.next;
                current.next = null;
                countnodes--;
            }
            else
                WriteLine("Оберіть, будь ласка, іншу функцію для виконання!");
        }
        public void DeleteLast()//Функція для видалення останнього елемента
            
        {
            if (countnodes != 1)
            {
                DLNode current = tail.next;
                while (current.next != tail)
                {
                    current = current.next;
                }
                current = tail.previous;
                current.next = tail.next;
                tail.next.previous = current;
                tail.next = null;
                tail = current;
                countnodes--;
            }
            else
                WriteLine("Оберіть, будь ласка, іншу функцію для виконання!");
        }
        public void Print()//Функція для виведення листа
        {
            if (tail != null)
            {
                DLNode current, stop;
                current = tail.next;
                stop = current.next;
                Write("Лист: ");
                do
                {
                    Write(current.data + " ");
                    current = current.next;
                }
                while (current.next != stop);
            }
        }
        public void ZvLab(int data)//Реалізована згідно з моїм варіантом функція - "Додати новий вузол після середнього вузла, якщо у списку парна кількість вузлів, інакше – перед головою списку"
        {
            DLNode current = new DLNode(data);
            DLNode temp = tail.next;
            if (countnodes % 2 == 0)
            {
                int pozition = (countnodes / 2) ;
                while(pozition!=1)
                {
                    temp = temp.next;
                    pozition--;
                }
                current.previous = temp;
                current.next = temp.next;
                temp.next.previous = current;
                temp.next = current;
            }
            else
            {
                current.previous = tail;
                current.next = temp;
                temp.previous = current;
                tail.next = current;
            }
            countnodes++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n,key,data,position;
            DLList circular_list;
            Write("Введіть,будь ласка,перший елемент вашого списку : "); n = Convert.ToInt32(ReadLine());
            circular_list = new DLList(n);

            while (true)
            {
                WriteLine();
                WriteLine("Введіть цифру, відповідно функції, яку ви хочете використати: ");
                WriteLine("1 - Вивести чинний список;");
                WriteLine("2 - Додати новий елемент на першу позицію;");
                WriteLine("3 - Додати новий елемент на останню позицію;");
                WriteLine("4 - Додати новий елемент на визначену позицію");
                WriteLine("5 - Видалити перший елемент;");
                WriteLine("6 - Видалити останній елемент;");
                WriteLine("7 - Видалити елемент на зазначеній позиції;");
                WriteLine("8 - Використати функцію задану у завданні Лаболаторної роботи;");
                WriteLine("9 - Завершити програму(вийти з програми).");
                WriteLine("_____________________________________________________________________________________________");
                Write("Виберіть цифру функції, яку ви хочете використати: "); key = Convert.ToInt32(ReadLine());

                if (key == 1)
                    circular_list.Print();
                else if (key == 2)
                {
                    Write("Введіть елемент для цієї функції: "); data = Convert.ToInt32(ReadLine());
                    circular_list.AddFirst(data);
                    circular_list.Print();
                    WriteLine();
                }
                else if (key == 3)
                {
                    Write("Введіть елемент для цієї функції: "); data = Convert.ToInt32(ReadLine());
                    circular_list.AddLast(data);
                    circular_list.Print();
                    WriteLine();
                }
                else if (key == 4)
                {

                    Write("Введіть елемент для цієї функції: "); data = Convert.ToInt32(ReadLine());
                    Write("Введіть бажану позицію для цього методу: "); position = Convert.ToInt32(ReadLine());
                    circular_list.AddToPosition(data, position);
                    circular_list.Print();
                    WriteLine();
                }
                else if (key == 5)
                {
                    circular_list.DeleteFirst();
                    circular_list.Print();
                    WriteLine();
                }
                else if (key == 6)
                {
                    circular_list.DeleteLast();
                    circular_list.Print();
                    WriteLine();
                }
                else if (key == 7)
                {
                    Write("Введіть бажану позицію для цього методу: "); position = Convert.ToInt32(ReadLine());
                    circular_list.DeleteFromPosition(position);
                    circular_list.Print();
                    WriteLine();
                }
                else if (key == 8)
                {
                    Write("Введіть елемент для цієї функції: "); data = Convert.ToInt32(ReadLine());
                    circular_list.ZvLab(data);
                    circular_list.Print();
                    WriteLine();
                }
                else if(key==9)
                {
                    Write("Роботу програми завершено!");
                    break;
                }
                else
                {
                    WriteLine("Введіть корректну цифру функції!");
                }
            }
        }
    }
}
