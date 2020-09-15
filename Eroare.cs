using System;
using System.Drawing;
using System.Windows.Forms;

namespace Teste
{
    public partial class Eroare : Form
    {
        public static string textEroare = null;
        public static string OKCancel = null;
        public Eroare()
        {
            InitializeComponent();

            OKCancel = null;
            labelEroare.Text = textEroare;

            if (labelEroare.Text.Contains("sigur"))
            {
                buttonCancel.Visible = true;
                buttonOK.Size = new Size(72, 37);
                buttonOK.Location = new Point(19, 54);
                buttonOK.Text = "Da";
                buttonCancel.Size = new Size(72, 37);
                buttonCancel.Location = new Point(92, 54);
                buttonCancel.Text = "Nu";
            }
            else
            {
                buttonCancel.Visible = false;
                buttonOK.Text = "OK";
                buttonOK.Location = new Point(42, 54);
                buttonOK.Size = new Size(101, 37);
            }
        }
        private void Eroare_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
        }
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
            OKCancel = "OK";
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
            OKCancel = "Cancel";
        }
    }
}
