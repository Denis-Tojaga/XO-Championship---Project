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
    public partial class frmRegistracija : Form
    {
        static public List<TextBox> OsamIgracaImena { get; set; } = new List<TextBox>();
        static public List<TextBox> CetiriIgracaImena { get; set; } = new List<TextBox>();
        static public List<TextBox> DvaIgracaImena { get; set; } = new List<TextBox>();
        static public List<TextBox> Final { get; set; } = new List<TextBox>();
        static public List<Igrac> OsamIgraca { get; set; } = new List<Igrac>();
        static public List<Igrac> CetiriIgraca { get; set; } = new List<Igrac>();
        static public List<Igrac> DvaIgraca { get; set; } = new List<Igrac>();
        static int brojIgracaTurnir { get; set; }
        static string dioBracketa { get; set;}
        static int brojacRundi { get; set; }=0;
        public frmRegistracija()
        {
            InitializeComponent();
            OsamIgracaImena.Add(txtOsam1);
            OsamIgracaImena.Add(txtOsam2);
            OsamIgracaImena.Add(txtOsam3);
            OsamIgracaImena.Add(txtOsam4);
            OsamIgracaImena.Add(txtOsam5);
            OsamIgracaImena.Add(txtOsam6);
            OsamIgracaImena.Add(txtOsam7);
            OsamIgracaImena.Add(txtOsam8);


            CetiriIgracaImena.Add(txtCetiri1);
            CetiriIgracaImena.Add(txtCetiri2);
            CetiriIgracaImena.Add(txtCetiri3);
            CetiriIgracaImena.Add(txtCetiri4);


            DvaIgracaImena.Add(txtDva1);
            DvaIgracaImena.Add(txtDva2);
            Final.Add(txtChampion);
        }
        public frmRegistracija(int brojIgraca): this()
        {
            btnPokreniIgru.Hide();
            txtChampion.Enabled = false;
            brojIgracaTurnir = brojIgraca;
            if (brojIgraca == 8)
            {
                dioBracketa = "quater";
                OnemoguciUlaze(CetiriIgracaImena);
                OnemoguciUlaze(DvaIgracaImena);
            }
            else if(brojIgraca==4)
            {
                dioBracketa = "semi";

                OnemoguciUlaze(OsamIgracaImena);
                OnemoguciUlaze(DvaIgracaImena);
            }
            else
            {
                dioBracketa = "final";
                OnemoguciUlaze(OsamIgracaImena);
                OnemoguciUlaze(CetiriIgracaImena);
            }
        }

        private void OnemoguciUlaze(List<TextBox> parametarLista)
        {
            foreach (var textBox in parametarLista)
                textBox.Enabled = false;
        }


        private void frmRegistracija_Load(object sender, EventArgs e)
        {

        }

        private bool ProvjeriInputIgraca(string inputIgraca)
        {
            return (!string.IsNullOrEmpty(inputIgraca));
        }

        private void btnPokreniIgru_Click(object sender, EventArgs e)
        {
            if(dioBracketa=="quater" && brojacRundi <= 3)
            {
                string prvi;
                string drugi;
                prvi= OsamIgracaImena[brojacRundi*2].Text;
                drugi=OsamIgracaImena[brojacRundi*2+1].Text;
                frmGame igra = new frmGame(prvi,drugi, 3,brojacRundi,CetiriIgracaImena);
                igra.ShowDialog();
                brojacRundi++;
                if (brojacRundi == 4)
                {
                    brojacRundi = 0;
                    dioBracketa = "semi";
                }
            }
            if (dioBracketa=="semi" && brojacRundi <= 1)
            {
                string prvi = CetiriIgracaImena[brojacRundi * 2].Text;
                string drugi = CetiriIgracaImena[brojacRundi * 2 + 1].Text;
                frmGame igra = new frmGame(prvi, drugi, 3,brojacRundi,DvaIgracaImena);
                igra.ShowDialog();
                brojacRundi++;
                if (brojacRundi == 2)
                {
                    brojacRundi = 0;
                    dioBracketa = "final";
                }
            }
            if (dioBracketa == "final")
            {
                string prvi = DvaIgracaImena[brojacRundi * 2].Text;
                string drugi = DvaIgracaImena[brojacRundi * 2 + 1].Text;
                frmGame igra = new frmGame(prvi, drugi,5,brojacRundi,Final);
                igra.ShowDialog();
                brojacRundi++;
                if(brojacRundi==1)
                {
                    brojacRundi = 0;
                    dioBracketa = "kraj";
                }
            }
            if(dioBracketa=="kraj")
            {
                frmWinnerForm theEnd = new frmWinnerForm(txtChampion.Text);
                theEnd.ShowDialog();
                if(!string.IsNullOrEmpty(txtChampion.Text))
                    Close();
            }
        }

        private void frmRegistracija_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void SakrijUlaze(List<TextBox> ulazi)
        {
            foreach (var i in ulazi)
                i.Hide();
        }
        private void btnLock_Click(object sender, EventArgs e)
        {
            if (brojIgracaTurnir == 8 && ProvjeriInputIgraca(txtOsam1.Text) && ProvjeriInputIgraca(txtOsam2.Text) && ProvjeriInputIgraca(txtOsam3.Text) && ProvjeriInputIgraca(txtOsam4.Text) && ProvjeriInputIgraca(txtOsam5.Text) && ProvjeriInputIgraca(txtOsam6.Text) && ProvjeriInputIgraca(txtOsam7.Text) && ProvjeriInputIgraca(txtOsam8.Text))
            {
                OnemoguciUlaze(OsamIgracaImena);
                txtChampion.Enabled = false;
                btnLock.Hide();
                btnPokreniIgru.Show();
                OsamIgraca.Add(new Igrac(txtOsam1.Text));
                OsamIgraca.Add(new Igrac(txtOsam2.Text));
                OsamIgraca.Add(new Igrac(txtOsam3.Text));
                OsamIgraca.Add(new Igrac(txtOsam4.Text));
                OsamIgraca.Add(new Igrac(txtOsam5.Text));
                OsamIgraca.Add(new Igrac(txtOsam6.Text));
                OsamIgraca.Add(new Igrac(txtOsam7.Text));
                OsamIgraca.Add(new Igrac(txtOsam8.Text));
                return;
            }
            if(brojIgracaTurnir==4 && ProvjeriInputIgraca(txtCetiri1.Text) && ProvjeriInputIgraca(txtCetiri2.Text) && ProvjeriInputIgraca(txtCetiri3.Text) && ProvjeriInputIgraca(txtCetiri4.Text))
            {
                OnemoguciUlaze(CetiriIgracaImena);
                SakrijUlaze(OsamIgracaImena);
                txtChampion.Enabled = false;
                btnLock.Hide();
                btnPokreniIgru.Show();
                CetiriIgraca.Add(new Igrac(txtCetiri1.Text));
                CetiriIgraca.Add(new Igrac(txtCetiri2.Text));
                CetiriIgraca.Add(new Igrac(txtCetiri3.Text));
                CetiriIgraca.Add(new Igrac(txtCetiri4.Text));
                return;
            }
            if(brojIgracaTurnir==2 && ProvjeriInputIgraca(txtDva1.Text) && ProvjeriInputIgraca(txtDva2.Text))
            {
                OnemoguciUlaze(DvaIgracaImena);
                SakrijUlaze(OsamIgracaImena);
                SakrijUlaze(CetiriIgracaImena);
                txtChampion.Enabled = false;
                btnLock.Hide();
                btnPokreniIgru.Show();
                DvaIgraca.Add(new Igrac(txtDva1.Text));
                DvaIgraca.Add(new Igrac(txtDva2.Text));
                return;
            }
            MessageBox.Show("Please enter all required fields");
        }
    }
}
