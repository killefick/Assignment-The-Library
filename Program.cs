namespace Biblioteket
{
    class Program
    {
        static void Main(string[] args)
        {
            // adds some initial books to library
            Novel myBook1 = new Novel("Pippi Långstrump", "Astrid Lindgren", 1945);
            Library.AddBook(myBook1);
            Novel myBook2 = new Novel("Bröderna Lejonhjärta", "Astrid Lindgren", 1973);
            Library.AddBook(myBook2);
            Novel myBook3 = new Novel("Alla vi barn i Bullerbyn", "Astrid Lindgren", 1943);
            Library.AddBook(myBook3);
            Novel myBook4 = new Novel("Lotta på Bråkmakargatan", "Astrid Lindgren", 1961);
            Library.AddBook(myBook4);
            Novel myBook5 = new Novel("Lillebror och Karlsson på taket", "Astrid Lindgren", 1955);
            Library.AddBook(myBook5);

            // show user interface
            Menu.ShowMenu();
        }
    }
}