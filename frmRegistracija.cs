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
        static public List<Igrac> OsamIgraca { get; set; } = new List<Igrac>();
        static public List<Igrac> CetiriIgraca { get; set; } = new List<Igrac>();
        static public List<Igrac> DvaIgraca { get; set; } = new List<Igrac>();

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
        }
        public frmRegistracija(int brojIgraca): this()
        {
            if (brojIgraca == 8)
            {
                OnemoguciUlaze(CetiriIgracaImena);
                OnemoguciUlaze(DvaIgracaImena);

                OsamIgraca.Add(new Igrac(txtOsam1.Text));
                OsamIgraca.Add(new Igrac(txtOsam2.Text));
                OsamIgraca.Add(new Igrac(txtOsam3.Text));
                OsamIgraca.Add(new Igrac(txtOsam4.Text));
                OsamIgraca.Add(new Igrac(txtOsam5.Text));
                OsamIgraca.Add(new Igrac(txtOsam6.Text));
                OsamIgraca.Add(new Igrac(txtOsam7.Text));
                OsamIgraca.Add(new Igrac(txtOsam8.Text));
            }
            else if(brojIgraca==4)
            {
                OnemoguciUlaze(OsamIgracaImena);
                OnemoguciUlaze(DvaIgracaImena);
            }
            else
            {
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
            if(txtOsam1.Text=="" && txtCetiri1.Text=="")
            {
                if(ProvjeriInputIgraca(txtDva1.Text) && ProvjeriInputIgraca(txtDva2.Text))
                {
                     DvaIgraca.Add(new Igrac(txtDva1.Text));
                     DvaIgraca.Add(new Igrac(txtDva2.Text));
                }
                else
                {
                    MessageBox.Show("Please enter all required fields!");
                    return;
                }

            }else if(txtOsam1.Text=="" && txtDva1.Text == "")
            {
                if (ProvjeriInputIgraca(txtCetiri1.Text) && ProvjeriInputIgraca(txtCetiri2.Text) && ProvjeriInputIgraca(txtCetiri3.Text) && ProvjeriInputIgraca(txtCetiri4.Text))
                {
                    CetiriIgraca.Add(new Igrac(txtCetiri1.Text));
                    CetiriIgraca.Add(new Igrac(txtCetiri2.Text));
                    CetiriIgraca.Add(new Igrac(txtCetiri3.Text));
                    CetiriIgraca.Add(new Igrac(txtCetiri4.Text));
                }
                else
                {
                    MessageBox.Show("Please enter all required fields!");
                    return;
                }
            }
            else
            {
                if (ProvjeriInputIgraca(txtOsam1.Text) && ProvjeriInputIgraca(txtOsam2.Text) && ProvjeriInputIgraca(txtOsam3.Text) && ProvjeriInputIgraca(txtOsam4.Text) && ProvjeriInputIgraca(txtOsam5.Text) && ProvjeriInputIgraca(txtOsam6.Text) && ProvjeriInputIgraca(txtOsam7.Text) && ProvjeriInputIgraca(txtOsam8.Text))
                {
                    OsamIgraca.Add(new Igrac(txtOsam1.Text));
                    OsamIgraca.Add(new Igrac(txtOsam2.Text));
                    OsamIgraca.Add(new Igrac(txtOsam3.Text));
                    OsamIgraca.Add(new Igrac(txtOsam4.Text));
                    OsamIgraca.Add(new Igrac(txtOsam5.Text));
                    OsamIgraca.Add(new Igrac(txtOsam6.Text));
                    OsamIgraca.Add(new Igrac(txtOsam7.Text));
                    OsamIgraca.Add(new Igrac(txtOsam8.Text));
                }
                else
                {
                    MessageBox.Show("Please enter all required fields!");
                    return;
                }
            }
            this.Hide();
            frmGame igra = new frmGame();
            igra.ShowDialog();
            Close();
        }

       
    }
}
