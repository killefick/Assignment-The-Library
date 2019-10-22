using System;
using System.Collections.Generic;

namespace Biblioteket
{
    class Menu
    {
        static string userInput;
        static string genre;
        static string title;
        static string author;
        static int releaseYear;

        // creates instance of Menu
        Menu M = new Menu();

        // list that holds books details
        static List<string> tempBooksString = new List<string>();
        // list that holds several stringified books
        static List<List<string>> tempBooksList = new List<List<string>>();

        // method to show menu to user
        public static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till biblioteket!");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("[1] Lägg till en bok");
                Console.WriteLine("[2] Lägg till flera böcker");
                Console.WriteLine("[3] Skriv ut alla böcker som finns");
                Console.WriteLine("[4] Leta efter en bok");
                Console.WriteLine("[X] Avsluta programmet");
                Console.WriteLine("------------------------------------------------");
                Console.Write("Ditt val: ");
                userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        // pick a genre
                        genre = GetGenre();
                        // read book details
                        GetBookDetails();
                        // create a book in library
                        Book.CreateBook(genre, title, author, releaseYear.ToString());

                        Console.WriteLine("Boken har lagts till i bibioteket.");
                        System.Threading.Thread.Sleep(1000);
                        break;

                    case "2":
                        while (true)
                        {
                            tempBooksString.Clear();
                            genre = GetGenre();
                            GetBookDetails();
                            // add current book to temp list
                            tempBooksString.Add(genre);
                            tempBooksString.Add(title);
                            tempBooksString.Add(author);
                            tempBooksString.Add(releaseYear.ToString());

                            // add the list of 4 to another list (making them en entity) 
                            tempBooksList.Add(tempBooksString);

                            Console.Clear();
                            Console.Write("Vill du lägga till fler böcker? [J/N]: ");
                            userInput = Console.ReadLine().ToUpper();

                            // create books from details in list
                            if (userInput != "J")
                            {
                                Library.AddManyBooks(tempBooksList);
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
                        Console.WriteLine("Ange en siffra mellan 1 och 4!");
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
                Console.WriteLine("Ange bokens genre!");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("[1] Roman");
                Console.WriteLine("[2] Tidskrift");
                Console.WriteLine("[3] Novellsamling");
                Console.WriteLine("[X] Gå tillbaka");
                Console.WriteLine("------------------------------------------------");
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
                        Console.WriteLine("Ange en siffra mellan 1 och 3!");
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            }
        }

        // method to create a book with all details
        static void CreateOneBook(string genre)
        {
            Console.Clear();
            Console.WriteLine("Ange bokens titel: ");
            title = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Ange bokens författare: ");
            author = Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ange bokens utgivningsår: ");
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
                        Console.WriteLine("Ange ett giltigt årtal!");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                catch
                {
                    Console.WriteLine("Ange ett giltigt årtal!");
                    System.Threading.Thread.Sleep(1000);
                }
            }
            Book.CreateBook(genre, title, author, releaseYear.ToString());
        }

        // method to get book's details
        static void GetBookDetails()
        {
            Console.Clear();
            Console.WriteLine("Ange bokens titel: ");
            title = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Ange bokens författare: ");
            author = Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ange bokens utgivningsår: ");
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
                        Console.WriteLine("Ange ett giltigt årtal!");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                catch
                {
                    Console.WriteLine("Ange ett giltigt årtal!");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        // method to print all books in library to screen
        static void PrintBookList()
        {
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
            Console.ReadKey();
        }

        // method to search library for matches
        static void Search()
        {
            tempBooksList.Clear();
            while (true)
            {
                Console.Clear();
                Console.Write("Ange sökord: ");
                string searchString = Console.ReadLine();

                // ignore short strings
                if (searchString.Length > 3)
                {
                    tempBooksList.Add(Library.SearchBooks(searchString.ToLower()));
                    foreach (var bookObject in tempBooksList)
                    {
                        foreach (var bookString in bookObject)
                        {
                            Console.WriteLine(bookString);
                        }
                    }
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