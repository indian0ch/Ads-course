using System;
using System.Collections.Generic;
using static System.Console;
namespace adslab7
{
    class Program
    {
        public static HashTable hashTable = HashTable.InitHashtable(55);//Основна геш-таблиця
        public static HashTable hashTable2 = HashTable.InitHashtable(15);//Додаткова геш-таблиця, у якої ключем є імʼя курʼєра
        //Загальні змінні, які ми будемо використовувати в подальшій реалізації програми
        public static string objecttype, couriername, street,month;
        public static int houseNumber, appartmentNumber,day,counter=0,l=0;
        public static int year;//Враховуючи те, що Лаболаторна робота виконується у 2022 році можна було поставити стале значення, але було прийнято рішення залишити так як є, щоб уникнути непорозумінь і зниження оцінки
        static void Main(string[] args)//Функція, що відповідає за користувацький інтерфейс програми
        {
            WriteLine("*** Користувацький інтерфейс для Лаболаторної роботи №7, Варіант 10, Фесюк А.А. КП-12 2022 ***");
            while (true)
            {
                string[] streets = { "Головна", "Грушевського", "Бандери", "Польова", "Степанська", "Надвірна", "eded", "deed", "edede", "deedd", "edededde" };
                Console.BackgroundColor = ConsoleColor.DarkRed;
                WriteLine("Виберіть потрібну функцію для зміни:");
                ResetColor();
                WriteLine("1)Додати новий елемент до таблиці;\n2)Переглянути вміст хеш-таблиці;\n3)Заповнити таблицю контрольними значеннями;\n4)Видалити елемент за ключем;\n5)Вихід та завершення роботи програми");
                int buf = Convert.ToInt32(ReadLine());
                if (buf == 1)//Користувач вибрав додати елемент до таблиці,реалізовано перевірку коректності даних, але лише одноразово, тобто передбачається, що користувач ввів з другого разу все вірно
                {
                    Write("Введіть предмет, який буде відправлятись: ");
                    objecttype = Convert.ToString(ReadLine());
                    if (objecttype == "")
                    {
                        Write("Ви нічого не ввели! Будь ласка, введіть предмет, який потрібно відправити:");
                        objecttype = Convert.ToString(ReadLine());
                    }
                    Write("Введіть імʼя курʼєра: ");
                    couriername = Convert.ToString(ReadLine());
                    if (couriername == "")
                    {
                        Write("Ви нічого не ввели! Будь ласка, введіть потрібні дані:");
                        couriername = Convert.ToString(ReadLine());
                    }
                    Write("Введіть назву вулиці: ");
                    street = Convert.ToString(ReadLine());
                    if (street == "")
                    {
                        Write("Ви нічого не ввели! Будь ласка, введіть потрібні дані:");
                        street = Convert.ToString(ReadLine());
                    }
                    Write("Введіть номер будинку: ");
                    string housenumstr = Convert.ToString(ReadLine());
                    if (int.TryParse(housenumstr, out houseNumber) == false)//якщо користувач ввів значення не числове
                    {
                        Write("Ви нічого не ввели! Будь ласка, введіть потрібні дані:");
                        houseNumber = Convert.ToInt32(ReadLine());
                    }
                    else
                    {
                        houseNumber = int.Parse(housenumstr);
                    }
                    Write("Введіть номер апартаментів: ");
                    string appartmentstr = Convert.ToString(ReadLine());
                    if (int.TryParse(appartmentstr, out appartmentNumber) == false)//якщо користувач ввів значення не числове
                    {
                        Write("Ви нічого не ввели! Будь ласка, введіть потрібні дані:");
                        appartmentNumber = Convert.ToInt32(ReadLine());
                    }
                    else
                    {
                        appartmentNumber = int.Parse(appartmentstr);
                    }
                    Write("Введіть потрібний рік: ");//
                    year = Convert.ToInt32(ReadLine());
                    if (year > 2022)
                    {
                        Write("Ви нічого не ввели або ж ваші дані не відповідають дійсності! Будь ласка, введіть потрібні дані:");
                        houseNumber = Convert.ToInt32(ReadLine());
                    }
                    Write("Введіть місяць{Передбаченно ввід українською мовою з великої літери!}: ");
                    month = Convert.ToString(ReadLine());
                    if (month == "" || month != "Січень" && month != "Лютий" && month != "Березень" && month != "Квітень" && month != "Травень" && month != "Червень" && month != "Липень" && month != "Серпень" && month != "Вересень" && month != "Жовтень" && month != "Листопад" && month != "Грудень")
                    {
                        Write("Ви нічого не ввели або ж ваші дані не відповідають дійсності! Будь ласка, введіть потрібні дані:");
                        month = Convert.ToString(ReadLine());
                    }
                    Write("Введіть день: ");
                    day = Convert.ToInt32(ReadLine());
                    if (day <= 0 || month == "Лютий" && day > 29 || month == "Травень" && day > 31 || month == "Січень" && day > 31 || month == "Березень" && day > 31 || month == "Жовтень" && day > 31 || month == "Серпень" && day > 31 || month == "Грудень" && day > 31 || month == "Квітень" && day > 30 || month == "Липень" && day > 31 || month == "Червень" && day > 30 || month == "Вересень" && day > 30 || month == "Листопад" && day > 30)
                    {
                        Write("Ви нічого не ввели або ж ваші дані не відповідають дійсності! Будь ласка, введіть потрібні дані:");
                        day = Convert.ToInt32(ReadLine());
                    }
                    AddToHashTable();
                    WriteLine("Дані успішно занесено!");
                }
                else if (buf == 2)//Користувач обрав переглянути вміст таблиці
                {
                    BackgroundColor = ConsoleColor.Red;
                    WriteLine("Виберіть потрібен вам варіант:");
                    ResetColor();
                    WriteLine("1)Переглянути увесь зміст хеш-таблиці;\n 2)Переглянути всі замовлення потрібного вам курʼєра;\n 3)Переглянути дані про конkтретно задане замовлення;");
                    int buf1 = Convert.ToInt32(ReadLine());//В залежності від вибраного варіанту будуть виконані подальші дії
                    if (buf1 == 1)
                    {
                        PrintHashTable(hashTable);
                    }
                    else if (buf1 == 2)
                    {
                        BackgroundColor = ConsoleColor.DarkBlue;
                        Write("Введіть імʼя потрібного вам курʼєра:");
                        ResetColor();
                        string name = Convert.ToString(ReadLine());
                        if (name != null)
                            PrintChosenCourier(name);
                    }
                    else if (buf1 == 3)
                    {
                        BackgroundColor = ConsoleColor.DarkBlue;
                        Write("Введіть номер потрібного вам замовлення:");
                        ResetColor();
                        int keyorder = Convert.ToInt32(ReadLine());
                        PrintChosenOrder(keyorder);
                    }
                }
                else if (buf == 3)//Користувач вибрав контрольне заповнення таблиці
                {
                    SetControlParameters();
                    BackgroundColor = ConsoleColor.DarkMagenta;
                    WriteLine("Таблиця успішно заповнена шістьма контрольними значеннями!");
                    ResetColor();
                }
                else if (buf == 4)//Користувач хоче видалити елемент з таблиці(реалізовано видалення через ключ - номер замовлення)
                {
                    BackgroundColor = ConsoleColor.DarkMagenta;
                    Write("Введіть номер замовлення, яке потрібно видалити: ");
                    ResetColor();
                    int key1 = Convert.ToInt32(ReadLine());

                    DeleteChosenOrder(key1);
                }
                else if (buf == 5)
                {
                    BackgroundColor = ConsoleColor.DarkMagenta;
                    WriteLine("Роботу програми завершено! Гарного дня!");
                    break;
                }
                else if (buf > 5||buf<=0)
                {
                    BackgroundColor = ConsoleColor.Black;
                    WriteLine("Ви ввели непередбачене програмою число, введіть будь ласке інше!");
                    ResetColor();
                }
            }
        }
        static void SetControlParameters()//Закинути в геш таблицю сталі значення якісь
        {
            string[] objects = { "Білизна", "Шкарпетки", "Велосипед", "Навушники", "Телефон", "Зошит" };
            string[] names = { "Andriy", "Stepan", "Vlad", "Bondan", "Maria", "Roman" };
            int[] days = new int[6] { 3, 6, 8, 9, 23, 26 };
            string[] streets = { "Головна", "Грушевського", "Бандери", "Польова", "Степанська", "Надвірна" };
            int number1 = 45, number2 = 3;
            for (int i = 0; i < 6; i++)
            {
                objecttype = $"{objects[i]}";
                couriername = $"{names[i]}";
                street = $"{streets[i]}";
                houseNumber = number1;
                appartmentNumber = number2;
                year = 2022;
                month = "Червень";
                day = days[i];
                AddToHashTable();
                number1++;
                number2++;
            }
        }
        static void DeleteChosenOrder(int key)//Функція для видалення елемента з таблиці 
        {
            Key key1 = new Key(key);
            BackgroundColor = ConsoleColor.DarkMagenta;
            if (FindEntry1(hashTable, key1) != null)//якщо таке значення взагалі існує, будуть виконані подальші дії
            {
                Value1 value1 = FindEntry1(hashTable, key1);
                string name = value1.CourierName;
                Key key2 = new Key(name);
                RemoveEntry1(hashTable, key1);
                RemoveEntry2(key2, int.Parse(key1.MyKey));
                WriteLine("Замовлення успішно видалене!");
            }
            else
            {
                WriteLine("Елемента з таким ключем немає!");
            }
            ResetColor();
        }
        static void PrintChosenOrder(int ID)//Функція для виведення в консоль даних про конкретно вказане користувачем замовлення
        {
            if (FindEntry1(hashTable, new Key(ID)) != null)
            {
                Value1 value1 = FindEntry1(hashTable, new Key(ID));
                string text = "";
                text += value1.Value1Formatting();
                WriteLine($"{text}");
            }
            else
            {
                BackgroundColor = ConsoleColor.DarkMagenta;
                WriteLine("Замовлення з таким номером немає!");
                ResetColor();
            }
        }
        static void PrintChosenCourier(string name)//Функція для виведення в консоль даних про замовлення, яке доставляє вказаний курʼєр
        {
            if (FindEntry2(hashTable2, new Key(name)) != null)
            {
                Value2 value2 = FindEntry2(hashTable2, new Key(name));
                string text = "Імʼя курʼєра: " + name + "\n\n";
                text += value2.Value2Formatting();
                WriteLine($"{text}");
            }
            else
            {
                BackgroundColor = ConsoleColor.DarkMagenta;
                WriteLine("Курʼєра з даним імʼям немає!");
                ResetColor();
            }
        }
        static void PrintHashTable(HashTable tablehash)//Функція для виведення в консоль вміст геш-таблиці
        {
            string text = $"Кількість ключів таблиці на даний момент: {tablehash.loadness.ToString()}\n";
            text += $"Розмір таблиці на даний момент: {tablehash.size.ToString()}\n";
            for (int i = 0; i < tablehash.size; i++)
            {
                if (tablehash.table[i] != null)
                {
                    text += $"\nНомер замовлення №{tablehash.table[i].KEY.MyKey}\n {((Value1)tablehash.table[i].Value).Value1Formatting()}";
                }
            }
            WriteLine($"{text}\n");
        }
        static int GetRandomNumber()//Отримання рандомного номера для замовленняв форматі, що вказаний у завданні до Лаболаторної роботи
        {
            Random rnd = new Random();
            int res = rnd.Next(100000, 999999);
            Key key = new Key(res);
            while (FindEntry1(hashTable, key) != null)
            {
                res = rnd.Next(100000, 999999);
                key = new Key(res);
            }
            return res;
        }
        static string FindStreet(int delID)//Функція для пошуку вулиці, зі вказаного номеру замовлення
        {
            for (int i = 0; i < hashTable.size; i++)
            {
                if (hashTable.table[i] != null)
                {
                    if (hashTable.table[i].KEY.MyKey == delID.ToString())
                    {
                        return ((Value1)hashTable.table[i].Value).AddressOfDelivery.Street;
                    }
                }
            }
            return null;
        }
        static bool PerevStreet(List<int> IDs)//Функція для перевірки, чи існує вже така вулиця у замовленнях
        {
            for (int i = 0; i < IDs.Count; i++)
            {
                if (FindStreet(IDs[i]) == street)
                {
                    return false;
                }
            }
            return true;
        }
        static bool IsCourierOld(HashTable hashtable, string name)//Функція для перевірки чи існує вже курʼєр з таким імʼям
        {
            for (int i = 0; i < hashtable.size; i++)
            {
                if (hashtable.table[i] != null)
                {
                    if (((Value1)hashtable.table[i].Value).CourierName == name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static bool IsCourierAvailable(string couriername1, string street1, Date date1)//Додаткова функція, яка перевіряє чи може курʼєр доставити нове відправлення. Реалізація даної функції була передбачена умовою завданням
        {
            if (hashTable2.table[GetHash(hashTable2, new Key(couriername1))] != null)
            {
                if (PerevStreet(((Value2)hashTable2.table[GetHash(hashTable2, new Key(couriername1))].Value).DeliveryIDs))//
                {
                    //Потрібно зауважити, що в якості "зміни", яка прописана у умові завдання, було взято повний робочий день. Тобто одна зміна для курʼєра це один повний робочий день. Тобто за одну зміну=один день курʼєр може відправити щонайбліьше 10 замовлень ну і якщо на одну ту ж саму вулицю то більше
                     return CompareDateAndStreet(((Value2)hashTable2.table[GetHash(hashTable2, new Key(couriername1))].Value).DeliveryIDs,date1);
                }
            }
            return true;
        }
        static bool CompareDateAndStreet(List<int> IDs,Date date111)//Функція для перевірки чи зможе курʼєр доставити замовлення з заданими даними
        {
            string generaldate = date111.GetDateString();
            if (IDs.Count < 9)//якщо загальна кількість замовлень впринципі менша 9, то звичайно курʼєр зможе, але таке буде дуже малоймовірно, якщо заповнювати таблицю великою кількістю значень
            {
                return true;
            }
            else
            {
                int countofdelivers = 0,buffer=0;
                for (int i = 0; i < IDs.Count; i++)//проходимось циклом по всім замовленням курʼєра
                {
                    Date datebufer = FindDate(IDs[i]);//беремо дату змовлення, яке переглядаємо
                    if (datebufer != null)//якщо замовлення дійсне(не видалене) 
                    {
                        string datebuf =datebufer.GetDateString();

                        for (int j = 0; j < IDs.Count; j++)
                        {
                            string streetbuf = FindStreet(IDs[i]);
                            if (streetbuf == street)//якщо серед замовлень є з такою ж самою вулицею
                            {
                                buffer = 1;//просто лічильник в залежності від якого буде змінюватись умова
                            }
                        }
                        if (generaldate == datebuf && buffer == 1)//якщо дата і вулиця співпадає, то однозначно, курʼєр зможе доставити замовлення
                        {
                            return true;
                        }
                        else if (generaldate == datebuf && buffer == 0)//якщо дата співпадає, а вулиці ні, то будемо рахувати скільки таких співпадань
                        {
                            countofdelivers++;
                        }
                    }
                }
                if(countofdelivers<=9)//якщо кількість замовлень в один той самий день буде менше або рівна 9, то курʼєр зможе віправити
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        static void AddToHashTable()//Функція для додавання елемента у хеш-таблицю
        {
            int deliveryID = GetRandomNumber();
            Key key1 = new Key(deliveryID);
            Date date11 = new Date(year, month, day);
            bool buffer1 = false;
            bool courierold = IsCourierOld(hashTable, couriername);
            if (courierold==true)//перевірка наявності такого курʼєра
            {
                bool availablecourier = IsCourierAvailable(couriername, street, date11);
                if (availablecourier==true)//перевірка на те, чи може курʼєр доставити нове замовлення
                {
                    if (FindEntry2(hashTable2, new Key(couriername)) != null)
                    {
                        Value2 value2 = FindEntry2(hashTable2, new Key(couriername));
                        value2.DeliveryIDs.Add(deliveryID);
                    }
                }
                else
                {
                    //спроба призначити іншого курʼєра
                    for (int i = 0; i < hashTable2.size; i++)
                    {
                        if (hashTable2.table[i] != null)
                        {
                            string temporarycourier = hashTable2.table[i].KEY.MyKey;
                            bool bool1 = IsCourierAvailable(temporarycourier, street, date11);
                            if (bool1==true)
                            {
                                if (FindEntry2(hashTable2, new Key(temporarycourier)).ToString() != null)
                                {
                                    couriername = temporarycourier;
                                    Value2 value2 = FindEntry2(hashTable2, new Key(temporarycourier));
                                    value2.DeliveryIDs.Add(deliveryID);
                                    WriteLine($"Вибраний вами курʼєр не зможе відправити ваше замовлення, тому вам буде призначено іншого курʼєра! Новий курʼєр матиме імʼя: {temporarycourier}");
                                    buffer1 = true;
                                    break;
                                }
                            }

                        }
                    }
                    string newcour;
                    if (buffer1==false)//якщо немає вільних курʼєрів, передбачено, що користувач введе імʼя нового
                    {
                        Write("Вибачаємось за незручності, але даний курʼєр в даний день не зможе доставити ваше замовлення, через досягнення ліміту доставок на зміну! Інші курʼєри також зайняті. Будь ласка, введіть імʼя іншого курʼєра:");
                        newcour = Convert.ToString(ReadLine());
                        couriername = newcour;
                    }
                }
            }
            else
            {
                InsertEntry(ref hashTable2, new Key(couriername), new Value2(deliveryID));
            }
            Value1 value1 = new Value1(objecttype, couriername, new Address(street, houseNumber, appartmentNumber), new Date(year, month, day));
            InsertEntry(ref hashTable, key1, value1);
        }
     
        /// Нижче буде наведено частина програмного коду, яка передбачає реалізацію саме геш-таблиць(основої та додаткової) та усіх основних функцій для роботи з ними
      
        public class HashTable//Програмна реалізація геш-таблиці
        {
            public Entry[] table;
            public double loadness;
            public int size;
            public class Items
            {
                public int Deliveryid;
            }
            public static HashTable InitHashtable(int capacity)//Створює нашу геш-таблицю, реалізовано як конструктор класу
            {
                HashTable hashTable = new HashTable();
                hashTable.loadness = 0;
                hashTable.table = new Entry[capacity];
                hashTable.size = capacity;
                return hashTable;
            }
        }
        public class Entry//Даний клас описує елемент, що додається до таблиці, як і повинен - містить поля key та value
        {
            public Key KEY;
            public object Value;
            public Entry(Key inputKey, object inputValue)
            {
                KEY = inputKey;
                Value = inputValue;
            }
        }
        public class Key//Kлас описує ключ
        {
            public string MyKey;

            public Key(string stringKey)
            {
                MyKey = stringKey;
            }
            public Key(int intKey)
            {
                MyKey = intKey.ToString();
            }
        }
        public class Address//Описує адресу доставки
        {
            public string Street;
            public int HouseNumber;
            public int Appartment;
            public Address(string street, int houseNum, int appartment)
            {
                Street = street;
                HouseNumber = houseNum;
                Appartment = appartment;
            }
            public string GetAddressString()//Для форматування виводу(виводить все в типі string)
            {
               string text = Street + HouseNumber.ToString() + "/" + Appartment.ToString();
                return text;
            }
        }
        public class Date//Користувацька структура, що описує дату
        {
            public int Year;
            public string Month;
            public int Day;
            public Date(int year, string month, int day)
            {
                Year = year;
                Month = month;
                Day = day;
            }
            public string GetDateString()//Для форматування виводу(виводить все в типі string)
            {
                string text = $"{Day}.{Month}.{Year}";
                return text;
            }
        }
        public class Value1
        {
            public string ObjectType;
            public string CourierName;
            public Address AddressOfDelivery;
            public Date DateOfDelivery;
            public Value1(string objectType, string courierName, Address addressOfDelivery, Date dateOfDelivery)
            {
                ObjectType = objectType;
                CourierName = courierName;
                AddressOfDelivery = addressOfDelivery;
                DateOfDelivery = dateOfDelivery;
            }
            public string Value1Formatting()//Форматування виводу 
            {
                string text = "";
                text += "Обʼєкт: " + ObjectType + "\n";
                text += "Імʼя курʼєра: " + CourierName + "\n";
                text += "Адреса: " + AddressOfDelivery.GetAddressString() + "\n";
                text += "Дата: " + DateOfDelivery.GetDateString() + "\n";
                return text;
            }
        }
        public class Value2
        {
            public List<int> DeliveryIDs = new List<int>();

            public Value2(int deliveryID)
            {
                DeliveryIDs.Add(deliveryID);
            }
            public string Value2Formatting()//Форматування виводу
            {
                string text = "";
                for (int i = 0; i < DeliveryIDs.Count; i++)
                {
                    text += "" + (i + 1) + ":\t" + DeliveryIDs[i] + "\n";
                    if (FindDate(DeliveryIDs[i]) != null)
                    {
                        text += "Дата замовлення:" + FindDate(DeliveryIDs[i]).GetDateString() + "\n";
                        text += "Адреса:" + FindAddress(DeliveryIDs[i]).GetAddressString() + "\n\n";
                    }
                    else
                    {
                        text += "Дату замовлення Deleted\n Адресу Deleted\n\n";
                    }
                }
                return text;
            }
        }
        public static void InsertEntry(ref HashTable hashtable, Key key, object value)//Функція,яка додає нову пару до геш-таблиці
        {
            if (1.0 * hashtable.loadness / hashtable.size > 0.75)//Якщо фактор завантаженості перевищить рекомендований, буде виконано перегешування таблиці
            {
                Rehashing(ref hashtable);
                BackgroundColor = ConsoleColor.DarkMagenta;
                WriteLine("Фактор завантаженості перевищував рекомендований, тому відбулось перегешування геш-таблиці!");
                ResetColor();
            } 
            int index = GetHash(hashtable, key);
            Entry newEntry = new Entry(key, value);
            /*
            if(index==hashtable.size)
            {
                index = 0;
            }
            */
            if (hashtable.table[index] == null)
            {
                hashtable.table[index] = newEntry;
            }
            else//якщо виникає колізія, вирішуємо її методом лінійного зондування
            {
                for (int i = 0; i < hashtable.size; i++)
                {
                    if (hashtable.table[index] != null)
                    {
                        index++;
                    }
                    else
                    {
                        hashtable.table[index] = newEntry;
                        break;
                    }
                }
            }
            hashtable.loadness++;
        }
        public static Value1 FindEntry1(HashTable hashtable, Key key)//Виконує пошук даних у основній геш-таблиці за ключем
        {
            if (hashtable != null)
            {
                int index = GetHash(hashtable, key);
                for (int i = 0; i < hashtable.size; i++)
                {
                    if (hashtable.table[index] != null)
                    {
                        if (getHashCode(key) == getHashCode(hashtable.table[index].KEY))
                            return (Value1)hashtable.table[index].Value;
                        else
                            index++;
                    }
                }
            }
            return null;
        }
        
        public static Value2 FindEntry2(HashTable hashtable, Key key)//Виконуe пошук елементів у геш-таблиці з замовленнями курʼєрів(додатковій)
        {
            if (hashtable != null)
            {
                int index = GetHash(hashtable, key);
                /*
                if(index==hashTable.size)
                {
                    index = 0;
                }
                */
                for (int i = 0; i < hashtable.size; i++)
                {
                    if (hashtable.table[index] != null)
                    {
                        if (getHashCode(key) == getHashCode(hashtable.table[index].KEY))
                            return (Value2)hashtable.table[index].Value;
                        else
                            index++;
                    }
                }
            }
            return null;
        }
        
        private static bool IsDeleteCourier2(Key key)//Перевірка на те, чи потрібно нам видаляти курʼєра з додаткової таблиці
        {
            Value2 value2 = FindEntry2(hashTable2, key);
            int buf = 0;
            for (int i = 0; i < value2.DeliveryIDs.Count; i++)
            {
                if (value2.DeliveryIDs[i]<=0)
                    buf++;
            }
            if (buf == value2.DeliveryIDs.Count)
            {
                return true;
            }
            return false;
        }
        public static void RemoveEntry1(HashTable hashtable, Key key)//видаляє пару з основної геш-таблиці за ключем, і залишає мітку
        {
            int index = GetHash(hashtable, key);
            for (int i = 0; i < hashtable.size; i++)
            {
                if (hashtable.table[index] != null)
                {
                    if (key.MyKey == hashtable.table[index].KEY.MyKey)
                    {
                        hashtable.table[index].KEY = new Key("DELETED");//ставимо мітку, оскільки саме такий спосіб передбачає лінійне зондування
                        return;
                    }
                    else
                        index++;
                }
            }
        }
        public static void RemoveEntry2(Key key, int delID)//видаляє замовлення з додаткової геш-таблиці
        {
            Value2 value2 = FindEntry2(hashTable2, key);
            for (int i = 0; i < value2.DeliveryIDs.Count; i++)
            {
                if (value2.DeliveryIDs[i] == delID)
                {
                    value2.DeliveryIDs[i] = counter;//для замовлення, яке нам потрібно видалити, ми змінюємо унікальний номер
                    counter--;
                    break;
                }
            }
            if (IsDeleteCourier2(key)==true)//якщо в курʼєра не залишилось дійсних замовлень, ми його видаляємо з додаткової геш-таблиці
                key.MyKey = null;
        }
        private static void Rehashing(ref HashTable hashtable)//Виконує перегешування геш-таблиці, коли досягається відповідний фактор завантаженості
        {
            HashTable newHashtable = HashTable.InitHashtable(hashtable.size * 2);
            for (int i = 0; i < hashtable.size; i++)
            {
                if (hashtable.table[i] != null)
                {
                    Key key = hashtable.table[i].KEY;
                    object value = hashtable.table[i].Value;
                    InsertEntry(ref newHashtable, key, value);
                }
            }
            hashtable = newHashtable;
        }
        public static int GetHash(HashTable hashtable, Key key)//обчислює функцію гешування для визначення індексу слота геш-таблиці
        {
            return getHashCode(key) % (hashtable.size-1);
        }
        public static int getHashCode(Key key)//обчислює геш-код ключа
        {
                int sum = 0;
                for (int i = 0; i < key.MyKey.Length; i++)
                {
                    sum += 37*(i+1)*(int)key.MyKey[i];
                }
                return sum;
        }
        public static Address FindAddress(int delID)//Знаходить адресу зі вказаного ключа(номер замовлення)
        {
            for (int i = 0; i < hashTable.size; i++)
            {
                if (hashTable.table[i] != null)
                {
                    if (hashTable.table[i].KEY.MyKey == delID.ToString())
                        return ((Value1)hashTable.table[i].Value).AddressOfDelivery;
                }
            }
            return null;
        }
        public static Date FindDate(int delID)//Знаходить дату зі вказаного ключа(номер замовлення)
        {
            for (int i = 0; i < hashTable.size; i++)
            {
                if (hashTable.table[i] != null)
                {
                    if (hashTable.table[i].KEY.MyKey == delID.ToString())
                        return ((Value1)hashTable.table[i].Value).DateOfDelivery;
                }
            }
            return null;
        }
    }
}
