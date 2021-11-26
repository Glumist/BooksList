using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksList.Classes
{
    public class Genre 
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

        public override string ToString()
        {
            return Name;
        }

        public static int CompareByName(Genre a, Genre b)
        {
            return string.Compare(a.Name, b.Name);
        }
    }
}
