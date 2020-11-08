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
        int bestOF;
        public int BrojacPoteza { get; set; }
        public int RezultatIgraca1 { get; set; } = 0;
        public int RezultatIgraca2 { get; set; } = 0;
        public int BrojPobjedaPrvog { get; set; } = 0;
        public int BrojPobjedaDrugog { get; set; } = 0;
        public List<TextBox> nextBracket { get; set; }
        public int brojacRudne { get; set; }
        public frmGame()
        {
            InitializeComponent();
        }
        public frmGame(string prvi,string drugi,int best,int brojac,List<TextBox>next):this()
        {
            brojacRudne = brojac;
            nextBracket = next;
            bestOF = best;
            lblPrviIgrac.Text =prvi ;
            lblDrugiIgrac.Text= drugi;
        }
        public frmGame(string prvi,string drugi,string finale):this(){
            lblPrviIgrac.Text = prvi;
            lblDrugiIgrac.Text = drugi;
            
            bestOF = 5;
        }
      
        private void frmGame_Load(object sender, EventArgs e)
        {
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
        private void UgasiDugmicAkoGotovo(Button dugmic)
        {
            if (!ProvjeriTextButtona(dugmic))
                dugmic.Enabled = false;
        }
        private void PromijeniVrijednost(object kliknut)
        {
            int newButtonTextSize = 50;
            Button kliknutiDugmic = kliknut as Button;
            if (string.IsNullOrEmpty(kliknutiDugmic.Text))
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
                btnNextRound.Show();
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
                    lblRezultatIgraca2.Text = (++BrojPobjedaDrugog).ToString();
                    UgasiDugmice();
                    lblTrenutniPotez.Hide();
                    lblCurrently.Text="                                 >> Match ended <<";
                    btnNextRound.Show();


                    if(BrojPobjedaDrugog==bestOF/2 + 1)
                    {
                        nextBracket[brojacRudne].Text = lblDrugiIgrac.Text;
                        Hide();
                    }
                }
                else
                {
                    lblPobjednik.Text = lblPrviIgrac.Text + " WON !";
                    lblRezultatIgraca1.Text = (++BrojPobjedaPrvog).ToString();
                    UgasiDugmice();
                    lblCurrently.Text = "                                 >> Match ended <<";
                    lblTrenutniPotez.Hide();
                    btnNextRound.Show();
                    if (BrojPobjedaPrvog == bestOF / 2 + 1)
                    {
                        nextBracket[brojacRudne].Text = lblPrviIgrac.Text;
                        Hide();
                    }
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
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            PromijeniVrijednost(sender);
            ProvjeraPobjednika();
            ProvjeraNerijeseno();
        }
        private void OslobodiDugmic(Button dugmic)
        {
            dugmic.Enabled = true;
        }
        private void RestartIgru()
        {
            btn1.BackColor = btn2.BackColor = btn3.BackColor = btn4.BackColor = btn5.BackColor = btn6.BackColor = btn7.BackColor = btn8.BackColor = btn9.BackColor = Color.White;
            btn1.Text = btn2.Text = btn3.Text = btn4.Text = btn5.Text = btn6.Text = btn7.Text = btn8.Text = btn9.Text = "";
            lblCurrently.Text="";
            if(BrojacPoteza%2==0)
                lblTrenutniPotez.Text =lblPrviIgrac.Text;
            else
                lblTrenutniPotez.Text =lblDrugiIgrac.Text;
            lblCurrently.Text = "Currently playing >> ";
            lblTrenutniPotez.Show();
            btnNextRound.Hide();
            OslobodiDugmic(btn1);
            OslobodiDugmic(btn2);
            OslobodiDugmic(btn3);
            OslobodiDugmic(btn4);
            OslobodiDugmic(btn5);
            OslobodiDugmic(btn6);
            OslobodiDugmic(btn7);
            OslobodiDugmic(btn8);
            OslobodiDugmic(btn9);
        }
        private void btnNextRound_Click(object sender, EventArgs e)
        {
            RestartIgru();
        }
        private void btnExitGame_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
