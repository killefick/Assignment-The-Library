using System;
using System.Collections.Generic;

namespace Biblioteket
{
    class Menu
    {
        static string userInput;


        // creates instance of Menu
        Menu M = new Menu();

        // static List<string> tempBooksString = new List<string>();
        //static List<List<string>> tempBooksList = new List<List<string>>();

        // method to show menu to user
        public static void ShowMenu()
        {
            // list that holds several stringified books
            List<List<string>> bookList = new List<List<string>>();


            string genre = "";
            string title = "";
            string author = "";
            int releaseYear = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till biblioteket!");
                Console.WriteLine("---------------------------");
                Console.WriteLine("[1] Lägg till en bok");
                Console.WriteLine("[2] Lägg till flera böcker");
                Console.WriteLine("[3] Skriv ut alla böcker");
                Console.WriteLine("[4] Leta efter en bok");
                Console.WriteLine("[X] Avsluta programmet");
                Console.WriteLine("---------------------------");
                Console.Write("Ditt val: ");
                userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        // get book details
                        genre = GetGenre();
                        title = GetTitle();
                        author = GetAuthor();
                        releaseYear = GetReleaseYear();

                        // create a book in library
                        Book.CreateBook(genre, title, author, releaseYear.ToString());
                        Console.WriteLine("Boken har lagts till i bibioteket.");
                        System.Threading.Thread.Sleep(1000);
                        break;

                    case "2":
                        while (true)
                        {
                            // list that holds books details
                            List<string> tempBooksString = new List<string>();
                            // list that holds all four details as a list
                            List<List<string>> tempBooksList = new List<List<string>>();

                            // get book details
                            genre = GetGenre();
                            title = GetTitle();
                            author = GetAuthor();
                            releaseYear = GetReleaseYear();

                            // add current book to temp list
                            tempBooksString.Add(genre);
                            tempBooksString.Add(title);
                            tempBooksString.Add(author);
                            tempBooksString.Add(releaseYear.ToString());

                            // add the list of 4 to another NEWLY CREATED list (making them en entity) 
                            tempBooksList.Add(tempBooksString);

                            // save list entry in other list 
                            bookList.AddRange(tempBooksList);

                            //dump temp lists
                            tempBooksString = null;
                            tempBooksList = null;

                            Console.Clear();
                            Console.Write("Vill du lägga till fler böcker? [J/N]: ");
                            userInput = Console.ReadLine().ToUpper();

                            // create books from details in list
                            if (userInput != "J")
                            {
                                Library.AddBook(bookList);
                                Console.WriteLine("Böckerna har lagts till i bibioteket.");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                            else
                            {
                                // continue loop
                            }
                        }
                        break;

                    case "3":
                        PrintBookList();
                        break;

                    case "4":
                        Search();
                        break;

                    case "X":
                        return;

                    default:
                        Console.WriteLine("Vänligen ange en siffra mellan 1 och 4!");
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            }
        }

        // method to ask for genre
        static string GetGenre()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vänligen ange genre!");
                Console.WriteLine("--------------------");
                Console.WriteLine("[1] Roman");
                Console.WriteLine("[2] Tidskrift");
                Console.WriteLine("[3] Novellsamling");
                Console.WriteLine("[X] Gå tillbaka");
                Console.WriteLine("--------------------");
                Console.Write("Ditt val: ");

                userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        return "Roman";

                    case "2":
                        return "Tidskrift";

                    case "3":
                        return "Novellsamling";

                    case "X":
                        break;

                    default:
                        Console.WriteLine("Vänligen ange en siffra mellan 1 och 3!");
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            }
        }

        // method to ask for title
        static string GetTitle()
        {
            Console.Clear();
            Console.WriteLine("Vänligen ange titel: ");
            string title = Console.ReadLine();
            return title;
        }

        // method to ask for author
        static string GetAuthor()
        {
            Console.Clear();
            Console.WriteLine("Vänligen ange författare: ");
            string author = Console.ReadLine();
            return author;
        }

        // method to ask for release year
        static int GetReleaseYear()
        {
            int releaseYear;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vänligen ange utgivningsår: ");
                string tempInt = Console.ReadLine();

                // check if input can be a year
                try
                {
                    releaseYear = Convert.ToInt32(tempInt);
                    if (releaseYear >= 1454 && releaseYear <= DateTime.Now.Year)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vänligen ange ett giltigt årtal!");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                catch
                {
                    Console.WriteLine("Vänligen ange ett giltigt årtal!");
                    System.Threading.Thread.Sleep(1000);
                }
            }
            return releaseYear;
        }

        // method to print all books in library to screen
        static void PrintBookList()
        {
            List<List<string>> tempBooksList = new List<List<string>>();
            Console.Clear();
            Console.WriteLine("Biblioteket innehåller: ");
            Console.WriteLine("-----------------------");
            // add all books to the list
            tempBooksList.Add(Library.MakeListOfBooks());
            foreach (var bookObject in tempBooksList)
            {
                foreach (var bookString in bookObject)
                {
                    Console.WriteLine(bookString);
                }
            }
            tempBooksList.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("-> Tryck valfri tangent <-");
            Console.ReadKey();
        }

        // method to search library for matches
        static void Search()
        {
            List<List<string>> matchingBooks = new List<List<string>>();

            while (true)
            {
                Console.Clear();
                Console.Write("Ange sökord: ");
                string searchString = Console.ReadLine();

                // ignore short strings
                if (searchString.Length > 3)
                {
                    // make the search case insensitive
                    // look for match in all books
                    // if match, get returning list of book details (4 strings per book entry)
                    // and add to matchingBooks
                    matchingBooks.Add(Library.SearchBooks(searchString.ToLower()));

                    // every list containing book details
                    foreach (var books in matchingBooks)
                    {
                        // every book
                        foreach (var book in books)
                        {
                            Console.WriteLine(book);
                        }
                    }
                    Console.WriteLine("-> Tryck valfri tangent <-");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Skriv minst 4 tecken som sökord!");
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }
    }
}