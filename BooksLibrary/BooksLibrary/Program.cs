using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Menu menu = new Menu();
            
            menu.showTitle();
            menu.showMenu();
            int option = -1;

            while (option < 0 || option > menu.getMenuOptionsNumber())
            {
                Console.WriteLine("Podaj liczbę z zakresu 0-" + menu.getMenuOptionsNumber());
                try
                {
                    option = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    
                }
            }


            while (true){ 
            switch (option)
            {
                case 1:
                    Console.Clear();
                    menu.showLibrary(menu.books);
                    break;

                case 2:
                    Console.Clear();
                    menu.addBook();
                    break;

                case 3:
                    Console.Clear();
                    menu.deleteBook();
                    break;

                case 4:
                    Console.Clear();
                    menu.checkIsRead();
                    break;

                case 5:
                    Console.Clear();
                    menu.showAuthorBooks();
                    break;

                case 6:
                    Console.Clear();
                    menu.showTitleBook();
                    break;

                case 7:
                    Console.Clear();
                    menu.sortByTitle();
                    break;

                case 8:
                    Console.Clear();
                    menu.sortByAuthor();
                    break;

                case 9: return;
                    
            }

                option = -1;
                menu.showMenu();
                while (option < 0 || option > menu.getMenuOptionsNumber())
                {
                    Console.WriteLine("Podaj liczbę z zakresu 0-" + menu.getMenuOptionsNumber());
                    try
                    {
                        option = Int32.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {

                    }
                }

            }







           
            
        }
          
        
    }
}
