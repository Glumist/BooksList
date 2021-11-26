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
using System.Windows.Forms.DataVisualization.Charting;

namespace BooksList.Forms
{
    public partial class FormMain : Form
    {
        BooksCollection _booksCollection;

        private const string BUNDLE_NONE = "Без набора";
        private const string BUNDLE_ALL = "Все";
        private const string BUNDLE_SUM = "Сводный";

        public FormMain()
        {
            InitializeComponent();

            dgvGroups.AutoGenerateColumns = false;
            dgvBooks.AutoGenerateColumns = false;

            ucBook.BookSaved += UcBook_BookSaved;
            ucBook.BundleSelected += UcBook_BundleSelected;
            ucBook.GenreSelected += UcBook_GenreSelected;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _booksCollection = BooksCollection.GetInstance();

            tscbGroup.SelectedIndex = 0;
            tscbSort.SelectedIndex = 0;
        }

        private void Save()
        {
            if (!_booksCollection.Save())
                MessageBox.Show("Ошибка при сохранении!");
        }

        private void ColorRow(DataGridViewRow row, Color color)
        {
            foreach (DataGridViewCell cell in row.Cells)
                cell.Style.BackColor = color;
        }

        #region Groups

        private void RefreshGroupTable()
        {
            dgvGroups.Rows.Clear();
            switch (tscbGroup.SelectedIndex)
            {
                case 0: RefreshBundles(); break;
                case 1: RefreshGenres(); break;
            }

            foreach (DataGridViewRow row in dgvGroups.Rows)
                row.Height = 30;
        }

        private void AddGroupRow(object dataBoundObject)
        {
            DataGridViewRow dGVRow = new DataGridViewRow();
            MultiColorDataGridViewTextBoxCell textCell = new MultiColorDataGridViewTextBoxCell();
            textCell.Value = dataBoundObject.ToString();
            dGVRow.Cells.Add(textCell);
            dGVRow.Tag = dataBoundObject;
            dgvGroups.Rows.Add(dGVRow);
        }

        private void TscbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGroupTable();
        }

        private void tsmiGroupAdd_Click(object sender, EventArgs e)
        {
            switch (tscbGroup.SelectedIndex)
            {
                case 0: AddBundle(); break;
                case 1: AddGenre(); break;
            }
        }

        private void tsmiGroupEdit_Click(object sender, EventArgs e)
        {
            switch (tscbGroup.SelectedIndex)
            {
                case 0: EditBundle(); break;
                case 1: EditGenre(); break;
            }
        }

        private void tsmiGroupDelete_Click(object sender, EventArgs e)
        {
            switch (tscbGroup.SelectedIndex)
            {
                case 0: DeleteBundle(); break;
                case 1: DeleteGenre(); break;
            }
        }

        #region Bundles

        private void RefreshBundles()
        {
            List<Bundle> bundles = new List<Bundle>(_booksCollection.Bundles);
            bundles.Add(new Bundle() { Name = BUNDLE_NONE });
            bundles.Add(new Bundle() { Name = BUNDLE_ALL });
            bundles.Insert(0, new Bundle() { Name = BUNDLE_SUM });
            bundles.ForEach(b => AddGroupRow(b));
            //dgvGroups.DataSource = bundles;
            ColorBundlesTable();
        }

        private void AddBundle()
        {
            FormBundle form = new FormBundle();
            if (form.ShowDialog() != DialogResult.OK)
                return;

            _booksCollection.Add(form.EditedBundle);
            Save();
            RefreshGroupTable();
            SelectBundle(form.EditedBundle);
        }

        private void EditBundle()
        {
            Bundle selectedBundle = GetSelectedBundle();
            if (selectedBundle == null || !IsBundleReal(selectedBundle))
                return;

            if (new FormBundle(selectedBundle).ShowDialog() != DialogResult.OK)
                return;

            Save();
            RefreshGroupTable();
            SelectBundle(selectedBundle);
        }

