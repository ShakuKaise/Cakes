using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    internal class Menu
    {
        private string[,] prices = new string[6, 6]
            {
                {"500", "500", "500", "700", "", ""},
                {"1000", "1200", "2000", "", "", ""},
                {"100", "100", "150", "200", "250", ""},
                {"200", "400", "600", "800", "", ""},
                {"100", "100", "150", "150", "200", ""},
                {"150", "150", "150", "", "", ""},
            };
        private string[,] parameters = new string[6, 6]
        {
                {"Круг", "Квадрат", "Прямоугольник", "Сердешко", "", ""},
                {"Маленький(D - 16cm, 8 порц.)", "Обычный(D - 18cm, 10 порц.)", "Большой(D - 28cm, 24 порц.)", "", "", ""},
                {"Ванильный", "Шоколадный", "Карамельный", "Ягодный", "Кокосовый", ""},
                {"1 корж", "2 коржа", "3 коржа", "4 коржа", "", ""},
                {"Шоколад", "Крем", "Бизе", "Драже", "Ягоды", ""},
                {"Шоколадная", "Ягодная", "Кремовая", "", "", ""},
        };
        public void MenuUI()
        {
            

            int MaxVerPos = 8;
            int MinVerPos = 2;
            int VerPos = 1;
            int price = 0;
            int menu = 1;
            int index = 0;
            Cake cake = new Cake(0, 0, 0, 0, 0, 0, 0, null, null, null, null, null, null, null);
            ConsoleKey key;

            while (true)
            {
                cake.AllPrice = cake.FormPrice + cake.SizePrice + cake.TastePrice + cake.AmountPrice + cake.DecorationPrice + cake.GlazePrice;
                cake.AllOptions = $"{cake.form} {cake.size} {cake.taste} {cake.amount} {cake.decoration} {cake.glaze}";
                switch (menu)
                {
                    case 1:
                        MainMenu(price, cake);
                        break;
                    case 2:
                        SecondaryMenu(prices, parameters, index);
                        break;
                }
                WriteCursor(VerPos);
                key = Console.ReadKey(true).Key;
                VerPos = UpdateCursorPos(VerPos, MaxVerPos, MinVerPos, key);
                switch (menu)
                {
                    case 1:
                        switch (key)
                        {
                            case ConsoleKey.Enter:
                                if (VerPos < 8)
                                {
                                    menu = 2;
                                    MinVerPos = 3;
                                    index = VerPos - 2;
                                    for (int i = 0; i < 6; i++)
                                    {
                                        if (parameters[index, i] == "")
                                        {
                                            MaxVerPos -= 1;
                                        }
                                    }
                                }
                                else if (VerPos == 8)
                                {
                                    WritingOrder(cake.AllOptions, cake.AllPrice);
                                    Console.Clear();
                                    Console.WriteLine("Спасибо за заказ!");
                                    Console.WriteLine("Если хотите завершить выполнение программы нажмите ESC.");
                                    key = Console.ReadKey(true).Key;
                                    if (key == ConsoleKey.Escape)
                                    {
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        cake = new Cake(0, 0, 0, 0, 0, 0, 0, null, null, null, null, null, null, null);
                                    }
                                }
                                break;
                        }
                        break;
                    case 2:
                        switch (key)
                        {
                            case ConsoleKey.Enter:
                                int option = VerPos - 3;
                                ChoosingOptions(option, index, parameters, prices, cake);
                                menu = 1;
                                MinVerPos = 2;
                                MaxVerPos = 8;
                                break;
                            case ConsoleKey.Escape:
                                menu = 1;
                                MinVerPos = 2;
                                MaxVerPos = 8;
                                break;
                        }
                        break;
                }
            }
        }
        private void MainMenu(int price, Cake cake)
        {
            Console.Clear();
            Console.WriteLine("Выберите параметр торта");
            Console.WriteLine("---------------------------"); // VerPos = 1
            Console.WriteLine("  Форма торта");     // index = 1 VerPos = 2
            Console.WriteLine("  Размер торта");    // index = 2 VerPos = 3
            Console.WriteLine("  Вкус коржей");     // index = 3 VerPos = 4
            Console.WriteLine("  Кол-во коржей");   // index = 4 VerPos = 5
            Console.WriteLine("  Глазурь");         // index = 5 VerPos = 6
            Console.WriteLine("  Декор");           // index = 6 VerPos = 7
            Console.WriteLine("  Конец заказа");    // exit()    VerPos = 8
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Цена: {cake.AllPrice}");
            Console.WriteLine($"Заказ: {cake.AllOptions}");

        }
        private int UpdateCursorPos(int VerPos, int MaxVerPos, int MinVerPos, ConsoleKey key) //Изменение позиции курсора
        {
            switch (key)
            {
                case (ConsoleKey.W):
                    VerPos--;
                    if (VerPos < MinVerPos)
                    {
                        VerPos = MinVerPos;
                    }
                    break;
                case (ConsoleKey.S):
                    VerPos++;
                    if (VerPos > MaxVerPos)
                    {
                        VerPos = MaxVerPos;
                    };
                    break;
            }
            return VerPos;
        }
        private void WriteCursor(int VerPos) //создание курсора в позиции
        {
            Console.SetCursorPosition(0, VerPos);
            Console.WriteLine("->");
        }
        private void SecondaryMenu(string[,] prices, string[,] parameters, int index) //в зависимости от индекса менять наполнение данного меню
        {// проверка на дауна, если в массиме пустая строка, то скипай в условии нахуй
            Console.Clear();
            Console.WriteLine("Для выхода нажмите ESC");
            Console.WriteLine("Выберите параметр торта");
            Console.WriteLine("-----------------------------------------");
            for (int i = 0; i < 6; i++)
            {
                if (parameters[index, i] != "")
                {
                    Console.WriteLine($"  {parameters[index, i]} - {prices[index, i]} рубелей");
                }
            }

        }
        private void ChoosingOptions(int option, int index, string[,] parameters, string[,] prices, Cake cake)
        {
            switch (index)
            {
                case 0:
                    cake.form = parameters[index, option];
                    cake.FormPrice = Convert.ToInt32(prices[index, option]);
                    break;
                case 1:
                    cake.size = parameters[index, option];
                    cake.SizePrice = Convert.ToInt32(prices[index, option]);
                    break;
                case 2:
                    cake.taste = parameters[index, option];
                    cake.TastePrice = Convert.ToInt32(prices[index, option]);
                    break;
                case 3:
                    cake.amount = parameters[index, option];
                    cake.AmountPrice = Convert.ToInt32(prices[index, option]);
                    break;
                case 4:
                    cake.glaze = parameters[index, option];
                    cake.GlazePrice = Convert.ToInt32(prices[index, option]);
                    break;
                case 5:
                    cake.decoration = parameters[index, option];
                    cake.DecorationPrice = Convert.ToInt32(prices[index, option]);
                    break;
            }
        }
        private void WritingOrder(string AllOptions, int AllPrice)
        {
            File.AppendAllText("C:\\mpt\\С#\\Cakes\\Order.txt", $"\n{DateTime.Now}\n{AllPrice}\n{AllOptions}");
        }
    }
}
