using System.Collections.Generic;

namespace Biblioteket
{
    public class Library
    {
        // list to save books in library
        private List<Book> myLibrary = new List<Book>();
        private List<string> bookList = new List<string>();

        // adds some books to library
        public Library()
        {
            Novel myBook1 = new Novel("W", "Steve Sem-Sandberg", "2013");
            AddBook(myBook1);
            Magazine myBook2 = new Magazine("Vem dödade bambi?", "Monika Fagerholm", "1973");
            AddBook(myBook2);
            NovelCollection myBook3 = new NovelCollection("Köttets tid", "Lina Wolff", "1943");
            AddBook(myBook3);
            Novel myBook4 = new Novel("Jag vill sätta världen i rörelse", "Anna-Karin Palm", "1961");
            AddBook(myBook4);
            Magazine myBook5 = new Magazine("Oktoberbarn", "Linda Boström Knausgård", "1955");
            AddBook(myBook5);
        }

        // method to add books to library via constructor
        public void AddBook(Book myBook)
        {
            myLibrary.Add(myBook);
        }

        // method to add one book to library
        public void AddBook(Library L, Book myBook)
        {
            myLibrary.Add(myBook);
        }

        // method to add several books to library
        public void AddBook(Library L, List<List<string>> bookList)
        {
            string genre = "";
            string title = "";
            string author = "";
            string releaseYear = "";

            foreach (var tempBookString in bookList)
            {
                genre = tempBookString[0];
                title = tempBookString[1];
                author = tempBookString[2];
                releaseYear = tempBookString[3];
                Book.CreateBook(L, genre, title, author, releaseYear);
            }
        }

        // method to put all books into a list of strings for output
        public List<string> MakeListOfBooks()
        {
            bookList.Clear();
            foreach (var book in myLibrary)
            {
                bookList.Add(book.ToString());
            }
            return bookList;
        }

        // method to search library for title, author or release year
        public List<string> SearchBooks(string searchString)
        {
            bookList.Clear();
            foreach (var book in myLibrary)
            {
                // if match, add to list
                if (book.ToString().ToLower().Contains(searchString))
                {
                    bookList.Add(book.ToString());
                }
            }
            // if there were no matches, add placeholder with message
            if (bookList.Count == 0)
            {
                NoBook noBook = new NoBook();
                bookList.Add(noBook.ToString());
            }
            return bookList;
        }
    }
}