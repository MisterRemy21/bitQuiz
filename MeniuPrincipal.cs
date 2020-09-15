using bitQuiz;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuTextbox;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Teste
{
    public partial class MeniuPrincipal : Form
    {
        [Obsolete]
        public MeniuPrincipal()
        {
            InitializeComponent();

            Capitole();
            Initializare();
            AfisareCapitole(1);
            AfisareVietiAcasa();
            AfisareClasament();
            AfisareAcasa();
        }

        bool isPrietenos = false;

        private void RealizarePrietenos()
        {
            if (!imagineR1.Visible && progressBarPrietenos.Value < 3)
            {
                progressBarPrietenos.Value++;
                labelPrietenos.Text = progressBarPrietenos.Value + "/3";

                if (progressBarPrietenos.Value == 3)
                {
                    using (SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.realizare))
                    {
                        audio.Play();
                    }

                    imagineR1.Visible = true;

                    Utilizator u = new Utilizator
                    {
                        UserName = labelUtilizator.Text
                    };

                    u.AdaugareRealizare(u, 1);

                    isPrietenos = true;
                    panelRealizare.Visible = true;
                    pictureBoxRealizare.Image = R1.Image;
                    labelNumeRealizare.Text = "Prietenos";
                }
            }
        }

        bool isPrint = false;

        private void RealizarePrint()
        {
            if (!imagineR2.Visible && progressBarPrint.Value < 10)
            {
                progressBarPrint.Value++;
                labelPrint.Text = progressBarPrint.Value + "/10";

                if (progressBarPrint.Value == 10)
                {
                    imagineR2.Visible = true;

                    Utilizator u = new Utilizator
                    {
                        UserName = labelUtilizator.Text
                    };

                    u.AdaugareRealizare(u, 2);

                    isPrint = true;
                    panelRealizare.Visible = true;
                    pictureBoxRealizare.Image = R2.Image;
                    labelNumeRealizare.Text = "Prinț";
                }
            }
        }

        bool isRege = false;
        private void RealizareRege()
        {
            if (!imagineR3.Visible && progressBarRege.Value < numarCapitole)
            {
                progressBarRege.Value++;
                labelRege.Text = progressBarRege.Value + "/" + numarCapitole.ToString();

                if (progressBarRege.Value == numarCapitole)
                {
                    imagineR3.Visible = true;

                    Utilizator u = new Utilizator
                    {
                        UserName = labelUtilizator.Text
                    };

                    u.AdaugareRealizare(u, 3);

                    isRege = true;
                    panelRealizare.Visible = true;
                    pictureBoxRealizare.Image = R3.Image;
                    labelNumeRealizare.Text = "Rege";
                }
            }
        }

        bool isIncepeAventura = false;

        private void RealizareIncepeAventura()
        {
            if (!imagineR8.Visible && progressBarIncepeAventura.Value < 4)
            {
                progressBarIncepeAventura.Value++;
                labelIncepeAventura.Text = progressBarIncepeAventura.Value + "/4";

                if (progressBarIncepeAventura.Value == 4)
                {
                    imagineR8.Visible = true;

                    Utilizator u = new Utilizator
                    {
                        UserName = labelUtilizator.Text
                    };

                    u.AdaugareRealizare(u, 8);

                    isIncepeAventura = true;
                    panelRealizare.Visible = true;
                    pictureBoxRealizare.Image = R8.Image;
                    labelNumeRealizare.Text = "Începe aventura";
                }
            }
        }

        bool isInimaDeOtel = false;
        private void RealizareInimaDeOtel()
        {
            if (!imagineR6.Visible && progressBarInimaDeOtel.Value < 1)
            {
                progressBarInimaDeOtel.Value++;
                labelInimaDeOtel.Text = progressBarInimaDeOtel.Value + "/1";

                if (progressBarInimaDeOtel.Value == 1)
                {
                    imagineR6.Visible = true;
                    Utilizator u = new Utilizator
                    {
                        UserName = labelUtilizator.Text
                    };

                    u.AdaugareRealizare(u, 6);

                    isInimaDeOtel = true;
                    panelRealizare.Visible = true;
                    pictureBoxRealizare.Image = R6.Image;
                    labelNumeRealizare.Text = "Inimă de oțel";
                }
            }
        }

        bool isManaLarga = false;
        private void RealizareManaLarga(int suma)
        {
            if (!imagineR9.Visible && progressBarManaLarga.Value < 1000)
            {
                int maxim = progressBarManaLarga.Value + suma;

                if (maxim <= progressBarManaLarga.MaximumValue)
                {
                    progressBarManaLarga.Value += suma;
                }
                else
                {
                    progressBarManaLarga.Value = 1000;
                }

                labelManaLarga.Text = progressBarManaLarga.Value.ToString() + "/1000";

                if (progressBarManaLarga.Value == 1000)
                {
                    SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.realizare);
                    audio.Play();

                    imagineR9.Visible = true;
                    Utilizator u = new Utilizator
                    {
                        UserName = labelUtilizator.Text
                    };

                    u.AdaugareRealizare(u, 9);

                    isManaLarga = true;

                    panelRealizare.Visible = true;
                    pictureBoxRealizare.Image = R9.Image;
                    labelNumeRealizare.Text = "Mână largă";
                }
            }
        }


        bool isPirat = false;
        private void RealizarePirat()
        {
            if (!imagineR7.Visible && progressBarPirat.Value < 5)
            {
                progressBarPirat.Value++;
                labelPirat.Text = progressBarPirat.Value.ToString() + "/5";

                if (progressBarPirat.Value == 5)
                {
                    SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.realizare);
                    audio.Play();

                    imagineR7.Visible = true;
                    Utilizator u = new Utilizator
                    {
                        UserName = labelUtilizator.Text
                    };

                    u.AdaugareRealizare(u, 7);

                    isPirat = true;

                    panelRealizare.Visible = true;
                    pictureBoxRealizare.Image = R7.Image;
                    labelNumeRealizare.Text = "Pirat";
                }
            }
        }

        bool isMarulDeAur = false;
        private void RealizareMaruldeAur()
        {
            if (!imagineR5.Visible && progressBarMarulDeAur.Value < 1)
            {
                progressBarMarulDeAur.Value++;
                labelMarulDeAur.Text = "1/1";

                if (progressBarMarulDeAur.Value == 1)
                {
                    SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.realizare);
                    audio.Play();

                    imagineR5.Visible = true;
                    Utilizator u = new Utilizator
                    {
                        UserName = labelUtilizator.Text
                    };

                    u.AdaugareRealizare(u, 5);

                    isMarulDeAur = true;

                    panelRealizare.Visible = true;
                    pictureBoxRealizare.Image = R5.Image;
                    labelNumeRealizare.Text = "Mărul de aur";
                }
            }
        }

        bool isTraznet = false;

        private void RealizareEstiTraznet()
        {
            if (!imagineR4.Visible && progressBarEstiTraznet.Value < 5)
            {
                progressBarEstiTraznet.Value++;
                labelEstiTraznet.Text = progressBarEstiTraznet.Value.ToString() + "/5";

                if (progressBarEstiTraznet.Value == 5)
                {
                    imagineR4.Visible = true;
                    Utilizator u = new Utilizator
                    {
                        UserName = labelUtilizator.Text
                    };

                    u.AdaugareRealizare(u, 4);

                    isTraznet = true;
                    panelRealizare.Visible = true;
                    pictureBoxRealizare.Image = R4.Image;
                    labelNumeRealizare.Text = "Ești trăsnet";
                }
            }
        }

        private void RealizareDeblocataCapitol()
        {
            if (isPrietenos)
            {
                pictureBoxRealizare.Image = R1.Image;
                labelNumeRealizare.Text = "Prietenos";
            }
            else if (isPrint)
            {
                pictureBoxRealizare.Image = R2.Image;
                labelNumeRealizare.Text = "Prinț";
            }
            else if (isRege)
            {
                pictureBoxRealizare.Image = R3.Image;
                labelNumeRealizare.Text = "Rege";
            }
            else if (isTraznet)
            {
                pictureBoxRealizare.Image = R4.Image;
                labelNumeRealizare.Text = "Ești trăsnet";
            }
            else if (isMarulDeAur)
            {
                pictureBoxRealizare.Image = R5.Image;
                labelNumeRealizare.Text = "Mărul de aur";
            }
            else if (isInimaDeOtel)
            {
                pictureBoxRealizare.Image = R6.Image;
                labelNumeRealizare.Text = "Inimă de oțel";
            }
            else if (isPirat)
            {
                pictureBoxRealizare.Image = R7.Image;
                labelNumeRealizare.Text = "Pirat";
            }
            else if (isIncepeAventura)
            {
                pictureBoxRealizare.Image = R8.Image;
                labelNumeRealizare.Text = "Începe aventura";
            }
            else if (isManaLarga)
            {
                pictureBoxRealizare.Image = R8.Image;
                labelNumeRealizare.Text = "Mână largă";
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            if (labelNumeRealizare.Text.Equals("Prietenos"))
            {
                isPrietenos = false;
            }
            else if (labelNumeRealizare.Text.Equals("Prinț"))
            {
                isPrint = false;
            }
            else if (labelNumeRealizare.Text.Equals("Rege"))
            {
                isRege = false;
            }
            else if (labelNumeRealizare.Text.Equals("Ești trăsnet"))
            {
                isTraznet = false;
            }
            else if (labelNumeRealizare.Text.Equals("Mărul de aur"))
            {
                isMarulDeAur = false;
            }
            else if (labelNumeRealizare.Text.Equals("Inimă de oțel"))
            {
                isInimaDeOtel = false;
            }
            else if (labelNumeRealizare.Text.Equals("Pirat"))
            {
                isPirat = false;
            }
            else if (labelNumeRealizare.Text.Equals("Începe aventura"))
            {
                isIncepeAventura = false;
            }
            else if (labelNumeRealizare.Text.Equals("Mână largă"))
            {
                isManaLarga = false;
            }

            if (isPrietenos == false
                && isPrint == false
                && isRege == false
                && isTraznet == false
                && isMarulDeAur == false
                && isInimaDeOtel == false
                && isPirat == false
                && isIncepeAventura == false
                && isManaLarga == false)
            {
                panelRealizare.Visible = false;
            }
            else
            {
                RealizareDeblocataCapitol();
            }
        }





        int numarVieti;
        int numarMere;
        int numarSariPeste;
        int numarPuncte;
        int numarTrofee;
        char sex = '\0';
        string email;
        [Obsolete]
        private void Initializare()
        {
            Utilizator u = new Utilizator
            {
                UserName = Login.utilizator
            };

            DataTable dt = u.ExtragereUtilizator(u);

            numarPuncte = Convert.ToInt32(dt.Rows[0][8]);
            numarVieti = Convert.ToInt32(dt.Rows[0][9]);
            numarTrofee = Convert.ToInt32(dt.Rows[0][10]);
            numarSariPeste = Convert.ToInt32(dt.Rows[0][11]);
            numarMere = Convert.ToInt32(dt.Rows[0][12]);

            byte[] img = (byte[])(dt.Rows[0][7]);
            MemoryStream ms = new MemoryStream(img);
            buttonModificareProfil.Image = pictureBoxAcasa.Image = imagineModificareProfil.Image = Image.FromStream(ms);

            labelSariPesteMeniu.Text = numarSariPeste.ToString();
            labelTrofeeMeniu.Text = labelNumarTrofee.Text = numarTrofee.ToString();
            labelMereMeniu.Text = numarMere.ToString();
            labelNumarPuncte.Text = numarPuncte.ToString();

            circleProgressBar.MaxValue = numarCapitole;
            circleProgressBar.Value = numarTrofee;

            labelCapitoleComplete.Text = numarTrofee.ToString() + "/" + numarCapitole.ToString();

            labelNivel.Text = "Nivel " + dt.Rows[0][13].ToString();
            progressBarNivel.Value = numarTrofee % 4;

            labelUtilizator.Text = labelUtilizatorAcasa.Text = dt.Rows[0][0].ToString();
            textBoxEmail.Text = email = dt.Rows[0][1].ToString();
            textBoxNume.Text = dt.Rows[0][2].ToString();
            textBoxPrenume.Text = dt.Rows[0][3].ToString();

            labelNumeAcasa.Text = textBoxNume.Text + " " + textBoxPrenume.Text;

            sex = Convert.ToChar(dt.Rows[0][4].ToString());
            textBoxStare.Text = labelAutoBiografie.Text = dt.Rows[0][5].ToString();
            textBoxPrimaInregistrare.Text = dt.Rows[0][6].ToString();
            textBoxParola.Text = textBoxParolaNoua.Text = Login.parola;

            GenerareDiagrama();
        }

        private void AfisareVieti()
        {
            if (numarVieti == 3)
            {
                pictureBoxViata1.Image = pictureBoxViata2.Image = pictureBoxViata3.Image = new Bitmap(bitQuiz.Properties.Resources.inima);
            }
            else if (numarVieti == 2)
            {
                pictureBoxViata1.Image = pictureBoxViata2.Image = new Bitmap(bitQuiz.Properties.Resources.inima);
                pictureBoxViata3.Image = new Bitmap(bitQuiz.Properties.Resources.fara_inima);
            }
            else if (numarVieti == 1)
            {
                pictureBoxViata1.Image = new Bitmap(bitQuiz.Properties.Resources.inima);
                pictureBoxViata2.Image = pictureBoxViata3.Image = new Bitmap(bitQuiz.Properties.Resources.fara_inima);
            }
            else
            {
                pictureBoxViata1.Image = pictureBoxViata2.Image = pictureBoxViata3.Image = new Bitmap(bitQuiz.Properties.Resources.fara_inima);
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            if (intrebari != null)
            {
                Eroare.textEroare = "Ești sigur că vrei să pierzi progresul?";
                using (Eroare er = new Eroare
                {
                    StartPosition = FormStartPosition.CenterParent
                })
                {
                    er.ShowDialog(this);
                }

                if (Eroare.OKCancel == "OK")
                {
                    Close();
                    Application.Exit();
                }
            }
            else
            {
                Close();
                Application.Exit();
            }
        }

        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        [Obsolete]
        private void ButtonLogOut_Click(object sender, EventArgs e)
        {
            if (intrebari != null)
            {
                Eroare.textEroare = "Ești sigur că vrei să pierzi progresul?";
                using (Eroare er = new Eroare
                {
                    StartPosition = FormStartPosition.CenterParent
                })
                {
                    er.ShowDialog(this);
                }

                if (Eroare.OKCancel == "OK")
                {
                    intrebari = null;
                    using (Login l = new Login())
                    {
                        Close();
                        l.ShowDialog();
                    }
                }
            }
            else
            {
                intrebari = null;
                using (Login l = new Login())
                {
                    Close();
                    l.ShowDialog();
                }
            }
        }

        // Configurarea butoanelor din panelMenu // -> Miscare userControlMenu // -> Schimbare culoare // -> Acces panel-uri
        private void ResetColorMenu()
        {
            buttonAcasa.BackColor = Color.FromArgb(36, 176, 246);
            buttonActivitate_click.BackColor = Color.FromArgb(36, 176, 246);
            buttonClasament.BackColor = Color.FromArgb(36, 176, 246);
            buttonMagazin.BackColor = Color.FromArgb(36, 176, 246);
            userControlMenu.Visible = true;
        }

        private void ButtonAcasa_MouseEnter(object sender, EventArgs e)
        {
            ResetColorMenu();

            userControlMenu.Location = new Point(275, 16);
            userControlMenu.Size = new Size(70, 26);
            buttonAcasa.BackColor = Color.FromArgb(27, 141, 198);
        }

        bool afiseazama = false;
        bool afiseazaMarul = false;
        private void AfisareRealizari(string s)
        {
            foreach (string c in s.Split(','))
            {
                if (c == "1")
                {
                    progressBarPrietenos.Value = 3;
                    labelPrietenos.Text = "3/3";
                    imagineR1.Visible = true;
                }
                else if (c == "2")
                {
                    progressBarPrint.Value = 10;
                    labelPrint.Text = "10/10";
                    imagineR2.Visible = true;
                }
                else if (c == "3")
                {
                    progressBarRege.MaximumValue = numarCapitole;
                    progressBarRege.Value = numarCapitole;
                    labelRege.Text = string.Format("{0}/{0}", numarCapitole);
                    imagineR3.Visible = true;
                }
                else if (c == "4")
                {
                    progressBarEstiTraznet.Value = 5;
                    labelEstiTraznet.Text = "5/5";
                    imagineR4.Visible = true;
                }
                else if (c == "5")
                {
                    afiseazaMarul = true;
                    progressBarMarulDeAur.Value = 1;
                    labelMarulDeAur.Text = "1/1";
                    imagineR5.Visible = true;

                }
                else if (c == "6")
                {
                    afiseazama = true;
                    progressBarInimaDeOtel.Value = 1;
                    labelInimaDeOtel.Text = "1/1";
                    imagineR6.Visible = true;
                }
                else if (c == "7")
                {
                    progressBarPirat.Value = 5;
                    labelPirat.Text = "5/5";
                    imagineR7.Visible = true;
                }
                else if (c == "8")
                {
                    progressBarIncepeAventura.Value = 4;
                    labelIncepeAventura.Text = "4/4";
                    imagineR8.Visible = true;
                }
                else if (c == "9")
                {
                    progressBarManaLarga.Value = 1000;
                    labelManaLarga.Text = "1000/1000";
                    imagineR9.Visible = true;
                }
            }
        }

        private void IntializareProgresRealizari(string numarTrasnete, string numarCufare, string mereCheltuite)
        {
            if (!imagineR1.Visible)
            {
                if (int.Parse(labelNumarUrmaresti.Text) > 3)
                {
                    progressBarPrietenos.Value = 3;
                    labelPrietenos.Text = "3/3";
                }
                else
                {
                    progressBarPrietenos.Value = int.Parse(labelNumarUrmaresti.Text);
                    labelPrietenos.Text = labelNumarUrmaresti.Text + "/3";
                }
            }

            if (!imagineR2.Visible)
            {
                if (numarTrofee > 10)
                {
                    progressBarPrint.Value = 10;
                    labelPrint.Text = string.Format("{0}/{1}", 10, 10);
                }
                else
                {
                    progressBarPrint.Value = numarTrofee;
                    labelPrint.Text = string.Format("{0}/{1}", numarTrofee, 10);
                }
            }

            if (!imagineR3.Visible)
            {
                progressBarRege.MaximumValue = numarCapitole;
                progressBarRege.Value = numarTrofee;
                labelRege.Text = string.Format("{0}/{1}", numarTrofee, numarCapitole);
            }

            if (!imagineR4.Visible)
            {
                if (int.Parse(numarTrasnete) > 5)
                {
                    progressBarEstiTraznet.Value = 5;
                    labelEstiTraznet.Text = "5/5";
                }
                else
                {
                    progressBarEstiTraznet.Value = int.Parse(numarTrasnete);
                    labelEstiTraznet.Text = numarTrasnete + "/5";
                }
            }

            if (!imagineR5.Visible)
            {
                if(afiseazaMarul == true)
                {
                    progressBarMarulDeAur.Value = 1;
                    labelMarulDeAur.Text = "1/1";
                }
                else
                {
                    progressBarMarulDeAur.Value = 0;
                    labelMarulDeAur.Text = "0/1";
                }
            }

            if (!imagineR6.Visible)
            {
                if(afiseazama == true)
                {
                    progressBarInimaDeOtel.Value = 1;
                    labelInimaDeOtel.Text = "1/1";
                }
                else
                {
                    progressBarInimaDeOtel.Value = 0;
                    labelInimaDeOtel.Text = "0/1";
                }
            }

            if (!imagineR7.Visible)
            {
                if (int.Parse(numarCufare) > 5)
                {
                    progressBarPirat.Value = 5;
                    labelPirat.Text = string.Format("{0}/{1}", 5, 5);
                }
                else
                {
                    progressBarPirat.Value = Convert.ToInt32(numarCufare);
                    labelPirat.Text = string.Format("{0}/{1}", numarCufare, 5);
                }
            }

            if (!imagineR8.Visible)
            {
                if (numarTrofee > 4)
                {
                    progressBarIncepeAventura.Value = 4;
                    labelIncepeAventura.Text = "4/4";
                }
                else
                {
                    progressBarIncepeAventura.Value = numarTrofee;
                    labelIncepeAventura.Text = numarTrofee.ToString() + "/4";
                }
            }

            if (!imagineR9.Visible)
            {
                if (int.Parse(mereCheltuite) > 1000)
                {
                    progressBarManaLarga.Value = 1000;
                    labelManaLarga.Text = string.Format("{0}/{1}", 1000, 1000);
                }
                else
                {
                    progressBarManaLarga.Value = int.Parse(mereCheltuite);
                    labelManaLarga.Text = string.Format("{0}/{1}", mereCheltuite, 1000);
                }
            }
        }

        bool isLoaded = false;

        private void AfisareAcasa()
        {
            panelUrmaritori.Visible = false;
            bunifuVScrollBar4.Value = 0;

            Utilizator u = new Utilizator
            {
                UserName = labelUtilizator.Text
            };

            DataTable dt = u.SelectUtilizatorAcasa(u);

            pictureBoxAcasa.Image = buttonModificareProfil.Image;

            labelUtilizatorAcasa.Text = dt.Rows[0][1].ToString();
            labelNumeAcasa.Text = dt.Rows[0][2].ToString();
            labelAutoBiografie.Text = dt.Rows[0][3].ToString();
            labelNumarUrmaritori.Text = dt.Rows[0][4].ToString();
            labelNumarUrmaresti.Text = dt.Rows[0][5].ToString();
            labelRaspunsuriCorecte.Text = "Răspunsuri corecte: " + dt.Rows[0][6].ToString();
            labelRaspunsuriGresite.Text = "Răspunsuri greșite: " + dt.Rows[0][7].ToString();
            labelTrazneteFolosite.Text = "Trăsnete folosite: " + dt.Rows[0][8].ToString();

            if (isLoaded == false)
            {
                isLoaded = true;
                imagineR1.Visible = imagineR2.Visible = imagineR3.Visible = imagineR4.Visible = imagineR5.Visible = imagineR6.Visible = imagineR7.Visible = imagineR8.Visible = imagineR9.Visible = false;

                AfisareRealizari(dt.Rows[0][11].ToString());
                IntializareProgresRealizari(dt.Rows[0][8].ToString(), dt.Rows[0][9].ToString(), dt.Rows[0][10].ToString());
            }
        }

        private void ButtonAcasa_Click(object sender, EventArgs e)
        {
            if (intrebari != null)
            {
                Eroare.textEroare = "Ești sigur că vrei să pierzi progresul?";
                using (Eroare er = new Eroare
                {
                    StartPosition = FormStartPosition.CenterParent
                })
                {
                    er.ShowDialog(this);
                }

                if (Eroare.OKCancel == "OK")
                {
                    ButtonAcasa_MouseEnter(sender, e);

                    intrebari = null;

                    panelPrimaPagina.BringToFront();

                    labelProgres.Text = "Progres";
                    buttonProgressNext.Image = new Bitmap(bitQuiz.Properties.Resources.chevron_right_120px_yellow);

                    AfisareVietiAcasa();
                    AfisareAcasa();
                    panelProgres1.BringToFront();
                    panelAcasa.BringToFront();
                }
            }
            else
            {
                ButtonAcasa_MouseEnter(sender, e);

                AfisareVietiAcasa();
                AfisareAcasa();
                panelPrimaPagina.BringToFront();
                panelAcasa.BringToFront();
            }
        }

        private void ButtonActivitate_MouseEnter(object sender, EventArgs e)
        {
            ResetColorMenu();

            userControlMenu.Location = new Point(359, 16);
            userControlMenu.Size = new Size(88, 26);
            buttonActivitate_click.BackColor = Color.FromArgb(27, 141, 198);
        }

        bool isAfisatClasament = false;

        private void AfisareClasament()
        {
            Utilizator u = new Utilizator();
            DataTable dt = u.Clasament();

            if (dt.Rows.Count == 15)
            {
                if (isAfisatClasament == false)
                {
                    isAfisatClasament = true;

                    panelClasamentUtilizatori.Visible = true;
                    panelBaraClasament.Visible = true;
                    panel14.Visible = true;

                    labelClasamentIndisponibil.Visible = false;
                    pictureBoxClasamentIndisponibil.Visible = false;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Label pozitie = new Label
                        {
                            Name = "Pozitie" + (i + 1),
                            AutoSize = false,
                            Size = new Size(45, 35),
                            Location = new Point(17, 25 + i * 91),
                            ForeColor = Color.FromArgb(248, 191, 51),
                            Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                            Text = dt.Rows[i][0].ToString() + ".",
                            TextAlign = ContentAlignment.TopCenter
                        };

                        panelClasamentUtilizatori.Controls.Add(pozitie);

                        Label userName = new Label
                        {
                            Name = "UserName" + (i + 1),
                            AutoSize = false,
                            Size = new Size(132, 19),
                            Location = new Point(124, 25 + i * 91),
                            ForeColor = Color.FromArgb(36, 176, 246),
                            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                            Text = dt.Rows[i][2].ToString(),
                            TextAlign = ContentAlignment.TopCenter
                        };

                        if (userName.Text.Equals(labelUtilizator.Text))
                        {
                            userName.ForeColor = Color.FromArgb(126, 181, 48);
                        }

                        panelClasamentUtilizatori.Controls.Add(userName);

                        Label Nume = new Label
                        {
                            Name = "Nume" + (i + 1),
                            AutoSize = false,
                            Size = new Size(130, 17),
                            Location = new Point(126, 43 + i * 91),
                            ForeColor = Color.Silver,
                            Font = new Font("Segoe UI Semibold", 9F),
                            Text = dt.Rows[i][3].ToString(),
                            TextAlign = ContentAlignment.TopCenter
                        };

                        panelClasamentUtilizatori.Controls.Add(Nume);


                        Label Capitole = new Label
                        {
                            Name = "Capitole" + (i + 1),
                            AutoSize = false,
                            Size = new Size(83, 25),
                            Location = new Point(310, 29 + i * 91),
                            ForeColor = Color.FromArgb(36, 176, 246),
                            Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                            Text = dt.Rows[i][4].ToString(),
                            TextAlign = ContentAlignment.TopCenter
                        };

                        panelClasamentUtilizatori.Controls.Add(Capitole);

                        Label Nivel = new Label
                        {
                            Name = "Nivel" + (i + 1),
                            AutoSize = false,
                            Size = new Size(85, 25),
                            Location = new Point(417, 29 + i * 91),
                            ForeColor = Color.FromArgb(36, 176, 246),
                            Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                            Text = "Nivel " + dt.Rows[i][5].ToString(),
                            TextAlign = ContentAlignment.TopCenter
                        };

                        panelClasamentUtilizatori.Controls.Add(Nivel);

                        Label Puncte = new Label
                        {
                            Name = "Puncte" + (i + 1),
                            AutoSize = false,
                            Size = new Size(72, 25),
                            Location = new Point(519, 29 + i * 91),
                            ForeColor = Color.FromArgb(248, 191, 51),
                            Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                            Text = dt.Rows[i][6].ToString(),
                            TextAlign = ContentAlignment.TopCenter
                        };

                        panelClasamentUtilizatori.Controls.Add(Puncte);

                        BunifuSeparator bs = new BunifuSeparator
                        {
                            Name = "ClasamentSeparator" + i,
                            Size = new Size(518, 14),
                            LineThickness = 2,
                            Location = new Point(46, 85 + i * 91)
                        };

                        if (i < dt.Rows.Count - 1)
                        {
                            bs.LineColor = Color.FromArgb(242, 242, 242);
                        }
                        else
                        {
                            bs.LineColor = Color.White;
                        }

                        panelClasamentUtilizatori.Controls.Add(bs);

                        Bunifu.Framework.UI.BunifuImageButton bib = new Bunifu.Framework.UI.BunifuImageButton
                        {
                            Name = "ClasamentImagine" + (i + 1),
                            Zoom = 3,
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Size = new Size(61, 51),
                            Location = new Point(62, 16 + i * 91),
                            Cursor = Cursors.Hand
                        };


                        bib.Click += (s, ex) => { AfisarePrieten(userName.Text, Capitole.Text, bib.Image); };


                        byte[] img = (byte[])(dt.Rows[i][1]);
                        MemoryStream ms = new MemoryStream(img);
                        bib.Image = Image.FromStream(ms);

                        panelClasamentUtilizatori.Controls.Add(bib);
                    }
                }
                else
                {
                    UpdateClasament(dt);
                }
            }
            else if (dt.Rows.Count < 15)
            {
                isAfisatClasament = false;
                panelClasamentUtilizatori.Visible = false;
                panelBaraClasament.Visible = false;
                panel14.Visible = false;

                labelClasamentIndisponibil.Visible = true;
                pictureBoxClasamentIndisponibil.Visible = true;
            }
        }


        private void UpdateClasament(DataTable dt)
        {
            int contorUserName, contorNume, contorCapitole, contorNivel, contorPuncte, contorImagine;
            contorUserName = contorNume = contorCapitole = contorNivel = contorPuncte = contorImagine = 1;

            foreach (Label lbl in panelClasamentUtilizatori.Controls.OfType<Label>())
            {
                if (lbl.Name.Contains("UserName"))
                {
                    if (lbl.Name.Equals("UserName" + contorUserName))
                    {
                        if (lbl.Text.Equals(labelUtilizator.Text))
                        {
                            lbl.ForeColor = Color.FromArgb(126, 181, 48);
                        }
                        else
                        {
                            lbl.ForeColor = Color.FromArgb(36, 176, 246);
                        }

                        lbl.Text = dt.Rows[contorUserName - 1][2].ToString();
                    }

                    contorUserName++;
                }
                else if (lbl.Name.Contains("Nume"))
                {
                    if (lbl.Name.Equals("Nume" + contorNume))
                    {
                        lbl.Text = dt.Rows[contorNume - 1][3].ToString();
                    }

                    contorNume++;
                }
                else if (lbl.Name.Contains("Capitole"))
                {
                    if (lbl.Name.Equals("Capitole" + contorCapitole))
                    {
                        lbl.Text = dt.Rows[contorCapitole - 1][4].ToString();
                    }

                    contorCapitole++;
                }
                else if (lbl.Name.Contains("Nivel"))
                {
                    if (lbl.Name.Equals("Nivel" + contorNivel))
                    {
                        lbl.Text = dt.Rows[contorNivel - 1][5].ToString();
                    }

                    contorNivel++;
                }
                else if (lbl.Name.Contains("Puncte"))
                {
                    if (lbl.Name.Equals("Puncte" + contorPuncte))
                    {
                        lbl.Text = dt.Rows[contorPuncte - 1][6].ToString();
                    }

                    contorPuncte++;
                }
            }

            foreach (Bunifu.Framework.UI.BunifuImageButton bib in panelClasamentUtilizatori.Controls.OfType<Bunifu.Framework.UI.BunifuImageButton>())
            {
                if (bib.Name.Equals("ClasamentImagine" + contorImagine))
                {
                    byte[] img = (byte[])(dt.Rows[contorImagine - 1][1]);
                    MemoryStream ms = new MemoryStream(img);
                    bib.Image = Image.FromStream(ms);

                    contorImagine++;
                }
            }
        }

        private void ButtonActivitate_Click(object sender, EventArgs e)
        {
            if (intrebari != null)
            {
                Eroare.textEroare = "Ești sigur că vrei să pierzi progresul?";
                using (Eroare er = new Eroare
                {
                    StartPosition = FormStartPosition.CenterParent
                })
                {
                    er.ShowDialog(this);
                }

                if (Eroare.OKCancel == "OK")
                {
                    ButtonActivitate_MouseEnter(sender, e);


                    intrebari = null;

                    panelPrimaPagina.BringToFront();


                    labelProgres.Text = "Progres";
                    buttonProgressNext.Image = new Bitmap(bitQuiz.Properties.Resources.chevron_right_120px_yellow);

                    panelProgres1.BringToFront();
                    panelActivitate.BringToFront();
                }
            }
            else
            {
                ButtonActivitate_MouseEnter(sender, e);

                panelPrimaPagina.BringToFront();
                panelActivitate.BringToFront();
            }
        }

        private void ButtonClasament_MouseEnter(object sender, EventArgs e)
        {
            ResetColorMenu();

            userControlMenu.Location = new Point(461, 16);
            userControlMenu.Size = new Size(91, 26);
            buttonClasament.BackColor = Color.FromArgb(27, 141, 198);
        }

        private void ButtonClasament_Click(object sender, EventArgs e)
        {
            if (intrebari != null)
            {
                Eroare.textEroare = "Ești sigur că vrei să pierzi progresul?";
                using (Eroare er = new Eroare
                {
                    StartPosition = FormStartPosition.CenterParent
                })
                {
                    er.ShowDialog(this);
                }

                if (Eroare.OKCancel == "OK")
                {
                    ButtonClasament_MouseEnter(sender, e);

                    intrebari = null;

                    AfisareClasament();
                    panelPrimaPagina.BringToFront();

                    labelProgres.Text = "Progres";
                    buttonProgressNext.Image = new Bitmap(bitQuiz.Properties.Resources.chevron_right_120px_yellow);

                    panelProgres1.BringToFront();
                    panelClasament.BringToFront();
                }
            }
            else
            {
                ButtonClasament_MouseEnter(sender, e);
                AfisareClasament();
                panelPrimaPagina.BringToFront();
                panelClasament.BringToFront();
            }
        }

        private void ButtonMagazin_MouseEnter(object sender, EventArgs e)
        {
            ResetColorMenu();

            userControlMenu.Location = new Point(561, 16);
            userControlMenu.Size = new Size(73, 26);
            buttonMagazin.BackColor = Color.FromArgb(27, 141, 198);
        }

        private void ButtonMagazin_Click(object sender, EventArgs e)
        {
            if (intrebari != null)
            {
                Eroare.textEroare = "Ești sigur că vrei să pierzi progresul?";
                using (Eroare er = new Eroare
                {
                    StartPosition = FormStartPosition.CenterParent
                })
                {
                    er.ShowDialog(this);
                }

                if (Eroare.OKCancel == "OK")
                {
                    ButtonMagazin_MouseEnter(sender, e);

                    panelCastig.Visible = false;
                    intrebari = null;

                    if (numarVieti == 3)
                    {
                        buttonPutere1.Visible = false;
                    }
                    else
                    {
                        buttonPutere1.Visible = true;
                    }

                    if (numarSariPeste == 3)
                    {
                        buttonPutere2.Visible = false;
                    }
                    else
                    {
                        buttonPutere2.Visible = true;
                    }

                    panelPrimaPagina.BringToFront();

                    labelProgres.Text = "Progres";
                    buttonProgressNext.Image = new Bitmap(bitQuiz.Properties.Resources.chevron_right_120px_yellow);
                    pictureBoxEroareMereCuriosii.Visible = pictureBoxEroareMereTraznet.Visible = pictureBoxEroareMereVieti.Visible = false;

                    panelProgres1.BringToFront();
                    panelMagazin.BringToFront();
                }
            }
            else
            {
                ButtonMagazin_MouseEnter(sender, e);

                panelCastig.Visible = false;

                if (numarVieti == 3)
                {
                    buttonPutere1.Visible = false;
                }
                else
                {
                    buttonPutere1.Visible = true;
                }

                if (numarSariPeste == 3)
                {
                    buttonPutere2.Visible = false;
                }
                else
                {
                    buttonPutere2.Visible = true;
                }

                pictureBoxEroareMereCuriosii.Visible = pictureBoxEroareMereTraznet.Visible = pictureBoxEroareMereVieti.Visible = false;

                panelPrimaPagina.BringToFront();
                panelMagazin.BringToFront();
            }
        }

        // Extragerea capitolelor din baza de date
        private void AfisareCapitole(int i)
        {
            Capitol c = new Capitol
            {
                Id = i,
                Utilizator = labelUtilizator.Text
            };
            using (DataTable dt = c.SelectCapitole(c))
            {
                // Afisare buton Inapoi

                if (i == 1)
                {
                    buttonInapoi.Visible = false;
                }
                else
                {
                    buttonInapoi.Visible = true;
                }

                // Afisare buton Inainte

                if (i + 6 <= numarCapitole)
                {
                    buttonInainte.Visible = true;
                }
                else
                {
                    buttonInainte.Visible = false;
                }

                // Afisare Capitole
                int numarLinii = Convert.ToInt32(dt.Rows.Count);

                if (numarLinii == 1)
                {
                    // Vizibilitate true pentru capitolul unu

                    buttonCapitol1.Visible = true;
                    labelDificultate1.Visible = true;
                    labelDescriere1.Visible = true;
                    labelPuncte1.Visible = true;
                    D1.Visible = true;
                    DD1.Visible = true;
                    P1.Visible = true;

                    buttonCapitol2.Visible = false;
                    labelDificultate2.Visible = false;
                    labelDescriere2.Visible = false;
                    labelPuncte2.Visible = false;
                    D2.Visible = false;
                    DD2.Visible = false;
                    P2.Visible = false;

                    buttonCapitol3.Visible = false;
                    labelDificultate3.Visible = false;
                    labelDescriere3.Visible = false;
                    labelPuncte3.Visible = false;
                    D3.Visible = false;
                    DD3.Visible = false;
                    P3.Visible = false;

                    buttonCapitol4.Visible = false;
                    labelDificultate4.Visible = false;
                    labelDescriere4.Visible = false;
                    labelPuncte4.Visible = false;
                    D4.Visible = false;
                    DD4.Visible = false;
                    P4.Visible = false;

                    buttonCapitol5.Visible = false;
                    labelDificultate5.Visible = false;
                    labelDescriere5.Visible = false;
                    labelPuncte5.Visible = false;
                    D5.Visible = false;
                    DD5.Visible = false;
                    P5.Visible = false;

                    buttonCapitol6.Visible = false;
                    labelDificultate6.Visible = false;
                    labelDescriere6.Visible = false;
                    labelPuncte6.Visible = false;
                    D6.Visible = false;
                    DD6.Visible = false;
                    P6.Visible = false;

                    // Afisare imagine

                    byte[] C1 = (byte[])(dt.Rows[0][1]);
                    MemoryStream C_1 = new MemoryStream(C1);
                    buttonCapitol1.Image = Image.FromStream(C_1);

                    // Afisare text 

                    labelDescriere1.Text = dt.Rows[0][2].ToString();
                    labelDificultate1.Text = dt.Rows[0][3].ToString();
                    labelPuncte1.Text = dt.Rows[0][4].ToString();

                    trofeu1.Visible = dt.Rows[0][5].ToString() == "0" ? false : true;
                    trofeu2.Visible = false;
                    trofeu3.Visible = false;
                    trofeu4.Visible = false;
                    trofeu5.Visible = false;
                    trofeu6.Visible = false;

                    labelRevinoMaiTarziu.Visible = false;
                    pictureRevinoMaiTarziu.Visible = false;
                }
                else if (numarLinii == 2)
                {
                    buttonCapitol1.Visible = true;
                    labelDificultate1.Visible = true;
                    labelDescriere1.Visible = true;
                    labelPuncte1.Visible = true;
                    D1.Visible = true;
                    DD1.Visible = true;
                    P1.Visible = true;

                    buttonCapitol2.Visible = true;
                    labelDificultate2.Visible = true;
                    labelDescriere2.Visible = true;
                    labelPuncte2.Visible = true;
                    D2.Visible = true;
                    DD2.Visible = true;
                    P2.Visible = true;

                    buttonCapitol3.Visible = false;
                    labelDificultate3.Visible = false;
                    labelDescriere3.Visible = false;
                    labelPuncte3.Visible = false;
                    D3.Visible = false;
                    DD3.Visible = false;
                    P3.Visible = false;

                    buttonCapitol4.Visible = false;
                    labelDificultate4.Visible = false;
                    labelDescriere4.Visible = false;
                    labelPuncte4.Visible = false;
                    D4.Visible = false;
                    DD4.Visible = false;
                    P4.Visible = false;

                    buttonCapitol5.Visible = false;
                    labelDificultate5.Visible = false;
                    labelDescriere5.Visible = false;
                    labelPuncte5.Visible = false;
                    D5.Visible = false;
                    DD5.Visible = false;
                    P5.Visible = false;

                    buttonCapitol6.Visible = false;
                    labelDificultate6.Visible = false;
                    labelDescriere6.Visible = false;
                    labelPuncte6.Visible = false;
                    D6.Visible = false;
                    DD6.Visible = false;
                    P6.Visible = false;

                    byte[] C1 = (byte[])(dt.Rows[0][1]);
                    MemoryStream C_1 = new MemoryStream(C1);
                    buttonCapitol1.Image = Image.FromStream(C_1);

                    labelDescriere1.Text = dt.Rows[0][2].ToString();
                    labelDificultate1.Text = dt.Rows[0][3].ToString();
                    labelPuncte1.Text = dt.Rows[0][4].ToString();

                    C1 = (byte[])(dt.Rows[1][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol2.Image = Image.FromStream(C_1);

                    labelDescriere2.Text = dt.Rows[1][2].ToString();
                    labelDificultate2.Text = dt.Rows[1][3].ToString();
                    labelPuncte2.Text = dt.Rows[1][4].ToString();

                    trofeu1.Visible = dt.Rows[0][5].ToString() == "0" ? false : true;
                    trofeu2.Visible = dt.Rows[1][5].ToString() == "0" ? false : true;
                    trofeu3.Visible = false;
                    trofeu4.Visible = false;
                    trofeu5.Visible = false;
                    trofeu6.Visible = false;

                    labelRevinoMaiTarziu.Visible = false;
                    pictureRevinoMaiTarziu.Visible = false;
                }
                else if (numarLinii == 3)
                {
                    buttonCapitol1.Visible = true;
                    labelDificultate1.Visible = true;
                    labelDescriere1.Visible = true;
                    labelPuncte1.Visible = true;
                    D1.Visible = true;
                    DD1.Visible = true;
                    P1.Visible = true;

                    buttonCapitol2.Visible = true;
                    labelDificultate2.Visible = true;
                    labelDescriere2.Visible = true;
                    labelPuncte2.Visible = true;
                    D2.Visible = true;
                    DD2.Visible = true;
                    P2.Visible = true;

                    buttonCapitol3.Visible = true;
                    labelDificultate3.Visible = true;
                    labelDescriere3.Visible = true;
                    labelPuncte3.Visible = true;
                    D3.Visible = true;
                    DD3.Visible = true;
                    P3.Visible = true;

                    buttonCapitol4.Visible = false;
                    labelDificultate4.Visible = false;
                    labelDescriere4.Visible = false;
                    labelPuncte4.Visible = false;
                    D4.Visible = false;
                    DD4.Visible = false;
                    P4.Visible = false;

                    buttonCapitol5.Visible = false;
                    labelDificultate5.Visible = false;
                    labelDescriere5.Visible = false;
                    labelPuncte5.Visible = false;
                    D5.Visible = false;
                    DD5.Visible = false;
                    P5.Visible = false;

                    buttonCapitol6.Visible = false;
                    labelDificultate6.Visible = false;
                    labelDescriere6.Visible = false;
                    labelPuncte6.Visible = false;
                    D6.Visible = false;
                    DD6.Visible = false;
                    P6.Visible = false;

                    byte[] C1 = (byte[])(dt.Rows[0][1]);
                    MemoryStream C_1 = new MemoryStream(C1);
                    buttonCapitol1.Image = Image.FromStream(C_1);

                    labelDescriere1.Text = dt.Rows[0][2].ToString();
                    labelDificultate1.Text = dt.Rows[0][3].ToString();
                    labelPuncte1.Text = dt.Rows[0][4].ToString();

                    C1 = (byte[])(dt.Rows[1][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol2.Image = Image.FromStream(C_1);

                    labelDescriere2.Text = dt.Rows[1][2].ToString();
                    labelDificultate2.Text = dt.Rows[1][3].ToString();
                    labelPuncte2.Text = dt.Rows[1][4].ToString();

                    C1 = (byte[])(dt.Rows[2][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol3.Image = Image.FromStream(C_1);

                    labelDescriere3.Text = dt.Rows[2][2].ToString();
                    labelDificultate3.Text = dt.Rows[2][3].ToString();
                    labelPuncte3.Text = dt.Rows[2][4].ToString();

                    trofeu1.Visible = dt.Rows[0][5].ToString() == "0" ? false : true;
                    trofeu2.Visible = dt.Rows[1][5].ToString() == "0" ? false : true;
                    trofeu3.Visible = dt.Rows[2][5].ToString() == "0" ? false : true;
                    trofeu4.Visible = false;
                    trofeu5.Visible = false;
                    trofeu6.Visible = false;

                    labelRevinoMaiTarziu.Visible = false;
                    pictureRevinoMaiTarziu.Visible = false;
                }
                else if (numarLinii == 4)
                {
                    buttonCapitol1.Visible = true;
                    labelDificultate1.Visible = true;
                    labelDescriere1.Visible = true;
                    labelPuncte1.Visible = true;
                    D1.Visible = true;
                    DD1.Visible = true;
                    P1.Visible = true;

                    buttonCapitol2.Visible = true;
                    labelDificultate2.Visible = true;
                    labelDescriere2.Visible = true;
                    labelPuncte2.Visible = true;
                    D2.Visible = true;
                    DD2.Visible = true;
                    P2.Visible = true;

                    buttonCapitol3.Visible = true;
                    labelDificultate3.Visible = true;
                    labelDescriere3.Visible = true;
                    labelPuncte3.Visible = true;
                    D3.Visible = true;
                    DD3.Visible = true;
                    P3.Visible = true;

                    buttonCapitol4.Visible = true;
                    labelDificultate4.Visible = true;
                    labelDescriere4.Visible = true;
                    labelPuncte4.Visible = true;
                    D4.Visible = true;
                    DD4.Visible = true;
                    P4.Visible = true;

                    buttonCapitol5.Visible = false;
                    labelDificultate5.Visible = false;
                    labelDescriere5.Visible = false;
                    labelPuncte5.Visible = false;
                    D5.Visible = false;
                    DD5.Visible = false;
                    P5.Visible = false;

                    buttonCapitol6.Visible = false;
                    labelDificultate6.Visible = false;
                    labelDescriere6.Visible = false;
                    labelPuncte6.Visible = false;
                    D6.Visible = false;
                    DD6.Visible = false;
                    P6.Visible = false;

                    byte[] C1 = (byte[])(dt.Rows[0][1]);
                    MemoryStream C_1 = new MemoryStream(C1);
                    buttonCapitol1.Image = Image.FromStream(C_1);

                    labelDescriere1.Text = dt.Rows[0][2].ToString();
                    labelDificultate1.Text = dt.Rows[0][3].ToString();
                    labelPuncte1.Text = dt.Rows[0][4].ToString();

                    C1 = (byte[])(dt.Rows[1][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol2.Image = Image.FromStream(C_1);

                    labelDescriere2.Text = dt.Rows[1][2].ToString();
                    labelDificultate2.Text = dt.Rows[1][3].ToString();
                    labelPuncte2.Text = dt.Rows[1][4].ToString();

                    C1 = (byte[])(dt.Rows[2][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol3.Image = Image.FromStream(C_1);

                    labelDescriere3.Text = dt.Rows[2][2].ToString();
                    labelDificultate3.Text = dt.Rows[2][3].ToString();
                    labelPuncte3.Text = dt.Rows[2][4].ToString();

                    C1 = (byte[])(dt.Rows[3][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol4.Image = Image.FromStream(C_1);

                    labelDescriere4.Text = dt.Rows[3][2].ToString();
                    labelDificultate4.Text = dt.Rows[3][3].ToString();
                    labelPuncte4.Text = dt.Rows[3][4].ToString();

                    trofeu1.Visible = dt.Rows[0][5].ToString() == "0" ? false : true;
                    trofeu2.Visible = dt.Rows[1][5].ToString() == "0" ? false : true;
                    trofeu3.Visible = dt.Rows[2][5].ToString() == "0" ? false : true;
                    trofeu4.Visible = dt.Rows[3][5].ToString() == "0" ? false : true;
                    trofeu5.Visible = false;
                    trofeu6.Visible = false;

                    labelRevinoMaiTarziu.Visible = false;
                    pictureRevinoMaiTarziu.Visible = false;

                }
                else if (numarLinii == 5)
                {
                    buttonCapitol1.Visible = true;
                    labelDificultate1.Visible = true;
                    labelDescriere1.Visible = true;
                    labelPuncte1.Visible = true;
                    D1.Visible = true;
                    DD1.Visible = true;
                    P1.Visible = true;

                    buttonCapitol2.Visible = true;
                    labelDificultate2.Visible = true;
                    labelDescriere2.Visible = true;
                    labelPuncte2.Visible = true;
                    D2.Visible = true;
                    DD2.Visible = true;
                    P2.Visible = true;

                    buttonCapitol3.Visible = true;
                    labelDificultate3.Visible = true;
                    labelDescriere3.Visible = true;
                    labelPuncte3.Visible = true;
                    D3.Visible = true;
                    DD3.Visible = true;
                    P3.Visible = true;

                    buttonCapitol4.Visible = true;
                    labelDificultate4.Visible = true;
                    labelDescriere4.Visible = true;
                    labelPuncte4.Visible = true;
                    D4.Visible = true;
                    DD4.Visible = true;
                    P4.Visible = true;

                    buttonCapitol5.Visible = true;
                    labelDificultate5.Visible = true;
                    labelDescriere5.Visible = true;
                    labelPuncte5.Visible = true;
                    D5.Visible = true;
                    DD5.Visible = true;
                    P5.Visible = true;

                    buttonCapitol6.Visible = false;
                    labelDificultate6.Visible = false;
                    labelDescriere6.Visible = false;
                    labelPuncte6.Visible = false;
                    D6.Visible = false;
                    DD6.Visible = false;
                    P6.Visible = false;

                    byte[] C1 = (byte[])(dt.Rows[0][1]);
                    MemoryStream C_1 = new MemoryStream(C1);
                    buttonCapitol1.Image = Image.FromStream(C_1);

                    labelDescriere1.Text = dt.Rows[0][2].ToString();
                    labelDificultate1.Text = dt.Rows[0][3].ToString();
                    labelPuncte1.Text = dt.Rows[0][4].ToString();

                    C1 = (byte[])(dt.Rows[1][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol2.Image = Image.FromStream(C_1);

                    labelDescriere2.Text = dt.Rows[1][2].ToString();
                    labelDificultate2.Text = dt.Rows[1][3].ToString();
                    labelPuncte2.Text = dt.Rows[1][4].ToString();

                    C1 = (byte[])(dt.Rows[2][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol3.Image = Image.FromStream(C_1);

                    labelDescriere3.Text = dt.Rows[2][2].ToString();
                    labelDificultate3.Text = dt.Rows[2][3].ToString();
                    labelPuncte3.Text = dt.Rows[2][4].ToString();

                    C1 = (byte[])(dt.Rows[3][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol4.Image = Image.FromStream(C_1);

                    labelDescriere4.Text = dt.Rows[3][2].ToString();
                    labelDificultate4.Text = dt.Rows[3][3].ToString();
                    labelPuncte4.Text = dt.Rows[3][4].ToString();

                    C1 = (byte[])(dt.Rows[4][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol5.Image = Image.FromStream(C_1);

                    labelDescriere5.Text = dt.Rows[4][2].ToString();
                    labelDificultate5.Text = dt.Rows[4][3].ToString();
                    labelPuncte5.Text = dt.Rows[4][4].ToString();

                    trofeu1.Visible = dt.Rows[0][5].ToString() == "0" ? false : true;
                    trofeu2.Visible = dt.Rows[1][5].ToString() == "0" ? false : true;
                    trofeu3.Visible = dt.Rows[2][5].ToString() == "0" ? false : true;
                    trofeu4.Visible = dt.Rows[3][5].ToString() == "0" ? false : true;
                    trofeu5.Visible = dt.Rows[4][5].ToString() == "0" ? false : true;
                    trofeu6.Visible = false;

                    labelRevinoMaiTarziu.Visible = false;
                    pictureRevinoMaiTarziu.Visible = false;

                }
                else if (numarLinii == 6)
                {
                    buttonCapitol1.Visible = true;
                    labelDificultate1.Visible = true;
                    labelDescriere1.Visible = true;
                    labelPuncte1.Visible = true;
                    D1.Visible = true;
                    DD1.Visible = true;
                    P1.Visible = true;

                    buttonCapitol2.Visible = true;
                    labelDificultate2.Visible = true;
                    labelDescriere2.Visible = true;
                    labelPuncte2.Visible = true;
                    D2.Visible = true;
                    DD2.Visible = true;
                    P2.Visible = true;

                    buttonCapitol3.Visible = true;
                    labelDificultate3.Visible = true;
                    labelDescriere3.Visible = true;
                    labelPuncte3.Visible = true;
                    D3.Visible = true;
                    DD3.Visible = true;
                    P3.Visible = true;

                    buttonCapitol4.Visible = true;
                    labelDificultate4.Visible = true;
                    labelDescriere4.Visible = true;
                    labelPuncte4.Visible = true;
                    D4.Visible = true;
                    DD4.Visible = true;
                    P4.Visible = true;

                    buttonCapitol5.Visible = true;
                    labelDificultate5.Visible = true;
                    labelDescriere5.Visible = true;
                    labelPuncte5.Visible = true;
                    D5.Visible = true;
                    DD5.Visible = true;
                    P5.Visible = true;

                    buttonCapitol6.Visible = true;
                    labelDificultate6.Visible = true;
                    labelDescriere6.Visible = true;
                    labelPuncte6.Visible = true;
                    D6.Visible = true;
                    DD6.Visible = true;
                    P6.Visible = true;

                    byte[] C1 = (byte[])(dt.Rows[0][1]);
                    MemoryStream C_1 = new MemoryStream(C1);
                    buttonCapitol1.Image = Image.FromStream(C_1);

                    labelDescriere1.Text = dt.Rows[0][2].ToString();
                    labelDificultate1.Text = dt.Rows[0][3].ToString();
                    labelPuncte1.Text = dt.Rows[0][4].ToString();

                    C1 = (byte[])(dt.Rows[1][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol2.Image = Image.FromStream(C_1);

                    labelDescriere2.Text = dt.Rows[1][2].ToString();
                    labelDificultate2.Text = dt.Rows[1][3].ToString();
                    labelPuncte2.Text = dt.Rows[1][4].ToString();

                    C1 = (byte[])(dt.Rows[2][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol3.Image = Image.FromStream(C_1);

                    labelDescriere3.Text = dt.Rows[2][2].ToString();
                    labelDificultate3.Text = dt.Rows[2][3].ToString();
                    labelPuncte3.Text = dt.Rows[2][4].ToString();

                    C1 = (byte[])(dt.Rows[3][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol4.Image = Image.FromStream(C_1);

                    labelDescriere4.Text = dt.Rows[3][2].ToString();
                    labelDificultate4.Text = dt.Rows[3][3].ToString();
                    labelPuncte4.Text = dt.Rows[3][4].ToString();

                    C1 = (byte[])(dt.Rows[4][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol5.Image = Image.FromStream(C_1);

                    labelDescriere5.Text = dt.Rows[4][2].ToString();
                    labelDificultate5.Text = dt.Rows[4][3].ToString();
                    labelPuncte5.Text = dt.Rows[4][4].ToString();

                    C1 = (byte[])(dt.Rows[5][1]);
                    C_1 = new MemoryStream(C1);
                    buttonCapitol6.Image = Image.FromStream(C_1);

                    labelDescriere6.Text = dt.Rows[5][2].ToString();
                    labelDificultate6.Text = dt.Rows[5][3].ToString();
                    labelPuncte6.Text = dt.Rows[5][4].ToString();

                    trofeu1.Visible = dt.Rows[0][5].ToString() == "0" ? false : true;
                    trofeu2.Visible = dt.Rows[1][5].ToString() == "0" ? false : true;
                    trofeu3.Visible = dt.Rows[2][5].ToString() == "0" ? false : true;
                    trofeu4.Visible = dt.Rows[3][5].ToString() == "0" ? false : true;
                    trofeu5.Visible = dt.Rows[4][5].ToString() == "0" ? false : true;
                    trofeu6.Visible = dt.Rows[5][5].ToString() == "0" ? false : true;

                    labelRevinoMaiTarziu.Visible = false;
                    pictureRevinoMaiTarziu.Visible = false;

                }
                else if (numarLinii == 0 && i == 1)
                {
                    buttonCapitol1.Visible = false;
                    labelDificultate1.Visible = false;
                    labelDescriere1.Visible = false;
                    labelPuncte1.Visible = false;
                    D1.Visible = false;
                    DD1.Visible = false;
                    P1.Visible = false;

                    buttonCapitol2.Visible = false;
                    labelDificultate2.Visible = false;
                    labelDescriere2.Visible = false;
                    labelPuncte2.Visible = false;
                    D2.Visible = false;
                    DD2.Visible = false;
                    P2.Visible = false;

                    buttonCapitol3.Visible = false;
                    labelDificultate3.Visible = false;
                    labelDescriere3.Visible = false;
                    labelPuncte3.Visible = false;
                    D3.Visible = false;
                    DD3.Visible = false;
                    P3.Visible = false;

                    buttonCapitol4.Visible = false;
                    labelDificultate4.Visible = false;
                    labelDescriere4.Visible = false;
                    labelPuncte4.Visible = false;
                    D4.Visible = false;
                    DD4.Visible = false;
                    P4.Visible = false;

                    buttonCapitol5.Visible = false;
                    labelDificultate5.Visible = false;
                    labelDescriere5.Visible = false;
                    labelPuncte5.Visible = false;
                    D5.Visible = false;
                    DD5.Visible = false;
                    P5.Visible = false;

                    buttonCapitol6.Visible = false;
                    labelDificultate6.Visible = false;
                    labelDescriere6.Visible = false;
                    labelPuncte6.Visible = false;
                    D6.Visible = false;
                    DD6.Visible = false;
                    P6.Visible = false;

                    labelRevinoMaiTarziu.Visible = true;
                    pictureRevinoMaiTarziu.Visible = true;

                    trofeu1.Visible = false;
                    trofeu2.Visible = false;
                    trofeu3.Visible = false;
                    trofeu4.Visible = false;
                    trofeu5.Visible = false;
                    trofeu6.Visible = false;

                    buttonInapoi.Visible = false;
                    buttonInainte.Visible = false;
                }
            }
        }

        // Configurare butoane pagini 
        int numarPagina = 1;
        int numarCapitole = 0;
        private void Capitole()
        {
            Capitol c = new Capitol();
            numarCapitole = c.NumarCapitole();
        }
        private void ButtonInainte_Click(object sender, EventArgs e)
        {
            numarPagina += 6;
            Capitole();
            AfisareCapitole(numarPagina);
        }

        private void ButtonInapoi_Click(object sender, EventArgs e)
        {
            numarPagina -= 6;
            Capitole();
            AfisareCapitole(numarPagina);
        }

        // Alegere Capitole
        string capitol;
        string dificultate;
        int puncteCapitol;
        private void ButtonCapitol1_Click(object sender, EventArgs e)
        {
            if (trofeu1.Visible == false)
            {
                if (numarVieti > 0 && labelPuncte1.Text != "0")
                {
                    intrebari = null;
                    capitol = labelDescriere1.Text;
                    dificultate = labelDificultate1.Text;
                    puncteCapitol = int.Parse(labelPuncte1.Text);

                    GenerareIntrebari(capitol, dificultate);
                    labelIntrebareCapitol.Text = capitol;

                }
                else
                {
                    if (labelPuncte1.Text == "0")
                    {
                        Eroare.textEroare = "Nu sunt întrebări disponibile";
                    }
                    else
                    {
                        Eroare.textEroare = "Vieți indisponibile";
                    }

                    using (Eroare er = new Eroare
                    {
                        StartPosition = FormStartPosition.CenterParent
                    })
                    {
                        er.ShowDialog(this);
                    }
                }
            }
        }

        private void ButtonCapitol2_Click(object sender, EventArgs e)
        {
            if (trofeu2.Visible == false)
            {
                if (numarVieti > 0 && labelPuncte2.Text != "0")
                {
                    intrebari = null;
                    capitol = labelDescriere2.Text;
                    dificultate = labelDificultate2.Text;
                    puncteCapitol = int.Parse(labelPuncte2.Text);

                    GenerareIntrebari(capitol, dificultate);
                    labelIntrebareCapitol.Text = capitol;

                }
                else
                {
                    if (labelPuncte2.Text == "0")
                    {
                        Eroare.textEroare = "Nu sunt întrebări disponibile";
                    }
                    else
                    {
                        Eroare.textEroare = "Vieți indisponibile";
                    }

                    using (Eroare er = new Eroare
                    {
                        StartPosition = FormStartPosition.CenterParent
                    })
                    {
                        er.ShowDialog(this);
                    }
                }
            }
        }

        private void ButtonCapitol3_Click(object sender, EventArgs e)
        {
            if (trofeu3.Visible == false)
            {
                if (numarVieti > 0 && labelPuncte3.Text != "0")
                {
                    intrebari = null;
                    capitol = labelDescriere3.Text;
                    dificultate = labelDificultate3.Text;
                    puncteCapitol = int.Parse(labelPuncte3.Text);

                    GenerareIntrebari(capitol, dificultate);
                    labelIntrebareCapitol.Text = capitol;

                }
                else
                {
                    if (labelPuncte3.Text == "0")
                    {
                        Eroare.textEroare = "Nu sunt întrebări disponibile";
                    }
                    else
                    {
                        Eroare.textEroare = "Vieți indisponibile";
                    }

                    using (Eroare er = new Eroare
                    {
                        StartPosition = FormStartPosition.CenterParent
                    })
                    {
                        er.ShowDialog(this);
                    }
                }
            }
        }

        private void ButtonCapitol4_Click(object sender, EventArgs e)
        {
            if (trofeu4.Visible == false)
            {
                if (numarVieti > 0 && labelPuncte4.Text != "0")
                {
                    intrebari = null;
                    capitol = labelDescriere4.Text;
                    dificultate = labelDificultate4.Text;
                    puncteCapitol = int.Parse(labelPuncte4.Text);

                    GenerareIntrebari(capitol, dificultate);
                    labelIntrebareCapitol.Text = capitol;

                }
                else
                {
                    if (labelPuncte4.Text == "0")
                    {
                        Eroare.textEroare = "Nu sunt întrebări disponibile";
                    }
                    else
                    {
                        Eroare.textEroare = "Vieți indisponibile";
                    }

                    using (Eroare er = new Eroare
                    {
                        StartPosition = FormStartPosition.CenterParent
                    })
                    {
                        er.ShowDialog(this);
                    }
                }
            }
        }

        private void ButtonCapitol5_Click(object sender, EventArgs e)
        {
            if (trofeu5.Visible == false)
            {
                if (numarVieti > 0 && labelPuncte5.Text != "0")
                {
                    intrebari = null;
                    capitol = labelDescriere5.Text;
                    dificultate = labelDificultate5.Text;
                    puncteCapitol = int.Parse(labelPuncte5.Text);

                    GenerareIntrebari(capitol, dificultate);
                    labelIntrebareCapitol.Text = capitol;

                }
                else
                {
                    if (labelPuncte5.Text == "0")
                    {
                        Eroare.textEroare = "Nu sunt întrebări disponibile";
                    }
                    else
                    {
                        Eroare.textEroare = "Vieți indisponibile";
                    }

                    using (Eroare er = new Eroare
                    {
                        StartPosition = FormStartPosition.CenterParent
                    })
                    {
                        er.ShowDialog(this);
                    }
                }
            }
        }

        private void ButtonCapitol6_Click(object sender, EventArgs e)
        {
            if (trofeu6.Visible == false)
            {
                if (numarVieti > 0 && labelPuncte6.Text != "0")
                {
                    intrebari = null;
                    capitol = labelDescriere6.Text;
                    dificultate = labelDificultate6.Text;
                    puncteCapitol = int.Parse(labelPuncte6.Text);

                    GenerareIntrebari(capitol, dificultate);
                    labelIntrebareCapitol.Text = capitol;
                }
                else
                {
                    if (labelPuncte6.Text == "0")
                    {
                        Eroare.textEroare = "Nu sunt întrebări disponibile";
                    }
                    else
                    {
                        Eroare.textEroare = "Vieți indisponibile";
                    }

                    using (Eroare er = new Eroare
                    {
                        StartPosition = FormStartPosition.CenterParent
                    })
                    {
                        er.ShowDialog(this);
                    }
                }
            }
        }

        // Extragere intrebari din baza de date

        int tipIntrebare;
        string raspunsCorect;
        static DataTable intrebari;
        int linie = 0;
        int numarIntrebari = 0;
        int inimiInitiale;
        private void GenerareIntrebari(string descriere, string dificultate)
        {
            if (intrebari == null)
            {
                Intrebare i = new Intrebare
                {
                    Descriere = descriere,
                    Dificultate = dificultate,
                };

                intrebari = i.SelectIntrebari(i);
                linie = 0;
                numarIntrebari = intrebari.Rows.Count;

                progressBarCapitol.Value = 0;
                inimiInitiale = numarVieti;

                AfisareVieti();
            }

            if (intrebari.Rows.Count > 0 && linie < intrebari.Rows.Count)
            {
                ClearVerificare();
                tipIntrebare = Convert.ToInt32(intrebari.Rows[linie][1]);

                if (tipIntrebare == 1)
                {
                    Intrebare j = new Intrebare
                    {
                        IntrebareId = Convert.ToInt32(intrebari.Rows[linie][0])
                    };
                    DataTable dt = j.SelectIntrebariTip1(j);

                    labelEnuntTip1.Text = dt.Rows[0][1].ToString();
                    labelEnuntTip1.Text = labelEnuntTip1.Text;

                    raspunsCorect = dt.Rows[0][2].ToString();

                    panelIntrebareTip1.BringToFront();

                }
                else if (tipIntrebare == 2)
                {
                    raspunsCorect = null;

                    Intrebare j = new Intrebare
                    {
                        IntrebareId = Convert.ToInt32(intrebari.Rows[linie][0])
                    };
                    DataTable dt = j.SelectIntrebariTip2(j);

                    foreach (char c in dt.Rows[0][5].ToString())
                    {
                        if (c == 'A')
                        {
                            raspunsCorect += dt.Rows[0][2].ToString() + ", ";
                        }
                        else if (c == 'B')
                        {
                            raspunsCorect += dt.Rows[0][3].ToString() + ", ";
                        }
                        else if (c == 'C')
                        {
                            raspunsCorect += dt.Rows[0][4].ToString() + ", ";
                        }
                    }

                    raspunsCorect = raspunsCorect.Remove(raspunsCorect.Length - 2, 2);

                    Random rnd = new Random();
                    int A1 = rnd.Next(2, 5);

                    int A2;
                    do
                    {
                        A2 = rnd.Next(2, 5);
                    } while (A2 == A1);

                    int A3;

                    if ((A1 == 2 && A2 == 3) || (A1 == 3 && A2 == 2))
                    {
                        A3 = 4;
                    }
                    else if ((A1 == 2 && A2 == 4) || (A1 == 4 && A2 == 2))
                    {
                        A3 = 3;
                    }
                    else
                    {
                        A3 = 2;
                    }

                    labelEnuntTip2.Text = dt.Rows[0][1].ToString();
                    labelEnuntTip2.Text = labelEnuntTip2.Text;
                    buttonA.Text = dt.Rows[0][A1].ToString();
                    buttonB.Text = dt.Rows[0][A2].ToString();
                    buttonC.Text = dt.Rows[0][A3].ToString();

                    panelIntrebareTip2.BringToFront();
                }
                else if (tipIntrebare == 3)
                {
                    Intrebare j = new Intrebare
                    {
                        IntrebareId = Convert.ToInt32(intrebari.Rows[linie][0])
                    };
                    DataTable dt = j.SelectIntrebariTip3(j);

                    Random rnd = new Random();
                    int A1 = rnd.Next(3, 6);

                    int A2;
                    do
                    {
                        A2 = rnd.Next(3, 6);
                    } while (A2 == A1);

                    int A3;

                    if ((A1 == 3 && A2 == 4) || (A1 == 4 && A2 == 3))
                    {
                        A3 = 5;
                    }
                    else if ((A1 == 3 && A2 == 5) || (A1 == 5 && A2 == 3))
                    {
                        A3 = 4;
                    }
                    else
                    {
                        A3 = 3;
                    }

                    labelEnuntTip3.Text = dt.Rows[0][1].ToString();

                    labelA.Text = dt.Rows[0][A1].ToString();
                    labelB.Text = dt.Rows[0][A2].ToString();
                    labelC.Text = dt.Rows[0][A3].ToString();

                    labelEnuntSuplimentar.Text = dt.Rows[0][2].ToString();
                    labelEnuntSuplimentar.Text = labelEnuntSuplimentar.Text;

                    byte[] C1 = (byte[])(dt.Rows[0][A1 + 3]);
                    MemoryStream C_1 = new MemoryStream(C1);
                    imageA.Image = Image.FromStream(C_1);

                    C1 = (byte[])(dt.Rows[0][A2 + 3]);
                    C_1 = new MemoryStream(C1);
                    imageB.Image = Image.FromStream(C_1);

                    C1 = (byte[])(dt.Rows[0][A3 + 3]);
                    C_1 = new MemoryStream(C1);
                    imageC.Image = Image.FromStream(C_1);

                    raspunsCorect = dt.Rows[0][9].ToString();

                    panelIntrebareTip3.BringToFront();
                }
                else if (tipIntrebare == 4)
                {
                    buttonText1.Text = buttonText2.Text = buttonText3.Text = buttonText4.Text = buttonText5.Text = raspunsCorect = null;

                    Intrebare j = new Intrebare
                    {
                        IntrebareId = Convert.ToInt32(intrebari.Rows[linie][0])
                    };
                    DataTable dt = j.SelectIntrebariTip4(j);

                    labelEnuntIntrebare4.Text = dt.Rows[0][1].ToString();

                    foreach (char c in dt.Rows[0][7].ToString())
                    {
                        if (c == 'A')
                        {
                            raspunsCorect += dt.Rows[0][2].ToString() + ", ";
                        }
                        else if (c == 'B')
                        {
                            raspunsCorect += dt.Rows[0][3].ToString() + ", ";
                        }
                        else if (c == 'C')
                        {
                            raspunsCorect += dt.Rows[0][4].ToString() + ", ";
                        }
                        else if (c == 'D')
                        {
                            raspunsCorect += dt.Rows[0][5].ToString() + ", ";
                        }
                        else if (c == 'E')
                        {
                            raspunsCorect += dt.Rows[0][6].ToString() + ", ";
                        }
                    }

                    raspunsCorect = raspunsCorect.Remove(raspunsCorect.Length - 2, 2);

                    Random rnd = new Random();

                    int A1 = rnd.Next(2, 7);

                    int A2;

                    do
                    {
                        A2 = rnd.Next(2, 7);
                    } while (A2 == A1);

                    int A3;
                    do
                    {
                        A3 = rnd.Next(2, 7);
                    } while (A3 == A1 || A3 == A2);

                    int A4;
                    do
                    {
                        A4 = rnd.Next(2, 7);
                    } while (A4 == A1 || A4 == A2 || A4 == A3);

                    int A5;
                    do
                    {
                        A5 = rnd.Next(2, 7);
                    } while (A5 == A1 || A5 == A2 || A5 == A3 || A5 == A4);

                    btn1.Text = dt.Rows[0][A1].ToString();
                    btn2.Text = dt.Rows[0][A2].ToString();
                    btn3.Text = dt.Rows[0][A3].ToString();
                    btn4.Text = dt.Rows[0][A4].ToString();
                    btn5.Text = dt.Rows[0][A5].ToString();

                    panelIntrebareTip4.BringToFront();
                }

                if (linie == 0)
                {
                    progressBarCapitol.ProgressColorLeft = Color.FromArgb(248, 191, 51);
                    progressBarCapitol.ProgressColorRight = Color.FromArgb(248, 191, 51);
                    panelIntrebare.BringToFront();
                }
                linie++;
            }
        }

        // Configurare butoane raspuns

        private void ButtonVerificare_Click(object sender, EventArgs e)
        {
            if (tipIntrebare == 1)
            {
                if (txtInserareCod.Text != "")
                {
                    buttonVerificare.Visible = false;
                    buttonTrazneste.Visible = false;
                    txtInserareCod.ReadOnly = true;

                    if (txtInserareCod.Text == raspunsCorect)
                    {
                        RaspunsCorect();
                    }
                    else
                    {
                        RaspunsGresit(raspunsCorect);
                    }
                }
            }
            else if (tipIntrebare == 2)
            {
                if (raspunsA != null || raspunsB != null || raspunsC != null)
                {
                    buttonVerificare.Visible = false;
                    buttonTrazneste.Visible = false;

                    string raspunsCorectFaraVirgule = raspunsCorect.Replace(", ", "");

                    if (raspunsA + raspunsB + raspunsC == raspunsCorectFaraVirgule ||
                        raspunsA + raspunsC + raspunsB == raspunsCorectFaraVirgule ||
                        raspunsB + raspunsA + raspunsC == raspunsCorectFaraVirgule ||
                        raspunsB + raspunsC + raspunsA == raspunsCorectFaraVirgule ||
                        raspunsC + raspunsA + raspunsB == raspunsCorectFaraVirgule ||
                        raspunsC + raspunsB + raspunsA == raspunsCorectFaraVirgule ||
                        raspunsA + raspunsB + raspunsC == raspunsCorectFaraVirgule ||
                        raspunsA + raspunsC + raspunsB == raspunsCorectFaraVirgule ||
                        raspunsB + raspunsA + raspunsC == raspunsCorectFaraVirgule ||
                        raspunsB + raspunsC + raspunsA == raspunsCorectFaraVirgule ||
                        raspunsC + raspunsA + raspunsB == raspunsCorectFaraVirgule ||
                        raspunsC + raspunsB + raspunsA == raspunsCorectFaraVirgule)
                    {
                        RaspunsCorect();
                    }
                    else
                    {
                        RaspunsGresit(raspunsCorect);
                    }
                }
            }
            else if (tipIntrebare == 3)
            {
                if (raspuns != null)
                {
                    buttonVerificare.Visible = false;
                    buttonTrazneste.Visible = false;

                    if (raspuns == raspunsCorect)
                    {
                        RaspunsCorect();
                    }
                    else
                    {
                        RaspunsGresit(raspunsCorect);
                    }
                }
            }
            else if (tipIntrebare == 4)
            {
                buttonVerificare.Visible = false;
                buttonTrazneste.Visible = false;

                string raspunsCorectFaraVirgule = raspunsCorect.Replace(", ", "");

                if (buttonText1.Text + buttonText2.Text + buttonText3.Text + buttonText4.Text + buttonText5.Text == raspunsCorectFaraVirgule)
                {
                    RaspunsCorect();
                }
                else
                {
                    RaspunsGresit(raspunsCorect.Replace(",", ", "));
                }
            }
        }

        private void AfisareVietiAcasa()
        {
            if (numarVieti == 0)
            {
                imageViataAcasa1.Image = imageViataAcasa2.Image = imageViataAcasa3.Image = new Bitmap(bitQuiz.Properties.Resources.fara_inima);
                labelRecuperareInimi.Visible = labelTimpRamasInima.Visible = true;
                labelTimpRamasInima.BringToFront();
                labelRecuperareInimi.Text = "Recuperare inimi în";

                timerRecuperareVieti.Enabled = true;
                timerRecuperareVieti.Start();
            }
            else if (numarVieti == 1)
            {
                imageViataAcasa1.Image = imageViataAcasa2.Image = new Bitmap(bitQuiz.Properties.Resources.fara_inima);
                imageViataAcasa3.Image = new Bitmap(bitQuiz.Properties.Resources.inima);
                labelTimpRamasInima.Visible = false;
                labelRecuperareInimi.Visible = true;
                labelRecuperareInimi.Text = "Recuperare indisponibilă" + Environment.NewLine + "1/3";
            }
            else if (numarVieti == 2)
            {
                imageViataAcasa1.Image = new Bitmap(bitQuiz.Properties.Resources.fara_inima);
                imageViataAcasa2.Image = imageViataAcasa3.Image = new Bitmap(bitQuiz.Properties.Resources.inima);
                labelTimpRamasInima.Visible = false;
                labelRecuperareInimi.Visible = true;
                labelRecuperareInimi.Text = "Recuperare indisponibilă" + Environment.NewLine + "2/3";
            }
            else
            {
                timerRecuperareVieti.Stop();
                timerRecuperareVieti.Enabled = false;

                imageViataAcasa1.Image = imageViataAcasa2.Image = imageViataAcasa3.Image = new Bitmap(bitQuiz.Properties.Resources.inima);
                labelRecuperareInimi.Visible = true;
                labelTimpRamasInima.Visible = false;
                labelRecuperareInimi.Text = "Ai toate inimile." + Environment.NewLine + "Hai să începem!";
            }
        }

        private void timerRecuperareVieti_Tick(object sender, EventArgs e)
        {
            Utilizator u = new Utilizator
            {
                UserName = labelUtilizator.Text
            };
            DateTime recuperareViata = u.RegenerareVieti(u);


            TimeSpan t = recuperareViata - DateTime.Now;

            if (recuperareViata > DateTime.Now)
            {
                labelTimpRamasInima.Text = labelTimpRamasFaraInimi.Text = t.ToString(@"mm\:ss");
            }
            else
            {
                SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.inimi);
                audio.Play();

                numarVieti = 3;
                u.AdaugareViata(u);

                u.Vieti = numarVieti;
                u.UpdateVieti(u);

                AfisareVietiAcasa();
                InimiRecuperare();
            }
        }

        private void RaspunsCorect()
        {
            SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.correct);
            audio.Play();

            Intrebare i = new Intrebare
            {
                IntrebareId = Convert.ToInt32(intrebari.Rows[linie - 1][0]),
                UserName = labelUtilizator.Text,
                Raspuns = 0
            };
            i.InserareIntrebareUtilizator(i);

            panelVerificare.BackColor = Color.FromArgb(223, 241, 155);
            labelRaspuns.Visible = true;
            labelRaspuns.Text = "Felicitări!";
            labelRaspuns.BackColor = Color.FromArgb(223, 241, 155);
            labelRaspuns.ForeColor = Color.FromArgb(163, 192, 40);
            labelRaspunsCorect.Visible = true;
            labelRaspunsCorect.BackColor = Color.FromArgb(223, 241, 155);
            labelRaspunsCorect.ForeColor = Color.FromArgb(163, 192, 40);
            labelRaspunsCorect.Text = "Ai răspuns corect!";
            imageCheck.Visible = true;
            buttonContinuare.Visible = true;

            if (progressBarCapitol.Value >= 70)
            {
                progressBarCapitol.ProgressColorLeft = Color.FromArgb(71, 204, 59);
                progressBarCapitol.ProgressColorRight = Color.FromArgb(71, 204, 59);
                progressBarCapitol.Value += progressBarCapitol.MaximumValue / numarIntrebari;
            }
            else
            {
                progressBarCapitol.Value += progressBarCapitol.MaximumValue / numarIntrebari;
            }
        }

        private void RaspunsGresit(string raspuns)
        {
            SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.wrong);
            audio.Play();

            numarVieti--;

            Utilizator u = new Utilizator
            {
                UserName = labelUtilizator.Text,
                Vieti = numarVieti
            };
            u.UpdateVieti(u);

            if (numarVieti == 0)
            {
                u.TimpRamas(3, 0.00975f);
                AfisareVietiAcasa();
            }
            else
            {
                DataRow dr = intrebari.NewRow();
                dr["Id"] = intrebari.Rows[linie - 1][0];
                dr["Tip"] = intrebari.Rows[linie - 1][1];
                dr["Capitol"] = intrebari.Rows[linie - 1][2];
                dr["Dificultate"] = intrebari.Rows[linie - 1][3];
                dr["Puncte"] = intrebari.Rows[linie - 1][4];
                intrebari.Rows.Add(dr);
            }

            AfisareVieti();

            Intrebare i = new Intrebare
            {
                IntrebareId = Convert.ToInt32(intrebari.Rows[linie - 1][0]),
                UserName = labelUtilizator.Text,
                Raspuns = 1
            };
            i.InserareIntrebareUtilizator(i);


            if (raspuns[raspuns.Length - 1] == ',')
            {
                labelRaspunsCorect.Text = "Răspuns corect: " + raspuns.Remove(raspuns.Length - 1, 1);
            }
            else
            {
                labelRaspunsCorect.Text = "Răspuns corect: " + raspuns;
            }

            imageX.Visible = true;
            buttonContinuare.Visible = true;

            panelVerificare.BackColor = Color.FromArgb(248, 188, 189);
            labelRaspuns.Visible = true;
            labelRaspuns.Text = "Ai răspuns greșit!";
            labelRaspuns.BackColor = Color.FromArgb(248, 188, 189);
            labelRaspuns.ForeColor = Color.FromArgb(244, 94, 93);
            labelRaspunsCorect.Visible = true;
            labelRaspunsCorect.BackColor = Color.FromArgb(248, 188, 189);
            labelRaspunsCorect.ForeColor = Color.FromArgb(244, 94, 93);
        }

        // Curatare intrebari
        public void ClearVerificare()
        {
            buttonContinuare.Visible = false;
            buttonVerificare.Visible = false;
            panelVerificare.BackColor = Color.FromArgb(242, 242, 242);
            imageX.Visible = false;
            imageCheck.Visible = false;
            labelRaspunsCorect.Visible = false;
            labelRaspuns.Visible = false;
            buttonTrazneste.Visible = true;

            if (tipIntrebare == 1)
            {
                txtInserareCod.Text = "";
                txtInserareCod.ReadOnly = false;
            }
            else if (tipIntrebare == 2)
            {
                buttonA.Iconimage = new Bitmap(bitQuiz.Properties.Resources._1_silver);
                buttonA.Activecolor = Color.White;
                buttonA.Normalcolor = Color.White;
                buttonA.Textcolor = Color.Silver;
                raspunsA = null;

                buttonB.Iconimage = new Bitmap(bitQuiz.Properties.Resources._2_silver);
                buttonB.Activecolor = Color.White;
                buttonB.Normalcolor = Color.White;
                buttonB.Textcolor = Color.Silver;
                raspunsB = null;

                buttonC.Iconimage = new Bitmap(bitQuiz.Properties.Resources._3_silver);
                buttonC.Activecolor = Color.White;
                buttonC.Normalcolor = Color.White;
                buttonC.Textcolor = Color.Silver;
                raspunsC = null;

                A = 0;
                B = 0;
                C = 0;
            }
            else if (tipIntrebare == 3)
            {
                userControlA.BorderColor = Color.FromArgb(229, 229, 229);
                userControlB.BorderColor = Color.FromArgb(229, 229, 229);
                userControlC.BorderColor = Color.FromArgb(229, 229, 229);

                raspuns = null;
            }
            else if (tipIntrebare == 4)
            {
                buttonText1.Text = buttonText2.Text = buttonText3.Text = buttonText4.Text = buttonText5.Text = null;
                buttonText1.Visible = buttonText2.Visible = buttonText3.Visible = buttonText4.Visible = buttonText5.Visible = false;
                btn1.Visible = btn2.Visible = btn3.Visible = btn4.Visible = btn5.Visible = true;
            }
        }

        bool avansareNivel = false;
        private void UpdateNivel()
        {
            if (progressBarNivel.Value + 1 == 4)
            {
                avansareNivel = true;
                progressBarNivel.Value = 0;
                string[] Nivel = labelNivel.Text.Split(' ');
                labelNivel.Text = "Nivel " + (int.Parse(Nivel[1]) + 1).ToString();
            }
            else
            {
                avansareNivel = false;
                progressBarNivel.Value++;
            }
        }

        private void ButtonContinuare_Click(object sender, EventArgs e)
        {
            if (linie == intrebari.Rows.Count && numarVieti > 0)
            {
                Utilizator u = new Utilizator
                {
                    UserName = labelUtilizator.Text,
                    Descriere = labelIntrebareCapitol.Text
                };
                u.FinalizareCapitol(u);

                numarTrofee++;
                numarMere += 100;

                if (numarVieti == inimiInitiale)
                {
                    RealizareInimaDeOtel();
                }

                RealizareIncepeAventura();
                RealizarePrint();
                RealizareRege();

                GenerareDiagrama();
                UpdateNivel();


                if (avansareNivel == true)
                {
                    numarMere += 100;

                    u.Mere = numarMere;
                    u.UpdateMere(u);
                }

                intrebari = null;
                labelTrofeeMeniu.Text = labelNumarTrofee.Text = numarTrofee.ToString();
                labelNumarPuncte.Text = (numarPuncte + puncteCapitol).ToString();
                circleProgressBar.MaxValue = numarCapitole;
                circleProgressBar.Value = numarTrofee;
                labelMereMeniu.Text = numarMere.ToString();
                labelCapitoleComplete.Text = labelCapitoleTerminateFinal.Text = numarTrofee.ToString() + "/" + numarCapitole.ToString();

                InitilizareFinalizareCapitol();
            }
            else if (numarVieti == 0)
            {
                intrebari = null;
                InitializareFaraInimi();

                panelPrimaPagina.BringToFront();
                panelFaraInimi.BringToFront();
            }
            else
            {
                ClearVerificare();
                GenerareIntrebari(capitol, dificultate);
            }
        }

        private void TxtInserareCod_TextChanged(object sender, EventArgs e)
        {
            if (txtInserareCod.Text.Length > 0)
            {
                buttonVerificare.Visible = true;
            }
            else
            {
                buttonVerificare.Visible = false;
            }
        }

        // Configurare butoane raspuns multiplu

        int A = 0;
        string raspunsA = null;
        private void ButtonA_Click(object sender, EventArgs e)
        {
            if (buttonTrazneste.Visible == true)
            {
                if (A % 2 == 0)
                {
                    buttonA.Iconimage = buttonA.Iconimage_Selected;
                    buttonA.Activecolor = Color.FromArgb(242, 242, 242);
                    buttonA.Normalcolor = Color.FromArgb(242, 242, 242);
                    buttonA.Textcolor = Color.FromArgb(248, 191, 51);
                    raspunsA = buttonA.Text;
                }
                else
                {
                    buttonA.Iconimage = new Bitmap(bitQuiz.Properties.Resources._1_silver);
                    buttonA.Activecolor = Color.White;
                    buttonA.Normalcolor = Color.White;
                    buttonA.Textcolor = Color.Silver;
                    raspunsA = null;
                }
                A++;

                if (raspunsA == null && raspunsB == null && raspunsC == null)
                {
                    buttonVerificare.Visible = false;
                }
                else
                {
                    buttonVerificare.Visible = true;
                }
            }
        }

        int B = 0;
        string raspunsB = null;
        private void ButtonB_Click(object sender, EventArgs e)
        {
            if (buttonTrazneste.Visible == true)
            {
                if (B % 2 == 0)
                {
                    buttonB.Iconimage = buttonB.Iconimage_Selected;
                    buttonB.Activecolor = Color.FromArgb(242, 242, 242);
                    buttonB.Normalcolor = Color.FromArgb(242, 242, 242);
                    buttonB.Textcolor = Color.FromArgb(248, 191, 51);
                    raspunsB = buttonB.Text;
                }
                else
                {
                    buttonB.Iconimage = new Bitmap(bitQuiz.Properties.Resources._2_silver);
                    buttonB.Activecolor = Color.White;
                    buttonB.Normalcolor = Color.White;
                    buttonB.Textcolor = Color.Silver;
                    raspunsB = null;
                }
                B++;


                if (raspunsA == null && raspunsB == null && raspunsC == null)
                {
                    buttonVerificare.Visible = false;
                }
                else
                {
                    buttonVerificare.Visible = true;
                }
            }
        }

        int C = 0;
        string raspunsC = null;
        private void ButtonC_Click(object sender, EventArgs e)
        {
            if (buttonTrazneste.Visible == true)
            {
                if (C % 2 == 0)
                {
                    buttonC.Iconimage = buttonC.Iconimage_Selected;
                    buttonC.Activecolor = Color.FromArgb(242, 242, 242);
                    buttonC.Normalcolor = Color.FromArgb(242, 242, 242);
                    buttonC.Textcolor = Color.FromArgb(248, 191, 51);
                    raspunsC = buttonC.Text;
                }
                else
                {
                    buttonC.Iconimage = new Bitmap(bitQuiz.Properties.Resources._3_silver);
                    buttonC.Activecolor = Color.White;
                    buttonC.Normalcolor = Color.White;
                    buttonC.Textcolor = Color.Silver;
                    raspunsC = null;
                }
                C++;

                if (raspunsA == null && raspunsB == null && raspunsC == null)
                {
                    buttonVerificare.Visible = false;
                }
                else
                {
                    buttonVerificare.Visible = true;
                }
            }
        }

        // Configurare butoane raspuns imagine

        string raspuns = null;
        private void ImageA_Click(object sender, EventArgs e)
        {
            if (buttonTrazneste.Visible == true)
            {
                raspuns = labelA.Text;

                userControlA.BorderColor = Color.FromArgb(163, 192, 62);
                userControlB.BorderColor = Color.FromArgb(229, 229, 229);
                userControlC.BorderColor = Color.FromArgb(229, 229, 229);

                if (raspuns == null)
                {
                    buttonVerificare.Visible = false;
                }
                else
                {
                    buttonVerificare.Visible = true;
                }
            }
        }

        private void ImageB_Click(object sender, EventArgs e)
        {
            if (buttonTrazneste.Visible == true)
            {
                raspuns = labelB.Text;

                userControlA.BorderColor = Color.FromArgb(229, 229, 229);
                userControlB.BorderColor = Color.FromArgb(163, 192, 62);
                userControlC.BorderColor = Color.FromArgb(229, 229, 229);

                if (raspuns == null)
                {
                    buttonVerificare.Visible = false;
                }
                else
                {
                    buttonVerificare.Visible = true;
                }
            }
        }



        private void ImageC_Click(object sender, EventArgs e)
        {
            if (buttonTrazneste.Visible == true)
            {
                raspuns = labelC.Text;

                userControlA.BorderColor = Color.FromArgb(229, 229, 229);
                userControlB.BorderColor = Color.FromArgb(229, 229, 229);
                userControlC.BorderColor = Color.FromArgb(163, 192, 62);

                if (raspuns == null)
                {
                    buttonVerificare.Visible = false;
                }
                else
                {
                    buttonVerificare.Visible = true;
                }
            }
        }

        private void ButtonTrazneste_Click(object sender, EventArgs e)
        {
            if (numarSariPeste > 0)
            {


                Intrebare i = new Intrebare
                {
                    IntrebareId = Convert.ToInt32(intrebari.Rows[linie - 1][0]),
                    UserName = labelUtilizator.Text,
                    Raspuns = 2
                };
                i.InserareIntrebareUtilizator(i);

                ButtonContinuare_Click(sender, e);
                numarSariPeste--;

                Utilizator u = new Utilizator
                {
                    UserName = labelUtilizator.Text,
                    SariPeste = numarSariPeste
                };
                u.UpdateTraznet(u);

                if (progressBarCapitol.Value >= 70)
                {
                    progressBarCapitol.ProgressColorLeft = Color.FromArgb(71, 204, 59);
                    progressBarCapitol.ProgressColorRight = Color.FromArgb(71, 204, 59);
                    progressBarCapitol.Value += progressBarCapitol.MaximumValue / numarIntrebari;
                }
                else
                {
                    progressBarCapitol.Value += progressBarCapitol.MaximumValue / numarIntrebari;
                }

                labelSariPesteMeniu.Text = numarSariPeste.ToString();

                SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.traznet);
                audio.Play();

                RealizareEstiTraznet();
            }
        }

        private void ButtonPutere1_Click(object sender, EventArgs e)
        {
            if (numarMere >= 250)
            {
                SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.inimi);
                audio.Play();

                numarVieti = 3;
                numarMere -= 250;
                labelMereMeniu.Text = numarMere.ToString();

                Utilizator u = new Utilizator
                {
                    UserName = labelUtilizator.Text,
                    Vieti = numarVieti,
                    Mere = numarMere
                };

                if (numarVieti == 0)
                {
                    u.AdaugareViata(u);
                    timerRecuperareVieti.Enabled = false;
                    timerRecuperareVieti.Stop();
                }

                u.UpdateVieti(u);
                u.UpdateMere(u);
                u.Magazin(u, 1);

                buttonPutere1.Visible = false;
                RealizareManaLarga(250);
            }
            else
            {
                pictureBoxEroareMereTraznet.Visible = pictureBoxEroareMereCuriosii.Visible = false;
                pictureBoxEroareMereVieti.Visible = true;
            }
        }

        private void ButtonPutere2_Click(object sender, EventArgs e)
        {
            if (numarMere >= 150 && numarSariPeste < 3)
            {
                SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.traznet);
                audio.Play();

                numarSariPeste++;
                numarMere -= 150;
                labelSariPesteMeniu.Text = numarSariPeste.ToString();
                labelMereMeniu.Text = numarMere.ToString();

                Utilizator u = new Utilizator
                {
                    UserName = labelUtilizator.Text,
                    SariPeste = numarSariPeste,
                    Mere = numarMere
                };

                u.UpdateTraznet(u);
                u.Magazin(u, 2);
                u.UpdateMere(u);

                if (numarSariPeste == 3)
                {
                    buttonPutere2.Visible = false;
                }

                RealizareManaLarga(150);
            }
            else
            {
                pictureBoxEroareMereVieti.Visible = pictureBoxEroareMereCuriosii.Visible = false;
                pictureBoxEroareMereTraznet.Visible = true;
            }
        }

        private void ButtonPutere3_Click(object sender, EventArgs e)
        {
            if (numarMere >= 75)
            {
                SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.cufar);
                audio.Play();

                RealizarePirat();

                Utilizator u = new Utilizator
                {
                    UserName = labelUtilizator.Text
                };

                numarMere -= 75;

                u.Magazin(u, 3);

                string[] split = labelNivel.Text.Split(' ');
                int nivel = Convert.ToInt32(split[1]);

                Random rnd = new Random();

                int alegere = 0;
                if (nivel < 4)
                {
                    alegere = rnd.Next(0, 3);
                }
                else if (nivel > 3 && nivel < 6)
                {
                    if (numarVieti < 3 && numarVieti > 0)
                    {
                        alegere = rnd.Next(0, 6);
                    }
                    else
                    {
                        alegere = rnd.Next(0, 5);
                    }
                }
                else if (nivel > 5)
                {
                    if (numarVieti < 3 && numarVieti > 0 && numarSariPeste < 3)
                    {
                        alegere = rnd.Next(0, 9);
                    }
                    alegere = rnd.Next(0, 5);
                }

                switch (alegere)
                {
                    case 0:
                        bunifuToolTip1.SetToolTip(imagineCastig, "Cufărul a fost gol");
                        imagineCastig.Image = new Bitmap(bitQuiz.Properties.Resources.mar_muscat);

                        break;

                    case 1:
                        bunifuToolTip1.SetToolTip(imagineCastig, "Ai găsit 75 de mere");
                        imagineCastig.Image = bunifuImageButton4.Image;
                        numarMere += 75;
                        break;

                    case 2:
                        bunifuToolTip1.SetToolTip(imagineCastig, "Ai găsit 100 de mere");
                        imagineCastig.Image = bunifuImageButton4.Image;
                        numarMere += 100;
                        break;

                    case 3:
                        bunifuToolTip1.SetToolTip(imagineCastig, "Ai găsit 150 de mere");
                        imagineCastig.Image = bunifuImageButton4.Image;
                        numarMere += 150;
                        break;
                    case 4:
                        bunifuToolTip1.SetToolTip(imagineCastig, "Ai găsit 300 de mere");
                        imagineCastig.Image = bunifuImageButton4.Image;
                        numarMere += 300;
                        break;

                    case 5:
                        bunifuToolTip1.SetToolTip(imagineCastig, "Ai găsit o inima");
                        imagineCastig.Image = imagePutere1.Image;
                        numarVieti++;
                        u.Vieti = numarVieti;
                        u.UpdateVieti(u);
                        break;

                    case 6:
                        bunifuToolTip1.SetToolTip(imagineCastig, "Ai găsit un trăsnet");
                        imagineCastig.Image = imagePutere2.Image;
                        numarSariPeste++;
                        u.SariPeste = numarSariPeste;
                        u.UpdateTraznet(u);
                        break;

                    case 7:
                        bunifuToolTip1.SetToolTip(imagineCastig, "Ai găsit 500 de mere");
                        imagineCastig.Image = new Bitmap(bitQuiz.Properties.Resources.green_apple);
                        numarMere += 500;
                        break;

                    case 8:
                        bunifuToolTip1.SetToolTip(imagineCastig, "Ai găsit mărul de aur");
                        imagineCastig.Image = R5.Image;
                        numarMere += 1000;
                        RealizareMaruldeAur();
                        break;
                }

                u.Mere = numarMere;
                u.UpdateMere(u);

                labelMereMeniu.Text = numarMere.ToString();

                RealizareManaLarga(75);
                panelCastig.Visible = true;
            }
            else
            {
                pictureBoxEroareMereVieti.Visible = pictureBoxEroareMereTraznet.Visible = false;
                pictureBoxEroareMereCuriosii.Visible = true;
            }
        }

        bool prieten = false;
        private void ButtonProgressNext_Click(object sender, EventArgs e)
        {

            if (labelProgres.Text == "Progres")
            {
                labelProgres.Text = "Prieteni";
                textBoxCautareAltPrieten.Text = "";
                buttonProgressNext.Image = new Bitmap(bitQuiz.Properties.Resources.chevron_left_120px_yellow);

                Utilizator u = new Utilizator
                {
                    UserName = labelUtilizator.Text
                };

                DataTable dt = u.Prieteni(u);

                if (dt.Rows.Count > 0)
                {
                    string numarcapitole;
                    labelNiciunPrieten.Visible = true;
                    labelNiciunPrieten.Text = "Caută un prieten cu care să concurezi.";
                    imageAltPrieten.Visible = labelUserNameAltPrieten.Visible = buttonAdaugaAltPrieten.Visible = false;

                    if (prieten == false)
                    {
                        prieten = true;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Label userName = new Label
                            {
                                Name = "labelListaPrieten " + i,
                                AutoSize = false,
                                Size = new Size(161, 22),
                                Location = new Point(62, 19 + i * 65),
                                ForeColor = Color.FromArgb(36, 176, 246),
                                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                                Text = dt.Rows[i][1].ToString(),
                                TextAlign = ContentAlignment.TopCenter
                            };

                            Label puncte = new Label
                            {
                                Name = "labelListaPrietenPuncte" + i,
                                Location = new Point(223, 22 + i * 65),
                                ForeColor = Color.FromArgb(224, 224, 224),
                                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                                Text = dt.Rows[i][2].ToString() + "p"
                            };

                            Bunifu.Framework.UI.BunifuImageButton bib = new Bunifu.Framework.UI.BunifuImageButton
                            {
                                Name = "ImagePrieten" + i,
                                Zoom = 5,
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Size = new Size(53, 46),
                                Location = new Point(2, 3 + i * 65),
                                Cursor = Cursors.Hand
                            };


                            byte[] img = (byte[])(dt.Rows[i][0]);
                            MemoryStream ms = new MemoryStream(img);
                            bib.Image = Image.FromStream(ms);

                            BunifuSeparator bs = new BunifuSeparator
                            {
                                Name = "BunifuSeparatorPrieten" + i,
                                Size = new Size(256, 11),
                                LineThickness = 2,
                                Location = new Point(22, 55 + i * 65)
                            };

                            if (i < dt.Rows.Count - 1)
                            {
                                bs.LineColor = Color.FromArgb(242, 242, 242);
                            }
                            else
                            {
                                bs.Size = new Size(256, 3);
                                bs.LineColor = Color.White;
                            }

                            numarcapitole = dt.Rows[i][3].ToString();

                            bib.Click += (s, ex) => { AfisarePrieten(userName.Text, numarcapitole, bib.Image); };

                            panel16.Controls.Add(bs);
                            panel16.Controls.Add(bib);
                            panel16.Controls.Add(userName);
                            panel16.Controls.Add(puncte);
                        }
                    }

                    panelPrieteniUtilizator.BringToFront();
                }
                else
                {
                    textBoxCautarePrieteni.Visible = false;
                    pictureBoxPrieten1.Visible = false;
                    labelPrieten1.Visible = false;
                    buttonAdaugaPrieten1.Visible = false;

                    pictureBoxPrieten2.Visible = false;
                    labelPrieten2.Visible = false;
                    buttonAdaugaPrieten2.Visible = false;

                    pictureBoxPrieten3.Visible = false;
                    labelPrieten3.Visible = false;
                    buttonAdaugaPrieten3.Visible = false;

                    separatorPrieten1.Visible = false;
                    separatorPrieten2.Visible = false;
                    labelNiciunUtilizator.Visible = false;
                    buttonCautarePrieten.Location = new Point(77, 83);
                    panelPrieteni.BringToFront();
                }
            }
            else
            {
                labelProgres.Text = "Progres";
                buttonProgressNext.Image = new Bitmap(bitQuiz.Properties.Resources.chevron_right_120px_yellow);
                panelProgres1.BringToFront();
            }
        }

        private void MeniuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utilizator u = new Utilizator
            {
                UserName = labelUtilizator.Text
            };
            u.UpdateUltimaIntregistrareUtilizator(u);
            Dispose();
        }

        private void ButtonModificareProfil_Click(object sender, EventArgs e)
        {
            if (intrebari != null)
            {
                Eroare.textEroare = "Ești sigur că vrei să pierzi progresul?";
                using (Eroare er = new Eroare
                {
                    StartPosition = FormStartPosition.CenterParent
                })
                {
                    er.ShowDialog(this);
                }

                if (Eroare.OKCancel == "OK")
                {
                    ResetColorMenu();
                    userControlMenu.Visible = false;

                    intrebari = null;

                    panelPrimaPagina.BringToFront();

                    ModificareProfil();

                    labelProgres.Text = "Progres";
                    buttonProgressNext.Image = new Bitmap(bitQuiz.Properties.Resources.chevron_right_120px_yellow);

                    panelProgres1.BringToFront();
                    panelUtilizator.BringToFront();
                }
            }
            else
            {
                ResetColorMenu();
                userControlMenu.Visible = false;

                ModificareProfil();

                panelPrimaPagina.BringToFront();
                panelUtilizator.BringToFront();
            }
        }

        private void BunifuUserControl1_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxResetareProfil_MouseEnter(object sender, EventArgs e)
        {
            textBoxResetareProfil.ForeColor = Color.Silver;
        }

        private void TextBoxResetareProfil_MouseLeave(object sender, EventArgs e)
        {
            textBoxResetareProfil.ForeColor = Color.FromArgb(232, 232, 232);
        }

        private void TextBoxResetareProfil_Click(object sender, EventArgs e)
        {
            Eroare.textEroare = "Ești sigur că vrei să îți resetezi profilul?";
            using (Eroare er = new Eroare
            {
                StartPosition = FormStartPosition.CenterParent
            })
            {
                er.ShowDialog(this);
            }

            if (Eroare.OKCancel == "OK")
            {
                Utilizator u = new Utilizator
                {
                    UserName = labelUtilizator.Text
                };
                u.ResetareUtilizator(u);

                isPrietenos = isPrint = isRege = isTraznet = isMarulDeAur = isInimaDeOtel = isPirat = isIncepeAventura = isManaLarga = false;

                panelRealizare.Visible = false;
                imagineR1.Visible = imagineR2.Visible = imagineR3.Visible = imagineR4.Visible = imagineR5.Visible = imagineR6.Visible = imagineR7.Visible = imagineR8.Visible = imagineR9.Visible = false;

                isLoaded = false;
                Initializare();
                AfisareVietiAcasa();
                numarPagina = 1;
                AfisareCapitole(numarPagina);
                AfisareAcasa();
                AfisareClasament();

                paneLoading.BringToFront();
                timerLoading.Enabled = true;
                timerLoading.Start();
            }
        }

        private void textBoxDezactivareProfil_MouseEnter(object sender, EventArgs e)
        {
            textBoxDezactivareProfil.ForeColor = Color.Silver;
        }

        private void TextBoxDezactivareProfil_MouseLeave(object sender, EventArgs e)
        {
            textBoxDezactivareProfil.ForeColor = Color.FromArgb(232, 232, 232);
        }

        private void textBoxDezactivareProfil_Click(object sender, EventArgs e)
        {
            Eroare.textEroare = "Ești sigur că vrei să îți dezactivezi profilul?";
            using (Eroare er = new Eroare
            {
                StartPosition = FormStartPosition.CenterParent
            })
            {
                er.ShowDialog(this);
            }

            if (Eroare.OKCancel == "OK")
            {
                Utilizator u = new Utilizator
                {
                    UserName = labelUtilizator.Text
                };

                u.ActivateDezactivareUtilizator(u, 0);

                Close();
                Application.Exit();
            }
        }

        private void buttonCautarePrieten_Click(object sender, EventArgs e)
        {
            if (textBoxCautarePrieteni.Visible == false)
            {
                buttonCautarePrieten.Location = new Point(77, 135);
                textBoxCautarePrieteni.Text = "";
                textBoxCautarePrieteni.Visible = true;
            }
            else
            {

                if (textBoxCautarePrieteni.Text.Length > 2)
                {
                    labelNiciunUtilizator.Visible = false;

                    Utilizator u = new Utilizator
                    {
                        UserName = labelUtilizator.Text,
                        Prieten = textBoxCautarePrieteni.Text
                    };

                    DataTable dt = u.CautarePrieten(u);

                    if (dt.Rows.Count > 0)
                    {
                        labelNiciunUtilizator.Visible = false;

                        if (dt.Rows.Count == 1)
                        {
                            pictureBoxPrieten1.Visible = true;
                            labelPrieten1.Visible = true;

                            if (dt.Rows[0][2].ToString() == "0")
                            {
                                buttonAdaugaPrieten1.Visible = true;
                            }
                            else
                            {
                                buttonAdaugaPrieten1.Visible = false;
                            }

                            labelPrieten1.Text = dt.Rows[0][1].ToString();

                            byte[] img = (byte[])(dt.Rows[0][0]);
                            MemoryStream ms = new MemoryStream(img);
                            pictureBoxPrieten1.Image = Image.FromStream(ms);

                            pictureBoxPrieten2.Visible = false;
                            labelPrieten2.Visible = false;
                            buttonAdaugaPrieten2.Visible = false;

                            pictureBoxPrieten3.Visible = false;
                            labelPrieten3.Visible = false;
                            buttonAdaugaPrieten3.Visible = false;

                            separatorPrieten1.Visible = false;
                            separatorPrieten2.Visible = false;
                        }
                        else if (dt.Rows.Count == 2)
                        {
                            pictureBoxPrieten1.Visible = true;
                            labelPrieten1.Visible = true;

                            if (dt.Rows[0][2].ToString() == "0")
                            {
                                buttonAdaugaPrieten1.Visible = true;
                            }
                            else
                            {
                                buttonAdaugaPrieten1.Visible = false;
                            }

                            labelPrieten1.Text = dt.Rows[0][1].ToString();

                            byte[] img = (byte[])(dt.Rows[0][0]);
                            MemoryStream ms = new MemoryStream(img);
                            pictureBoxPrieten1.Image = Image.FromStream(ms);

                            pictureBoxPrieten2.Visible = true;
                            labelPrieten2.Visible = true;

                            if (dt.Rows[1][2].ToString() == "0")
                            {
                                buttonAdaugaPrieten2.Visible = true;
                            }
                            else
                            {
                                buttonAdaugaPrieten2.Visible = false;
                            }

                            labelPrieten2.Text = dt.Rows[1][1].ToString();

                            img = (byte[])(dt.Rows[1][0]);
                            ms = new MemoryStream(img);
                            pictureBoxPrieten2.Image = Image.FromStream(ms);

                            pictureBoxPrieten3.Visible = false;
                            labelPrieten3.Visible = false;
                            buttonAdaugaPrieten3.Visible = false;

                            separatorPrieten1.Visible = true;
                            separatorPrieten2.Visible = false;
                        }
                        else
                        {
                            pictureBoxPrieten1.Visible = true;
                            labelPrieten1.Visible = true;

                            if (dt.Rows[0][2].ToString() == "0")
                            {
                                buttonAdaugaPrieten1.Visible = true;
                            }
                            else
                            {
                                buttonAdaugaPrieten1.Visible = false;
                            }

                            labelPrieten1.Text = dt.Rows[0][1].ToString();

                            byte[] img = (byte[])(dt.Rows[0][0]);
                            MemoryStream ms = new MemoryStream(img);
                            pictureBoxPrieten1.Image = Image.FromStream(ms);

                            pictureBoxPrieten2.Visible = true;
                            labelPrieten2.Visible = true;

                            if (dt.Rows[1][2].ToString() == "0")
                            {
                                buttonAdaugaPrieten2.Visible = true;
                            }
                            else
                            {
                                buttonAdaugaPrieten2.Visible = false;
                            }

                            labelPrieten2.Text = dt.Rows[1][1].ToString();

                            img = (byte[])(dt.Rows[1][0]);
                            ms = new MemoryStream(img);
                            pictureBoxPrieten2.Image = Image.FromStream(ms);

                            pictureBoxPrieten3.Visible = true;
                            labelPrieten3.Visible = true;

                            if (dt.Rows[2][2].ToString() == "0")
                            {
                                buttonAdaugaPrieten3.Visible = true;
                            }
                            else
                            {
                                buttonAdaugaPrieten3.Visible = false;
                            }

                            labelPrieten3.Text = dt.Rows[2][1].ToString();

                            img = (byte[])(dt.Rows[2][0]);
                            ms = new MemoryStream(img);
                            pictureBoxPrieten3.Image = Image.FromStream(ms);

                            separatorPrieten1.Visible = true;
                            separatorPrieten2.Visible = true;
                        }
                    }
                    else
                    {
                        pictureBoxPrieten1.Visible = false;
                        labelPrieten1.Visible = false;
                        buttonAdaugaPrieten1.Visible = false;

                        pictureBoxPrieten2.Visible = false;
                        labelPrieten2.Visible = false;
                        buttonAdaugaPrieten2.Visible = false;

                        pictureBoxPrieten3.Visible = false;
                        labelPrieten3.Visible = false;
                        buttonAdaugaPrieten3.Visible = false;

                        separatorPrieten1.Visible = false;
                        separatorPrieten2.Visible = false;
                        labelNiciunUtilizator.Visible = true;
                    }
                }
                else
                {
                    pictureBoxPrieten1.Visible = false;
                    labelPrieten1.Visible = false;
                    buttonAdaugaPrieten1.Visible = false;

                    pictureBoxPrieten2.Visible = false;
                    labelPrieten2.Visible = false;
                    buttonAdaugaPrieten2.Visible = false;

                    pictureBoxPrieten3.Visible = false;
                    labelPrieten3.Visible = false;
                    buttonAdaugaPrieten3.Visible = false;

                    separatorPrieten1.Visible = false;
                    separatorPrieten2.Visible = false;
                    labelNiciunUtilizator.Visible = true;
                }
            }
        }

        [Obsolete]
        private void AdaugaPrieten(string s)
        {
            if (labelUserNamePrieten.Text == s)
            {
                buttonUrmareste.Visible = false;
                buttonUrmaresti.Visible = true;
            }

            labelNumarUrmaresti.Text = (int.Parse(labelNumarUrmaresti.Text) + 1).ToString();

            Utilizator u = new Utilizator
            {
                UserName = labelUtilizator.Text,
                Prieten = s
            };

            u.AdaugarePrieten(u);
            RealizarePrietenos();
        }

        [Obsolete]
        private void buttonAdaugaPrieten1_Click(object sender, EventArgs e)
        {
            if (labelPrieten1.Text.Equals(labelUserNamePrieten.Text))
            {
                labelNumarUrmaritoriPrieten.Text = (int.Parse(labelNumarUrmaritoriPrieten.Text) + 1).ToString();
            }

            AdaugaPrieten(labelPrieten1.Text);
            buttonAdaugaPrieten1.Visible = false;
        }

        [Obsolete]
        private void buttonAdaugaPrieten2_Click(object sender, EventArgs e)
        {
            if (labelPrieten2.Text.Equals(labelUserNamePrieten.Text))
            {
                labelNumarUrmaritoriPrieten.Text = (int.Parse(labelNumarUrmaritoriPrieten.Text) + 1).ToString();
            }

            AdaugaPrieten(labelPrieten2.Text);
            buttonAdaugaPrieten2.Visible = false;
        }

        [Obsolete]
        private void buttonAdaugaPrieten3_Click(object sender, EventArgs e)
        {
            if (labelPrieten3.Text.Equals(labelUserNamePrieten.Text))
            {
                labelNumarUrmaritoriPrieten.Text = (int.Parse(labelNumarUrmaritoriPrieten.Text) + 1).ToString();
            }

            AdaugaPrieten(labelPrieten3.Text);
            buttonAdaugaPrieten3.Visible = false;
        }

        private void pictureBoxPrieten1_Click(object sender, EventArgs e)
        {
            AfisareProfilPrieten(labelPrieten1.Text, pictureBoxPrieten1.Image);
        }

        private void pictureBoxPrieten2_Click(object sender, EventArgs e)
        {
            AfisareProfilPrieten(labelPrieten2.Text, pictureBoxPrieten2.Image);

        }

        private void pictureBoxPrieten3_Click(object sender, EventArgs e)
        {
            AfisareProfilPrieten(labelPrieten3.Text, pictureBoxPrieten3.Image);
        }

        private void AlegereAvatar(int i)
        {
            switch (i)
            {
                case 1:
                    if (sex == 'M')
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._1_boy);
                    }
                    else
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._1_girl);
                    }

                    break;

                case 2:
                    if (sex == 'M')
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._2_boy);
                    }
                    else
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._2_girl);
                    }

                    break;

                case 3:
                    if (sex == 'M')
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._3_boy);
                    }
                    else
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._3_girl);
                    }

                    break;

                case 4:
                    if (sex == 'M')
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._4_boy);
                    }
                    else
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._4_girl);
                    }

                    break;

                case 5:
                    if (sex == 'M')
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._5_boy);
                    }
                    else
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._5_girl);
                    }

                    break;

                case 6:
                    if (sex == 'M')
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._6_boy);
                    }
                    else
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._6_girl);
                    }

                    break;

                case 7:
                    if (sex == 'M')
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._7_boy);
                    }
                    else
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._7_girl);
                    }

                    break;

                case 8:
                    if (sex == 'M')
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._8_boy);
                    }
                    else
                    {
                        imagineModificareProfil.Image = new Bitmap(bitQuiz.Properties.Resources._8_girl);
                    }

                    break;
            }
        }

        int i = 0;
        private void buttonSchimbareImagine_Click(object sender, EventArgs e)
        {
            i++;
            if (i == 9)
            {
                i = 0;
            }

            AlegereAvatar(i);
        }

        [Obsolete]
        private void buttonModificareCont_Click(object sender, EventArgs e)
        {
            int contor = 0;

            if (textBoxNume.Text == "" || textBoxPrenume.Text == "")
            {
                pictureBoxEroareNumeSauPrenume.Visible = true;
                bunifuToolTip1.SetToolTip(pictureBoxEroareNumeSauPrenume, "Nu ai introdus numele sau prenumele");
            }

            foreach (BunifuTextBox txt in panel9.Controls.OfType<BunifuTextBox>())
            {
                if (string.IsNullOrEmpty(txt.Text.Trim()) && txt.Name != "textBoxParola" && txt.Name != "textBoxStare")
                {
                    if (txt.Name == "textBoxParolaNoua")
                    {
                        pictureBoxEroareParolaNoua.Visible = true;
                        bunifuToolTip1.SetToolTip(pictureBoxEroareParolaNoua, "Nu ai introdus parola");
                    }
                    else if (txt.Name == "textBoxEmail")
                    {
                        pictureBoxEroareEmail.Visible = true;
                        bunifuToolTip1.SetToolTip(pictureBoxEroareEmail, "Nu ai introdus niciun e-mail");
                    }
                    contor++;
                }
                else
                {
                    if (txt.Name == "textBoxNume")
                    {
                        foreach (char c in textBoxNume.Text)
                        {
                            if (char.IsLetter(c) == false)
                            {
                                contor++;
                                pictureBoxEroareNumeSauPrenume.Visible = true;
                                bunifuToolTip1.SetToolTip(pictureBoxEroareNumeSauPrenume, "Numele și prenumele nu pot conține cifre sau caractere speciale");
                                break;
                            }
                        }
                    }
                    else if (txt.Name == "textBoxPrenume")
                    {
                        foreach (char c in textBoxPrenume.Text)
                        {
                            if (char.IsLetter(c) == false)
                            {
                                contor++;
                                pictureBoxEroareNumeSauPrenume.Visible = true;
                                bunifuToolTip1.SetToolTip(pictureBoxEroareNumeSauPrenume, "Numele și prenumele nu pot conține cifre sau caractere speciale");
                                break;
                            }
                        }
                    }
                    else if (txt.Name == "textBoxEmail")
                    {
                        if (Login.IsEmail(textBoxEmail.Text) == false)
                        {
                            contor++;
                            pictureBoxEroareEmail.Visible = true;
                            bunifuToolTip1.SetToolTip(pictureBoxEroareEmail, "E-mail-ul introdus este invalid");
                        }
                        else
                        {
                            Utilizator u = new Utilizator
                            {
                                Email = textBoxEmail.Text,
                                UserName = labelUtilizator.Text
                            };

                            if (txt.Text != email)
                            {
                                if (u.VerificareEmail(u) == true)
                                {
                                    contor++;
                                    pictureBoxEroareEmail.Visible = true;
                                    bunifuToolTip1.SetToolTip(pictureBoxEroareEmail, "E-mail-ul introdus este folosit de către un utilizator");
                                }
                            }
                        }
                    }
                    else if (txt.Name == "textBoxParolaNoua")
                    {
                        if (textBoxParolaNoua.Text.Length < 8)
                        {
                            contor++;
                            pictureBoxEroareParolaNoua.Visible = true;
                            bunifuToolTip1.SetToolTip(pictureBoxEroareParolaNoua, "Parola trebuie să fie formată din minim 8 caractere");
                        }
                    }
                }
            }

            if (contor == 0)
            {

                Eroare.textEroare = "Ești sigur că vrei să actualizezi profilul?";
                using (Eroare er = new Eroare
                {
                    StartPosition = FormStartPosition.CenterParent
                })
                {
                    er.ShowDialog(this);
                }

                if (Eroare.OKCancel == "OK")
                {
                    Utilizator u = new Utilizator
                    {
                        Nume = textBoxNume.Text,
                        Prenume = textBoxPrenume.Text,
                        Email = email = textBoxEmail.Text,
                        Parola = textBoxParola.Text = textBoxParolaNoua.Text,
                        Stare = textBoxStare.Text,
                        Imagine = imagineModificareProfil.Image,
                        UserName = Login.utilizator = labelUtilizator.Text
                    };

                    u.UpdateUtilizator(u);

                    Login.parola = textBoxParola.Text = textBoxParolaNoua.Text;
                    labelProverb.Text = Login.Proverbe();
                    paneLoading.BringToFront();
                    timerLoading.Enabled = true;
                    timerLoading.Start();
                }
            }
        }

        private void textBoxNume_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNume.Text.Length > 0)
            {
                if (textBoxPrenume.Text.Length > 0)
                {
                    pictureBoxEroareNumeSauPrenume.Visible = false;
                }
            }
        }

        private void textBoxPrenume_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPrenume.Text.Length > 0)
            {
                if (textBoxNume.Text.Length > 0)
                {
                    pictureBoxEroareNumeSauPrenume.Visible = false;
                }
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEmail.Text.Length > 0)
            {
                pictureBoxEroareEmail.Visible = false;
            }
        }

        private void textBoxParolaNoua_TextChanged(object sender, EventArgs e)
        {
            if (textBoxParolaNoua.Text.Length > 7)
            {
                pictureBoxEroareParolaNoua.Visible = false;
            }
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            timerLoading.Stop();
            timerLoading.Enabled = false;

            pictureBoxAcasa.Image = buttonModificareProfil.Image = imagineModificareProfil.Image;
            ButtonAcasa_Click(sender, e);

            labelProgres.Text = "Progres";
            buttonProgressNext.Image = new Bitmap(bitQuiz.Properties.Resources.chevron_right_120px_yellow);
            panelProgres1.BringToFront();
        }

        private void buttonCautareAltPrieten_Click(object sender, EventArgs e)
        {
            if (textBoxCautareAltPrieten.Text.Length > 2)
            {
                Utilizator u = new Utilizator
                {
                    UserName = labelUtilizator.Text,
                    Prieten = textBoxCautareAltPrieten.Text
                };

                DataTable dt = u.CautareAltPrieten(u);

                if (dt.Rows.Count > 0)
                {
                    labelNiciunPrieten.Visible = false;
                    imageAltPrieten.Visible = labelUserNameAltPrieten.Visible = true;
                    buttonAdaugaAltPrieten.Visible = true;

                    byte[] img = (byte[])(dt.Rows[0][0]);
                    MemoryStream ms = new MemoryStream(img);
                    imageAltPrieten.Image = Image.FromStream(ms);

                    labelUserNameAltPrieten.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    labelNiciunPrieten.Text = "Nu a fost găsit niciun utilizator.";
                    labelNiciunPrieten.Visible = true;
                    imageAltPrieten.Visible = labelUserNameAltPrieten.Visible = buttonAdaugaAltPrieten.Visible = false;
                }
            }
        }

        private void AdaugarePrietenInTabel()
        {
            panel16.Controls.Clear();

            Utilizator u = new Utilizator
            {
                UserName = labelUtilizator.Text
            };
            DataTable dt = u.Prieteni(u);

            string numarcapitole;

            panel16.Visible = false;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Label userName = new Label
                {
                    Name = "labelListaPrieten " + i,
                    AutoSize = false,
                    Size = new Size(161, 22),
                    Location = new Point(62, 19 + i * 65),
                    ForeColor = Color.FromArgb(36, 176, 246),
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    Text = dt.Rows[i][1].ToString(),
                    TextAlign = ContentAlignment.TopCenter
                };

                Label puncte = new Label
                {
                    Name = "labelListaPrietenPuncte" + i,
                    Location = new Point(223, 22 + i * 65),
                    ForeColor = Color.FromArgb(224, 224, 224),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Text = dt.Rows[i][2].ToString() + "p"
                };

                Bunifu.Framework.UI.BunifuImageButton bib = new Bunifu.Framework.UI.BunifuImageButton
                {
                    Name = "ImagePrieten" + i,
                    Zoom = 5,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(53, 46),
                    Location = new Point(2, 3 + i * 65),
                    Cursor = Cursors.Hand
                };


                byte[] img = (byte[])(dt.Rows[i][0]);
                MemoryStream ms = new MemoryStream(img);
                bib.Image = Image.FromStream(ms);

                BunifuSeparator bs = new BunifuSeparator
                {
                    LineColor = Color.FromArgb(224, 224, 224),
                    Name = "BunifuSeparatorPrieten" + i,
                    Size = new Size(256, 11),
                    LineThickness = 2,
                    Location = new Point(22, 55 + i * 65)
                };

                if (i < dt.Rows.Count - 1)
                {
                    bs.LineColor = Color.FromArgb(242, 242, 242);
                }
                else
                {
                    bs.Size = new Size(256, 3);
                    bs.LineColor = Color.White;
                }

                numarcapitole = dt.Rows[i][3].ToString();

                bib.Click += (s, ex) => { AfisarePrieten(userName.Text, numarcapitole, bib.Image); };
                panel16.Controls.Add(bs);
                panel16.Controls.Add(bib);
                panel16.Controls.Add(userName);
                panel16.Controls.Add(puncte);
            }
            panel16.Visible = true;
        }

        private void buttonAdaugaAltPrieten_Click(object sender, EventArgs e)
        {
            if (labelUserNameAltPrieten.Text.Equals(labelUserNamePrieten.Text))
            {
                labelNumarUrmaresti.Text = (int.Parse(labelNumarUrmaresti.Text) + 1).ToString();
            }

            AdaugaPrieten(labelUserNameAltPrieten.Text);

            AdaugarePrietenInTabel();

            buttonAdaugaAltPrieten.Visible = false;
        }

        private void ModificareProfil()
        {
            Utilizator u = new Utilizator
            {
                UserName = Login.utilizator
            };
            DataTable dt = u.ExtragereUtilizator(u);

            labelUtilizator.Text = dt.Rows[0][0].ToString();
            textBoxEmail.Text = email = dt.Rows[0][1].ToString();
            textBoxNume.Text = dt.Rows[0][2].ToString();
            textBoxPrenume.Text = dt.Rows[0][3].ToString();
            sex = Convert.ToChar(dt.Rows[0][4].ToString());
            textBoxStare.Text = dt.Rows[0][5].ToString();
            textBoxPrimaInregistrare.Text = dt.Rows[0][6].ToString();
            textBoxParola.Text = textBoxParolaNoua.Text = Login.parola;

            imagineModificareProfil.Image = buttonModificareProfil.Image;
        }

        private void Temporizator_Tick(object sender, EventArgs e)
        {

        }

        private void GenerareDiagrama()
        {
            chartProgress.Series[0].Points.Clear();

            Utilizator u = new Utilizator
            {
                UserName = labelUtilizator.Text
            };

            DataTable dt = u.DiagramaUtilizator(u);

            int contorZero = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartProgress.Series[0].Points.AddXY(dt.Rows[i][0].ToString(), Convert.ToInt32(dt.Rows[i][1]));

                if (Convert.ToInt32(dt.Rows[i][1]) == 0)
                {
                    contorZero++;
                }
            }

            if (contorZero == dt.Rows.Count)
            {
                chartProgress.ChartAreas[0].AxisY.Maximum = 20;
            }
            else
            {
                chartProgress.ChartAreas[0].AxisY.Maximum = double.NaN;
                chartProgress.ChartAreas[0].RecalculateAxesScale();
            }
        }

        private void GenerareDiagramaPrieten()
        {
            chartProgressPrieten.Series[0].Points.Clear();
            chartProgressPrieten.Series[1].Points.Clear();

            Utilizator u = new Utilizator
            {
                UserName = labelUtilizator.Text
            };

            DataTable dt = u.DiagramaUtilizator(u);

            u.UserName = labelUserNamePrieten.Text;
            DataTable rt = u.DiagramaUtilizator(u);

            int contorZero = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartProgressPrieten.Series[0].Points.AddXY(dt.Rows[i][0].ToString(), Convert.ToInt32(dt.Rows[i][1]));
                chartProgressPrieten.Series[1].Points.AddXY(rt.Rows[i][0].ToString(), Convert.ToInt32(rt.Rows[i][1]));

                if (Convert.ToInt32(dt.Rows[i][1]) == 0 && Convert.ToInt32(rt.Rows[i][1]) == 0)
                {
                    contorZero++;
                }
            }

            if (contorZero == dt.Rows.Count)
            {
                chartProgressPrieten.ChartAreas[0].AxisY.Maximum = 20;
            }
            else
            {
                chartProgressPrieten.ChartAreas[0].AxisY.Maximum = double.NaN;
                chartProgressPrieten.ChartAreas[0].RecalculateAxesScale();
            }
        }

        private void AfisareInimiPrieten(int numarInimi)
        {
            if (numarInimi == 3)
            {
                viataPrieten1.Image = viataPrieten2.Image = viataPrieten3.Image = new Bitmap(bitQuiz.Properties.Resources.inima);
            }
            else if (numarInimi == 2)
            {
                viataPrieten1.Image = viataPrieten2.Image = new Bitmap(bitQuiz.Properties.Resources.inima);
                viataPrieten3.Image = new Bitmap(bitQuiz.Properties.Resources.fara_inima);
            }
            else if (numarInimi == 1)
            {
                viataPrieten1.Image = new Bitmap(bitQuiz.Properties.Resources.inima);
                viataPrieten2.Image = viataPrieten3.Image = new Bitmap(bitQuiz.Properties.Resources.fara_inima);
            }
            else
            {
                viataPrieten1.Image = viataPrieten2.Image = viataPrieten3.Image = new Bitmap(bitQuiz.Properties.Resources.fara_inima);
            }
        }

        private void AfisarePrieten(string userNamePrieten, string capitoleTerminate, Image imagine)
        {
            if (!userNamePrieten.Equals(labelUtilizator.Text))
            {
                imagePrietenProfil.Image = imagine;
                labelUserNamePrieten.Text = userNamePrieten;
                labelCapitoleTerminatePrieten.Text = capitoleTerminate;

                Utilizator u = new Utilizator
                {
                    UserName = labelUserNamePrieten.Text
                };

                DataTable dt = u.SelectUtilizatorAcasa(u);

                AfisareInimiPrieten(u.NumarVietiPrieten(u));

                labelNumePrieten.Text = dt.Rows[0][2].ToString();
                labelStarePrieten.Text = dt.Rows[0][3].ToString();
                labelNumarUrmaritoriPrieten.Text = dt.Rows[0][4].ToString();
                labelUrmarestePrieten.Text = dt.Rows[0][5].ToString();

                labelRaspunsuriCorectePrieten.Text = "Răspunsuri corecte: " + dt.Rows[0][6].ToString();
                labelRaspunsuriGresitePrieten.Text = "Răspunsuri greșite: " + dt.Rows[0][7].ToString();
                labelTrasneteFolositePrieten.Text = "Trăsnete folosite: " + dt.Rows[0][8].ToString();
                labelUltimaInregistrarePrieten.Text = dt.Rows[0][12].ToString();

                string[] nume = labelNumePrieten.Text.Split(' ');
                labelPrietenCurent.Text = nume[1];
                string[] numeUtilizator = labelNumeAcasa.Text.Split(' ');
                labelUtilizatorCurent.Text = numeUtilizator[1];

                AfisareRealizariPrieten(dt.Rows[0][11].ToString());
                GenerareDiagramaPrieten();

                u.UserName = labelUtilizator.Text;
                u.Prieten = labelUserNamePrieten.Text;

                if (u.isPrieten(u))
                {
                    buttonUrmareste.Visible = false;
                    buttonUrmaresti.Visible = true;
                }
                else
                {
                    buttonUrmaresti.Visible = false;
                    buttonUrmareste.Visible = true;
                }
                panelPrieten.BringToFront();
            }
        }

        private void AfisareRealizariPrieten(string realizari)
        {
            R1.Visible = R2.Visible = R3.Visible = R4.Visible = R5.Visible = R6.Visible = R7.Visible = R8.Visible = R9.Visible = false;

            string[] realizare = realizari.Split(',');

            foreach (string i in realizare)
            {
                if (i.Equals("1"))
                {
                    R1.Visible = true;
                }
                else if (i.Equals("2"))
                {
                    R2.Visible = true;
                }
                else if (i.Equals("3"))
                {
                    R3.Visible = true;
                }
                else if (i.Equals("4"))
                {
                    R4.Visible = true;
                }
                else if (i.Equals("5"))
                {
                    R5.Visible = true;
                }
                else if (i.Equals("6"))
                {
                    R6.Visible = true;
                }
                else if (i.Equals("7"))
                {
                    R7.Visible = true;
                }
                else if (i.Equals("8"))
                {
                    R8.Visible = true;
                }
                else if (i.Equals("9"))
                {
                    R9.Visible = true;
                }
            }
        }

        private void AfisareProfilPrieten(string s, Image image)
        {
            Utilizator u = new Utilizator
            {
                UserName = s
            };

            AfisarePrieten(s, u.CapitolePrieten(u), image);
        }

        private void imageAltPrieten_Click(object sender, EventArgs e)
        {
            AfisareProfilPrieten(labelUserNameAltPrieten.Text, imageAltPrieten.Image);
        }

        private void StergerePrieten(string numePrieten)
        {
            labelNumarUrmaritoriPrieten.Text = (int.Parse(labelNumarUrmaritoriPrieten.Text) - 1).ToString();
            labelNumarUrmaresti.Text = (int.Parse(labelNumarUrmaresti.Text) - 1).ToString();

            Utilizator u = new Utilizator
            {
                UserName = labelUtilizator.Text,
                Prieten = numePrieten
            };
            u.StergePrieten(u);

            DataTable dt = u.Prieteni(u);

            if (dt.Rows.Count > 0)
            {
                prieten = true;
            }
            else
            {
                prieten = false;
                textBoxCautarePrieteni.Visible = false;
                pictureBoxPrieten1.Visible = false;
                labelPrieten1.Visible = false;
                buttonAdaugaPrieten1.Visible = false;

                pictureBoxPrieten2.Visible = false;
                labelPrieten2.Visible = false;
                buttonAdaugaPrieten2.Visible = false;

                pictureBoxPrieten3.Visible = false;
                labelPrieten3.Visible = false;
                buttonAdaugaPrieten3.Visible = false;

                separatorPrieten1.Visible = false;
                separatorPrieten2.Visible = false;
                labelNiciunUtilizator.Visible = false;
                buttonCautarePrieten.Location = new Point(77, 83);
                panelPrieteni.BringToFront();
            }
        }

        private void buttonUrmareste_Click_1(object sender, EventArgs e)
        {
            buttonUrmareste.Visible = false;
            buttonUrmaresti.Visible = true;

            labelNumarUrmaritoriPrieten.Text = (int.Parse(labelNumarUrmaritoriPrieten.Text) + 1).ToString();

            if (labelUserNameAltPrieten.Text == labelUserNamePrieten.Text && buttonAdaugaAltPrieten.Visible == true)
            {
                buttonAdaugaAltPrieten.Visible = false;
            }
            else if (labelPrieten1.Text == labelUserNamePrieten.Text && buttonAdaugaPrieten1.Visible == true)
            {
                buttonAdaugaPrieten1.Visible = false;
            }
            else if (labelPrieten2.Text == labelUserNamePrieten.Text && buttonAdaugaPrieten2.Visible == true)
            {
                buttonAdaugaPrieten2.Visible = false;
            }
            else if (labelPrieten3.Text == labelUserNamePrieten.Text && buttonAdaugaPrieten3.Visible == true)
            {
                buttonAdaugaPrieten3.Visible = false;
            }

            AdaugaPrieten(labelUserNamePrieten.Text);
            AdaugarePrietenInTabel();
        }

        private void buttonUrmaresti_Click_1(object sender, EventArgs e)
        {
            buttonUrmaresti.Visible = false;
            buttonUrmareste.Visible = true;

            if (labelUserNameAltPrieten.Visible == true && labelUserNameAltPrieten.Text == labelUserNamePrieten.Text && buttonAdaugaAltPrieten.Visible == false)
            {
                buttonAdaugaAltPrieten.Visible = true;
            }
            else if (labelPrieten1.Visible == true && labelPrieten1.Text == labelUserNamePrieten.Text && buttonAdaugaPrieten1.Visible == false)
            {
                buttonAdaugaPrieten1.Visible = true;
            }
            else if (labelPrieten2.Visible == true && labelPrieten2.Text == labelUserNamePrieten.Text && buttonAdaugaPrieten2.Visible == false)
            {
                buttonAdaugaPrieten2.Visible = true;
            }
            else if (labelPrieten3.Visible == true && labelPrieten3.Text == labelUserNamePrieten.Text && buttonAdaugaPrieten3.Visible == false)
            {
                buttonAdaugaPrieten3.Visible = true;
            }

            StergerePrieten(labelUserNamePrieten.Text);
            if (imagineR1.Visible == false && progressBarPrietenos.Value > 0)
            {
                progressBarPrietenos.Value--;
                labelPrietenos.Text = progressBarPrietenos.Value.ToString() + "/" + progressBarPrietenos.MaximumValue.ToString();
            }
            AdaugarePrietenInTabel();
        }

        private void InitilizareFinalizareCapitol()
        {
            AfisareCapitole(numarPagina);

            labelNumarPuncteCapitolFinalizat.Text = "+" + puncteCapitol.ToString() + " puncte";
            imageCapitolFinalizat1.Image = new Bitmap(bitQuiz.Properties.Resources.CapitolFinalizat1);
            labelNumarPuncteCapitolFinalizat.ForeColor = Color.FromArgb(248, 191, 51);
            labelDenumireCapitol.Text = capitol;
            labelProgres.Text = "Progres";
            buttonProgressNext.Image = new Bitmap(bitQuiz.Properties.Resources.chevron_right_120px_yellow);

            panelPrimaPagina.BringToFront();
            panelProgres1.BringToFront();

            panelFinalCapitol.BringToFront();

            SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.ta_da);
            audio.Play();
        }

        private void pictureBoxRealizare_Click(object sender, EventArgs e)
        {
            panelAcasa.BringToFront();
        }

        private void CompletareIntrebare4(string s)
        {
            if (buttonText1.Visible == false)
            {
                buttonText1.Text = s;
                buttonText1.Visible = true;
                buttonVerificare.Visible = true;
            }
            else if (buttonText2.Visible == false)
            {
                buttonText2.Text = s;
                buttonText2.Visible = true;
            }
            else if (buttonText3.Visible == false)
            {
                buttonText3.Text = s;
                buttonText3.Visible = true;
            }
            else if (buttonText4.Visible == false)
            {
                buttonText4.Text = s;
                buttonText4.Visible = true;
            }
            else if (buttonText5.Visible == false)
            {
                buttonText5.Text = s;
                buttonText5.Visible = true;
            }
        }

        private void DecompletareIntrebare4(string s)
        {
            if (btn1.Visible == false && btn1.Text.Equals(s))
            {
                btn1.Visible = true;
            }
            else if (btn2.Visible == false && btn2.Text.Equals(s))
            {
                btn2.Visible = true;
            }
            else if (btn3.Visible == false && btn3.Text.Equals(s))
            {
                btn3.Visible = true;
            }
            else if (btn4.Visible == false && btn4.Text.Equals(s))
            {
                btn4.Visible = true;
            }
            else if (btn5.Visible == false && btn5.Text.Equals(s))
            {
                btn5.Visible = true;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (buttonTrazneste.Visible == true)
            {
                CompletareIntrebare4(btn1.Text);
                btn1.Visible = false;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (buttonTrazneste.Visible == true)
            {
                CompletareIntrebare4(btn2.Text);
                btn2.Visible = false;
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (buttonTrazneste.Visible == true)
            {
                CompletareIntrebare4(btn3.Text);
                btn3.Visible = false;
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (buttonTrazneste.Visible == true)
            {
                CompletareIntrebare4(btn4.Text);
                btn4.Visible = false;
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (buttonTrazneste.Visible == true)
            {
                CompletareIntrebare4(btn5.Text);
                btn5.Visible = false;
            }
        }

        private void buttonText1_Click(object sender, EventArgs e)
        {
            if (buttonText2.Visible == false && buttonTrazneste.Visible == true)
            {
                DecompletareIntrebare4(buttonText1.Text);
                buttonText1.Visible = false;
                buttonText1.Text = null;
                buttonVerificare.Visible = false;
            }
        }

        private void buttonText2_Click(object sender, EventArgs e)
        {
            if (buttonText3.Visible == false && buttonTrazneste.Visible == true)
            {
                DecompletareIntrebare4(buttonText2.Text);
                buttonText2.Visible = false;
                buttonText2.Text = null;
            }
        }

        private void buttonText3_Click(object sender, EventArgs e)
        {
            if (buttonText4.Visible == false && buttonTrazneste.Visible == true)
            {
                DecompletareIntrebare4(buttonText3.Text);
                buttonText3.Visible = false;
                buttonText3.Text = null;
            }
        }

        private void buttonText4_Click(object sender, EventArgs e)
        {
            if (buttonText5.Visible == false && buttonTrazneste.Visible == true)
            {
                DecompletareIntrebare4(buttonText4.Text);
                buttonText4.Visible = false;
                buttonText4.Text = null;
            }
        }

        private void buttonText5_Click(object sender, EventArgs e)
        {
            if (buttonTrazneste.Visible == true)
            {
                DecompletareIntrebare4(buttonText5.Text);
                buttonText5.Visible = false;
                buttonText5.Text = null;
            }
        }

        private void panelIntrebareTip4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void imagineCastig_Click(object sender, EventArgs e)
        {

        }

        private void panelFinalCapitol_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonFinalizareCapitol_Click_2(object sender, EventArgs e)
        {
            if (labelNumarPuncteCapitolFinalizat.Text.Equals("+100 de mere") || labelNumarPuncteCapitolFinalizat.Text.Equals("BONUS +200 de mere"))
            {
                panelActivitate.BringToFront();
            }
            else
            {
                imageCapitolFinalizat1.Image = new Bitmap(bitQuiz.Properties.Resources.CapitolFinalizat2);
                if (avansareNivel == true)
                {
                    SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.realizare);
                    audio.Play();
                    labelNumarPuncteCapitolFinalizat.Text = "BONUS +200 de mere";
                }
                else
                {
                    labelNumarPuncteCapitolFinalizat.Text = "+100 de mere";
                }
                labelNumarPuncteCapitolFinalizat.ForeColor = Color.FromArgb(249, 104, 111);
            }
        }

        private void labelNumarUrmaritori_Click(object sender, EventArgs e)
        {
            if (!labelNumarUrmaritori.Text.Equals("0") && !panelUrmaritori.Visible)
            {
                bunifuVScrollBar4.Value = 0;
                bunifuVScrollBar4.BindingContainer = this.panelUrmaritor;

                panelUrmaritor.Controls.Clear();

                Utilizator u = new Utilizator
                {
                    UserName = labelUtilizator.Text
                };

                DataTable dt = u.SelectUrmaritori(u);

                string numarcapitole = null;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Label Urmaritor = new Label
                    {
                        Name = "Urmaritor" + (i + 1),
                        AutoSize = false,
                        Size = new Size(161, 22),
                        Location = new Point(58, 17 + i * 70),
                        ForeColor = Color.FromArgb(36, 176, 246),
                        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                        Text = dt.Rows[i][1].ToString(),
                        TextAlign = ContentAlignment.TopCenter
                    };

                    panelUrmaritor.Controls.Add(Urmaritor);

                    Label NumeUrmaritor = new Label
                    {
                        Name = "NumeUrmaritor" + (i + 1),
                        AutoSize = false,
                        Size = new Size(156, 21),
                        Location = new Point(60, 36 + i * 70),
                        ForeColor = Color.Silver,
                        Font = new Font("Segoe UI Semibold", 9F),
                        Text = dt.Rows[i][2].ToString(),
                        TextAlign = ContentAlignment.TopCenter
                    };

                    panelUrmaritor.Controls.Add(NumeUrmaritor);

                    Bunifu.Framework.UI.BunifuImageButton bib = new Bunifu.Framework.UI.BunifuImageButton
                    {
                        Name = "ImageUrmaritor" + i + 1,
                        Zoom = 5,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(53, 46),
                        Location = new Point(5, 12 + i * 70),
                        Cursor = Cursors.Hand
                    };

                    byte[] img = (byte[])(dt.Rows[i][0]);
                    MemoryStream ms = new MemoryStream(img);
                    bib.Image = Image.FromStream(ms);
                    numarcapitole = dt.Rows[0][4].ToString();

                    bib.Click += (s, ex) => { AfisarePrieten(Urmaritor.Text, numarcapitole, bib.Image); };

                    panelUrmaritor.Controls.Add(bib);

                    if (i != 0 && i == dt.Rows.Count - 1)
                    {
                        BunifuSeparator bs = new BunifuSeparator
                        {
                            Name = "UrmaritorSeparator" + i,
                            Size = new Size(190, 14),
                            LineThickness = 2,
                            Location = new Point(18, 65 + i * 70),
                            LineColor = Color.White
                        };
                        panelUrmaritor.Controls.Add(bs);
                    }
                }
                panelUrmaritori.Visible = true;
            }
            else if (panelUrmaritori.Visible)
            {
                panelUrmaritori.Visible = false;
            }
        }

        private void labelNumarUrmaritori_MouseEnter(object sender, EventArgs e)
        {
            labelNumarUrmaritori.ForeColor = Color.FromArgb(71, 204, 59);
        }

        private void labelNumarUrmaritori_MouseLeave(object sender, EventArgs e)
        {
            labelNumarUrmaritori.ForeColor = Color.FromArgb(36, 176, 246);
        }

        private void labelNumarUrmaresti_Click(object sender, EventArgs e)
        {
            if (!labelNumarUrmaresti.Text.Equals("0") && labelProgres.Text.Equals("Progres"))
            {
                ButtonProgressNext_Click(sender, e);
            }
        }

        private void labelNumarUrmaresti_MouseEnter(object sender, EventArgs e)
        {
            labelNumarUrmaresti.ForeColor = Color.FromArgb(71, 204, 59);
        }

        private void labelNumarUrmaresti_MouseLeave(object sender, EventArgs e)
        {
            labelNumarUrmaresti.ForeColor = Color.FromArgb(36, 176, 246);
        }

        private void InimiRecuperare()
        {
            bright.Image = bunifuImageButton7.Image;
            bleft.Image = bunifuImageButton6.Image;
            labelAiRamasFaraInimi.Text = "Inimi recuperate";
            labelDinGreseliInveti.Text = "Hai să începem!";
            imagineInima.Image = new Bitmap(bitQuiz.Properties.Resources.inima_buna);
            imagineInima1.Image = imagineInima2.Image = imagineInima3.Image = new Bitmap(bitQuiz.Properties.Resources.inima);
        }

        private void InitializareFaraInimi()
        {
            using (SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.loss))
            {
                audio.Play();
            }

            labelProgres.Text = "Progres";
            buttonProgressNext.Image = new Bitmap(bitQuiz.Properties.Resources.chevron_right_120px_yellow);

            bright.Image = new Bitmap(bitQuiz.Properties.Resources.bright);
            bleft.Image = new Bitmap(bitQuiz.Properties.Resources.bleft);
            labelAiRamasFaraInimi.Text = "Ai rămas fără inimi";
            labelDinGreseliInveti.Text = "Din greșeli înveți!";
            imagineInima.Image = new Bitmap(bitQuiz.Properties.Resources.inima_stricata);
            imagineInima1.Image = imagineInima2.Image = imagineInima3.Image = new Bitmap(bitQuiz.Properties.Resources.fara_inima);

            panelProgres1.BringToFront();
        }
    }
}
