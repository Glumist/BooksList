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
    public partial class FormBundle : Form
    {
        public Bundle EditedBundle;

        public FormBundle()
        {
            InitializeComponent();

            EditedBundle = new Bundle();
        }

        public FormBundle(Bundle bundle)
        {
            InitializeComponent();

            EditedBundle = bundle;

            tbName.Text = bundle.Name;
            tbComment.Text = bundle.Comment;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            EditedBundle.Name = tbName.Text;
            EditedBundle.Comment = tbComment.Text;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
