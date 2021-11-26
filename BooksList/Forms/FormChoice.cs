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
    public partial class FormChoice : Form
    {
        public Bundle SelectedBundle;
        public Genre SelectedGenre;
        private Selection _selection;
        private BooksCollection _gamesCollection;

        public FormChoice(Selection selection)
        {
            InitializeComponent();

            _selection = selection;
            _gamesCollection = BooksCollection.GetInstance();

            if (selection == Selection.Bundle)
                Text += "набор";
            else if (selection == Selection.Genre)
                Text += "жанр";
            RefreshChoice();
        }
        
        private void RefreshChoice()
        {
            cbChoice.Items.Clear();
            if (_selection == Selection.Bundle)
                foreach (Bundle bundle in _gamesCollection.Bundles)
                    cbChoice.Items.Add(bundle);
            else if (_selection == Selection.Genre)
                foreach (Genre genre in _gamesCollection.Genres)
                    cbChoice.Items.Add(genre);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (_selection == Selection.Bundle)
            {
                FormBundle form = new FormBundle();
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                _gamesCollection.Add(form.EditedBundle);
                _gamesCollection.Save();
                RefreshChoice();
                cbChoice.SelectedItem = form.EditedBundle;
            }
            else if (_selection == Selection.Genre)
            {
                FormGenre form = new FormGenre();
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                _gamesCollection.Add(form.EditedGenre);
                _gamesCollection.Save();
                RefreshChoice();
                cbChoice.SelectedItem = form.EditedGenre;
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            switch (_selection)
            {
                case Selection.Bundle: SelectedBundle = (Bundle)cbChoice.SelectedItem; break;
                case Selection.Genre: SelectedGenre = (Genre)cbChoice.SelectedItem; break;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        public enum Selection
        {
            Bundle,
            Genre
        }
    }
}
