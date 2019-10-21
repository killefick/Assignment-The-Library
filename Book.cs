namespace Biblioteket
{
    // superclass
    public abstract class Book
    {
        // protected variables
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

                case "Novellsamling":
                    NovelCollection myNovelCollection = new NovelCollection(title, author, releaseYear);
                    Library.AddBook(myNovelCollection);
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
            string result = title + " skriven av " + author + ", utgiven " + releaseYear + " (Roman).";
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
            string result = title + " skriven av " + author + ", utgiven " + releaseYear + " (Tidskrift).";
            return result;
        }
    }
    class NovelCollection : Book
    {
        public NovelCollection(string title, string author, int releaseYear) : base(title, author, releaseYear)
        {
        }
        public override string ToString()
        {
            string result = title + " skriven av " + author + ", utgiven " + releaseYear + " (Novellsamling).";
            return result;
        }
    }
}