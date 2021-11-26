using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BooksList.Classes;
using System.Runtime.CompilerServices;

namespace BooksList.Forms
{
    public partial class UserControlBook : UserControl
    {
        public Book EditedBook;
        private bool changed = false;

        private List<Book.BookBundle> bundles;
        private List<Genre> genres;

        public UserControlBook()
        {
            InitializeComponent();

            dgvBundles.AutoGenerateColumns = false;
            dgvGenres.AutoGenerateColumns = false;

            cbStatus.Items.Clear();
            cbStatus.Items.Add("Не начата");
            cbStatus.Items.Add("В процессе");
            cbStatus.Items.Add("В ожидании");
            cbStatus.Items.Add("Отвергнута");
            cbStatus.Items.Add("Пропущена");
            cbStatus.Items.Add("Завершена");
            cbStatus.Items.Add("Ожидает перевода");
            cbStatus.Items.Add("Прослушана");
            cbStatus.Items.Add("Неизвестно");
            cbStatus.SelectedIndex = 0;

            ClearBook();
        }

        public void SetBook(Book book)
        {
            if (changed)
            {
                DialogResult dialogResult = MessageBox.Show("Имеются несохраненные данные. Сохранить?", "Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                    Save();
                else if (dialogResult == DialogResult.Cancel)
                    return;
            }

            bundles = new List<Book.BookBundle>(book.Bundles);
            genres = new List<Genre>(book.Genres);

            EditedBook = book;

            tbName.Text = book.Name;
            tbAuthor.Text = book.Author;
            tbComment.Text = book.Comment;
            dtpDate.Value = book.Date;
            chbHave.Checked = book.Have;

            switch (book.Status)
            {
                case Book.BookStatus.NotStarted: cbStatus.SelectedIndex = 0; break;
                case Book.BookStatus.Reading: cbStatus.SelectedIndex = 1; break;
                case Book.BookStatus.OnHold: cbStatus.SelectedIndex = 2; break;
                case Book.BookStatus.Dropped: cbStatus.SelectedIndex = 3; break;
                case Book.BookStatus.Skipped: cbStatus.SelectedIndex = 4; break;
                case Book.BookStatus.Completed: cbStatus.SelectedIndex = 5; break;
                case Book.BookStatus.WaitTranslation: cbStatus.SelectedIndex = 6; break;
                case Book.BookStatus.Listened: cbStatus.SelectedIndex = 7; break;
                default: cbStatus.SelectedIndex = 8; break;
            }
            dgvBundles.DataSource = new List<Book.BookBundle>(bundles);
            dgvGenres.DataSource = new List<Genre>(genres);

            changed = false;
        }

        public void ClearBook()
        {
            changed = false;
            SetBook(new Book());
        }

        private void fieldValue_Changed(object sender, EventArgs e)
        {
            changed = true;
        }

        #region Menu Buttons

        private void tsmiBundleAdd_Click(object sender, EventArgs e)
        {
            FormChoice form = new FormChoice(FormChoice.Selection.Bundle);
            if (form.ShowDialog() != DialogResult.OK)
                return;

            BooksCollection gamesCollection = BooksCollection.GetInstance();
            bundles.Add(gamesCollection.GetBookBundle(form.SelectedBundle));
            dgvBundles.DataSource = new List<Book.BookBundle>(bundles);

            fieldValue_Changed(sender, e);
        }

        private void tsmiBundleDelete_Click(object sender, EventArgs e)
        {
            Book.BookBundle selectedBundle = GetSelectedBundle();
            if (selectedBundle == null)
                return;

            bundles.Remove(selectedBundle);
            dgvBundles.DataSource = new List<Book.BookBundle>(bundles);

            fieldValue_Changed(sender, e);
        }

        private void tsmiGenreAdd_Click(object sender, EventArgs e)
        {
            FormChoice form = new FormChoice(FormChoice.Selection.Genre);
            if (form.ShowDialog() != DialogResult.OK)
                return;

            genres.Add(form.SelectedGenre);
            dgvGenres.DataSource = new List<Genre>(genres);

            fieldValue_Changed(sender, e);
        }

        private void tsmiGenreDelete_Click(object sender, EventArgs e)
        {
            Genre selectedGenre = GetSelectedGenre();
            if (selectedGenre == null)
                return;

            genres.Remove(selectedGenre);
            dgvGenres.DataSource = new List<Genre>(genres);

            fieldValue_Changed(sender, e);
        }

        #endregion

        #region Tables

        private void dgvBundles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Book.BookBundle selectedBundle = GetSelectedBundle();
            if (selectedBundle == null)
                return;

            OnBundleSelected(selectedBundle.Bundle);
        }

        private void dgvGenres_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Genre selectedGenre = GetSelectedGenre();
            if (selectedGenre == null)
                return;

            OnGenreSelected(selectedGenre);
        }

        private Book.BookBundle GetSelectedBundle()
        {
            if (dgvBundles.SelectedRows.Count == 0 || dgvBundles.SelectedRows[0].Index == -1)
                return null;

            return dgvBundles.SelectedRows[0].DataBoundItem as Book.BookBundle;
        }

        private Genre GetSelectedGenre()
        {
            if (dgvGenres.SelectedRows.Count == 0 || dgvGenres.SelectedRows[0].Index == -1)
                return null;

            return dgvGenres.SelectedRows[0].DataBoundItem as Genre;
        }

        #endregion

        #region Platform

        private Book.BookStatus GetSelectedStatus()
        {
            switch (cbStatus.SelectedIndex)
            {
                case 0: return Book.BookStatus.NotStarted; 
                case 1: return Book.BookStatus.Reading; 
                case 2: return Book.BookStatus.OnHold;
                case 3: return Book.BookStatus.Dropped;
                case 4: return Book.BookStatus.Skipped; 
                case 5: return Book.BookStatus.Completed;;
                case 6: return Book.BookStatus.WaitTranslation; 
                case 7: return Book.BookStatus.Listened; 
                default: return Book.BookStatus.Unknown;
            }

        }

        #endregion

        private void btOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            EditedBook.Name = tbName.Text;
            EditedBook.Author = tbAuthor.Text;
            EditedBook.Comment = tbComment.Text;
            EditedBook.Date = dtpDate.Value.Date;
            EditedBook.Status = GetSelectedStatus();
            EditedBook.Have = chbHave.Checked;

            EditedBook.Bundles = bundles;
            EditedBook.Genres = genres;

            changed = false;

            OnBookSaved(EditedBook);
        }

        #region Events

        public event EventHandler<Book> BookSaved;
        [MethodImpl(MethodImplOptions.Synchronized)]
        protected virtual void OnBookSaved(Book book)
        {
            if (BookSaved != null)
                BookSaved(this, book);
        }

        public event EventHandler<Bundle> BundleSelected;
        [MethodImpl(MethodImplOptions.Synchronized)]
        protected virtual void OnBundleSelected(Bundle bundle)
        {
            if (BundleSelected != null)
                BundleSelected(this, bundle);
        }

        public event EventHandler<Genre> GenreSelected;
        [MethodImpl(MethodImplOptions.Synchronized)]
        protected virtual void OnGenreSelected(Genre genre)
        {
            if (GenreSelected != null)
                GenreSelected(this, genre);
        }

        #endregion
    }
}