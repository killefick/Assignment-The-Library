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

        // list that holds stringified books
        static List<List<string>> bookListWithLists = new List<List<string>>();
        static List<string> bookListWithStrings = new List<string>();

        // method to show menu to user
        public static void ShowMenu()
        {
            while (true)
            {
                // print menu
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
                        genre = GetGenre();
                        CreateOneBook(genre);
                        

                        Console.WriteLine("Boken har lagts till i bibioteket.");
                        System.Threading.Thread.Sleep(1000);
                        break;

                    case "2":
                        while (true)
                        {
                            genre = GetGenre();
                            CreateManyBooks(genre);

                            Console.Write("Vill du lägga till en bok? [J/N]: ");
                            userInput = Console.ReadLine().ToUpper();
                            if (userInput == "J")
                            {
                            }
                            else
                            {
                                foreach (string bookString in bookListWithStrings)
                                {
                                    // genre = bookString;
                                    // title = bookString[1];
                                    // author = bookString[2];
                                    // releaseYear = Convert.ToInt32(bookString[3]);
                                    // Book.CreateBook(genre, title, author, releaseYear);
                                }
                                bookListWithStrings.Clear();
                                Console.WriteLine("Böckerna har lagts till i bibioteket.");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                        }
                        break;

                    case "3":
                        GetBookListFromLibrary();
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
            int releaseYear;
            Console.Clear();
            Console.WriteLine("Ange bokens titel: ");
            string title = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Ange bokens författare: ");
            string author = Console.ReadLine();

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

        // method to create list of books
        static void CreateManyBooks(string genre)
        {
            int releaseYear;
            Console.Clear();
            Console.WriteLine("Ange bokens titel: ");
            string title = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Ange bokens författare: ");
            string author = Console.ReadLine();

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
            bookListWithStrings.Add(genre);
            bookListWithStrings.Add(title);
            bookListWithStrings.Add(author);
            bookListWithStrings.Add(releaseYear.ToString());
            //  Book.CreateBook(genre, title, author, releaseYear);
            // Console.WriteLine("Boken har lagts till i bibioteket.");
        }

        // method to print all books in library to screen
        static void GetBookListFromLibrary()
        {
            Console.Clear();
            Console.WriteLine("Biblioteket innehåller: ");
            Console.WriteLine("-----------------------");
            // add all books to the list
            bookListWithLists.Add(Library.MakeListOfBooks());
            foreach (var bookObject in bookListWithLists)
            {
                foreach (var bookString in bookObject)
                {
                    Console.WriteLine(bookString);
                }
            }
            bookListWithLists.Clear();
            Console.ReadKey();
        }

        static void Search()
        {
            bookListWithLists.Clear();
            while (true)
            {
                Console.Clear();
                Console.Write("Ange sökord: ");
                string searchString = Console.ReadLine();

                // ignore short strings
                if (searchString.Length > 3)
                {
                    bookListWithLists.Add(Library.SearchBooks(searchString.ToLower()));
                    foreach (var bookObject in bookListWithLists)
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