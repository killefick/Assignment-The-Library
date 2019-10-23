namespace Biblioteket
{
    class Program
    {
        static void Main(string[] args)
        {
            Library L = new Library();
            Menu M = new Menu();

            // add some books to library
            Novel myBook1 = new Novel("W", "Steve Sem-Sandberg", "2013");
            L.AddBook(L, myBook1);
            Magazine myBook2 = new Magazine("Vem dödade bambi?", "Monika Fagerholm", "1973");
            L.AddBook(L, myBook2);
            NovelCollection myBook3 = new NovelCollection("Köttets tid", "Lina Wolff", "1943");
            L.AddBook(L, myBook3);
            Novel myBook4 = new Novel("Jag vill sätta världen i rörelse", "Anna-Karin Palm", "1961");
            L.AddBook(L, myBook4);
            Magazine myBook5 = new Magazine("Oktoberbarn", "Linda Boström Knausgård", "1955");
            L.AddBook(L, myBook5);

            // show user interface
            M.ShowMenu(L);
        }
    }
}