using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary
{
    class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int releaseYear { get; set; }
        public Boolean read { get; set; }

        static int nextId = 1;

        public Book(string title, string author, int releaseYear, Boolean read = false)
        {

            if (checkIsNotNull(title, author, releaseYear))
            {
                id = nextId++;
                this.title = title;
                this.author = author;
                this.releaseYear = releaseYear;
                this.read = read;
            }
            else { Console.WriteLine("Musisz podac wszystkie wymagane dane!"); }


        }

        Boolean checkIsNotNull(string title, string author, int releaseYear)
        {
            if (title.Count() > 0 && author.Count() > 0 && releaseYear != 0) return true;
            else return false;
        }

        public String orReads()
        {
            if (read) return "przeczytana";
            else return "nieprzeczytana";
        }




    }


}
