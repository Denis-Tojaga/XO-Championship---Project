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
    public partial class frmStart : Form
    {
        public int BrojIgracaUIgrici { get; set; }
        private void frmStart_Load(object sender, EventArgs e)
        {

        }
        public frmStart()
        {
            InitializeComponent();
        }


        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(lbl2Igraca.BackColor!=Color.Red && lbl4Igraca.BackColor != Color.Red && lbl8Igraca.BackColor != Color.Red)
            {
                MessageBox.Show("Please select how many players You want!");
                return;
            }
            Hide();
            frmRegistracija formaReg = new frmRegistracija(BrojIgracaUIgrici);
            formaReg.ShowDialog();
            Close();
        }
        private void lbl2Igraca_Click(object sender, EventArgs e)
        {
            lbl2Igraca.BackColor = Color.Red;
            BrojIgracaUIgrici = 2;
            lbl4Igraca.BackColor = Color.White;
            lbl8Igraca.BackColor = Color.White;
        }
        private void lbl4Igraca_Click(object sender, EventArgs e)
        {
            lbl2Igraca.BackColor = Color.White;
            lbl4Igraca.BackColor = Color.Red;
            BrojIgracaUIgrici = 4;
            lbl8Igraca.BackColor = Color.White;
        }
        private void lbl8Igraca_Click(object sender, EventArgs e)
        {
            lbl2Igraca.BackColor = Color.White;
            lbl4Igraca.BackColor = Color.White;
            lbl8Igraca.BackColor = Color.Red;
            BrojIgracaUIgrici = 8;
        }
       
    }
}
