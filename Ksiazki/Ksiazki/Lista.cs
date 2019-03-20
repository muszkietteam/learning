using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ksiazki
{
    internal class Lista
    {
        private SortedDictionary<string, string> gameLibrary = new SortedDictionary<string, string>() {
                { "Half-Life 2", "AAA" },
                { "Portal", "BBB" },
                { "Grand Theft Auto V", "CCC" },
                { "World of Warcraft", "DDD" },
                { "Don't Strave", "EEE" }
        };

        private ArrayList options = new ArrayList()
        {
            {"1. Dodaj nowy tytuł"},
            {"2. Usuń tytuł o podanej nazwie"},
            {"3. Wyświetl tytuły z mojej biblioteki"},
            {"4. Wyświetl tytuły według autorów"},
            {"5. Wyszukaj tytuł"},
            {"6. Szukaj ksiazek autora"},
            {"7. Wyczyść bibliotekę"},
            {"10. test paweł"},
            {"101. super test paweł"},
            {"0. Wyjdź z programu"},
        };

        public void showMenu()
        {
            foreach (string item in options)
            {
                Console.WriteLine(item);
            }
        }

        public void newTitle()
        {
            Console.Clear();
            Console.WriteLine("Podaj tytuł i autora ");
            gameLibrary.Add(Console.ReadLine(), Console.ReadLine());
            Console.WriteLine("Ksiazka została dodana do biblioteki!");
            
        }

        public void deleteTitle()
        {
            Console.Clear();
            Console.WriteLine("Podaj ksiazke która chcesz usunąć: ");
            string name = Console.ReadLine();
            if (gameLibrary.ContainsKey(name))
            {
                gameLibrary.Remove(name);
                Console.WriteLine();
                Console.WriteLine("Ksiazka: " + name + ", zostałą usunięta z biblioteki!");
                Console.WriteLine();
            }
            else Console.WriteLine("Brak tytułu o podanej nazwie.");
        }

        public void showTitle()
        {
            Console.Clear();
            isEmpty();
            foreach (KeyValuePair<string, string> game in gameLibrary)
            {
                Console.WriteLine("{0}, autor {1}", game.Key, game.Value);
            }
        }

        public void showTitleByAuthor()
        {
            Console.Clear();
            isEmpty();
            ArrayList author = new ArrayList();
            foreach (KeyValuePair<string, string> game in gameLibrary.OrderBy(key => key.Value))
            {
                Console.WriteLine("{0}, autor: {1}", game.Key, game.Value);
            }
        }

        public void searchTitle()
        {
            Console.Clear();
            Console.WriteLine("Podaj tytuł który chcesz wyszukać: ");
            string name1 = Console.ReadLine();
            if (gameLibrary.ContainsKey(name1))
            {
                Console.WriteLine('"' + name1 + '"' + " autor: " + gameLibrary[name1]);
                Console.WriteLine();
            }
            else Console.WriteLine("Brak tytułu o podanej nazwie.");
        }

        public void searchBooksByAuthor()
        {
            Console.Clear();
            Console.WriteLine("Podaj autora, ktorego ksiazki chcesz wyszukac: ");
            string name1 = Console.ReadLine();
            Boolean check = false;
            foreach (KeyValuePair<string, string> game in gameLibrary)
            {
                if(name1 == game.Value)
                {
                    Console.WriteLine("Ksiazki autora: ");
                    Console.WriteLine("" + game.Key);
                    check = true;
                }
                    
            }
            if(check == false)
                Console.WriteLine("Brak ksiazek podanego autora");
        }

        public void clear()
        {
            Console.Clear();
            gameLibrary.Clear();
            Console.WriteLine("Twoja biblioteka została wyczyszczona!");
        }

        public void isEmpty()
        {
            if(gameLibrary.Count() == 0)
            {
                Console.WriteLine("Brak ksiazek w bibliotece");
            }
        }
    }
}