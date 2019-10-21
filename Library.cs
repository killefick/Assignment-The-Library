using System.Collections.Generic;

namespace Biblioteket
{
    class Library
    {
        // list to save books in library
        private static List<Book> myLibrary = new List<Book>();

        // method to add one book to library
        public static void AddBook(Book myBook)
        {
            myLibrary.Add(myBook);
        }

        // method to add several books to library
        public static void AddSeveralBooks()
        {

        }

        // method to put all books into a list of strings
        public static List<string> GetBooks()
        {
            List<string> bookList = new List<string>();
            foreach (var book in myLibrary)
            {
                bookList.Add(book.ToString());
            }
            return bookList;
        }

        // method to search library for title, author or release year
        public static void Search()
        {

        }
    }
}