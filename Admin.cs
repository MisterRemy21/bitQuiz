using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Teste;

namespace bitQuiz
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();

            PaginaPrincipala();
            AfisarePanelJucatori();
            AfisarePanelIntrebari();
            AfisarePanelCapitole();
        }

        private void PaginaPrincipala()
        {
            AfisareTop3();
            AfisareStatisticiUtilizatori();
            AfisareStatisticiIntrebari();
        }

        private Image ConvertImageFromByte(byte[] image)
        {
            using (MemoryStream memstr = new MemoryStream(image))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }

        private byte[] ConvertByteFromImage(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                return stream.ToArray();
            }
        }

        private void AfisareTop3()
        {
            Utilizator u = new Utilizator();
            DataTable dt = u.ClasamentTop3();

            imageLocul1.Image = ConvertImageFromByte((byte[])(dt.Rows[0][1]));
            imageLocul2.Image = ConvertImageFromByte((byte[])(dt.Rows[1][1]));
            imageLocul3.Image = ConvertImageFromByte((byte[])(dt.Rows[2][1]));

            userName1.Text = dt.Rows[0][2].ToString();
            userName2.Text = dt.Rows[1][2].ToString();
            userName3.Text = dt.Rows[2][2].ToString();

            nume1.Text = dt.Rows[0][3].ToString();
            nume2.Text = dt.Rows[1][3].ToString();
            nume3.Text = dt.Rows[2][3].ToString();
        }

        private void AfisareStatisticiUtilizatori()
        {
            chartProgress.Series[0].Points.Clear();

            Utilizator u = new Utilizator();
            DataTable dt = u.StatisticiUtilizatori();

            chartProgress.Series[0].Points.AddXY("Jucători", Convert.ToInt32(dt.Rows[0][0]));
            chartProgress.Series[0].Points[0].Color = Color.FromArgb(36, 176, 246);

            chartProgress.Series[0].Points.AddXY("Activi", Convert.ToInt32(dt.Rows[0][1]));
            chartProgress.Series[0].Points[1].Color = Color.FromArgb(71, 204, 59);

            chartProgress.Series[0].Points.AddXY("Inactivi", Convert.ToInt32(dt.Rows[0][2]));
            chartProgress.Series[0].Points[2].Color = Color.FromArgb(249, 104, 111);

            chartProgress.Series[0].Points.AddXY("Fără inimi", Convert.ToInt32(dt.Rows[0][3]));
            chartProgress.Series[0].Points[3].Color = Color.FromArgb(232, 232, 232);

            chartProgress.Series[0].Points.AddXY("Regi", Convert.ToInt32(dt.Rows[0][4]));
        }

        private void AfisareStatisticiIntrebari()
        {
            Intrebare intrebare = new Intrebare();
            DataTable dt = intrebare.GraficIntrebari();

            panelIntrebari.Visible = false;
            bunifuVScrollBar3.Value = 0;
            panelIntrebari.Controls.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Label Id = new Label
                {
                    Name = "Id_Intrebare" + (i + 1),
                    AutoSize = false,
                    Size = new Size(43, 25),
                    Location = new Point(5, 16 + i * 45),
                    ForeColor = Color.FromArgb(192, 192, 202),
                    Font = new Font("Segoe UI Semibold", 10F),
                    Text = dt.Rows[i][0].ToString(),
                    TextAlign = ContentAlignment.TopCenter
                };

                Label Enunt = new Label
                {
                    Name = "Enunt" + (i + 1),
                    AutoSize = false,
                    Size = new Size(160, 39),
                    Location = new Point(63, 16 + i * 45),
                    ForeColor = Color.FromArgb(36, 176, 246),
                    Font = new Font("Segoe UI Semibold", 9F),
                    Text = dt.Rows[i][1].ToString(),
                    TextAlign = ContentAlignment.TopLeft
                };

                Label Capitol = new Label
                {
                    Name = "Capitol" + (i + 1),
                    AutoSize = false,
                    Size = new Size(143, 39),
                    Location = new Point(240, 16 + i * 45),
                    ForeColor = Color.FromArgb(192, 192, 202),
                    Font = new Font("Segoe UI Semibold", 9F),
                    Text = dt.Rows[i][2].ToString(),
                    TextAlign = ContentAlignment.TopCenter
                };

                Label Dificultate = new Label
                {
                    Name = "Dificultate" + (i + 1),
                    AutoSize = false,
                    Size = new Size(104, 25),
                    Location = new Point(389, 16 + i * 45),
                    ForeColor = Color.FromArgb(192, 192, 202),
                    Font = new Font("Segoe UI Semibold", 9F),
                    Text = dt.Rows[i][3].ToString(),
                    TextAlign = ContentAlignment.TopCenter
                };

                if (Dificultate.Text.Equals("Usor"))
                {
                    Dificultate.ForeColor = Color.FromArgb(71, 204, 59);
                }
                else if (Dificultate.Text.Equals("Mediu"))
                {
                    Dificultate.ForeColor = Color.FromArgb(248, 191, 51);
                }
                else
                {
                    Dificultate.ForeColor = Color.FromArgb(249, 104, 111);
                }

                Label Corect = new Label
                {
                    Name = "Corect" + (i + 1),
                    AutoSize = false,
                    Size = new Size(65, 21),
                    Location = new Point(508, 16 + i * 45),
                    ForeColor = Color.FromArgb(71, 204, 59),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Text = dt.Rows[i][4].ToString(),
                    TextAlign = ContentAlignment.TopCenter
                };

                Label Gresit = new Label
                {
                    Name = "Gresit" + (i + 1),
                    AutoSize = false,
                    Size = new Size(65, 21),
                    Location = new Point(579, 16 + i * 45),
                    ForeColor = Color.FromArgb(249, 104, 111),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Text = dt.Rows[i][5].ToString(),
                    TextAlign = ContentAlignment.TopCenter
                };

                Bunifu.Framework.UI.BunifuImageButton bibb = new Bunifu.Framework.UI.BunifuImageButton
                {
                    Name = "InfoStatistici" + i,
                    Zoom = 8,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(35, 23),
                    Location = new Point(641, 13 + i * 45),
                    Cursor = Cursors.Hand,
                    Image = new Bitmap(bitQuiz.Properties.Resources.info)
                };

                bibb.Click += (s, ex) => { ModificareIntrebare(Id.Text); };

                panelIntrebari.Controls.Add(Dificultate);
                panelIntrebari.Controls.Add(Id);
                panelIntrebari.Controls.Add(Enunt);
                panelIntrebari.Controls.Add(Capitol);
                panelIntrebari.Controls.Add(Corect);
                panelIntrebari.Controls.Add(Gresit);
                panelIntrebari.Controls.Add(bibb);
            }

            panelIntrebari.Visible = true;
        }

        bool isTabelCapitolAfisat = false;
        private void AfisarePanelCapitole()
        {
            if (!isTabelCapitolAfisat)
            {
                isTabelCapitolAfisat = true;
                bunifuVScrollBar1.Value = 0;

                Capitol c = new Capitol();
                panelCapitole.Visible = false;
                AfisareTabelCapitole(c.AfisareCapitolTable());
                panelCapitole.Visible = true;
            }
        }
        private void buttonCautareCapitol_Click(object sender, EventArgs e)
        {
            if (txtBoxCautareCapitol.Text.Length > 2)
            {
                isTabelCapitolAfisat = false;
                bunifuVScrollBar1.Value = 0;

                Capitol c = new Capitol();

                panelCapitole.Visible = false;
                AfisareTabelCapitole(c.SearchCapitol(txtBoxCautareCapitol.Text));
                panelCapitole.Visible = true;
            }
        }

        private void AfisareTabelCapitole(DataTable dt)
        {
            panelCapitole.Controls.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Label Id = new Label
                {
                    Name = "Capitol_id" + (i + 1),
                    AutoSize = false,
                    Size = new Size(46, 45),
                    Location = new Point(11, 9 + i * 76),
                    ForeColor = Color.FromArgb(192, 192, 202),
                    Font = new Font("Segoe UI Semibold", 14F),
                    Text = dt.Rows[i][0].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };


                Bunifu.Framework.UI.BunifuImageButton bib = new Bunifu.Framework.UI.BunifuImageButton
                {
                    Name = "CapitolImagine" + (i + 1),
                    Zoom = 5,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(67, 45),
                    Location = new Point(85, 9 + i * 76),
                    Cursor = Cursors.Hand,
                    Image = ConvertImageFromByte((byte[])(dt.Rows[i][1]))
                };


                Label Descriere = new Label
                {
                    Name = "DescriereCapitol" + (i + 1),
                    AutoSize = false,
                    Size = new Size(168, 45),
                    Location = new Point(163, 9 + i * 76),
                    ForeColor = Color.FromArgb(36, 176, 246),
                    Font = new Font("Segoe UI Semibold", 10F),
                    Text = dt.Rows[i][2].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };


                Label Dificultate = new Label
                {
                    Name = "DificultateCapitol" + (i + 1),
                    AutoSize = false,
                    Size = new Size(120, 45),
                    Location = new Point(320, 9 + i * 76),
                    ForeColor = Color.FromArgb(36, 176, 246),
                    Font = new Font("Segoe UI Semibold", 10F),
                    Text = dt.Rows[i][3].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                if (Dificultate.Text.Equals("Usor"))
                {
                    Dificultate.ForeColor = Color.FromArgb(71, 204, 59);
                }
                else if (Dificultate.Text.Equals("Mediu"))
                {
                    Dificultate.ForeColor = Color.FromArgb(248, 191, 51);
                }
                else
                {
                    Dificultate.ForeColor = Color.FromArgb(249, 104, 111);
                }

                Label Intrebari = new Label
                {
                    Name = "IntrebariCapitol" + (i + 1),
                    AutoSize = false,
                    Size = new Size(120, 45),
                    Location = new Point(430, 9 + i * 76),
                    ForeColor = Color.FromArgb(36, 176, 246),
                    Font = new Font("Segoe UI Semibold", 10F),
                    Text = dt.Rows[i][4].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };


                Label Puncte = new Label
                {
                    Name = "PuncteCapitol" + (i + 1),
                    AutoSize = false,
                    Size = new Size(80, 45),
                    Location = new Point(545, 9 + i * 76),
                    ForeColor = Color.FromArgb(248, 191, 51),
                    Font = new Font("Segoe UI Semibold", 10F),
                    Text = dt.Rows[i][5].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };


                Bunifu.Framework.UI.BunifuImageButton bibb = new Bunifu.Framework.UI.BunifuImageButton
                {
                    Name = "InfoCapitolTabel" + i,
                    Zoom = 8,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(35, 23),
                    Location = new Point(641, 20 + i * 76),
                    Cursor = Cursors.Hand,
                    Image = new Bitmap(bitQuiz.Properties.Resources.info)
                };

                bibb.Click += (s, ex) => { ExtragereCapitol(Descriere.Text); };

                BunifuSeparator bs = new BunifuSeparator
                {
                    Name = "BunifuSeparatorCapitol" + i,
                    Size = new Size(648, 21),
                    LineThickness = 2,
                    Location = new Point(15, 55 + i * 76)
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

                panelCapitole.Controls.Add(Id);
                panelCapitole.Controls.Add(Puncte);
                panelCapitole.Controls.Add(Descriere);
                panelCapitole.Controls.Add(Dificultate);
                panelCapitole.Controls.Add(Intrebari);
                panelCapitole.Controls.Add(bib);
                panelCapitole.Controls.Add(bibb);
                panelCapitole.Controls.Add(bs);

                bibb.BringToFront();
            }
        }


        private void buttonLogo_Click(object sender, EventArgs e)
        {
            PaginaPrincipala();

            labelMeniu.Text = "Prima pagină";
            panelPaginaPrincipala.BringToFront();
            userControlMenu.Height = buttonAcasa.Height;
            userControlMenu.Top = buttonAcasa.Top;
        }

        private void buttonCapitolNou_Click(object sender, EventArgs e)
        {
            ClearCapitol();

            buttonStergere.Visible = false;
            buttonAdaugare.Text = "Adăugare";

            panelAdaugareCapitol.Visible = true;
            panelCapitole.Size = new Size(683, 136);
            panelCapitole.Location = new Point(23, 56);

            bunifuVScrollBar1.Size = new Size(17, 136);
            bunifuVScrollBar1.Location = new Point(712, 56);
            panel4.Location = new Point(23, 201);
        }

        private void buttonCapitole_Click(object sender, EventArgs e)
        {
            labelMeniu.Text = "Capitole";
            txtBoxCautareCapitol.Text = "";

            AfisarePanelCapitole();

            panelAdaugareCapitol.Visible = false;
            panelCapitole.Size = new Size(683, 281);
            panelCapitole.Location = new Point(23, 56);

            bunifuVScrollBar1.Size = new Size(17, 281);
            bunifuVScrollBar1.Location = new Point(712, 56);
            panel4.Location = new Point(23, 357);

            panelCapitol.BringToFront();
            userControlMenu.Height = buttonCapitole.Height;
            userControlMenu.Top = buttonCapitole.Top;
        }

        private void IntrebareAdaugata()
        {
            Eroare.textEroare = "Întrebare adăugată";
            Eroare er = new Eroare
            {
                StartPosition = FormStartPosition.CenterParent
            };
            er.ShowDialog();
        }

        bool isTabelJucatoriAfisat = false;

        private void AfisarePanelJucatori()
        {
            if (!isTabelJucatoriAfisat)
            {
                isTabelJucatoriAfisat = true;
                bunifuVScrollBar2.Value = 0;

                Utilizator u = new Utilizator();
                panelJucatori.Visible = false;
                AfisareTabelJucatori(u.TableJucator());
                panelJucatori.Visible = true;
            }
        }

        private void buttonCautareJucator_Click(object sender, EventArgs e)
        {
            if (textBoxCautareJucator.Text.Length > 0)
            {
                isTabelJucatoriAfisat = false;
                bunifuVScrollBar2.Value = 0;

                Utilizator u = new Utilizator();
                panelJucatori.Visible = false;
                AfisareTabelJucatori(u.Jucatori(textBoxCautareJucator.Text));
                panelJucatori.Visible = true;
            }
        }

        private void AfisareTabelJucatori(DataTable dt)
        {
            panelJucatori.Controls.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Label Id = new Label
                {
                    Name = "Utilizator_id" + i,
                    AutoSize = false,
                    Size = new Size(46, 45),
                    Location = new Point(11, 9 + i * 76),
                    ForeColor = Color.FromArgb(192, 192, 202),
                    Font = new Font("Segoe UI Semibold", 14F),
                    Text = dt.Rows[i][0].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelJucatori.Controls.Add(Id);

                Bunifu.Framework.UI.BunifuImageButton bib = new Bunifu.Framework.UI.BunifuImageButton
                {
                    Name = "ImagineUtilizator" + i,
                    Zoom = 5,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(53, 46),
                    Location = new Point(69, 9 + i * 76),
                    Cursor = Cursors.Hand,
                    Image = ConvertImageFromByte((byte[])(dt.Rows[i][1]))
                };

                panelJucatori.Controls.Add(bib);

                Label UserName = new Label
                {
                    Name = "UserNameUtilizator" + i,
                    AutoSize = false,
                    Size = new Size(148, 23),
                    Location = new Point(128, 11 + i * 76),
                    ForeColor = Color.FromArgb(36, 176, 246),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Text = dt.Rows[i][2].ToString(),
                    TextAlign = ContentAlignment.TopCenter
                };

                panelJucatori.Controls.Add(UserName);

                Label Nume = new Label
                {
                    Name = "NumeUtilizator" + (i + 1),
                    AutoSize = false,
                    Size = new Size(148, 20),
                    Location = new Point(128, 33 + i * 76),
                    ForeColor = Color.FromArgb(192, 192, 202),
                    Font = new Font("Segoe UI Semibold", 9F),
                    Text = dt.Rows[i][3].ToString(),
                    TextAlign = ContentAlignment.TopCenter
                };

                panelJucatori.Controls.Add(Nume);

                Label Capitole = new Label
                {
                    Name = "PuncteUtilizator" + i,
                    AutoSize = false,
                    Size = new Size(85, 45),
                    Location = new Point(297, 9 + i * 76),
                    ForeColor = Color.FromArgb(36, 176, 246),
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Text = dt.Rows[i][4].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelJucatori.Controls.Add(Capitole);

                Label Nivel = new Label
                {
                    Name = "PuncteUtilizator" + i,
                    AutoSize = false,
                    Size = new Size(46, 45),
                    Location = new Point(451, 9 + i * 76),
                    ForeColor = Color.FromArgb(36, 176, 246),
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Text = dt.Rows[i][5].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelJucatori.Controls.Add(Nivel);

                Label Puncte = new Label
                {
                    Name = "PuncteUtilizator" + i,
                    AutoSize = false,
                    Size = new Size(46, 45),
                    Location = new Point(566, 9 + i * 76),
                    ForeColor = Color.FromArgb(248, 191, 51),
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Text = dt.Rows[i][6].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelJucatori.Controls.Add(Puncte);

                BunifuSeparator bs = new BunifuSeparator
                {
                    Name = "BunifuSeparatorUtilizator" + i,
                    Size = new Size(648, 21),
                    LineThickness = 2,
                    Location = new Point(15, 55 + i * 76)
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

                panelJucatori.Controls.Add(bs);
            }
        }

        private void buttonUtilizatori_Click(object sender, EventArgs e)
        {
            textBoxCautareJucator.Text = "";
            labelMeniu.Text = "Utilizatori";

            AfisarePanelJucatori();

            panelUtilizatori.BringToFront();

            userControlMenu.Height = buttonUtilizatori.Height;
            userControlMenu.Top = buttonUtilizatori.Top;
        }

        private void panelCapitol_MouseEnter(object sender, EventArgs e)
        {
        }

        private void buttonAcasa_Click(object sender, EventArgs e)
        {
            PaginaPrincipala();
            labelMeniu.Text = "Prima pagină";

            panelPaginaPrincipala.BringToFront();
            userControlMenu.Height = buttonAcasa.Height;
            userControlMenu.Top = buttonAcasa.Top;
        }

        private void buttonIntrebari_Click(object sender, EventArgs e)
        {
            txtBoxSearchIntrebare.Text = "";
            labelMeniu.Text = "Întrebări";

            AfisarePanelIntrebari();

            panelIntrebare.BringToFront();
            userControlMenu.Height = buttonIntrebari.Height;
            userControlMenu.Top = buttonIntrebari.Top;
        }

        bool isTabelIntrebariAfisat = false;

        private void AfisarePanelIntrebari()
        {
            if (!isTabelIntrebariAfisat)
            {
                isTabelIntrebariAfisat = true;
                bunifuVScrollBar3.Value = 0;

                Intrebare intrebare = new Intrebare();

                panelIntrebarile.Visible = false;
                AfisareTabelIntrebari(intrebare.AfisareIntrebari());
                panelIntrebarile.Visible = true;
            }
        }

        private void buttonCautareIntrebare_Click(object sender, EventArgs e)
        {
            if (txtBoxSearchIntrebare.Text.Length > 0)
            {
                isTabelIntrebariAfisat = false;
                bunifuVScrollBar3.Value = 0;

                Intrebare intrebare = new Intrebare();

                panelIntrebarile.Visible = false;
                AfisareTabelIntrebari(intrebare.CautareIntrebari(txtBoxSearchIntrebare.Text));
                panelIntrebarile.Visible = true;
            }
        }

        private void AfisareTabelIntrebari(DataTable dt)
        {
            panelIntrebarile.Controls.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Label Id = new Label
                {
                    Name = "Intrebare_id" + i,
                    AutoSize = false,
                    Size = new Size(46, 45),
                    Location = new Point(11, 9 + i * 76),
                    ForeColor = Color.FromArgb(192, 192, 202),
                    Font = new Font("Segoe UI Semibold", 14F),
                    Text = dt.Rows[i][0].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelIntrebarile.Controls.Add(Id);


                Label Enunt = new Label
                {
                    Name = "EnuntIntrebareTable" + i,
                    AutoSize = false,
                    Size = new Size(171, 36),
                    Location = new Point(72, 15 + i * 76),
                    ForeColor = Color.FromArgb(36, 176, 246),
                    Font = new Font("Segoe UI Semibold", 9F),
                    Text = dt.Rows[i][1].ToString(),
                    TextAlign = ContentAlignment.TopLeft
                };

                panelIntrebarile.Controls.Add(Enunt);

                Label Capitol = new Label
                {
                    Name = "CapitolIntrebareTabel" + i,
                    AutoSize = false,
                    Size = new Size(145, 36),
                    Location = new Point(242, 12 + i * 76),
                    ForeColor = Color.FromArgb(192, 192, 202),
                    Font = new Font("Segoe UI Semibold", 9F),
                    Text = dt.Rows[i][2].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelIntrebarile.Controls.Add(Capitol);

                Label Dificultate = new Label
                {
                    Name = "DificultateIntrebareTabel" + i,
                    AutoSize = false,
                    Size = new Size(46, 45),
                    Location = new Point(417, 9 + i * 76),
                    ForeColor = Color.FromArgb(192, 192, 202),
                    Font = new Font("Segoe UI Semibold", 10F),
                    Text = dt.Rows[i][3].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                if (Dificultate.Text.Equals("Usor"))
                {
                    Dificultate.ForeColor = Color.FromArgb(71, 204, 59);
                }
                else if (Dificultate.Text.Equals("Mediu"))
                {
                    Dificultate.ForeColor = Color.FromArgb(248, 191, 51);
                }
                else
                {
                    Dificultate.ForeColor = Color.FromArgb(249, 104, 111);
                }

                panelIntrebarile.Controls.Add(Dificultate);

                Label RaspunsCorect = new Label
                {
                    Name = "RaspunsCorectTabel" + i,
                    AutoSize = false,
                    Size = new Size(46, 45),
                    Location = new Point(517, 9 + i * 76),
                    ForeColor = Color.FromArgb(71, 204, 59),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Text = dt.Rows[i][4].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelIntrebarile.Controls.Add(RaspunsCorect);

                Label RaspunsGresit = new Label
                {
                    Name = "RaspunsGresitTabel" + i,
                    AutoSize = false,
                    Size = new Size(46, 45),
                    Location = new Point(588, 9 + i * 76),
                    ForeColor = Color.FromArgb(234, 72, 85),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Text = dt.Rows[i][5].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelIntrebarile.Controls.Add(RaspunsGresit);

                Bunifu.Framework.UI.BunifuImageButton bib = new Bunifu.Framework.UI.BunifuImageButton
                {
                    Name = "InfoIntrebareTabel" + i,
                    Zoom = 8,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(35, 23),
                    Location = new Point(641, 20 + i * 76),
                    Cursor = Cursors.Hand,
                    Image = new Bitmap(bitQuiz.Properties.Resources.info)
                };

                bib.Click += (s, ex) => { ModificareIntrebare(Id.Text); };

                panelIntrebarile.Controls.Add(bib);

                BunifuSeparator bs = new BunifuSeparator
                {
                    Name = "BunifuSeparatorUtilizator" + i,
                    Size = new Size(648, 21),
                    LineThickness = 2,
                    Location = new Point(15, 55 + i * 76)
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

                panelIntrebarile.Controls.Add(bs);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Hide();
            Login l = new Login();
            l.ShowDialog();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuVScrollBar4_Scroll(object sender, BunifuVScrollBar.ScrollEventArgs e)
        {

        }

        private void txtBoxSearchIntrebare_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonIntrebareNoua_Click(object sender, EventArgs e)
        {
            dropDownTipIntrebare.Text = "Răspuns prin cod";
            dropDownCapitol.Text = "   Capitol";
            buttonAdaugareIntrebare.Text = "Adăugare";

            AdaugareCapitoleDropDown();
            ClearIntrebareTip1();
            panelIntrebareNoua.BringToFront();
            panelIntrebareTip1.BringToFront();
        }

        private void dropDownTipIntrebare_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonAdaugareIntrebare.Text = "Adăugare";

            if (dropDownTipIntrebare.Text.Equals("Răspuns prin cod"))
            {
                ClearIntrebareTip1();
                panelIntrebareTip1.BringToFront();
            }
            else if (dropDownTipIntrebare.Text.Equals("Răspuns prin variante"))
            {
                ClearIntrebareTip2();
                panelIntrebareTip2.BringToFront();
            }
            else if (dropDownTipIntrebare.Text.Equals("Răspuns prin imagine"))
            {
                ClearIntrebareTip3();
                panelIntrebareTip3.BringToFront();
            }
            else if (dropDownTipIntrebare.Text.Equals("Răspuns prin completare"))
            {
                ClearIntrebareTip4();
                panelIntrebareTip4.BringToFront();
            }
        }

        private void AdaugareCapitoleDropDown()
        {
            Capitol c = new Capitol();
            DataTable dt = c.AfisareCapitolTable();

            dropDownCapitol.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dropDownCapitol.Items.Add(dt.Rows[i][2].ToString());
            }
        }

        private void CautareImagineFisier(Bunifu.Framework.UI.BunifuImageButton image)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image.ImageLocation = dialog.FileName.ToString();
            }
        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void imageA_Click(object sender, EventArgs e)
        {
            CautareImagineFisier(imageA);
        }

        private void imageB_Click(object sender, EventArgs e)
        {
            CautareImagineFisier(imageB);
        }

        private void imageC_Click(object sender, EventArgs e)
        {
            CautareImagineFisier(imageC);
        }

        private void imageA_DoubleClick(object sender, EventArgs e)
        {
        }

        private void txtBoxRaspunsA_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Muie");

        }

        private void ClearIntrebareTip1()
        {
            raspunsCorect = null;
            txtBoxCerintaCod.Text = txtBoxInserareCod.Text = "";
        }

        private void ClearIntrebareTip2()
        {
            raspunsCorect = null;
            textBoxVarianta1.Text = textBoxVarianta2.Text = textBoxVarianta3.Text = textBoxEnuntTip2.Text = "";
            raspunsTip1A.Image = raspunsTip1B.Image = raspunsTip1C.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);
            RA = RB = RC = false;
        }

        private void ClearIntrebareTip3()
        {
            raspunsCorect = null;
            txtBoxCerintaImagine2.Text = txtBoxCerintaImagine.Text = txtBoxRaspunsA.Text = txtBoxRaspunsB.Text = txtBoxRaspunsC.Text = "";
            userControlA.BorderColor = userControlB.BorderColor = userControlC.BorderColor = Color.FromArgb(229, 229, 229);
            raspunsA.Image = raspunsB.Image = raspunsC.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);
            imageA.Image = new Bitmap(bitQuiz.Properties.Resources._1apple);
            imageB.Image = new Bitmap(bitQuiz.Properties.Resources._2pples);
            imageC.Image = new Bitmap(bitQuiz.Properties.Resources._3apples);
        }

        private void ClearIntrebareTip4()
        {
            raspunsCorect = null;
            labelEnuntTip4.Text = textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
            R1 = R2 = R3 = R4 = R5 = false;
            raspuns1.Image = raspuns2.Image = raspuns3.Image = raspuns4.Image = raspuns5.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);
        }

        string raspunsCorect;

        private void raspunsA_Click(object sender, EventArgs e)
        {
            raspunsCorect = "A";
            raspunsA.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
            raspunsB.Image = raspunsC.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);

            userControlA.BorderColor = Color.FromArgb(163, 192, 62);
            userControlB.BorderColor = Color.FromArgb(229, 229, 229);
            userControlC.BorderColor = Color.FromArgb(229, 229, 229);
        }

        private void raspunsB_Click(object sender, EventArgs e)
        {
            raspunsCorect = "B";

            raspunsB.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
            raspunsA.Image = raspunsC.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);

            userControlA.BorderColor = Color.FromArgb(229, 229, 229);
            userControlB.BorderColor = Color.FromArgb(163, 192, 62);
            userControlC.BorderColor = Color.FromArgb(229, 229, 229);
        }

        private void raspunsC_Click(object sender, EventArgs e)
        {
            raspunsCorect = "C";

            raspunsC.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
            raspunsA.Image = raspunsB.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);

            userControlA.BorderColor = Color.FromArgb(229, 229, 229);
            userControlB.BorderColor = Color.FromArgb(229, 229, 229);
            userControlC.BorderColor = Color.FromArgb(163, 192, 62);
        }

        private void buttonAdaugareIntrebare_Click(object sender, EventArgs e)
        {
            Intrebare i = new Intrebare();
            Eroare.textEroare = "Câmpuri necompletate";
            Eroare er = new Eroare
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (buttonAdaugareIntrebare.Text.Equals("Adăugare"))
            {
                if (dropDownTipIntrebare.Text.Equals("Răspuns prin cod") && !txtBoxCerintaCod.Text.Equals("") && !txtBoxInserareCod.Text.Equals("") && !dropDownCapitol.Text.Equals("   Capitol"))
                {
                    i.Descriere = dropDownCapitol.Text;
                    i.Enunt = txtBoxCerintaCod.Text;
                    i.RaspunsCorect = txtBoxInserareCod.Text;
                    i.InserareIntrebareTip1(i);

                    isTabelIntrebariAfisat = false;
                    IntrebareAdaugata();
                    ClearIntrebareTip1();
                }
                else if (dropDownTipIntrebare.Text.Equals("Răspuns prin variante") && !dropDownCapitol.Text.Equals("   Capitol") && !textBoxVarianta1.Text.Equals("") && !textBoxVarianta2.Text.Equals("") && !textBoxVarianta3.Text.Equals("") && !textBoxEnuntTip2.Text.Equals(""))
                {
                    RaspunsCorectTip2And4();

                    if (raspunsCorect == null)
                    {
                        er.ShowDialog();
                    }
                    else
                    {
                        i.Descriere = dropDownCapitol.Text;
                        i.Enunt = textBoxEnuntTip2.Text;
                        i.Raspuns_A = textBoxVarianta1.Text;
                        i.Raspuns_B = textBoxVarianta2.Text;
                        i.Raspuns_C = textBoxVarianta3.Text;
                        i.RaspunsCorect = raspunsCorect;

                        i.InserareIntrebareTip2(i);

                        isTabelCapitolAfisat = false;
                        isTabelIntrebariAfisat = false;
                        IntrebareAdaugata();
                        ClearIntrebareTip2();
                    }
                }
                else if (dropDownTipIntrebare.Text.Equals("Răspuns prin imagine") && !dropDownCapitol.Text.Equals("   Capitol") && !txtBoxCerintaImagine.Text.Equals("") && !txtBoxCerintaImagine2.Equals("") && !txtBoxRaspunsA.Text.Equals("") && !txtBoxRaspunsB.Text.Equals("") && !txtBoxRaspunsC.Text.Equals("") && raspunsCorect != null)
                {
                    i.Descriere = dropDownCapitol.Text;
                    i.Enunt = txtBoxCerintaImagine.Text;
                    i.EnuntSuplimentar = txtBoxCerintaImagine2.Text;
                    i.ImagineA = ConvertByteFromImage(imageA.Image);
                    i.ImagineB = ConvertByteFromImage(imageB.Image);
                    i.ImagineC = ConvertByteFromImage(imageC.Image);
                    i.Raspuns_A = txtBoxRaspunsA.Text;
                    i.Raspuns_B = txtBoxRaspunsB.Text;
                    i.Raspuns_C = txtBoxRaspunsC.Text;
                    i.RaspunsCorect = raspunsCorect;

                    i.InserareIntrebareTip3(i);

                    isTabelCapitolAfisat = false;
                    isTabelIntrebariAfisat = false;
                    IntrebareAdaugata();
                    ClearIntrebareTip3();
                }
                else if (dropDownTipIntrebare.Text.Equals("Răspuns prin completare") && !dropDownCapitol.Text.Equals("   Capitol") && !textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals("") && !textBox4.Text.Equals("") && !textBox5.Text.Equals("") && !labelEnuntTip4.Text.Equals(""))
                {
                    RaspunsCorectTip2And4();

                    if (raspunsCorect == null)
                    {
                        er.ShowDialog();
                    }
                    else
                    {
                        i.Descriere = dropDownCapitol.Text;
                        i.Enunt = labelEnuntTip4.Text;
                        i.Raspuns_A = textBox1.Text;
                        i.Raspuns_B = textBox2.Text;
                        i.Raspuns_C = textBox3.Text;
                        i.Raspuns_D = textBox4.Text;
                        i.Raspuns_E = textBox5.Text;
                        i.RaspunsCorect = raspunsCorect;

                        i.InserareIntrebareTip4(i);

                        isTabelCapitolAfisat = false;
                        isTabelIntrebariAfisat = false;
                        IntrebareAdaugata();
                        ClearIntrebareTip4();
                    }
                }
                else
                {
                    er.ShowDialog(this);
                }
            }
            else
            {
                if (dropDownTipIntrebare.Text.Equals("Răspuns prin cod") && !txtBoxCerintaCod.Text.Equals("") && !txtBoxInserareCod.Text.Equals("") && !dropDownCapitol.Text.Equals("   Capitol"))
                {
                    i.Id = int.Parse(labelIdIntrebare.Text);
                    i.Descriere = dropDownCapitol.Text;
                    i.Tip = 1;
                    i.Enunt = txtBoxCerintaCod.Text;
                    i.RaspunsCorect = txtBoxInserareCod.Text;

                    i.UpdateIntrebare(i);

                    isTabelCapitolAfisat = false;
                    isTabelIntrebariAfisat = false;

                    IntrebareModificata();
                }
                else if (dropDownTipIntrebare.Text.Equals("Răspuns prin variante") && !dropDownCapitol.Text.Equals("   Capitol") && !textBoxVarianta1.Text.Equals("") && !textBoxVarianta2.Text.Equals("") && !textBoxVarianta3.Text.Equals("") && !textBoxEnuntTip2.Text.Equals(""))
                {
                    RaspunsCorectTip2And4();

                    if (raspunsCorect == null)
                    {
                        er.ShowDialog();
                    }
                    else
                    {
                        i.Id = int.Parse(labelIdIntrebare.Text);
                        i.Tip = 2;
                        i.Descriere = dropDownCapitol.Text;
                        i.Enunt = textBoxEnuntTip2.Text;
                        i.Raspuns_A = textBoxVarianta1.Text;
                        i.Raspuns_B = textBoxVarianta2.Text;
                        i.Raspuns_C = textBoxVarianta3.Text;
                        i.RaspunsCorect = raspunsCorect;

                        i.UpdateIntrebare(i);
                        isTabelIntrebariAfisat = false;

                        IntrebareModificata();
                    }
                }
                else if (dropDownTipIntrebare.Text.Equals("Răspuns prin imagine") && !dropDownCapitol.Text.Equals("   Capitol") && !txtBoxCerintaImagine.Text.Equals("") && !txtBoxCerintaImagine2.Equals("") && !txtBoxRaspunsA.Text.Equals("") && !txtBoxRaspunsB.Text.Equals("") && !txtBoxRaspunsC.Text.Equals("") && raspunsCorect != null)
                {
                    i.Id = int.Parse(labelIdIntrebare.Text);
                    i.Tip = 3;
                    i.Descriere = dropDownCapitol.Text;
                    i.Enunt = txtBoxCerintaImagine.Text;
                    i.EnuntSuplimentar = txtBoxCerintaImagine2.Text;
                    i.ImagineA = ConvertByteFromImage(imageA.Image);
                    i.ImagineB = ConvertByteFromImage(imageB.Image);
                    i.ImagineC = ConvertByteFromImage(imageC.Image);
                    i.Raspuns_A = txtBoxRaspunsA.Text;
                    i.Raspuns_B = txtBoxRaspunsB.Text;
                    i.Raspuns_C = txtBoxRaspunsC.Text;
                    i.RaspunsCorect = raspunsCorect;

                    i.UpdateIntrebare(i);

                    isTabelIntrebariAfisat = false;

                    IntrebareModificata();
                }
                else if (dropDownTipIntrebare.Text.Equals("Răspuns prin completare") && !dropDownCapitol.Text.Equals("   Capitol") && !textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals("") && !textBox4.Text.Equals("") && !textBox5.Text.Equals("") && !labelEnuntTip4.Text.Equals(""))
                {
                    RaspunsCorectTip2And4();

                    if (raspunsCorect == null)
                    {
                        er.ShowDialog();
                    }
                    else
                    {
                        i.Id = int.Parse(labelIdIntrebare.Text);
                        i.Tip = 4;
                        i.Descriere = dropDownCapitol.Text;
                        i.Enunt = labelEnuntTip4.Text;
                        i.Raspuns_A = textBox1.Text;
                        i.Raspuns_B = textBox2.Text;
                        i.Raspuns_C = textBox3.Text;
                        i.Raspuns_D = textBox4.Text;
                        i.Raspuns_E = textBox5.Text;
                        i.RaspunsCorect = raspunsCorect;

                        i.UpdateIntrebare(i);
                        isTabelIntrebariAfisat = false;
                        IntrebareModificata();
                    }
                }
                else
                {
                    er.ShowDialog();
                }
            }
        }

        private void IntrebareModificata()
        {
            Eroare.textEroare = "Întrebare modificată";
            Eroare er = new Eroare
            {
                StartPosition = FormStartPosition.CenterParent
            };
            er.ShowDialog();
        }

        bool R1 = false;
        private void raspuns1_Click(object sender, EventArgs e)
        {
            if (R1 == false)
            {
                R1 = true;
                raspuns1.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
            }
            else
            {
                R1 = false;
                raspuns1.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);
            }
        }

        bool R2 = false;

        private void raspuns2_Click(object sender, EventArgs e)
        {
            if (R2 == false)
            {
                R2 = true;
                raspuns2.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
            }
            else
            {
                R2 = false;
                raspuns2.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);
            }
        }

        bool R3 = false;

        private void raspuns3_Click(object sender, EventArgs e)
        {
            if (R3 == false)
            {
                R3 = true;
                raspuns3.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
            }
            else
            {
                R3 = false;
                raspuns3.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);
            }
        }

        bool R4 = false;

        private void raspuns4_Click(object sender, EventArgs e)
        {
            if (R4 == false)
            {
                R4 = true;
                raspuns4.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
            }
            else
            {
                R4 = false;
                raspuns4.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);
            }
        }

        bool R5 = false;

        private void raspuns5_Click(object sender, EventArgs e)
        {
            if (R5 == false)
            {
                R5 = true;
                raspuns5.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
            }
            else
            {
                R5 = false;
                raspuns5.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);
            }
        }

        private void RaspunsCorectTip2And4()
        {
            raspunsCorect = null;
            if (dropDownTipIntrebare.Text.Equals("Răspuns prin completare"))
            {
                if (R1 == true)
                {
                    raspunsCorect += "A";
                }

                if (R2 == true)
                {
                    raspunsCorect += "B";
                }

                if (R3 == true)
                {
                    raspunsCorect += "C";
                }

                if (R4 == true)
                {
                    raspunsCorect += "D";
                }

                if (R5 == true)
                {
                    raspunsCorect += "E";
                }
            }
            else
            {
                if (RA == true)
                {
                    raspunsCorect += "A";
                }

                if (RB == true)
                {
                    raspunsCorect += "B";
                }

                if (RC == true)
                {
                    raspunsCorect += "C";
                }
            }
        }

        bool RA = false;
        private void raspunsTip1A_Click(object sender, EventArgs e)
        {
            if (RA == false)
            {
                RA = true;
                raspunsTip1A.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
            }
            else
            {
                RA = false;
                raspunsTip1A.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);
            }
        }

        bool RB = false;
        private void raspunsTip1B_Click(object sender, EventArgs e)
        {
            if (RB == false)
            {
                RB = true;
                raspunsTip1B.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
            }
            else
            {
                RB = false;
                raspunsTip1B.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);
            }
        }

        bool RC = false;
        private void raspunsTip1C_Click(object sender, EventArgs e)
        {
            if (RC == false)
            {
                RC = true;
                raspunsTip1C.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
            }
            else
            {
                RC = false;
                raspunsTip1C.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);
            }
        }


        private void AfisareIntrebare(int id)
        {

        }

        private void imagineCapitol_Click(object sender, EventArgs e)
        {
            CautareImagineFisier(imagineCapitol);
        }

        private void CapitolPopUp(string s)
        {
            Eroare.textEroare = s;
            Eroare er = new Eroare
            {
                StartPosition = FormStartPosition.CenterParent
            };
            er.ShowDialog();
        }

        private void ClearCapitol()
        {
            buttonAdaugare.Text = "Adăugare";
            buttonStergere.Visible = false;

            textBoxDescriereCapitol.Text = "";
            dropDownDificultate.Text = "  Dificultate";
            imagineCapitol.Image = new Bitmap(bitQuiz.Properties.Resources.CapitolFinalizat1);
        }

        private void buttonAdaugare_Click(object sender, EventArgs e)
        {
            Eroare.textEroare = "Campuri necompletate";
            Eroare er = new Eroare
            {
                StartPosition = FormStartPosition.CenterParent
            };

            Capitol c = new Capitol();

            if (buttonAdaugare.Text.Equals("Adăugare") && !textBoxDescriereCapitol.Text.Equals("") && !dropDownDificultate.Text.Equals("  Dificultate"))
            {
                c.Descriere = textBoxDescriereCapitol.Text;
                c.Dificultate = dropDownDificultate.Text;
                c.Imagine = ConvertByteFromImage(imagineCapitol.Image);

                c.InserareCapitol(c);

                isTabelCapitolAfisat = false;

                CapitolPopUp("Capitol adăugat");
                AfisarePanelCapitole();
                ClearCapitol();
            }
            else if (buttonAdaugare.Text.Equals("Modificare") && !textBoxDescriereCapitol.Text.Equals("") && !dropDownDificultate.Text.Equals("  Dificultate"))
            {
                Image image = imagineCapitol.Image;

                c.Id = int.Parse(labelIdCapitol.Text);
                c.Descriere = textBoxDescriereCapitol.Text;
                c.Dificultate = dropDownDificultate.Text;
                c.Imagine = ConvertByteFromImage(image);

                c.UpdateCapitol(c);

                isTabelCapitolAfisat = false;

                CapitolPopUp("Capitol modificat");

                AfisarePanelCapitole();
            }
            else
            {
                er.ShowDialog();
            }
        }

        private void ExtragereCapitol(string descriere)
        {
            Capitol c = new Capitol
            {
                Descriere = descriere
            };

            DataTable dt = c.SelectTop1Capitol(c);

            buttonStergere.Visible = true;
            buttonAdaugare.Text = "Modificare";

            panelAdaugareCapitol.Visible = true;
            panelCapitole.Size = new Size(683, 136);
            panelCapitole.Location = new Point(23, 56);

            bunifuVScrollBar1.Size = new Size(17, 136);
            bunifuVScrollBar1.Location = new Point(712, 56);
            panel4.Location = new Point(23, 201);

            labelIdCapitol.Text = dt.Rows[0][0].ToString();
            imagineCapitol.Image = ConvertImageFromByte((byte[])(dt.Rows[0][1]));
            textBoxDescriereCapitol.Text = dt.Rows[0][2].ToString();
            dropDownDificultate.Text = dt.Rows[0][3].ToString();
            buttonAdaugare.Text = "Modificare";
            buttonStergere.Visible = true;
        }

        private void buttonStergere_Click(object sender, EventArgs e)
        {
            Eroare.textEroare = "Capitolul a fost șters";
            Eroare er = new Eroare
            {
                StartPosition = FormStartPosition.CenterParent
            };

            Capitol c = new Capitol
            {
                Id = int.Parse(labelIdCapitol.Text)
            };
            c.StergereCapitol(c);

            er.ShowDialog();

            isTabelCapitolAfisat = false;

            AfisarePanelCapitole();

            panelAdaugareCapitol.Visible = false;
            panelCapitole.Size = new Size(683, 281);
            panelCapitole.Location = new Point(23, 56);

            bunifuVScrollBar1.Size = new Size(17, 281);
            bunifuVScrollBar1.Location = new Point(712, 56);
            panel4.Location = new Point(23, 357);
        }


        private void ModificareIntrebare(string Id)
        {
            labelIdIntrebare.Text = Id;
            buttonAdaugareIntrebare.Text = "Modificare";
            AdaugareCapitoleDropDown();

            Intrebare i = new Intrebare
            {
                Id = int.Parse(labelIdIntrebare.Text)
            };
            DataTable dt = i.SelectTop1Intrebare(i);
            i.Tip = Convert.ToInt32(dt.Rows[0][3]);
            DataTable rt = i.SelectTop1RaspunsIntrebare(i);

            dropDownCapitol.Text = dt.Rows[0][4].ToString();

            if (Convert.ToInt32(dt.Rows[0][3]) == 1)
            {
                txtBoxCerintaCod.Text = dt.Rows[0][1].ToString();
                txtBoxInserareCod.Text = rt.Rows[0][1].ToString();
                dropDownTipIntrebare.Text = "Răspuns prin cod";
                panelIntrebareTip1.BringToFront();
            }
            else if (Convert.ToInt32(dt.Rows[0][3]) == 2)
            {
                ClearIntrebareTip2();

                textBoxEnuntTip2.Text = dt.Rows[0][1].ToString();
                dropDownTipIntrebare.Text = "Răspuns prin variante";
                textBoxVarianta1.Text = rt.Rows[0][1].ToString();
                textBoxVarianta2.Text = rt.Rows[0][2].ToString();
                textBoxVarianta3.Text = rt.Rows[0][3].ToString();

                foreach (char c in rt.Rows[0][4].ToString())
                {
                    if (c == 'A')
                    {
                        raspunsTip1A.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
                        RA = true;
                    }
                    else if (c == 'B')
                    {
                        raspunsTip1B.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
                        RB = true;
                    }
                    else if (c == 'C')
                    {
                        raspunsTip1C.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
                        RC = true;
                    }
                }

                panelIntrebareTip2.BringToFront();
            }
            else if (Convert.ToInt32(dt.Rows[0][3]) == 3)
            {
                ClearIntrebareTip3();

                dropDownTipIntrebare.Text = "Răspuns prin imagine";

                txtBoxCerintaImagine.Text = dt.Rows[0][1].ToString();
                txtBoxCerintaImagine2.Text = rt.Rows[0][8].ToString();

                imageA.Image = ConvertImageFromByte((byte[])(rt.Rows[0][1]));
                imageB.Image = ConvertImageFromByte((byte[])(rt.Rows[0][3]));
                imageC.Image = ConvertImageFromByte((byte[])(rt.Rows[0][5]));
                txtBoxRaspunsA.Text = rt.Rows[0][2].ToString();
                txtBoxRaspunsB.Text = rt.Rows[0][4].ToString();
                txtBoxRaspunsC.Text = rt.Rows[0][6].ToString();

                if (rt.Rows[0][7].ToString().Equals("A"))
                {
                    raspunsCorect = "A";
                    raspunsA.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
                    raspunsB.Image = raspunsC.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);

                    userControlA.BorderColor = Color.FromArgb(163, 192, 62);
                    userControlB.BorderColor = Color.FromArgb(229, 229, 229);
                    userControlC.BorderColor = Color.FromArgb(229, 229, 229);
                }
                else if (rt.Rows[0][7].ToString().Equals("B"))
                {
                    raspunsCorect = "B";

                    raspunsB.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
                    raspunsA.Image = raspunsC.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);

                    userControlA.BorderColor = Color.FromArgb(229, 229, 229);
                    userControlB.BorderColor = Color.FromArgb(163, 192, 62);
                    userControlC.BorderColor = Color.FromArgb(229, 229, 229);
                }
                else
                {
                    raspunsCorect = "C";

                    raspunsC.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
                    raspunsA.Image = raspunsB.Image = new Bitmap(bitQuiz.Properties.Resources.xxx);

                    userControlA.BorderColor = Color.FromArgb(229, 229, 229);
                    userControlB.BorderColor = Color.FromArgb(229, 229, 229);
                    userControlC.BorderColor = Color.FromArgb(163, 192, 62);
                }

                panelIntrebareTip3.BringToFront();
            }
            else
            {
                ClearIntrebareTip4();

                dropDownTipIntrebare.Text = "Răspuns prin completare";

                labelEnuntTip4.Text = dt.Rows[0][1].ToString();
                textBox1.Text = rt.Rows[0][1].ToString();
                textBox2.Text = rt.Rows[0][2].ToString();
                textBox3.Text = rt.Rows[0][3].ToString();
                textBox4.Text = rt.Rows[0][4].ToString();
                textBox5.Text = rt.Rows[0][5].ToString();

                foreach (char c in rt.Rows[0][6].ToString())
                {
                    if (c == 'A')
                    {
                        R1 = true;
                        raspuns1.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
                    }
                    else if (c == 'B')
                    {
                        R2 = true;
                        raspuns2.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
                    }
                    else if (c == 'C')
                    {
                        R3 = true;
                        raspuns3.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
                    }
                    else if (c == 'D')
                    {
                        R4 = true;
                        raspuns4.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
                    }
                    else if (c == 'E')
                    {
                        R5 = true;
                        raspuns5.Image = new Bitmap(bitQuiz.Properties.Resources.ok);
                    }
                }
                panelIntrebareTip4.BringToFront();
            }
            panelIntrebareNoua.BringToFront();
        }

        private void textBoxDescriereCapitol_TextChanged(object sender, EventArgs e)
        {

        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Dispose();
        }

        private void buttonExcelUtilizatori_Click(object sender, EventArgs e)
        {
            panelLoading.BringToFront();
            labelProverb.Text = Login.Proverbe();

            backgroundWorker.RunWorkerAsync();
        }

        Microsoft.Office.Interop.Excel.Application xcelApp;

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            Utilizator u = new Utilizator();
            DataTable dt = u.ExcelUtilizator();

            if (dt.Rows.Count > 0)
            {
                xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                DataColumnCollection columns = dt.Columns;
                xcelApp.Cells.EntireColumn.NumberFormat = "@";

                for (int i = 0; i < columns.Count; i++)
                {
                    xcelApp.Cells[1, i + 1] = columns[i].ColumnName.ToString();
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        xcelApp.Cells[j + 1][i + 2] = dt.Rows[i][j].ToString();
                    }
                }
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            xcelApp.Visible = true;
            panelUtilizatori.BringToFront();
        }

        private void DescarcareIntrebari_Click(object sender, EventArgs e)
        {
            panelLoading.BringToFront();
            labelProverb.Text = Login.Proverbe();

            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            Intrebare intrebare = new Intrebare();
            DataTable dt = intrebare.ExcelIntrebare();

            if (dt.Rows.Count > 0)
            {
                xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);
                xcelApp.Cells.EntireColumn.NumberFormat = "@";

                DataColumnCollection columns = dt.Columns;

                for (int i = 0; i < columns.Count; i++)
                {
                    xcelApp.Cells[1, i + 1] = columns[i].ColumnName.ToString();
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        xcelApp.Cells[j + 1][i + 2] = dt.Rows[i][j].ToString();
                    }
                }
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            xcelApp.Visible = true;
            panelIntrebare.BringToFront();
        }
    }
}
