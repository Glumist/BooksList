using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BooksList.Classes
{
    public class Book
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _author;
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        private List<Genre> _genres;
        [XmlIgnore]
        public List<Genre> Genres
        {
            get { return _genres; }
            set { _genres = value; }
        }

        private List<int> _genresIds;
        public List<int> GenresIds
        {
            get
            {
                if (Genres != null && Genres.Count > 0)
                {
                    List<int> ids = new List<int>();
                    foreach (Genre genre in Genres)
                        ids.Add(genre.Id);
                    return ids;
                }
                return _genresIds;
            }
            set { _genresIds = value; }
        }

        private List<BookBundle> _bundles;
        public List<BookBundle> Bundles
        {
            get { return _bundles; }
            set { _bundles = value; }
        }

        public Book()
        {
            Genres = new List<Genre>();
            GenresIds = new List<int>();
            Bundles = new List<BookBundle>();
            Status = BookStatus.NotStarted;
            Have = false;
            Date = new DateTime(DateTime.Today.Year, 12, 31, 0, 0, 0);
        }

        public override string ToString()
        {
            return Name;
        }

        /*private BookStatus _defaultStatus;
        public BookStatus DefaultStatus
        {
            get { return _defaultStatus; }
            set { _defaultStatus = value; }
        }*/

        public bool Started
        {
            get
            {
                return Status == Book.BookStatus.Reading ||
                       Status == Book.BookStatus.OnHold;
            }
        }

        public Color Color
        {
            get
            {
                return ColorByStatus(Status);
            }
        }

        private bool _have = true;
        public bool Have
        {
            get { return _have; }
            set { _have = value; }
        }

        public class BookBundle
        {
            private Bundle _bundle;
            [XmlIgnore]
            public Bundle Bundle
            {
                get { return _bundle; }
                set { _bundle = value; }
            }

            private int _bundleId;
            public int BundleId
            {
                get
                {
                    if (Bundle != null)
                        return Bundle.Id;
                    return _bundleId;
                }
                set { _bundleId = value; }
            }

            private int _number;
            public int Number
            {
                get { return _number; }
                set { _number = value; }
            }
        }

        public enum BookStatus
        {
            NotStarted,
            Reading,
            OnHold,
            Dropped,
            Skipped,
            WaitTranslation,
            Completed,
            Listened,
            NotYetReleased,
            Unknown
        }

        private BookStatus _status = BookStatus.Unknown;
        [XmlIgnore]
        public BookStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string BookStatusString
        {
            get { return BookStatusToString(Status); }
            set { Status = StringToBookStatus(value); }
        }


        public static string BookStatusToString(BookStatus status)
        {
            switch (status)
            {
                case BookStatus.NotStarted: return "Not Started";
                case BookStatus.Reading: return "Reading";
                case BookStatus.OnHold: return "On Hold";
                case BookStatus.Dropped: return "Dropped";
                case BookStatus.Skipped: return "Skipped";
                case BookStatus.Completed: return "Completed";
                case BookStatus.WaitTranslation: return "Wait Translation";
                case BookStatus.Listened: return "Listened";
                default: return "Unknown";
            }
        }

        public static BookStatus StringToBookStatus(string status)
        {
            switch (status)
            {
                case "Not Started": return BookStatus.NotStarted;
                case "Reading": return BookStatus.Reading;
                case "On Hold": return BookStatus.OnHold;
                case "Dropped": return BookStatus.Dropped;
                case "Skipped": return BookStatus.Skipped;
                case "Completed": return BookStatus.Completed;
                case "Wait Translation": return BookStatus.WaitTranslation;
                case "Listened": return BookStatus.Listened;
                default: return BookStatus.Unknown;
            }
        }
        
        public static Color ColorByStatus(BookStatus status)
        {
            switch (status)
            {
                case BookStatus.NotStarted: return Color.PaleGreen;
                case BookStatus.Reading: return Color.LimeGreen;
                case BookStatus.OnHold: return Color.Gold;
                case BookStatus.Dropped: return Color.Crimson;
                case BookStatus.Skipped: return Color.Silver;
                case BookStatus.WaitTranslation: return Color.LightGoldenrodYellow;
                case BookStatus.Completed: return Color.MediumOrchid;
                case BookStatus.Listened: return Color.SkyBlue;
                case BookStatus.NotYetReleased: return Color.LightPink;
                case BookStatus.Unknown:
                default:
                    return Color.White;
            }
        }

        public static int CompareByDate(Book a, Book b)
        {
            if (a.Date == b.Date)
                return string.Compare(a.Name, b.Name);
            return DateTime.Compare(a.Date, b.Date);
        }

        public static int CompareByName(Book a, Book b)
        {
            return string.Compare(a.Name, b.Name);
        }
        
        public static int CompareByAuthor(Book a, Book b)
        {
            if (a.Author == b.Author)
                return string.Compare(a.Name, b.Name);
            return string.Compare(a.Author, b.Author);
        }
    }

    public class BooksCollection
    {
        private static string fileName = "BooksList.xml";
        private static BooksCollection _booksCollection;

        private List<Genre> _genres;
        public List<Genre> Genres
        {
            get { return _genres; }
            set { _genres = value; }
        }

        private List<Bundle> _bundles;
        public List<Bundle> Bundles
        {
            get { return _bundles; }
            set { _bundles = value; }
        }

        private List<Book> _books;
        public List<Book> Books
        {
            get { return _books; }
            set { _books = value; }
        }

        private BooksCollection()
        {
            Genres = new List<Genre>();
            Bundles = new List<Bundle>();
            Books = new List<Book>();
        }

        public static BooksCollection GetInstance()
        {
            if (_booksCollection == null)
                _booksCollection = Load();
            return _booksCollection;
        }

        public bool Save()
        {
            try
            {
                XmlHelper.SerializeAndSave(fileName, this);
                return Check();
            }
            catch
            {
                return false;
            }
        }

        private bool Check()
        {
            try
            {
                BooksCollection toCheck = fileName.LoadAndDeserialize<BooksCollection>();
                if (toCheck.Books.Count != Books.Count)
                    return false;
                if (toCheck.Bundles.Count != Bundles.Count)
                    return false;
                if (toCheck.Genres.Count != Genres.Count)
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static BooksCollection Load()
        {
            BooksCollection result;
            try
            {
                result = fileName.LoadAndDeserialize<BooksCollection>();
            }
            catch
            {
                return new BooksCollection();
            }

            SetBooksGenres(result.Books, result.Genres);
            SetBooksBundles(result.Books, result.Bundles);

            result.Books.Sort(Book.CompareByDate);
            result.Bundles.Sort(Bundle.CompareByName);
            result.Genres.Sort(Genre.CompareByName);

            return result;
        }

        private static void SetBooksGenres(List<Book> books, List<Genre> genres)
        {
            foreach (Book book in books)
                foreach (int bookGenreId in book.GenresIds)
                    foreach (Genre genre in genres)
                        if (genre.Id == bookGenreId)
                        {
                            book.Genres.Add(genre);
                            break;
                        }
        }

        private static void SetBooksBundles(List<Book> books, List<Bundle> bundles)
        {
            foreach (Book book in books)
                foreach (Book.BookBundle bookBundle in book.Bundles)
                    foreach (Bundle bundle in bundles)
                        if (bundle.Id == bookBundle.BundleId)
                        {
                            bookBundle.Bundle = bundle;
                            break;
                        }
        }

        private int GetNextBundleNumber(Bundle bundle)
        {
            int num = -1;
            foreach (Book book in Books)
                foreach (Book.BookBundle bookBundle in book.Bundles)
                    if (bookBundle.Bundle == bundle)
                    {
                        if (bookBundle.Number > num)
                            num = bookBundle.Number;
                        break;
                    }

            return num + 1;
        }

        public static int GetLastBundleBookYear(Bundle bundle)
        {
            int num = -1;
            int year = DateTime.Today.Year;
            foreach (Bundle.BundleBook book in GetInstance().GetBundleBooks(bundle))
                if (book.Number > num)
                {
                    num = book.Number;
                    if (book.Date.HasValue)
                        year = book.Date.Value.Year;
                }
            return year;
        }

        public Book.BookBundle GetBookBundle(Bundle bundle)
        {
            return new Book.BookBundle()
            {
                Bundle = bundle,
                Number = GetNextBundleNumber(bundle)
            };
        }

        public List<Book> GetNextBooksInBundle(Bundle bundle, bool haveCheck)
        {
            List<Bundle.BundleBook> bundleBooks = GetBundleBooks(bundle);
            List<Book> result = new List<Book>();
            foreach (Bundle.BundleBook bundleBook in bundleBooks)
                if (bundleBook.Book.Status != Book.BookStatus.Completed &&
                    bundleBook.Book.Status != Book.BookStatus.Dropped &&
                    bundleBook.Book.Status != Book.BookStatus.Skipped &&
                    bundleBook.Book.Status != Book.BookStatus.Listened &&
                    bundleBook.Book.Status != Book.BookStatus.WaitTranslation)
                    if (!haveCheck || bundleBook.Book.Have)
                    {
                        result.Add(bundleBook.Book);
                        break;
                    }
            return result;
        }

        public bool IsBookNext(Book book, bool haveCheck)
        {
            foreach (Book.BookBundle bundle in book.Bundles)
                if (!GetNextBooksInBundle(bundle.Bundle, haveCheck).Contains(book))
                    return false;
            return true;
        }

        public List<Bundle.BundleBook> GetBundleBooks(Bundle bundle)
        {
            List<Book> booksOfBundle = Books.FindAll(g => g.Bundles.Exists(b => b.Bundle == bundle));
            List<Bundle.BundleBook> bundleBooks = new List<Bundle.BundleBook>();
            foreach (Book g in booksOfBundle)
                bundleBooks.Add(new Bundle.BundleBook()
                {
                    Book = g,
                    Number = g.Bundles.Find(b => b.Bundle == bundle).Number
                });
            bundleBooks.Sort(Bundle.BundleBook.CompareByNumber);

            return bundleBooks;
        }

        public void Add(Bundle bundle)
        {
            int lastId = -1;
            foreach (Bundle b in Bundles)
                if (b.Id > lastId)
                    lastId = b.Id;

            bundle.Id = lastId + 1;

            Bundles.Add(bundle);
            Bundles.Sort(Bundle.CompareByName);
        }

        public void Add(Genre genre)
        {
            int lastId = -1;
            foreach (Genre g in Genres)
                if (g.Id > lastId)
                    lastId = g.Id;

            genre.Id = lastId + 1;

            Genres.Add(genre);
            Genres.Sort(Genre.CompareByName);
        }

        public void Add(Book book)
        {
            Books.Add(book);
            Books.Sort(Book.CompareByDate);
        }

        public void Remove(Book book)
        {
            foreach (Book.BookBundle bundle in book.Bundles)
                foreach (Book bundleBook in Books)
                {
                    Book.BookBundle foundBundle = bundleBook.Bundles.Find(b => b.Bundle == bundle.Bundle);
                    if (foundBundle == null)
                        continue;
                    if (foundBundle.Number > bundle.Number)
                        foundBundle.Number--;
                }
            Books.Remove(book);
        }
    }
}