using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksList.Classes
{
    public class Bundle 
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        
        public override string ToString()
        {
            return Name;
        }

        public static int CompareByName(Bundle a, Bundle b)
        {
            return string.Compare(a.Name, b.Name);
        }

        public class BundleBook
        {
            private Book _book;
            public Book Book
            {
                get { return _book; }
                set { _book = value; }
            }
            
            private int _number;
            public int Number
            {
                get { return _number; }
                set { _number = value; }
            }

            public string Name { get { return Book != null ? Book.Name : ""; } }

            public bool Have { get { return Book != null ? Book.Have : false; } }

            public string Author { get { return Book != null ? Book.Author : ""; } }

            public string Status { get { return Book != null ? Book.BookStatusToString(Book.Status) : ""; } }

            public DateTime? Date { get
                {
                    if (Book != null)
                        return Book.Date;
                    else
                        return null;
                }
            }

            public static int CompareByNumber(BundleBook a, BundleBook b)
            {
                if (a.Number == b.Number)
                    return string.Compare(a.Name, b.Name);
                else
                    return a.Number - b.Number;
            }
        }
    }
}