using System;
using System.Collections.Generic;

namespace Biblioteket
{
    class Menu
    {
        static string userInput;
        static string genre;

        // list that holds stringified books
        static List<List<string>> bookListOfLists = new List<List<string>>();
        static List<string> bookList = new List<string>();

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

                                foreach (var item in bookList)
                                {
                                    // hur får man grejorna ur listan till att skapa en bok objekt?
                                }
                                Console.WriteLine("Böckerna har lagts till i bibioteket.");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                        }
                        break;

                    case "3":
                        ShowBooks();
                        break;

                    case "4":
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
            Book.CreateBook(genre, title, author, releaseYear);
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
                bookList.Add(genre);
                bookList.Add(title);
                bookList.Add(author);
                bookList.Add(releaseYear.ToString());
            //  Book.CreateBook(genre, title, author, releaseYear);
            // Console.WriteLine("Boken har lagts till i bibioteket.");
        }

        // method to print all books in library to screen
        static void ShowBooks()
        {
            Console.Clear();
            Console.WriteLine("Biblioteket innehåller: ");
            Console.WriteLine("-----------------------");
            // add all books to the list
            bookListOfLists.Add(Library.GetBooks());
            foreach (var bookString in bookListOfLists)
            {
                foreach (var book in bookString)
                {
                    Console.WriteLine(book);
                }
            }
            bookListOfLists.Clear();
            Console.ReadKey();
        }


    }
}