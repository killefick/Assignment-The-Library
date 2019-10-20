using System;

namespace Biblioteket
{
    class Menu
    {
        static string userInput;

        // method to show menu to user
        public static void ShowMenu()
        {
            string genre;
            while (true)
            {
                // print menu
                Console.Clear();
                Console.WriteLine("Välkommen till biblioteket!");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("[1] Lägg till en bok i biblioteket");
                Console.WriteLine("[2] Lägg till flera böcker i biblioteket");
                Console.WriteLine("[3] Skriv ut alla böcker som finns i biblioteket");
                Console.WriteLine("[4] Leta efter en bok i biblioteket");
                Console.WriteLine("[X] Avsluta programmet");
                Console.WriteLine("------------------------------------------------");
                Console.Write("Ditt val: ");

                userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        genre = GetGenre();
                        GetDetails(genre);
                        break;

                    case "2":
                        break;

                    case "3":
                        break;

                    case "4":
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

        static string GetGenre()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vänligen ange bokens genre!");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("[1] Roman");
                Console.WriteLine("[2] Tidskrift");
                Console.WriteLine("[3] Poesi");
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
                        return "Poesi";

                    case "X":
                        break;

                    default:
                        Console.WriteLine("Vänligen ange en siffra mellan 1 och 3!");
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            }
        }

        static void GetDetails(string genre)
        {
            int releaseYear;
            Console.Clear();
            Console.WriteLine("Vänligen ange bokens titel: ");
            string title = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Vänligen ange bokens författare: ");
            string author = Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vänligen ange bokens utgivningsår: ");
                string tempInt = Console.ReadLine();

                // check if input can be a year
                try
                {
                    releaseYear = Convert.ToInt32(tempInt);
                    if (releaseYear > 1454 && releaseYear <= DateTime.Now.Year)
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Vänligen ange ett giltigt årtal!");
                    System.Threading.Thread.Sleep(1000);
                }
            }
            Book.CreateBook(genre, title, author, releaseYear);
        }


        // method to print all books from library to screen
        public static void ShowAllBooks()
        {

        }
    }
}