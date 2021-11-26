using BooksList.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksList.Forms
{
    public partial class FormGenre : Form
    {
        public Genre EditedGenre;

        public FormGenre()
        {
            InitializeComponent();

            EditedGenre = new Genre();
        }

        public FormGenre(Genre genre)
        {
            InitializeComponent();

            EditedGenre = genre;

            tbName.Text = genre.Name;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            EditedGenre.Name = tbName.Text;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
