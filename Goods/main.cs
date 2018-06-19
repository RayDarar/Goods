using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Три аккаунта:
 * 1:
 * Логин: RayDarar
 * Пароль: Zaka2
 * 2:
 * Логин: Bracket
 * Пароль: bzzz228
 * 3:
 * Логин: Tutor
 * Пароль: glhf
 */

namespace ansarRyspekov.cSharp.Test.main
{
    public class User
    {
        public User()
        {
            name = "User";
            accessLevel = false;
            current = 4;

            accounts[0] = new Marketer.Marketer() { fullName = "Рыспеков Ансар Кайратович", login = "RayDarar", password = "Zaka2", wrongAccess = 0, WhichIsAvaliable = 0, WhichIsUnavaliable = 0 };
            accounts[1] = new Marketer.Marketer() { fullName = "Рыспекова Томирис Кайратовна", login = "Bracket", password = "bzzz228", wrongAccess = 0, WhichIsAvaliable = 0, WhichIsUnavaliable = 0 };
            accounts[2] = new Marketer.Marketer() { fullName = "Талгатбекова Асем-гуль Талгатбековна", login = "Tutor", password = "glhf", wrongAccess = 0, WhichIsAvaliable = 0, WhichIsUnavaliable = 0 };
            Random r = new Random();
            for (int i = 0, temp, temp2; i < 30; i++)
            {
                Random rnd = new Random(r.Next());
                temp = rnd.Next(30);
                rnd = new Random(r.Next());
                temp2 = rnd.Next(30);
                if (temp2 >= 0 && temp2 <= 9)//Первый Аккаунт
                    temp2 = 0;
                else if (temp2 >= 10 && temp2 <= 19)//Второй аккаунт
                    temp2 = 1;
                else if (temp2 >= 20 && temp2 <= 29)//Третий аккаунт
                    temp2 = 2;

                if (temp >= 0 && temp <= 9)//Первый продукт
                    goods[i] = new Goods.Goods("LION ULTANUL", "FA" + rnd.Next(10) + "S" + rnd.Next(300) + "FX", rnd.Next(0, 10), rnd.Next(0, 30), rnd.Next(0, 80), rnd.Next(1000, 99999), accounts[temp2]);
                else if (temp >= 10 && temp <= 19)//Второй продуктs
                    goods[i] = new Goods.Goods("MEGA ULTRA PONCHIK", "XA" + rnd.Next(2) + "S-T-S-" + rnd.Next(4000) + "SSS", rnd.Next(0, 30), rnd.Next(0, 30), rnd.Next(0, 25), rnd.Next(500, 5000), accounts[temp2]);
                 
                else if (temp >= 20 && temp <= 29)//Третий продукт
                    goods[i] = new Goods.Goods("VAC. CLEANER", "PANDA" + rnd.Next(14) + "-" + rnd.Next(18) + "SSS", rnd.Next(0, 30), rnd.Next(0, 30), rnd.Next(0, 95), rnd.Next(0, 999999), accounts[temp2]);

                if (goods[i].availlability > 0)
                    accounts[temp2].WhichIsAvaliable++;
                else
                    accounts[temp2].WhichIsUnavaliable++;
            }
        }
        public string name { get; set; }//Имя
        public int current;
        public bool accessLevel { get; set; }//Доступ
        public Marketer.Marketer[] accounts = new Marketer.Marketer[3];//Несколько аккаунтов
        public Goods.Goods[] goods = new Goods.Goods[30];//Несколько продуктов
    }
    class main
    {
        static int res = 0;
        static void Main(string[] args)
        {
            CC('w');
            User user = new User();
            menu(user);
            Console.Clear();
            Out("Досвидания, " + user.name);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------]
        static void menu(User user)
        {
            Console.Clear();
            if (user.accessLevel == false)//Пользователь не авторизован
            {
                Out("[------------------*------------------]\n1. Войти\n2. Список товара на складе\n3. Авторизоваться как гость\n4. Выход из приложения\n[------------------*------------------]");
                res = Ini(res, 0);
                switch (res)
                {
                    case 1:
                        {
                            Console.Clear();
                            task1(user);
                            Ins();
                            menu(user);
                        }
                        break;
                    case 2:
                        {
                            Console.Clear();
                            task2(user);
                            Ins();
                            menu(user);
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            task3(user);
                            if (user.name == "User")
                                menu(user);
                        }
                        break;
                    case 4:
                        break;
                    default:
                        menu(user);
                        break;
                }
            }
            else//Пользователь авторизован
            {
                Out("[------------------*------------------]");
                Out("Приветсвую вас, " + user.name);
                Console.Write("Количество доступного товара:\t"); CC('G'); Out(user.accounts[user.current].WhichIsAvaliable);
                CC('W'); Console.Write("Количество недоступного товара:\t"); CC('R'); Out(user.accounts[user.current].WhichIsUnavaliable);
                CC('W');
                Out("[------------------*------------------]");
                Out("1. Добавить товар\n2. Посчитать сумму всех товаров\n3. Вывести товары которые закончились\n4. Вывести товары которые есть в наличии\n5. Вывести все товары\n6. Выйти\n7. Выход из программы\n[------------------*------------------]");
                res = Ini(res, 0);
                switch (res)
                {
                    case 1:
                        {
                            Console.Clear();
                            vtask1(user);
                            Ins();
                            menu(user);
                        }
                        break;
                    case 2:
                        {
                            Console.Clear();
                            vtask2(user);
                            Ins();
                            menu(user);
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            vtask3(user);
                            Ins();
                            menu(user);
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            vtask4(user);
                            Ins();
                            menu(user);
                        }
                        break;
                    case 5:
                        {
                            Console.Clear();
                            vtask5(user);
                            Ins();
                            menu(user);
                        }
                        break;
                    case 6:
                        {
                            Console.Clear();
                            Out("Внимание! Выйти из акаунта?\n1)Да");
                            if (Ins() == "1")
                            {
                                CC('r');
                                Out("Вы вышли из акаунта!");
                                user.accessLevel = false;
                                user.name = "User";
                                user.current = 4;
                            }
                            else
                            {
                                CC('G');
                                Out("Отмена операции...");
                            }
                            CC('W');
                            Ins();
                            menu(user);
                        }
                        break;
                    case 7:
                        break;
                    default:
                        menu(user);
                        break;
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------]
        static void task1(User user)
        {
            if (user.accessLevel)//Выход из аккаунта
            {

                Out("Внимание! Выйти из акаунта?\n1)Да");
                if (Ins() == "1")
                {
                    CC('r');
                    Out("Вы вышли из акаунта!");
                    user.accessLevel = false;
                    user.name = "User";
                    user.current = 4;
                }
                else
                {
                    CC('G');
                    Out("Отмена операции...");
                }
                CC('W');
            }
            else//Вход в аккаунт
            {
                string temp;
                bool flag;
                while (true)
                {
                    flag = false;
                    Console.Clear();
                    Out("Вводите логин, выход - 0");
                    Console.Write("Логин:\t");
                    temp = Ins();
                    if (temp == "0")
                        break;
                    for (int i = 0; i < user.accounts.Length; i++)
                    {
                        if (temp == user.accounts[i].login)
                        {
                            user.current = i;
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                        break;
                }
                if (flag)//Идем на пароль
                {
                    Console.Clear();
                    Out("Последняя авторизация: " + user.accounts[user.current].printTime() + ", количество неудачных попыток входа: " + user.accounts[user.current].wrongAccess);
                    flag = false;
                    int count = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("Пароль:\t");
                        temp = Ins();
                        if (temp == user.accounts[user.current].password)
                        {
                            flag = true;
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            CC('R');
                            Out("Пароль не совпадает! " + (i + 1));
                            CC('W');
                            Out("Последняя авторизация: " + user.accounts[user.current].printTime() + ", количество неудачных попыток входа: " + user.accounts[user.current].wrongAccess);
                            count++;
                        }
                    }
                    if (flag)//Авторизация
                    {
                        user.accounts[user.current].lastEnter = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                        user.accounts[user.current].wrongAccess += count;
                        user.name = user.accounts[user.current].fullName;
                        user.accessLevel = true;
                        CC('G');
                        Out("Добро пожаловать, " + user.name);
                        CC('W');
                    }
                    else//Отмена
                    {
                        CC('R');
                        Out("Отмена авторизации!");
                        CC('w');
                    }
                }
                else
                {
                    CC('R');
                    Out("Отмена авторизации!");
                    CC('w');
                }
            }
        }
        static void task2(User user)
        {
            if (!user.accessLevel)//Не авторизован
            {
                Out("Список всех товаров со всех складов\n");
                foreach (var item in user.goods)
                    item.print();
            }
            else//Авторизован
            {
                Out("Список ваших товаров со всех складов\n");
                foreach (var item in user.goods)
                {
                    if (user.name == item.marketerer.fullName)
                        item.print();
                }
            }
            Out("----------------------------------------------------------------]");
        }
        static void task3(User user)
        {

            Console.Clear();
            user.name = "Guest";
            Out("ВНИМАНИЕ! Вы вошли как гость");
            Out("1. Товары в наличии и со скидкой ~30%\n2. Выйти\n3. Выход из программы");
            res = Ini(res, 0);
            switch (res)
            {
                case 1:
                    {
                        Console.Clear();
                        foreach (var item in user.goods)
                            if (item.discount >= 25 && item.discount <= 35 && item.availlability > 0)
                                item.print();

                        Out("----------------------------------------------]");
                        Ins();
                        task3(user);
                    }
                    break;
                case 2:
                    user.name = "User";
                    break;
                case 3:
                    break;
                default:
                    task3(user);
                    break;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------]

        //-------------------------------------------------------------------------------------------------------------------------------------------]
        static void vtask1(User user)
        {
            Goods.Goods temp = new Goods.Goods();
            Out("Добавить товар! Вводите данные");
            Console.Write("Наименование продукта: "); temp.productName = Ins();
            Console.Write("Артикул: "); temp.vendorCode = Ins();
            Console.Write("Количество: "); temp.availlability = Ini(temp.availlability, 0);
            Console.Write("Выберите хранилище (1 - Астана, 2 - Алматы, 3 - Караганда):"); res = Ini(res, 1);
            if (res == 1)
                temp.storage = "Астана";
            else if (res == 2)
                temp.storage = "Алматы";
            else if (res == 3)
                temp.storage = "Караганда";
            Console.Write("Скидка: "); temp.discount = Ini(temp.discount, 0);
            Console.Write("Цена: "); temp.price = Ini(temp.price, 1000);
            temp.price_D = temp.price - ((temp.price * temp.discount) / 100);
            temp.marketerer = user.accounts[user.current];

            Goods.Goods[] arr = new Goods.Goods[user.goods.Length + 1];
            arr[0] = temp;
            for (int i = 1, i1 = 0; i < arr.Length; i++, i1++)
                arr[i] = user.goods[i1];
            user.goods = new Goods.Goods[arr.Length];
            for (int i = 0; i < user.goods.Length; i++)
                user.goods[i] = arr[i];
            Console.Clear();
            CC('G');
            Out("Успешно!");
            CC('W');
        }
        static void vtask2(User user)
        {
            int sum = 0;
            int sumD = 0;
            foreach (var item in user.goods)
            {
                if (item.marketerer.fullName == user.accounts[user.current].fullName)
                {
                    sum += item.price;
                    sumD += item.price_D;
                }
            }
            Console.Write("Сумма всех товаров без учета скидки: "); CC('G'); Out(sum + "$"); CC('W');
            Console.Write("Сумма всех товаров с учетом скидки: "); CC('G'); Out(sumD + "$"); CC('W');
            Console.Write("На скидках вы теряеете: "); CC('R'); Out(sum - sumD + "$"); CC('W');
        }
        static void vtask3(User user)
        {
            foreach (var item in user.goods)
            {
                if (item.availlability == 0 && item.marketerer.fullName == user.accounts[user.current].fullName)
                    item.print();
            }
            Out("----------------------------------------------------]");
        }
        static void vtask4(User user)
        {
            foreach (var item in user.goods)
            {
                if (item.availlability > 0 && item.marketerer.fullName == user.accounts[user.current].fullName)
                    item.print();
            }
            Out("----------------------------------------------------]");
        }
        static void vtask5(User user)
        {
            foreach (var item in user.goods)
                if (item.marketerer.fullName == user.accounts[user.current].fullName)
                    item.print();
            Out("-------------------------------------------------------------------]");
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------]

        //-------------------------------------------------------------------------------------------------------------------------------------------]
        static void Out(object str) { Console.WriteLine(str); }
        static int Ini(int num, int def)
        {
            num = def;
            Int32.TryParse(Console.ReadLine(), out num);
            return num;
        }
        static string Ins() { return Console.ReadLine(); }
        static void CC(char color)
        {
            if (color == 'w' || color == 'W')
                Console.ForegroundColor = ConsoleColor.White;
            else if (color == 'r' || color == 'R')
                Console.ForegroundColor = ConsoleColor.Red;
            else if (color == 'g' || color == 'G')
                Console.ForegroundColor = ConsoleColor.Green;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------]
    }
}