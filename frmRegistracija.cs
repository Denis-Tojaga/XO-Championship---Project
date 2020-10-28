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
        public List<TextBox> OsamIgracaImena { get; set; } = new List<TextBox>();
        public List<TextBox> CetiriIgracaImena { get; set; } = new List<TextBox>();
        public List<TextBox> DvaIgracaImena { get; set; } = new List<TextBox>();
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

        private void btnPokreniIgru_Click(object sender, EventArgs e)
        {
            frmGame igra = new frmGame();
            igra.ShowDialog();
            Close();
        }
    }
}
