namespace Biblioteket
{
    // superclass
    public abstract class Book
    {
        // protected variables
        // protected string genre;
        protected string title;
        protected string author;
        protected int releaseYear;

        // accessable properties
        public static string Title { get; set; }
        public static string Author { get; set; }
        public static int ReleaseYear { get; set; }

        // constructor initialising varibles
        public Book(string title, string author, int releaseYear)
        {
            this.title = title;
            this.author = author;
            this.releaseYear = releaseYear;
        }

        // method to create a book
        public static void CreateBook(string genre, string title, string author, int releaseYear)
        {
            switch (genre)
            {
                case "Roman":
                    Novel myNovel = new Novel(title, author, releaseYear);
                    Library.AddBook(myNovel);
                    break;

                case "Tidskrift":
                    Magazine myMagazine = new Magazine(title, author, releaseYear);
                    Library.AddBook(myMagazine);
                    break;

                case "Peosi":
                    Poetry myPoetry = new Poetry(title, author, releaseYear);
                    Library.AddBook(myPoetry);
                    break;
            }
        }
    }

    // subclasses
    class Novel : Book
    {
        public Novel(string title, string author, int releaseYear) : base(title, author, releaseYear)
        {
        }
        public override string ToString()
        {
            string result = "Roman: " + title + " " + author + " " + releaseYear;
            return result;
        }
    }
    class Magazine : Book
    {
        public Magazine(string title, string author, int releaseYear) : base(title, author, releaseYear)
        {
        }
        public override string ToString()
        {
            string result = "Tidskrift: " + title + " " + author + " " + releaseYear;
            return result;
        }
    }
    class Poetry : Book
    {
        public Poetry(string title, string author, int releaseYear) : base(title, author, releaseYear)
        {
        }
        public override string ToString()
        {
            string result = "Poesi: " + title + " " + author + " " + releaseYear;
            return result;
        }
    }
}