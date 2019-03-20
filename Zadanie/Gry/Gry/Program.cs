using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gry
{
    class Program
    {
        static void Main(string[] args)
        {

            SortedDictionary<string, string> booksLibrary = new SortedDictionary<string, string>() {
                {"W pustyni i w puszczy","Henryk Sienkiewicz"},
                { "Krzyżacy", "Henryk Sienkiewicz" },
                { "Wiedźmin", "Andrzej Sapkowski" },
                { "World of Warcraft", "King William" },
                { "Abecadło", "Ania Ann" }
                

            };

            Menu menu = new Menu();
            for (; ; )
            {
                menu.showMenu();
            int choose = Int32.Parse(Console.ReadLine());


            
            while (!(0<choose && choose <= 6))
            {
                Console.WriteLine("Podaj liczbę z zakresu 1-5");
                choose = Int32.Parse(Console.ReadLine());
            }

            switch (choose)
            {
                case 1:
                    Console.WriteLine("Podaj tytuł i autora po enterze");

                    booksLibrary.Add(Console.ReadLine(),(Console.ReadLine()));
                        Console.WriteLine("Książka została dodana do biblioteki!");
                        Console.WriteLine();
                    break;

                case 2:

                        Console.WriteLine("Podaj tytuł który chcesz usunąć: ");
                        string name = Console.ReadLine();
                        if (booksLibrary.ContainsKey(name))
                        {
                            booksLibrary.Remove(name);
                            Console.WriteLine();
                            Console.WriteLine("Książka: " + name + ", zostałą usunięta z biblioteki!");
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Brak tytułu o podanej nazwie.");
                        Console.WriteLine();
                        

                        break;

                case 3:

                        foreach (KeyValuePair<string, string> game in booksLibrary)
                        {
                            Console.WriteLine("{0}, autor {1}", game.Key, game.Value);
                        }
                        Console.WriteLine();

                        break;

                    case 4:

                        List<KeyValuePair<string, string>> sortedByAuthor = (from books in booksLibrary orderby books.Value select books).ToList();

                        foreach (KeyValuePair<string, string> kv in sortedByAuthor)
                        {
                            Console.WriteLine("{0},  {1}", kv.Value, kv.Key);
                            
                        }
                        Console.WriteLine();



                        break;

                    case 5:
                        Console.WriteLine("Podaj tytuł który chcesz wyszukać: ");
                        string name1 = Console.ReadLine();
                        if (booksLibrary.ContainsKey(name1))
                        {
                            Console.WriteLine('"' + name1 + '"' + " autor: " + booksLibrary[name1]);
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Brak tytułu o podanej nazwie.");
                        Console.WriteLine();
                        break;

                    case 6:
                        Console.WriteLine("Podaj autora którego książki chcesz wyświetlić: ");
                        string name2 = Console.ReadLine();
                        if (booksLibrary.ContainsValue(name2))
                        {
                            Console.WriteLine("Książki " + name2);
                            foreach (KeyValuePair<string, string> game in booksLibrary)
                            {
                                if(name2 == game.Value)Console.WriteLine(game.Key);
                            }
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Brak tytułu o podanej nazwie.");
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case 7:
                        booksLibrary.Clear();
                        Console.WriteLine("Twoja biblioteka ksiażek została wyczyszczona!");
                        Console.WriteLine();
                   break;

                    case 8: return;


                }

            }



        }
    }
}
