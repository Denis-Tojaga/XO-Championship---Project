using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO_Game_Project
{
    public partial class frmWinnerForm : Form
    {
        public frmWinnerForm()
        {
            InitializeComponent();
        }

        public frmWinnerForm(string pobjednik) : this()
        {
            lblCestitka.Text = pobjednik + " WON";
        }

        private void frmWinnerForm_Load(object sender, EventArgs e)
        {

        }

        private void frmWinnerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Close();
        }
    }
}
