using System.Collections.Generic;

namespace Biblioteket
{
    class Library
    {
        // list to save books in library
        static List<Book> myLibrary = new List<Book>();

        protected static string result = "";

        // method to add one book to library
        public static void AddBook(Book book)
        {
            myLibrary.Add(book);
        }
        
        // method to add several books to library
        public static void AddSeveralBooks()
        {

        }

        // method to print all books from library to screen
        public static void ShowAllBooks()
        {

        }

        // method to search library for title, author or release year
        public static void Search()
        {

        }


    }
}
