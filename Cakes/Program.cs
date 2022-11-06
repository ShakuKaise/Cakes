using System;

namespace Cakes
{
    internal class Program // НЕОБХОДИМО: Создание курсора и изменение его позиции, создание заказа, оснвоное меню, второстепенное меню, создать функции для каждого подменю
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.MenuUI();
        }

    }
}