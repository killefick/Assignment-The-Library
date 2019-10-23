namespace Biblioteket
{
    // superclass, not instatiable
    public abstract class Book
    {
        // protected variables
        protected string title;
        protected string author;
        protected string releaseYear;

        // constructor initialising varibles
        public Book(string title, string author, string releaseYear)
        {
            this.title = title;
            this.author = author;
            this.releaseYear = releaseYear;
        }

        // method to create a book
        public static void CreateBook(Library L, string genre, string title, string author, string releaseYear)
        {
            switch (genre)
            {
                case "Roman":
                    Novel myNovel = new Novel(title, author, releaseYear);
                    L.AddBook(myNovel);
                    break;

                case "Tidskrift":
                    Magazine myMagazine = new Magazine(title, author, releaseYear);
                    L.AddBook(myMagazine);
                    break;

                case "Novellsamling":
                    NovelCollection myNovelCollection = new NovelCollection(title, author, releaseYear);
                    L.AddBook(myNovelCollection);
                    break;
            }
        }
    }

    // subclasses
    class Novel : Book
    {
        public Novel(string title, string author, string releaseYear) : base(title, author, releaseYear)
        {
        }
        public override string ToString()
        {
            string result = '"' + title + '"' + " skriven av " + author + ", utgiven " + releaseYear + " (Roman).";
            return result;
        }
    }
    class Magazine : Book
    {
        public Magazine(string title, string author, string releaseYear) : base(title, author, releaseYear)
        {
        }
        public override string ToString()
        {
            string result = '"' + title + '"' + " skriven av " + author + ", utgiven " + releaseYear + " (Tidskrift).";
            return result;
        }
    }
    class NovelCollection : Book
    {
        public NovelCollection(string title, string author, string releaseYear) : base(title, author, releaseYear)
        {
        }
        public override string ToString()
        {
            string result = '"' + title + '"' + " skriven av " + author + ", utgiven " + releaseYear + " (Novellsamling).";
            return result;
        }
    }

    // used if a search gets no results
    class NoBook
    {
        public override string ToString()
        {
            string result = "Söktermen matchade inte med någon av böckerna...";
            return result;
        }
    }
}