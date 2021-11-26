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
    public partial class FormNumber : Form
    {
        public int SelectedNumber;

        public FormNumber(int currentValue, int maxValue)
        {
            InitializeComponent();

            nudValue.Maximum = maxValue;
            nudValue.Value = currentValue;
        }
        
        private void btOk_Click(object sender, EventArgs e)
        {
            SelectedNumber = (int)nudValue.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void nudValue_Enter(object sender, EventArgs e)
        {
            nudValue.Select(0, nudValue.Value.ToString().Length);
        }
    }
}