using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary>
/// hala oplakat ces
/// </summary>


namespace XO_Game_Project
{
    public partial class frmGame : Form
    {
        public int BrojacPoteza { get; set; }
        public int RezultatIgraca1 { get; set; } = 0;
        public int RezultatIgraca2 { get; set; } = 0;
        public frmGame()
        {
            InitializeComponent();
        }
        private void frmGame_Load(object sender, EventArgs e)
        {
            lblPrviIgrac.Text = frmRegistracija.DvaIgraca[0].ImeIgraca;
            lblDrugiIgrac.Text = frmRegistracija.DvaIgraca[1].ImeIgraca;
            lblTrenutniPotez.Text = lblPrviIgrac.Text;
        }
        private bool ProvjeriDugmice(Button button1, Button button2, Button button3)
        {
            if (button1.Text!="Click to play" && button1.Text == button2.Text && button1.Text == button3.Text)
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
        private void UgasiDugmicAkoGotovo(Button dugmic)
        {
            if (!ProvjeriTextButtona(dugmic) && ProvjeraPobjednika())
                dugmic.Enabled = false;
        }
        private void PromijeniVrijednost(object kliknut)
        {
            int newButtonTextSize = 50;
            Button kliknutiDugmic = kliknut as Button;
            if (kliknutiDugmic.Text == "Click to play")
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
                return true;
            }
            else
                return false;
        }
        private void UgasiDugmice()
        {
            UgasiDugmicAkoGotovo(btn1);
            UgasiDugmicAkoGotovo(btn2);
            UgasiDugmicAkoGotovo(btn3);
            UgasiDugmicAkoGotovo(btn4);
            UgasiDugmicAkoGotovo(btn5);
            UgasiDugmicAkoGotovo(btn6);
            UgasiDugmicAkoGotovo(btn7);
            UgasiDugmicAkoGotovo(btn8);
            UgasiDugmicAkoGotovo(btn9);
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
                    lblRezultatIgraca2.Text = (RezultatIgraca2+1).ToString();
                    lblCurrently.Text = "                       << Match ended >>";
                    lblTrenutniPotez.Text = "";
                }
                else
                {
                    lblPobjednik.Text = lblPrviIgrac.Text + " WON !";
                    lblRezultatIgraca1.Text = (RezultatIgraca1+1).ToString();
                    lblCurrently.Text = "                       << Match ended >>";
                    lblTrenutniPotez.Text = "";
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
    }
}
