using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary
{
    class Menu
    {
        public List<Book> books = new List<Book>()
        {
            {new Book("Tatuażysta z Auschwitz", "Morris Heather", 2018)},
            {new Book("Umorzenie", "Mróz Remigiusz", 2019)},
            {new Book("Niezniszczalny", "Gutowski Cezary", 2010)},
            {new Book("Kasacja", "Mróz Remigiusz", 2015)},
        };

        ArrayList menuOptions = new ArrayList()
        {
            {"1. Pokaż moją bibliotekę."},
            {"2. Dodaj ksiażkę do biblioteki."},
            {"3. Usuń książkę z biblioteki."},
            {"4. Oznacz książkę jako przeczytaną."},
            {"5. Wyświetl książki autora."},
            {"6. Wyszukaj tytuł."},
            {"7. Pokaż bibliotekę posortowaną po tytule."},
            {"8. Pokaż bibliotekę posortowaną po autorze."},
            {"9. Wyjdź z programu."},

        };

        ArrayList deleteOptions = new ArrayList()
        {
            {"1. Usuń książkę o podanym tytule."},
            {"2. Usuń książkę o ID"},
            {"3. Usuń książki autora."},
            {"4. Usuń książki przeczytane."},

        };

        public int getMenuOptionsNumber()
        {
            return menuOptions.Count;
        }

        public void showMenu()
        {
            foreach (string option in menuOptions)
                Console.WriteLine(option);

        }



        public void showTitle()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("WITAJ W PRYWATNEJ BIBLIOTECE KSIĄŻEK");
            Console.WriteLine("Co chcesz zrobic?");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void showLibrary(List<Book> list)
        {


            foreach (Book option in list)

                Console.WriteLine("ID KSIĄŻKI: " + option.id + "\nTYTUŁ: " + option.title + "\nAUTOR: " + option.author + "\nROK WYDANIA: " + option.releaseYear + "\nSTATUS: " + option.orReads() + "\n" + ("").PadRight(100, '.'));

            Console.WriteLine();
        }


        public void addBook()
        {

            string title, author;
            int releaseYear = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Podaj tytuł (OBOWIĄZKOWO)");
                title = Console.ReadLine();
            } while (string.IsNullOrEmpty(title));



            do
            {
                Console.Clear();
                Console.WriteLine("Podaj autora (OBOWIĄZKOWO)");
                author = Console.ReadLine();
            } while (string.IsNullOrEmpty(author));



            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Podaj rok wydania (OBOWIĄZKOWO)");
                    releaseYear = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {

                }
            } while (releaseYear == 0);

            Console.Clear();
            Console.WriteLine("Czy przeczytałeś tą książkę? (WPISZ \"T\" LUB \"N\")");
            String read = Console.ReadLine();
            Boolean reads = false;

            if (read.ToUpper() == "N") reads = false;
            else if (read.ToUpper() == "T") reads = true;
            else
            {
                Console.Clear();
                Console.WriteLine("Wpisałeś złą wartośc, a więc książka została zaznaczona domyślnie jako nieprzeczytana!\n");
            }


            try
            {
                books.Add(new Book(title, author, releaseYear, reads));
            }
            catch (FormatException)
            {
                Console.WriteLine("Nie podałeś wymaganych informacji!");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Książka dodana do biblioteki!\n\n");
            Console.ResetColor();
        }

        public void deleteBook()
        {

            foreach (string optionDel in deleteOptions)
                Console.WriteLine(optionDel);

            int option = -1;

            while (option < 0 || option > deleteOptions.Count)
            {
                Console.WriteLine("Podaj liczbę z zakresu 0-" + deleteOptions.Count);
                try
                {
                    option = Int32.Parse(Console.ReadLine());
                }
                catch (System.FormatException)
                {

                }
            }


            switch (option)
            {
                case 1:
                    Console.WriteLine("Podaj tytuł do usunięcia.");
                    String title = Console.ReadLine();
                    Boolean flag = false;

                    for (int i = 0; i < books.Count(); i++)
                    {
                        if (books[i].title.ToLower() == title.ToLower())
                        {
                            books.RemoveAt(i);
                            flag = true;
                        }


                    }
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (flag) Console.WriteLine("Książka usunięta!\n\n");
                    else Console.WriteLine("Brak książki o podanym tytule!\n\n");
                    Console.ResetColor();
                    break;

                case 2:
                    Console.WriteLine("Podaj ID książki do usunięcia.");
                    int id = Int32.Parse(Console.ReadLine());
                    Boolean flag1 = false;

                    for (int i = 0; i < books.Count(); i++)
                    {
                        if (books[i].id == id)
                        {
                            books.RemoveAt(i);
                            flag1 = true;
                        }


                    }
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (flag1) Console.WriteLine("Książka usunięta!\n\n");
                    else Console.WriteLine("Brak książki o podanym ID!\n\n");
                    Console.ResetColor();
                    break;

                case 3:
                    Console.WriteLine("Podaj autora, którego książki chcesz usunąc.");
                    String author = Console.ReadLine();
                    Boolean flag2 = false;

                    for (int i = 0; i < books.Count(); i++)
                    {
                        if (books[i].author.ToLower() == author.ToLower())
                        {
                            books.RemoveAt(i);
                            flag2 = true;
                        }


                    }
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (flag2) Console.WriteLine("Książka usunięta!\n\n");
                    else Console.WriteLine("Brak książek podanego autora!\n\n");
                    Console.ResetColor();
                    break;

                case 4:


                    Boolean flag3 = false;

                    for (int i = 0; i < books.Count(); i++)
                    {
                        if (books[i].read == true)
                        {
                            books.RemoveAt(i);
                            flag3 = true;
                        }


                    }
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (flag3) Console.WriteLine("Wszystkie przeczytane książka zostały usunięte!\n\n");
                    else Console.WriteLine("Brak przeczytanych książek.\n\n");
                    Console.ResetColor();
                    break;


            }

        }

        public void checkIsRead()
        {
            Console.WriteLine("Podaj ID książki którą przeczytałeś");
            int id = -1;
            Boolean flag = false;
            try
            {
                id = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                return;
            }


            for (int i = 0; i < books.Count(); i++)
            {
                if (id == books[i].id)
                {
                    books[i].read = true;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Książka " + books[i].title + " została oznaczona jako przeczytana!");
                    Console.ResetColor();
                    flag = true;
                }

                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Brak książki o podanym ID.");
                    Console.ResetColor();
                }

            }

        }

        public void showAuthorBooks()
        {
            Console.WriteLine("Podaj nazwisko autora.");
            String author = Console.ReadLine();
            Boolean flag = false;
            Console.Clear();
            for (int i = 0; i < books.Count(); i++)
            {

                if (books[i].author.ToLower().CompareTo(author.ToLower()) == 1)
                {

                    Console.WriteLine("ID KSIĄŻKI: " + books[i].id + "\nTYTUŁ: " + books[i].title + "\nROK WYDANIA: " + books[i].releaseYear + "\nSTATUS: " + books[i].orReads() + "\n" + ("").PadRight(100, '.'));
                    flag = true;
                }



            }
            if (!flag) Console.WriteLine("Brak książek tego autora.\n\n");
        }

        public void showTitleBook()
        {
            Console.WriteLine("Wpisz tytuł");
            String title = Console.ReadLine();
            Boolean flag = false;
            Console.Clear();
            for (int i = 0; i < books.Count(); i++)
            {

                if (books[i].title.ToLower().CompareTo(title.ToLower()) == 1)
                {

                    Console.WriteLine("ID KSIĄŻKI: " + books[i].id + "\nTYTUŁ: " + books[i].title + "\nROK WYDANIA: " + books[i].releaseYear + "\nSTATUS: " + books[i].orReads() + "\n" + ("").PadRight(100, '.'));
                    flag = true;
                }



            }
            if (!flag) Console.WriteLine("Brak książek o podanym tytule.");
        }

        public void sortByTitle()
        {
            ArrayList nowa = new ArrayList(books.OrderBy(x => x.title).ToList());

            foreach (Book option in nowa)

                Console.WriteLine("ID KSIĄŻKI: " + option.id + "\nTYTUŁ: " + option.title + "\nAUTOR: " + option.author + "\nROK WYDANIA: " + option.releaseYear + "\nSTATUS: " + option.orReads() + "\n" + ("").PadRight(100, '.'));

            Console.WriteLine();
        }

        public void sortByAuthor()
        {

            ArrayList nowa = new ArrayList(books.OrderBy(x => x.author).ToList());

            foreach (Book option in nowa)

                Console.WriteLine("ID KSIĄŻKI: " + option.id + "\nTYTUŁ: " + option.title + "\nAUTOR: " + option.author + "\nROK WYDANIA: " + option.releaseYear + "\nSTATUS: " + option.orReads() + "\n" + ("").PadRight(100, '.'));

            Console.WriteLine();

        }
    }
}

