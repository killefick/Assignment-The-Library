using System;

namespace Biblioteket
{
    class Menu
    {
        // method to show menu to users
        public static void ShowMenu()
        {
            int userInput = 0;

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

                // try to parse userInput to integer
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput != 1 || userInput != 2 || userInput != 3 || userInput != 4 || userInput != 5)
                    {
                        incorrectInput();
                    }
                }
                catch
                {
                    incorrectInput();
                }

                switch (userInput)
                {
                    case 1:
                        Library.AddBook();
                        break;

                    case 2:
                        Library.AddSeveralBooks();
                        break;

                    case 3:
                        Library.ShowAllBooks();
                        break;

                    case 4:
                        Library.Search();
                        break;

                    case 5:
                        return;
                }
            }
        }

        // method to tell user that input is incorrect
        static void incorrectInput()
        {
            Console.WriteLine("Vänligen ange en siffra mellan 1 och 5!");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
