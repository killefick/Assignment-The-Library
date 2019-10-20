using System;

namespace Biblioteket
{
    class Menu
    {
        static string userInput;

        // method to show menu to users
        public static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                // print menu
                Console.WriteLine("Välkommen till biblioteket!");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("[1] Lägg till en bok i biblioteket");
                Console.WriteLine("[2] Lägg till flera böcker i biblioteket");
                Console.WriteLine("[3] Skriv ut alla böcker som finns i biblioteket");
                Console.WriteLine("[4] Leta efter en bok i biblioteket");
                Console.WriteLine("[5] Avsluta programmet");
                Console.WriteLine("------------------------------------------------");
                Console.Write("Ditt val: ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        GetBookDetails();
                        break;

                    case "2":
                        Library.AddSeveralBooks();
                        break;

                    case "3":
                        Library.ShowAllBooks();
                        break;

                    case "4":
                        Library.Search();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Vänligen ange en siffra mellan 1 och 5!");
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            }
        }

        static void GetBookDetails()
        {
            string genre;
            string title;
            string author;
            int releaseYear;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vänligen ange bokens genre!");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("[1] Roman");
                Console.WriteLine("[2] Tidskrift");
                Console.WriteLine("[3] Poesi");
                Console.WriteLine("[4] Gå tillbaka");
                Console.WriteLine("------------------------------------------------");
                Console.Write("Ditt val: ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        genre = "Roman";
                        title = GetTitle();
                        author = GetAuthor();
                        releaseYear = GetReleaseYear();
                        Book.CreateBook(genre, title, author, releaseYear);
                        return;

                    case "2":
                        genre = "Tidskrift";
              
                        return;

                    case "3":
                        genre = "Poesi";
            
                        return;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Vänligen ange en siffra mellan 1 och 4!");
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            }
        }
        static string GetTitle()
        {
            Console.Clear();
            Console.WriteLine("Vänligen ange bokens titel: ");
            string title = Console.ReadLine();
            return title;
        }
        static string GetAuthor()
        {
            Console.Clear();
            Console.WriteLine("Vänligen ange bokens författare: ");
            string author = Console.ReadLine();
            return author;
        }
        static int GetReleaseYear()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vänligen ange bokens utgivningsår: ");

                try
                {
                    int releaseYear = Convert.ToInt32(Console.ReadLine());
                    return releaseYear;
                }
                catch
                {
                    Console.WriteLine("Vänligen ange ett giltigt årtal!");
                }
            }
        }
        static void GiveFeedback()
        {

        }
    }
}