using System.Collections.Generic;

namespace Biblioteket
{
    class Library
    {
        // list to save books in library
        private static List<Book> myLibrary = new List<Book>();
        private static List<string> bookList = new List<string>();

        // method to add one book to library
        public static void AddBook(Book myBook)
        {
            myLibrary.Add(myBook);
        }

        // method to add several books to library
        public static void AddSeveralBooks(List<string> myBooks)
        {

        }

        // method to put all books into a list of strings for output
        public static List<string> MakeListOfBooks()
        {
            bookList.Clear();
            foreach (var book in myLibrary)
            {
                bookList.Add(book.ToString());
            }
            return bookList;
        }

        // method to search library for title, author or release year
        public static List<string> SearchBooks(string searchString)
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