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
    public partial class frmGame : Form
    {
        bool krajIgre;
        int bestOF;
        public int BrojacPoteza { get; set; }
        public int RezultatIgraca1 { get; set; } = 0;
        public int RezultatIgraca2 { get; set; } = 0;
        public frmGame(int best)
        {
            krajIgre = false;
            bestOF = best;
            InitializeComponent();
        }
        private void frmGame_Load(object sender, EventArgs e)
        {
            lblPrviIgrac.Text = frmRegistracija.DvaIgraca[0].ImeIgraca;
            lblDrugiIgrac.Text = frmRegistracija.DvaIgraca[1].ImeIgraca;
            // Edit kasnije, eror se javlja na vise od 2 igraca 0-0-0-0-0-0-0-0-0
            lblTrenutniPotez.Text = lblPrviIgrac.Text;
        }
        private bool ProvjeriDugmice(Button button1, Button button2, Button button3)
        {
            if (button1.Text!="" && button1.Text == button2.Text && button1.Text == button3.Text)
            {
                button1.BackColor = Color.Red;
                button2.BackColor = Color.Red;
                button3.BackColor = Color.Red;
                
                return true;
            }
            return false;
        }
        private bool ProvjeriTextButtona(Button dugmic)
        {
            if (dugmic.Text == "X" || dugmic.Text == "O")
                return true;
            return false;
        }
        // Mislim da ne treba ova funkcija
        //private void UgasiDugmicAkoGotovo(Button dugmic)
        //{
        //    if (!ProvjeriTextButtona(dugmic) && ProvjeraPobjednika())
        //        dugmic.Enabled = false;
        //}
        private void PromijeniVrijednost(object kliknut)
        {
            int newButtonTextSize = 50;
            Button kliknutiDugmic = kliknut as Button;
            if (string.IsNullOrEmpty(kliknutiDugmic.Text) && !krajIgre)
            {
                if (BrojacPoteza % 2 == 0)
                {
                    kliknutiDugmic.Text = "X";
                    kliknutiDugmic.Font = new Font(kliknutiDugmic.Font.FontFamily, newButtonTextSize);
                    lblTrenutniPotez.Text = lblDrugiIgrac.Text;
                }
                else
                {
                    kliknutiDugmic.Text = "O";
                    kliknutiDugmic.Font = new Font(kliknutiDugmic.Font.FontFamily, newButtonTextSize);
                    lblTrenutniPotez.Text = lblPrviIgrac.Text;

                }
                BrojacPoteza++;
            }
        }
        private void PromijeniBojuButtonu(Button dugmic)
        {
            dugmic.BackColor = Color.Blue;
        }
        private void ZavrsiloNerijesenoPromijeniBoju()
        {
            PromijeniBojuButtonu(btn1);
            PromijeniBojuButtonu(btn2);
            PromijeniBojuButtonu(btn3);
            PromijeniBojuButtonu(btn4);
            PromijeniBojuButtonu(btn5);
            PromijeniBojuButtonu(btn6);
            PromijeniBojuButtonu(btn7);
            PromijeniBojuButtonu(btn8);
            PromijeniBojuButtonu(btn9);
        }
        private bool ProvjeraNerijeseno()
        {
            if(ProvjeriTextButtona(btn1) && ProvjeriTextButtona(btn2) && ProvjeriTextButtona(btn3) && ProvjeriTextButtona(btn4) && ProvjeriTextButtona(btn5) && ProvjeriTextButtona(btn6) && ProvjeriTextButtona(btn7) && ProvjeriTextButtona(btn8) && ProvjeriTextButtona(btn9) && !ProvjeraPobjednika())
            {
                ZavrsiloNerijesenoPromijeniBoju();
                lblPobjednik.Text = "Match ended with draw";
                krajIgre = true;
                btnNextRound.Show();
                return true;
            }
            else
                return false;
        }
        private void UgasiDugmice()
        {
            //UgasiDugmicAkoGotovo(btn1);
            //UgasiDugmicAkoGotovo(btn2);
            //UgasiDugmicAkoGotovo(btn3);
            //UgasiDugmicAkoGotovo(btn4);
            //UgasiDugmicAkoGotovo(btn5);
            //UgasiDugmicAkoGotovo(btn6);
            //UgasiDugmicAkoGotovo(btn7);
            //UgasiDugmicAkoGotovo(btn8);
            //UgasiDugmicAkoGotovo(btn9);
        }
        private bool ProvjeriRedove()
        {
            return ProvjeriDugmice(btn1, btn2, btn3) || ProvjeriDugmice(btn4, btn5, btn6) || ProvjeriDugmice(btn7, btn8, btn9);
        }
        private bool ProvjeriKolone()
        {
            return ProvjeriDugmice(btn1, btn4, btn7) || ProvjeriDugmice(btn2, btn5, btn8) || ProvjeriDugmice(btn3, btn6, btn9);
        }
        private bool ProvjeriDijagonale()
        {
            return ProvjeriDugmice(btn1, btn5, btn9) || ProvjeriDugmice(btn3, btn5, btn7);
        }
        private bool ProvjeraPobjednika()
        {
            if (ProvjeriRedove() || ProvjeriKolone() || ProvjeriDijagonale())
            {
                if (BrojacPoteza % 2 == 0)
                {
                    lblPobjednik.Text = lblDrugiIgrac.Text + " WON !";
                    int temp = int.Parse(lblRezultatIgraca2.Text) + 1;
                    lblRezultatIgraca2.Text = (temp).ToString();
                    lblCurrently.Text = "                       << Match ended >>";
                    lblTrenutniPotez.Text = "";
                    btnNextRound.Show();

                    krajIgre = true;
                }
                else
                {
                    lblPobjednik.Text = lblPrviIgrac.Text + " WON !";
                    int temp = int.Parse(lblRezultatIgraca1.Text) + 1;
                    lblRezultatIgraca1.Text = (temp).ToString();
                    lblCurrently.Text = "                       << Match ended >>";
                    lblTrenutniPotez.Text = "";
                    btnNextRound.Show();

                    krajIgre = true;
                }
                return true;
            }
            return false;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
            UgasiDugmice();
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
            UgasiDugmice();


        }
        private void btn3_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
            UgasiDugmice();

        }
        private void btn4_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
            UgasiDugmice();

        }
        private void btn5_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
            UgasiDugmice();

        }
        private void btn6_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
            UgasiDugmice();

        }
        private void btn7_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
            UgasiDugmice();

        }
        private void btn8_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
            UgasiDugmice();

        }
        private void btn9_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
            UgasiDugmice();

        }

        private void RestartIgru()
        {
            btn1.BackColor = btn2.BackColor = btn3.BackColor = btn4.BackColor = btn5.BackColor = btn6.BackColor = btn7.BackColor = btn8.BackColor = btn9.BackColor = Color.White;
            btn1.Text = btn2.Text = btn3.Text = btn4.Text = btn5.Text = btn6.Text = btn7.Text = btn8.Text = btn9.Text = "";
            krajIgre = false;
            btnNextRound.Hide();
            //BrojacPoteza = 0;
            //Brojac poteza odkomentarisati ako zelis da X igra uvijek prvi sto po meni nije fer.

        }
        private void btnNextRound_Click(object sender, EventArgs e)
        {
            RestartIgru();

        }
    }
}