        private void DeleteBundle()
        {
            Bundle selectedBundle = GetSelectedBundle();
            if (selectedBundle == null || !IsBundleReal(selectedBundle))
                return;

            if (MessageBox.Show("Вы дейтсвительно хотите удалить " + selectedBundle.ToString() + "?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            _booksCollection.Bundles.Remove(selectedBundle);
            Save();
            RefreshGroupTable();
        }

        private Bundle GetSelectedBundle()
        {
            if (dgvGroups.SelectedRows.Count == 0 || dgvGroups.SelectedRows[0].Index == -1)
                return null;

            return dgvGroups.SelectedRows[0].Tag as Bundle;
        }

        private void SelectBundle(Bundle bundle)
        {
            if (tscbGroup.SelectedIndex != 0)
                return;

            foreach (DataGridViewRow row in dgvGroups.Rows)
            {
                Bundle rowBundle;

                if (row.Tag is Bundle)
                    rowBundle = row.Tag as Bundle;
                else
                    continue;

                if (rowBundle == bundle)
                {
                    row.Selected = true;
                    dgvGroups.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void ColorBundlesTable()
        {
            foreach (DataGridViewRow row in dgvGroups.Rows)
            {
                Bundle bundle = row.Tag as Bundle;
                List<Book> bundleBooks = GetBundleBooks(bundle);
                if (bundleBooks.Count == 0)
                    continue;
                else if (!bundleBooks.Exists(bg => bg.Status != Book.BookStatus.Skipped))
                    ColorRow(row, Book.ColorByStatus(Book.BookStatus.Skipped));
                else if (bundleBooks.Exists(bg => bg.Status == Book.BookStatus.Reading))
                    ColorRow(row, Book.ColorByStatus(Book.BookStatus.Reading));
                else if (bundleBooks.Exists(bg => bg.Status == Book.BookStatus.OnHold))
                    ColorRow(row, Book.ColorByStatus(Book.BookStatus.OnHold));
                else if (bundleBooks.Exists(bg => bg.Status == Book.BookStatus.NotStarted))
                    ColorRow(row, Book.ColorByStatus(Book.BookStatus.NotStarted));
                else if (bundleBooks.Exists(bg => bg.Status == Book.BookStatus.NotYetReleased))
                    ColorRow(row, Book.ColorByStatus(Book.BookStatus.NotYetReleased));
                else if (bundleBooks.Exists(bg => bg.Status == Book.BookStatus.WaitTranslation))
                    ColorRow(row, Book.ColorByStatus(Book.BookStatus.WaitTranslation));
                else
                    ColorRow(row, Book.ColorByStatus(Book.BookStatus.Completed));                
            }
        }

        private static List<Book> GetBundleBooks(Bundle bundle)
        {
            List<Book> result = new List<Book>();
            if (bundle == null)
                return result;

            if (bundle.Name == BUNDLE_SUM)
                result = GetSumBundleBooks();
            else if (bundle.Name == BUNDLE_NONE)
                result = BooksCollection.GetInstance().Books.FindAll(g => g.Bundles.Count == 0);
            else if (bundle.Name == BUNDLE_ALL)
                result = BooksCollection.GetInstance().Books;
            else
                foreach (Bundle.BundleBook bundleBook in BooksCollection.GetInstance().GetBundleBooks(bundle))
                    result.Add(bundleBook.Book);

            return result;
        }

        private static bool IsBundleReal(Bundle bundle)
        {
            return bundle.Name != BUNDLE_NONE && bundle.Name != BUNDLE_ALL && bundle.Name != BUNDLE_SUM;
        }

        #endregion

        #region Genres

        private void RefreshGenres()
        {
            //dgvGroups.DataSource = new List<Genre>(_gamesCollection.Genres);
            _booksCollection.Genres.ForEach(g => AddGroupRow(g));
            ColorGenresTable();
        }

        private void AddGenre()
        {
            FormGenre form = new FormGenre();
            if (form.ShowDialog() != DialogResult.OK)
                return;

            _booksCollection.Add(form.EditedGenre);
            Save();
            RefreshGroupTable();
            SelectGenre(form.EditedGenre);
        }

        private void EditGenre()
        {
            Genre selectedGenre = GetSelectedGenre();
            if (selectedGenre == null)
                return;

            if (new FormGenre(selectedGenre).ShowDialog() != DialogResult.OK)
                return;

            Save();
            RefreshGroupTable();
            SelectGenre(selectedGenre);
        }

        private void DeleteGenre()
        {
            Genre selectedGenre = GetSelectedGenre();
            if (selectedGenre == null)
                return;

            if (MessageBox.Show("Вы дейтсвительно хотите удалить " + selectedGenre.ToString() + "?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            _booksCollection.Genres.Remove(selectedGenre);
            Save();
            RefreshGroupTable();
        }

        private Genre GetSelectedGenre()
        {
            if (dgvGroups.SelectedRows.Count == 0 || dgvGroups.SelectedRows[0].Index == -1)
                return null;

            return dgvGroups.SelectedRows[0].Tag as Genre;
        }

        private void SelectGenre(Genre genre)
        {
            if (tscbGroup.SelectedIndex != 2)
                return;

            foreach (DataGridViewRow row in dgvGroups.Rows)
            {
                Genre rowGenre;

                if (row.Tag is Genre)
                    rowGenre = row.Tag as Genre;
                else
                    continue;

                if (rowGenre == genre)
                {
                    row.Selected = true;
                    dgvGroups.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void ColorGenresTable()
        {
            foreach (DataGridViewRow row in dgvGroups.Rows)
            {
                Genre genre = row.Tag as Genre;
                if (genre == null)
                    continue;

                List<Book> genreBooks = _booksCollection.Books.FindAll(g => g.Genres.Contains(genre));
                if (genreBooks.Count == 0)
                    continue;
                else if (!genreBooks.Exists(bg => bg.Status != Book.BookStatus.Skipped))
                    ColorRow(row, Book.ColorByStatus(Book.BookStatus.Skipped));
                else if (genreBooks.Exists(bg => bg.Status == Book.BookStatus.Reading))
                    ColorRow(row, Book.ColorByStatus(Book.BookStatus.Reading));
                else if (genreBooks.Exists(bg => bg.Status == Book.BookStatus.OnHold))
                    ColorRow(row, Book.ColorByStatus(Book.BookStatus.OnHold));
                else if (!genreBooks.Exists(bg => bg.Status != Book.BookStatus.WaitTranslation))
                    ColorRow(row, Book.ColorByStatus(Book.BookStatus.WaitTranslation));
                else if (genreBooks.Exists(bg => bg.Status == Book.BookStatus.NotStarted))
                    ColorRow(row, Book.ColorByStatus(Book.BookStatus.NotStarted));
            }
        }

        #endregion

        private void dgvGroups_SelectionChanged(object sender, EventArgs e)
        {
            RefreshBooksTable();
        }

        #endregion

        #region Books

        private void RefreshChart()
        {
            Dictionary<Book.BookStatus, int> colorsCounts = new Dictionary<Book.BookStatus, int>();

            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                Book book = GetBookFromRow(row);
                if (!colorsCounts.ContainsKey(book.Status))
                    colorsCounts.Add(book.Status, 0);
                colorsCounts[book.Status]++;
            }

            Series series = chart.Series[0];
            series.Points.Clear();
            foreach (Book.BookStatus key in colorsCounts.Keys)
            {
                int pointNum = series.Points.AddY(colorsCounts[key]);
                DataPoint point = series.Points[pointNum];
                point.Color = Book.ColorByStatus(key);
                point.IsValueShownAsLabel = true;
                point.ToolTip = key.ToString();
                //point.Label = colorsCounts[key].ToString();
            }
        }

        private void RefreshBooksTable()
        {
            colBookNumber.Visible = false;
            tsbBookUp.Visible = false;
            tsbBookDown.Visible = false;
            tsbBookNumber.Visible = false;
            tssBookMove.Visible = false;

            switch (tscbGroup.SelectedIndex)
            {
                case 0:
                    Bundle selectedBundle = GetSelectedBundle();
                    if (selectedBundle != null)
                        ShowBooksByBundle(selectedBundle);
                    break;
                case 1:
                    Genre selectedGenre = GetSelectedGenre();
                    if (selectedGenre != null)
                        ShowBooksByGenre(selectedGenre);
                    break;
                default:
                    dgvBooks.DataSource = GetFilteredList(_booksCollection.Books);
                    break;
            }

            int readyBooks = 0;
            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                Book book = GetBookFromRow(row);
                if (book == null)
                    continue;

                if (book.Have)
                    readyBooks++;
            }

            tsslBooksCount.Text = "" + dgvBooks.Rows.Count;
            tsslReadyBooksCount.Text = "" + readyBooks;
            dgvBooks.ClearSelection();
            ColorBooksTable();

            foreach (DataGridViewRow row in dgvBooks.Rows)
                row.Height = 30;

            RefreshChart();
        }

        private void ColorBooksTable()
        {
            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                Book book = GetBookFromRow(row);
                if (book == null)
                    continue;

                ColorRow(row, book.Color);
            }
        }

        private List<Book> GetFilteredList(List<Book> books)
        {
            List<Book> result = new List<Book>();

            foreach (Book book in books)
            {
                if (tsbBookStarted.Checked && !(book.Started && book.Have))
                    continue;

                if (tstbFilter.Text.Trim() != "" && !book.ToString().ToLower().Contains(tstbFilter.Text.ToLower()))
                    continue;

                if (tsbBuyList.Checked)
                {
                    if (!_booksCollection.IsBookNext(book))
                        continue;
                    if (book.Have)
                        continue;
                }

                result.Add(book);
            }

            if (tscbSort.SelectedIndex == 1)
                result.Sort(Book.CompareByName);
            else if (tscbSort.SelectedIndex == 2)
                result.Sort(Book.CompareByAuthor);

            return result;
        }

        private void ShowBooksByBundle(Bundle bundle)
        {
            if (bundle.Name == BUNDLE_NONE)
                dgvBooks.DataSource = GetFilteredList(_booksCollection.Books.FindAll(g => g.Bundles.Count == 0));
            else if (bundle.Name == BUNDLE_ALL)
                dgvBooks.DataSource = GetFilteredList(_booksCollection.Books);
            else if (bundle.Name == BUNDLE_SUM)
                dgvBooks.DataSource = GetFilteredList(GetSumBundleBooks());
            else
            {
                dgvBooks.DataSource = _booksCollection.GetBundleBooks(bundle).FindAll(g => 
                    (!tsbBookStarted.Checked || (g.Book.Started && g.Have)) &&
                    (!tsbBuyList.Checked || !g.Have) &&
                    (tstbFilter.Text.Trim() == "" || g.Book.ToString().ToLower().Contains(tstbFilter.Text.ToLower()))
                );
                colBookNumber.Visible = true;
                tsbBookUp.Visible = true;
                tsbBookDown.Visible = true;
                tsbBookNumber.Visible = true;
                tssBookMove.Visible = true;
            }
        }

        private static List<Book> GetSumBundleBooks()
        {
            List<Book> result = new List<Book>();
            foreach (Book book in BooksCollection.GetInstance().Books)
            {
                if (book.Date > DateTime.Today)
                    continue;
                if (book.Status == Book.BookStatus.Completed ||
                    book.Status == Book.BookStatus.Listened ||
                    book.Status == Book.BookStatus.Dropped ||
                    book.Status == Book.BookStatus.Skipped)
                    continue;
                if (book.Status == Book.BookStatus.Reading ||
                    book.Status == Book.BookStatus.OnHold)
                {
                    result.Add(book);
                    continue;
                }

                if (BooksCollection.GetInstance().IsBookNext(book))
                    result.Add(book);
            }
            return result;
        }

        private void ShowBooksByGenre(Genre genre)
        {
            dgvBooks.DataSource = GetFilteredList(_booksCollection.Books.FindAll(g => g.Genres.Contains(genre)));
        }

        private void tsbBookAdd_Click(object sender, EventArgs e)
        {
            Book newBook = new Book();

            Bundle selectedBundle = GetSelectedBundle();
            if (selectedBundle != null && IsBundleReal(selectedBundle))
            {
                newBook.Bundles.Add(_booksCollection.GetBookBundle(selectedBundle));
                newBook.Author = selectedBundle.Name;
                int year = BooksCollection.GetLastBundleBookYear(selectedBundle);
                newBook.Date = new DateTime(year, newBook.Date.Month, newBook.Date.Day);
            }

            ucBook.SetBook(newBook);
            ucBook.BringToFront();
        }

        private void tsbBookEdit_Click(object sender, EventArgs e) => EditBook();

        private void tsbBookDelete_Click(object sender, EventArgs e)
        {
            Book selectedBook = GetSelectedBook();
            if (selectedBook == null)
                return;

            if (MessageBox.Show("Вы дейтсвительно хотите удалить " + selectedBook.ToString() + "?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            _booksCollection.Remove(selectedBook);
            Save();
            RefreshBooksTable();
        }

        private void tsbBookUp_Click(object sender, EventArgs e)
        {
            Bundle selectedBundle = GetSelectedBundle();
            Book selectedBook = GetSelectedBook();

            if (selectedBundle == null || selectedBook == null)
                return;

            Book.BookBundle selectedBookBundle = selectedBook.Bundles.Find(b => b.Bundle == selectedBundle);
            if (selectedBookBundle == null)
                return;
            int selectedBookNumber = selectedBookBundle.Number;

            List<Book> bundleBooks = _booksCollection.Books.FindAll(g => g.Bundles.Exists(b => b.Bundle == selectedBundle));
            Book.BookBundle previousBookBundle = null;
            foreach (Book book in bundleBooks)
            {
                Book.BookBundle bookBundle = book.Bundles.Find(b => b.Bundle == selectedBundle);
                if (bookBundle == null || bookBundle.Number >= selectedBookNumber)
                    continue;

                if (previousBookBundle == null || previousBookBundle.Number < bookBundle.Number)
                    previousBookBundle = bookBundle;
            }

            if (previousBookBundle == null)
                return;

            selectedBookBundle.Number = previousBookBundle.Number;
            previousBookBundle.Number = selectedBookNumber;
            Save();
            RefreshBooksTable();
            SelectBook(selectedBook);
        }

        private void tsbBookDown_Click(object sender, EventArgs e)
        {
            Bundle selectedBundle = GetSelectedBundle();
            Book selectedBook = GetSelectedBook();

            if (selectedBundle == null || selectedBook == null)
                return;

            Book.BookBundle selectedBookBundle = selectedBook.Bundles.Find(b => b.Bundle == selectedBundle);
            if (selectedBookBundle == null)
                return;
            int selectedBookNumber = selectedBookBundle.Number;

            List<Book> bundleBooks = _booksCollection.Books.FindAll(g => g.Bundles.Exists(b => b.Bundle == selectedBundle));
            Book.BookBundle nextBookBundle = null;
            foreach (Book book in bundleBooks)
            {
                Book.BookBundle bookBundle = book.Bundles.Find(b => b.Bundle == selectedBundle);
                if (bookBundle == null || bookBundle.Number <= selectedBookNumber)
                    continue;

                if (nextBookBundle == null || nextBookBundle.Number > bookBundle.Number)
                    nextBookBundle = bookBundle;
            }

            if (nextBookBundle == null)
                return;

            selectedBookBundle.Number = nextBookBundle.Number;
            nextBookBundle.Number = selectedBookNumber;
            Save();
            RefreshBooksTable();
            SelectBook(selectedBook);
        }

        private void tsbBookNumber_Click(object sender, EventArgs e)
        {
            Bundle selectedBundle = GetSelectedBundle();
            Book selectedBook = GetSelectedBook();

            if (selectedBundle == null || selectedBook == null)
                return;

            Book.BookBundle selectedBookBundle = selectedBook.Bundles.Find(b => b.Bundle == selectedBundle);
            if (selectedBookBundle == null)
                return;
            int selectedBookNumber = selectedBookBundle.Number;

            List<Book> bundleBooks = _booksCollection.Books.FindAll(g => g.Bundles.Exists(b => b.Bundle == selectedBundle));

            FormNumber form = new FormNumber(selectedBookNumber, bundleBooks.Count - 1);
            if (form.ShowDialog() != DialogResult.OK || form.SelectedNumber == selectedBookNumber)
                return;

            foreach (Book book in bundleBooks)
            {
                Book.BookBundle bookBundle = book.Bundles.Find(b => b.Bundle == selectedBundle);
                if (bookBundle == null)
                    continue;

                if (form.SelectedNumber < selectedBookNumber && bookBundle.Number >= form.SelectedNumber && bookBundle.Number < selectedBookNumber)
                        bookBundle.Number++;
                else if(form.SelectedNumber > selectedBookNumber && bookBundle.Number <= form.SelectedNumber && bookBundle.Number > selectedBookNumber)
                        bookBundle.Number--;
            }
            selectedBookBundle.Number = form.SelectedNumber;

            Save();
            RefreshBooksTable();
            SelectBook(selectedBook);
        }

        private void tsbBookStarted_CheckedChanged(object sender, EventArgs e)
        {
            RefreshBooksTable();
        }

        private void tsbBuyList_CheckedChanged(object sender, EventArgs e)
        {
            RefreshBooksTable();
        }

        private void tstbFilter_TextChanged(object sender, EventArgs e)
        {
            RefreshBooksTable();
        }

        private Book GetSelectedBook()
        {
            if (dgvBooks.SelectedRows.Count == 0 || dgvBooks.SelectedRows[0].Index == -1)
                return null;

            return GetBookFromRow(dgvBooks.SelectedRows[0]);
        }

        private Book GetBookFromRow(DataGridViewRow row)
        {
            if (row == null)
                return null;

            if (row.DataBoundItem is Book)
                return row.DataBoundItem as Book;
            else if (row.DataBoundItem is Bundle.BundleBook)
                return (row.DataBoundItem as Bundle.BundleBook).Book;
            else
                return null;
        }

        private void SelectBook(Book book)
        {
            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                Book rowBook;

                if (row.DataBoundItem is Book)
                    rowBook = row.DataBoundItem as Book;
                else if (row.DataBoundItem is Bundle.BundleBook)
                    rowBook = (row.DataBoundItem as Bundle.BundleBook).Book;
                else
                    continue;

                if (rowBook == book)
                {
                    row.Selected = true;
                    dgvBooks.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void EditBook()
        {
            Book selectedBook = GetSelectedBook();
            if (selectedBook == null)
                return;

            ucBook.SetBook(selectedBook);
        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            Book selectedBook = GetSelectedBook();
            if (selectedBook != null)
            {
                ucBook.BringToFront();
                ucBook.SetBook(selectedBook);
            }
            else
            {
                ucBook.ClearBook();
                pEmpty.BringToFront();
            }
        }

        #endregion

        public class MultiColorDataGridViewTextBoxCell : DataGridViewTextBoxCell
        {
            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                if (this.DataGridView.Rows[this.RowIndex].Selected)
                    base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                else
                {
                    graphics.FillRectangle(
                        new SolidBrush(cellStyle.BackColor),
                        new Rectangle(cellBounds.X, cellBounds.Y, cellBounds.Width, (int)Math.Floor(cellBounds.Height * 0.85))
                    );
                    DrawStats(
                        graphics,
                        new Rectangle(cellBounds.X, cellBounds.Y + (int)Math.Floor(cellBounds.Height * 0.85), cellBounds.Width, (int)Math.Floor(cellBounds.Height * 0.15)),
                        this.DataGridView.Rows[this.RowIndex].Tag);
                    //graphics.DrawString((String)formattedValue, cellStyle.Font, Brushes.Black, cellBounds.X, cellBounds.Y, GetStringFormat(cellStyle));
                    TextRenderer.DrawText(graphics, (String)formattedValue, cellStyle.Font, cellBounds, cellStyle.ForeColor, cellStyle.BackColor,
                        GetStringFormatFlags(cellStyle) | TextFormatFlags.GlyphOverhangPadding);
                    this.PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
                }
            }

            private void DrawStats(Graphics graphics, Rectangle cellBounds, object rowTag)
            {
                List<Book> books;
                if (rowTag is Bundle)
                    books = GetBundleBooks(rowTag as Bundle);
                else if (rowTag is Genre)
                    books = BooksCollection.GetInstance().Books.FindAll(g => g.Genres.Contains(rowTag as Genre));
                else
                    books = new List<Book>();

                if (books.Count == 0)
                    graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(cellBounds.X, cellBounds.Y, cellBounds.Width, cellBounds.Height));
                else
                {
                    int bookWidth = cellBounds.Width / books.Count;
                    int offsetX = 0;
                    if (bookWidth != 0)
                    {
                        int correction = cellBounds.Width - bookWidth * books.Count;
                        if (correction > 0)
                            bookWidth++;
                        else
                            correction = -1;
                        foreach (Book book in books)
                        {
                            graphics.FillRectangle(new SolidBrush(book.Color),
                                new Rectangle(cellBounds.X + offsetX, cellBounds.Y, bookWidth, cellBounds.Height));
                            offsetX += bookWidth;

                            if (correction > 0)
                                correction--;
                            else if (correction == 0)
                            {
                                bookWidth--;
                                correction = -1;
                            }
                        }
                    }
                    else
                    {
                        Dictionary<Color, int> booksColors = GetColorsFromBooks(books);
                        foreach (Color key in booksColors.Keys)
                        {
                            int width = cellBounds.Width * booksColors[key] / books.Count;
                            if (width == 0)
                                continue;
                            graphics.FillRectangle(new SolidBrush(key),
                                new Rectangle(cellBounds.X + offsetX, cellBounds.Y, width, cellBounds.Height));
                            offsetX += width;
                        }
                    }

                    if (offsetX < cellBounds.Width)
                        graphics.FillRectangle(new SolidBrush(Color.White),
                            new Rectangle(cellBounds.X + offsetX, cellBounds.Y, cellBounds.Width - cellBounds.X - offsetX, cellBounds.Height));
                }
            }
            
            private Dictionary<Color, int> GetColorsFromBooks(List<Book> games)
            {
                Dictionary<Color, int> result = new Dictionary<Color, int>();

                result.Add(Book.ColorByStatus(Book.BookStatus.NotStarted), 0);
                result.Add(Book.ColorByStatus(Book.BookStatus.Reading), 0);
                result.Add(Book.ColorByStatus(Book.BookStatus.OnHold), 0);
                result.Add(Book.ColorByStatus(Book.BookStatus.Dropped), 0);
                result.Add(Book.ColorByStatus(Book.BookStatus.Skipped), 0);
                result.Add(Book.ColorByStatus(Book.BookStatus.WaitTranslation), 0);
                result.Add(Book.ColorByStatus(Book.BookStatus.Listened), 0);
                result.Add(Book.ColorByStatus(Book.BookStatus.Completed), 0);
                result.Add(Book.ColorByStatus(Book.BookStatus.NotYetReleased), 0);
                result.Add(Book.ColorByStatus(Book.BookStatus.Unknown), 0);

                foreach (Book game in games)
                    result[game.Color]++;

                return result;
            }

            private StringFormat GetStringFormat(DataGridViewCellStyle cellStyle)
            {
                StringFormat result = new StringFormat();
                switch (cellStyle.Alignment)
                {
                    case DataGridViewContentAlignment.BottomCenter:
                    case DataGridViewContentAlignment.BottomLeft:
                    case DataGridViewContentAlignment.BottomRight:
                        result.LineAlignment = StringAlignment.Far;
                        break;
                    case DataGridViewContentAlignment.MiddleCenter:
                    case DataGridViewContentAlignment.MiddleLeft:
                    case DataGridViewContentAlignment.MiddleRight:
                    case DataGridViewContentAlignment.NotSet:
                        result.LineAlignment = StringAlignment.Center;
                        break;
                    case DataGridViewContentAlignment.TopCenter:
                    case DataGridViewContentAlignment.TopLeft:
                    case DataGridViewContentAlignment.TopRight:
                        result.LineAlignment = StringAlignment.Near;
                        break;
                }
                switch (cellStyle.Alignment)
                {
                    case DataGridViewContentAlignment.BottomCenter:
                    case DataGridViewContentAlignment.MiddleCenter:
                    case DataGridViewContentAlignment.TopCenter:
                        result.Alignment = StringAlignment.Center;
                        break;
                    case DataGridViewContentAlignment.BottomLeft:
                    case DataGridViewContentAlignment.MiddleLeft:
                    case DataGridViewContentAlignment.TopLeft:
                    case DataGridViewContentAlignment.NotSet:
                        result.Alignment = StringAlignment.Near;
                        break;
                    case DataGridViewContentAlignment.BottomRight:
                    case DataGridViewContentAlignment.MiddleRight:
                    case DataGridViewContentAlignment.TopRight:
                        result.Alignment = StringAlignment.Far;
                        break;
                }

                return result;
            }

            private TextFormatFlags GetStringFormatFlags(DataGridViewCellStyle cellStyle)
            {
                switch (cellStyle.Alignment)
                {
                    case DataGridViewContentAlignment.BottomCenter:
                        return TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    case DataGridViewContentAlignment.BottomLeft:
                        return TextFormatFlags.Bottom | TextFormatFlags.Left;
                    case DataGridViewContentAlignment.BottomRight:
                        return TextFormatFlags.Bottom | TextFormatFlags.Right;
                    case DataGridViewContentAlignment.MiddleCenter:
                        return TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
                    case DataGridViewContentAlignment.MiddleRight:
                        return TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                    case DataGridViewContentAlignment.TopCenter:
                        return TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                    case DataGridViewContentAlignment.TopLeft:
                        return TextFormatFlags.Top | TextFormatFlags.Left;
                    case DataGridViewContentAlignment.TopRight:
                        return TextFormatFlags.Top | TextFormatFlags.Right;
                    case DataGridViewContentAlignment.MiddleLeft:
                    case DataGridViewContentAlignment.NotSet:
                    default:
                        return TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                }
            }
        }

        private void chart_Click(object sender, EventArgs e)
        {
            Point pos = System.Windows.Forms.Cursor.Position;
            Point clientpos = chart.PointToClient(pos);
            HitTestResult contr = chart.HitTest(clientpos.X, clientpos.Y);
            if (contr.Series != null && contr.PointIndex != -1)
                MessageBox.Show(contr.ChartElementType.ToString() + Environment.NewLine + contr.Series.Points[contr.PointIndex]);
        }

        //private void dgvGames_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => EditGame();

        private void UcBook_BookSaved(object sender, Book book)
        {
            if (!_booksCollection.Books.Contains(book))
                _booksCollection.Add(book);
            else 
                _booksCollection.Books.Sort(Book.CompareByDate);

            Save();
            RefreshBooksTable();
            SelectBook(book);
        }

        private void UcBook_BundleSelected(object sender, Bundle e)
        {
            Book selectedBook = ucBook.EditedBook;
            tscbGroup.SelectedIndex = 0;
            SelectBundle(e);
            SelectBook(selectedBook);
        }

        private void UcBook_GenreSelected(object sender, Genre e)
        {
            Book selectedBook = ucBook.EditedBook;
            tscbGroup.SelectedIndex = 2;
            SelectGenre(e);
            SelectBook(selectedBook);
        }
    }
}

// вынести информацию о книге и бандле/жанре в отдельные юзерконтролы
// сделать открытие юзерконтрола в отдельном окне по даблклику