namespace Biblioteket
{
    public abstract class Book
    {
        // protected variables
        protected string genre;
        protected string title;
        protected string author;
        protected int releaseYear;

        // accessable properties
        public static string Title { get; set; }
        public static string Author { get; set; }
        public static int ReleaseYear { get; set; }

        public Book(string title, string author, int releaseYear)
        {
            this.title = title;
            this.author = author;
            this.releaseYear = releaseYear;
        }
        public static void CreateBook(string genre, string title, string author, int releaseYear)
        {
            switch (genre)
            {
                case "Roman":
                    Novel myNovel = new Novel(title, author, releaseYear);
                    myNovel.title = title;
                    myNovel.author = author;
                    myNovel.releaseYear = releaseYear;
                    Library.AddBook(myNovel);
                    break;

                case "Tidskrift":
                    Magazine myMagazine = new Magazine();
                    myMagazine.title = title;
                    myMagazine.author = author;
                    myMagazine.releaseYear = releaseYear;
                    break;

                case "Peosi":
                    Poetry myPoetry = new Poetry();
                    myPoetry.title = title;
                    myPoetry.author = author;
                    myPoetry.releaseYear = releaseYear;
                    break;
            }
        }

    }



    class Novel : Book
    {
        public Novel(string title, string author, int releaseYear)
        {
            this.title = title;
            this.author = author;
            this.releaseYear = releaseYear;
        }
        public override string ToString()
        {
            string result = "Skönlitteratur: " + title + " " + author + " " + releaseYear;
            return result;
        }
    }
    class Magazine : Book
    {
        public override string ToString()
        {
            string result = "Tidskrift: " + title + " " + author + " " + releaseYear;
            return result;
        }
    }
    class Poetry : Book
    {
        public override string ToString()
        {
            string result = "Poesi: " + title + " " + author + " " + releaseYear;
            return result;
        }
    }


}