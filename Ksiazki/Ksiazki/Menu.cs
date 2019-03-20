using System;
using System.Collections.Generic;

namespace Ksiazki
{
    internal class Menu
    {
        private Lista menu = new Lista();

        public void wyswietl()
        {
            for (; ; )
            {
                menu.showMenu();
                int choose = Int32.Parse(Console.ReadLine());

                while (!(0 <= choose && choose <= 7))
                {
                    Console.WriteLine("Podaj liczbę z zakresu 1-5");
                    choose = Int32.Parse(Console.ReadLine());
                }

                switch (choose)
                {
                    case 1:
                        menu.newTitle();
                        break;

                    case 2:
                        menu.deleteTitle();
                        break;

                    case 3:
                        menu.showTitle();
                        break;

                    case 4:
                        menu.showTitleByAuthor();
                        break;

                    case 5:
                        menu.searchTitle();
                        break;

                    case 6:
                        menu.searchBooksByAuthor();
                        break;
                    case 7:
                        menu.clear();
                        break;

                    case 0: return;
                }
            }
        }
    }
}