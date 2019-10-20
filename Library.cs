using System.Collections.Generic;

using System;

namespace Biblioteket
{
    class Library
    {
        // list to save books in library
        protected static List<Book> myLibrary = new List<Book>();

        // protected static string result = "";

        // method to add one book to library
        public static void AddBook(Book book)
        {
            myLibrary.Add(book);
            foreach (var item in myLibrary)
            {
                Console.WriteLine(item);
                Console.ReadKey();
            }
        }
        
        // method to add several books to library
        public static void AddSeveralBooks()
        {

        }

     

        // method to search library for title, author or release year
        public static void Search()
        {

        }


    }
}
