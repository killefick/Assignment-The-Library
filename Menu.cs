using System;
using System.Collections.Generic;

namespace Biblioteket
{
    class Menu
    {
        // method to show menu to user
        public void ShowMenu(Library L)
        {
            // list that holds several stringified books
            List<List<string>> bookList = new List<List<string>>();

            string userInput;
            string genre;
            string title;
            string author;
            int releaseYear;

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
                        Book.CreateBook(L, genre, title, author, releaseYear.ToString());
                        Console.WriteLine("Boken har lagts till i bibioteket.");
                        System.Threading.Thread.Sleep(1000);
                        break;

                    case "2":
                        while (true)
                        {
                            // list that holds book's 4 details
                            List<string> tempDetails = new List<string>();

                            // list that holds all four details combined in a list
                            List<List<string>> tempBook = new List<List<string>>();

                            // add current book details to tempDetails list
                            tempDetails.Add(GetGenre());
                            tempDetails.Add(GetTitle());
                            tempDetails.Add(GetAuthor());
                            tempDetails.Add(GetReleaseYear().ToString());

                            // add the list of 4 to another NEWLY CREATED list (making them en entity) 
                            tempBook.Add(tempDetails);

                            // save list entry in permanent list 
                            bookList.AddRange(tempBook);

                            // dump temp lists
                            tempDetails = null;
                            tempBook = null;

                            Console.Clear();
                            Console.Write("Vill du lägga till fler böcker? [J/N]: ");
                            userInput = Console.ReadLine().ToUpper();

                            // create books from details in list
                            if (userInput != "J")
                            {
                                L.AddBook(L, bookList);
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
                        PrintBookList(L);
                        break;

                    case "4":
                        Search(L);
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
        string GetGenre()
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

                string userInput = Console.ReadLine().ToUpper();

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
        string GetTitle()
        {
            Console.Clear();
            Console.WriteLine("Vänligen ange titel: ");
            string title = Console.ReadLine();
            return title;
        }

        // method to ask for author
        string GetAuthor()
        {
            Console.Clear();
            Console.WriteLine("Vänligen ange författare: ");
            string author = Console.ReadLine();
            return author;
        }

        // method to ask for release year
        int GetReleaseYear()
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
        void PrintBookList(Library L)
        {
            List<List<string>> tempBooksList = new List<List<string>>();
            Console.Clear();
            Console.WriteLine("Biblioteket innehåller: ");
            Console.WriteLine("-----------------------");
            
            // add all books to the list
            tempBooksList.Add(L.MakeListOfBooks());
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
        void Search(Library L)
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
                    matchingBooks.Add(L.SearchBooks(searchString.ToLower()));

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