namespace Biblioteket
{
    class Program
    {
        static void Main(string[] args)
        {
            // add some books to library
            Novel myBook1 = new Novel("W", "Steve Sem-Sandberg", "2013");
            Library.AddBook(myBook1);
            Magazine myBook2 = new Magazine("Vem dödade bambi?", "Monika Fagerholm", "1973");
            Library.AddBook(myBook2);
            NovelCollection myBook3 = new NovelCollection("Köttets tid", "Lina Wolff", "1943");
            Library.AddBook(myBook3);
            Novel myBook4 = new Novel("Jag vill sätta världen i rörelse", "Anna-Karin Palm", "1961");
            Library.AddBook(myBook4);
            Magazine myBook5 = new Magazine("Oktoberbarn", "Linda Boström Knausgård", "1955");
            Library.AddBook(myBook5);

            // show user interface
            Menu.ShowMenu();
        }
    }
}