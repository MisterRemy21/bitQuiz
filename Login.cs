using bitQuiz;
using Bunifu.UI.WinForms.BunifuTextbox;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Teste
{
    public partial class Login : Form
    {
        [System.Obsolete]
        public Login()
        {
            InitializeComponent();
        }

        private void ButtonVerificare_Click(object sender, System.EventArgs e)
        {
            ClearProfilNou();
            panelProfilNou.BringToFront();
        }

        private void LabelAmDejaProfil_Click(object sender, System.EventArgs e)
        {
            ClearAutentificare();
            panelConectare.BringToFront();
        }

        private void LabelProfil_Click(object sender, System.EventArgs e)
        {
            panelContNouSauConectare.BringToFront();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Dispose();
        }

        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ClearProfilNou()
        {
            sex = '\0';
            pictureBoxSex.Image = new Bitmap(bitQuiz.Properties.Resources.sex_neutru);
            textBoxNume.Text = "";
            textBoxPrenume.Text = "";
            textBoxEmail.Text = "";
            textBoxUtilizatorProfilNou.Text = "";
            textBoxParolaProfilNou.Text = "";
            buttonIncepere.Text = "Alegere nivel";
            pictureBoxEroareEmail.Visible = false;
            pictureBoxEroareNumeSauPrenume.Visible = false;
            pictureBoxEroareSex.Visible = false;
            pictureBoxEroareUtilizator.Visible = false;
            pictureBoxEroareParola.Visible = false;
            i = 1;
            j = 0;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void ClearAutentificare()
        {
            i = 0;
            textBoxUtilizatorEmail.Text = "";
            textBoxParola.Text = "";
            textBoxParola.UseSystemPasswordChar = true;
            textBoxParola.PasswordChar = '●';
            labelDescriereAutentificare.Text = "Bine ai revenit! Hai să începem.";
            pictureBoxEroareUtilizatorSauEmail.Visible = false;
            pictureBoxEroareParolaAutentificare.Visible = false;

        }

        private void PictureBoxLogo_Click(object sender, EventArgs e)
        {
            if (buttonVerificareIntrebare.Visible == false)
            {
                ClearAutentificare();
                panelConectare.BringToFront();
            }
        }

        [Obsolete]

        public static string utilizator;
        public static string parola;

        int rol = 0;
        [Obsolete]
        private void ButtonConectare_Click(object sender, EventArgs e)
        {
            if (textBoxUtilizatorEmail.Text == "" || textBoxParola.Text == "")
            {
                if (textBoxUtilizatorEmail.Text == "")
                {
                    pictureBoxEroareUtilizatorSauEmail.Visible = true;
                    bunifuToolTip1.SetToolTip(pictureBoxEroareUtilizatorSauEmail, "Nu ai introdus numele de utilizator sau e-mail-ul");
                }
                if (textBoxParola.Text == "")
                {
                    pictureBoxEroareParolaAutentificare.Visible = true;
                    bunifuToolTip1.SetToolTip(pictureBoxEroareParolaAutentificare, "Nu ai introdus parola");
                }
            }
            else
            {
                Utilizator u = new Utilizator
                {
                    UserName = textBoxUtilizatorEmail.Text,
                    Email = textBoxUtilizatorEmail.Text,
                    Parola = textBoxParola.Text
                };

                DataTable dt = u.VerificareUtilizator(u);

                if (dt.Rows.Count > 0 && (textBoxUtilizatorEmail.Text == dt.Rows[0][0].ToString() || textBoxUtilizatorEmail.Text == dt.Rows[0][1].ToString()))
                {
                    utilizator = textBoxUtilizatorEmail.Text;
                    parola = textBoxParola.Text;

                    if (dt.Rows[0][2].ToString() == "0")
                    {
                        u.ActivateDezactivareUtilizator(u, 1);
                    }

                    rol = Convert.ToInt32(dt.Rows[0][3]);

                    labelProverb.Text = Proverbe();
                    panelLoading.BringToFront();
                    timerLogin.Start();
                }
                else
                {
                    pictureBoxEroareParolaAutentificare.Visible = false;
                    pictureBoxEroareUtilizatorSauEmail.Visible = true;
                    bunifuToolTip1.SetToolTip(pictureBoxEroareUtilizatorSauEmail, "Utilizatorul nu există sau ai introdus incorect");
                }
            }
        }

        private void LabelProfil_MouseEnter(object sender, EventArgs e)
        {
            labelProfil.ForeColor = Color.FromArgb(246, 208, 122);
        }

        private void LabelProfil_MouseLeave(object sender, EventArgs e)
        {
            labelProfil.ForeColor = Color.White;
        }

        private void LabelAmDejaProfil_MouseEnter(object sender, EventArgs e)
        {
            labelAmDejaProfil.ForeColor = Color.FromArgb(246, 208, 122);
        }

        private void LabelAmDejaProfil_MouseLeave(object sender, EventArgs e)
        {
            labelAmDejaProfil.ForeColor = Color.White;
        }

        private void LabelTermeni_MouseEnter(object sender, EventArgs e)
        {
            labelTermeni.ForeColor = Color.FromArgb(246, 208, 122);
        }

        private void LabelTermeni_MouseLeave(object sender, EventArgs e)
        {
            labelTermeni.ForeColor = Color.White;
        }

        char sex;

        private void ButtonSexM_Click(object sender, EventArgs e)
        {
            pictureBoxSex.Image = new Bitmap(bitQuiz.Properties.Resources.sex_barbat);
            i = 1;
            sex = 'M';
            pictureBoxEroareSex.Visible = false;
        }

        private void ButtonSexF_Click(object sender, EventArgs e)
        {
            pictureBoxSex.Image = new Bitmap(bitQuiz.Properties.Resources.sex_femeie);
            i = 1;
            sex = 'F';
            pictureBoxEroareSex.Visible = false;
        }

        private void ButtonContinuare_Click_1(object sender, EventArgs e)
        {
            int contor = 0;

            if (textBoxNume.Text == "" || textBoxPrenume.Text == "")
            {
                bunifuToolTip1.SetToolTip(pictureBoxEroareNumeSauPrenume, "Nu ai introdus numele sau prenumele");
            }

            foreach (BunifuTextBox txt in panelProfilNou.Controls.OfType<BunifuTextBox>())
            {
                if (string.IsNullOrEmpty(txt.Text.Trim()))
                {
                    contor++;
                    if (txt.Name == "textBoxNume")
                    {
                        pictureBoxEroareNumeSauPrenume.Visible = true;
                    }
                    else if (txt.Name == "textBoxPrenume")
                    {
                        pictureBoxEroareNumeSauPrenume.Visible = true;
                    }
                    else if (txt.Name == "textBoxEmail")
                    {
                        pictureBoxEroareEmail.Visible = true;
                        bunifuToolTip1.SetToolTip(pictureBoxEroareEmail, "Nu ai introdus niciun e-mail");
                    }
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
                        if (IsEmail(textBoxEmail.Text) == false)
                        {
                            contor++;
                            pictureBoxEroareEmail.Visible = true;
                            bunifuToolTip1.SetToolTip(pictureBoxEroareEmail, "E-mail-ul introdus este invalid");
                        }
                        else
                        {
                            Utilizator u = new Utilizator
                            {
                                Email = textBoxEmail.Text
                            };

                            if (u.VerificareEmail(u) == true)
                            {
                                contor++;
                                pictureBoxEroareEmail.Visible = true;
                                bunifuToolTip1.SetToolTip(pictureBoxEroareEmail, "E-mail-ul introdus este folosit de către un utilizator");
                            }
                        }
                    }
                }
            }

            if (sex == '\0')
            {
                pictureBoxEroareSex.Visible = true;
                bunifuToolTip1.SetToolTip(pictureBoxEroareSex, "Nu ai selectat niciun gen");
                contor++;
            }

            if (contor == 0)
            {
                AlegereAvatar(i);
                panelProfil.BringToFront();
            }
        }

        int i = 0;
        private void ButtonVeziParola_Click(object sender, EventArgs e)
        {
            if (i % 2 == 0)
            {
                textBoxParola.UseSystemPasswordChar = false;
                textBoxParola.PasswordChar = '\0';
            }
            else
            {
                textBoxParola.UseSystemPasswordChar = true;
                textBoxParola.PasswordChar = '●';
            }
            i++;
        }

        private void LabelInapoi_Click(object sender, EventArgs e)
        {
            panelProfilNou.BringToFront();
        }

        private void LabelInapoi_MouseEnter(object sender, EventArgs e)
        {
            labelInapoi.ForeColor = Color.FromArgb(246, 208, 122);
        }

        private void LabelInapoi_MouseLeave(object sender, EventArgs e)
        {
            labelInapoi.ForeColor = Color.White;
        }

        private void ButtonVeziParola_MouseEnter(object sender, EventArgs e)
        {
            buttonVeziParola.Image = new Bitmap(bitQuiz.Properties.Resources.blue_eye);
        }

        private void ButtonVeziParola_MouseLeave(object sender, EventArgs e)
        {
            buttonVeziParola.Image = new Bitmap(bitQuiz.Properties.Resources.grey_eye);
        }


        private void LabelTermeniSiPolitica_MouseEnter(object sender, EventArgs e)
        {
            labelTermeniSiPolitica.ForeColor = Color.FromArgb(246, 208, 122);
        }

        private void LabelTermeniSiPolitica_MouseLeave(object sender, EventArgs e)
        {
            labelTermeniSiPolitica.ForeColor = Color.White;
        }

        private void LabelInapoiConectareSauContNou_Click(object sender, EventArgs e)
        {
            panelContNouSauConectare.BringToFront();
        }

        private void LabelInapoiConectareSauContNou_MouseEnter(object sender, EventArgs e)
        {
            labelInapoiConectareSauContNou.ForeColor = Color.FromArgb(246, 208, 122);
        }

        private void LabelInapoiConectareSauContNou_MouseLeave(object sender, EventArgs e)
        {
            labelInapoiConectareSauContNou.ForeColor = Color.White;
        }

        private void AlegereAvatar(int i)
        {
            switch (i)
            {
                case 1:
                    if (sex == 'M')
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._1_boy);
                    }
                    else
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._1_girl);
                    }

                    break;

                case 2:
                    if (sex == 'M')
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._2_boy);
                    }
                    else
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._2_girl);
                    }

                    break;

                case 3:
                    if (sex == 'M')
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._3_boy);
                    }
                    else
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._3_girl);
                    }

                    break;

                case 4:
                    if (sex == 'M')
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._4_boy);
                    }
                    else
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._4_girl);
                    }

                    break;

                case 5:
                    if (sex == 'M')
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._5_boy);
                    }
                    else
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._5_girl);
                    }

                    break;

                case 6:
                    if (sex == 'M')
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._6_boy);
                    }
                    else
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._6_girl);
                    }

                    break;

                case 7:
                    if (sex == 'M')
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._7_boy);
                    }
                    else
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._7_girl);
                    }

                    break;

                case 8:
                    if (sex == 'M')
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._8_boy);
                    }
                    else
                    {
                        pictureBoxAvatar.Image = new Bitmap(bitQuiz.Properties.Resources._8_girl);
                    }

                    break;
            }
        }

        private void ButtonAvatarAnterior_MouseEnter(object sender, EventArgs e)
        {
            buttonAvatarAnterior.Size = new Size(63, 53);
            buttonAvatarAnterior.Location = new Point(1, 157);
        }

        private void ButtonAvatarAnterior_MouseLeave(object sender, EventArgs e)
        {
            buttonAvatarAnterior.Size = new Size(48, 39);
            buttonAvatarAnterior.Location = new Point(4, 163);
        }

        private void ButtonAvatarAnterior_Click(object sender, EventArgs e)
        {
            i--;
            if (i == 0)
            {
                i = 8;
            }

            AlegereAvatar(i);
        }

        private void ButtonAvatarUrmator_Click(object sender, EventArgs e)
        {
            i++;
            if (i == 9)
            {
                i = 1;
            }

            AlegereAvatar(i);
        }

        private void ButtonAvatarUrmator_MouseLeave(object sender, EventArgs e)
        {
            buttonAvatarUrmator.Size = new Size(48, 39);
            buttonAvatarUrmator.Location = new Point(324, 163);
        }

        private void ButtonAvatarUrmator_MouseEnter(object sender, EventArgs e)
        {
            buttonAvatarUrmator.Size = new Size(63, 53);
            buttonAvatarUrmator.Location = new Point(321, 157);
        }

        private void ButtonFinalizare_Click(object sender, EventArgs e)
        {
            int contor = 0;

            foreach (BunifuTextBox txt in panelProfil.Controls.OfType<BunifuTextBox>())
            {
                if (string.IsNullOrEmpty(txt.Text.Trim()))
                {
                    contor++;
                    if (txt.Name == "textBoxUtilizatorProfilNou")
                    {
                        pictureBoxEroareUtilizator.Visible = true;
                        bunifuToolTip1.SetToolTip(pictureBoxEroareUtilizator, "Nu ai introdus numele de utilizator");
                    }
                    else if (txt.Name == "textBoxParolaProfilNou")
                    {
                        pictureBoxEroareParola.Visible = true;
                        bunifuToolTip1.SetToolTip(pictureBoxEroareParola, "Nu ai introdus parola");
                    }
                }
                else
                {
                    if (txt.Name == "textBoxUtilizatorProfilNou")
                    {
                        Utilizator u = new Utilizator
                        {
                            UserName = textBoxUtilizatorProfilNou.Text
                        };

                        if (u.VerificareUtilizatorDatabase(u) == true)
                        {
                            contor++;
                            pictureBoxEroareUtilizator.Visible = true;
                            bunifuToolTip1.SetToolTip(pictureBoxEroareUtilizator, "Numele de utilizator introdus este folosit de către alt utilizator");
                        }
                    }
                    else if (txt.Name == "textBoxParolaProfilNou")
                    {
                        if (textBoxParolaProfilNou.Text.Length < 8)
                        {
                            contor++;
                            pictureBoxEroareParola.Visible = true;
                            bunifuToolTip1.SetToolTip(pictureBoxEroareParola, "Parola trebuie să fie formată din minim 8 caractere");
                        }
                    }
                }
            }

            if (contor == 0)
            {
                labelProverb.Text = Proverbe();
                panelLoading.BringToFront();
                timerLoading.Enabled = true;

                userControlTestareNivel.BackgroundColor = Color.FromArgb(28, 199, 255);
                userControlTestareNivel.BorderColor = Color.FromArgb(28, 199, 255);
                bunifuLabel12.BackColor = Color.FromArgb(28, 199, 255);
                bunifuLabel13.BackColor = Color.FromArgb(28, 199, 255);
                bunifuImageButton6.BackColor = Color.FromArgb(28, 199, 255);
                bunifuImageButton8.BackColor = Color.FromArgb(28, 199, 255);
                bunifuImageButton7.BackColor = Color.FromArgb(28, 199, 255);

                bunifuLabel15.BackColor = Color.FromArgb(28, 199, 255);
                bunifuLabel18.BackColor = Color.FromArgb(28, 199, 255);
                bunifuLabel14.BackColor = Color.FromArgb(28, 199, 255);

                userControlIncepator.BackgroundColor = Color.FromArgb(28, 199, 255);
                userControlIncepator.BorderColor = Color.FromArgb(28, 199, 255);

                bunifuLabel16.BackColor = Color.FromArgb(28, 199, 255);
                bunifuImageButton5.BackColor = Color.FromArgb(28, 199, 255);
                bunifuImageButton4.BackColor = Color.FromArgb(28, 199, 255);
                bunifuImageButton3.BackColor = Color.FromArgb(28, 199, 255);

                bunifuLabel11.BackColor = Color.FromArgb(28, 199, 255);
                bunifuLabel41.BackColor = Color.FromArgb(28, 199, 255);
                bunifuLabel42.BackColor = Color.FromArgb(28, 199, 255);
                bunifuLabel10.BackColor = Color.FromArgb(28, 199, 255);

                timerLoading.Start();
            }
        }

        private void ButtonIncepere_Click(object sender, EventArgs e)
        {
            if (buttonIncepere.Text != "Alegere nivel")
            {
                parola = textBoxParolaProfilNou.Text;
                utilizator = textBoxUtilizatorProfilNou.Text;

                if (buttonIncepere.Text == "Începător")
                {
                    Utilizator u = new Utilizator
                    {
                        Nume = textBoxNume.Text,
                        Prenume = textBoxPrenume.Text,
                        Sex = sex,
                        Email = textBoxEmail.Text,
                        UserName = textBoxUtilizatorProfilNou.Text,
                        Parola = textBoxParolaProfilNou.Text,
                        Imagine = pictureBoxAvatar.Image,
                        SariPeste = 1,
                        Mere = 25
                    };

                    u.InserareUtilizator(u);
                    labelProverb.Text = Proverbe();
                    panelLoading.BringToFront();
                    rol = 1;
                    timerLogin.Start();
                }
                else
                {
                    Utilizator u = new Utilizator
                    {
                        Nume = textBoxNume.Text,
                        Prenume = textBoxPrenume.Text,
                        Sex = sex,
                        Email = textBoxEmail.Text,
                        UserName = textBoxUtilizatorProfilNou.Text,
                        Parola = textBoxParolaProfilNou.Text,
                        Imagine = pictureBoxAvatar.Image,
                        SariPeste = 2,
                        Mere = 100
                    };

                    u.InserareUtilizator(u);

                    capitoleTerminate = 0;
                    capitol = 1;

                    TestareNivel(capitol);
                    labelProverb.Text = Proverbe();
                    panelLoading.BringToFront();
                    buttonVerificareIntrebare.Visible = true;
                    timerLoading.Enabled = true;
                    timerLoading.Start();
                }
            }
        }

        int j = 0;
        private void ButtonVeziParolaProfilNou_Click(object sender, EventArgs e)
        {
            if (j % 2 == 0)
            {
                textBoxParolaProfilNou.UseSystemPasswordChar = false;
                textBoxParolaProfilNou.PasswordChar = '\0';
            }
            else
            {
                textBoxParolaProfilNou.UseSystemPasswordChar = true;
                textBoxParolaProfilNou.PasswordChar = '●';
            }
            j++;
        }

        private void ButtonVeziParolaProfilNou_MouseEnter(object sender, EventArgs e)
        {
            buttonVeziParolaProfilNou.Image = new Bitmap(bitQuiz.Properties.Resources.blue_eye);
        }

        private void ButtonVeziParolaProfilNou_MouseLeave(object sender, EventArgs e)
        {
            buttonVeziParolaProfilNou.Image = new Bitmap(bitQuiz.Properties.Resources.grey_eye);
        }

        private void LabelAiUitatParola_Click(object sender, EventArgs e)
        {
            textBoxUtilizatorResetareParola.Text = "";
            textBoxEmailResetareParola.Text = "";
            pictureBoxEroareUtilizatorResetareParola.Visible = false;
            pictureBoxEroareEmailResetareParola.Visible = false;
            panelResetareParola.BringToFront();
        }

        private void LabelAiUitatParola_MouseEnter(object sender, EventArgs e)
        {
            labelAiUitatParola.ForeColor = Color.FromArgb(246, 208, 122);
        }

        private void LabelAiUitatParola_MouseLeave(object sender, EventArgs e)
        {
            labelAiUitatParola.ForeColor = Color.White;
        }

        private void ButtonIncepator_Click(object sender, EventArgs e)
        {
            buttonIncepere.Text = "Începător";

            userControlIncepator.BackgroundColor = Color.FromArgb(36, 176, 246);
            userControlIncepator.BorderColor = Color.FromArgb(36, 176, 246);

            bunifuLabel16.BackColor = Color.FromArgb(36, 176, 246);
            bunifuImageButton5.BackColor = Color.FromArgb(36, 176, 246);
            bunifuImageButton4.BackColor = Color.FromArgb(36, 176, 246);
            bunifuImageButton3.BackColor = Color.FromArgb(36, 176, 246);
            bunifuLabel11.BackColor = Color.FromArgb(36, 176, 246);
            bunifuLabel41.BackColor = Color.FromArgb(36, 176, 246);
            bunifuLabel42.BackColor = Color.FromArgb(36, 176, 246);
            bunifuLabel10.BackColor = Color.FromArgb(36, 176, 246);

            userControlTestareNivel.BackgroundColor = Color.FromArgb(28, 199, 255);
            userControlTestareNivel.BorderColor = Color.FromArgb(28, 199, 255);
            bunifuLabel12.BackColor = Color.FromArgb(28, 199, 255);
            bunifuLabel13.BackColor = Color.FromArgb(28, 199, 255);
            bunifuImageButton6.BackColor = Color.FromArgb(28, 199, 255);
            bunifuImageButton8.BackColor = Color.FromArgb(28, 199, 255);
            bunifuImageButton7.BackColor = Color.FromArgb(28, 199, 255);

            bunifuLabel15.BackColor = Color.FromArgb(28, 199, 255);
            bunifuLabel18.BackColor = Color.FromArgb(28, 199, 255);
            bunifuLabel14.BackColor = Color.FromArgb(28, 199, 255);
        }

        private void ButtonTestareNivel_Click(object sender, EventArgs e)
        {
            buttonIncepere.Text = "Testare nivel";

            userControlTestareNivel.BackgroundColor = Color.FromArgb(36, 176, 246);
            userControlTestareNivel.BorderColor = Color.FromArgb(36, 176, 246);

            bunifuLabel12.BackColor = Color.FromArgb(36, 176, 246);
            bunifuLabel13.BackColor = Color.FromArgb(36, 176, 246);
            bunifuImageButton6.BackColor = Color.FromArgb(36, 176, 246);
            bunifuImageButton8.BackColor = Color.FromArgb(36, 176, 246);
            bunifuImageButton7.BackColor = Color.FromArgb(36, 176, 246);

            bunifuLabel15.BackColor = Color.FromArgb(36, 176, 246);
            bunifuLabel18.BackColor = Color.FromArgb(36, 176, 246);
            bunifuLabel14.BackColor = Color.FromArgb(36, 176, 246);

            userControlIncepator.BackgroundColor = Color.FromArgb(28, 199, 255);
            userControlIncepator.BorderColor = Color.FromArgb(28, 199, 255);

            bunifuLabel16.BackColor = Color.FromArgb(28, 199, 255);
            bunifuImageButton5.BackColor = Color.FromArgb(28, 199, 255);
            bunifuImageButton4.BackColor = Color.FromArgb(28, 199, 255);
            bunifuImageButton3.BackColor = Color.FromArgb(28, 199, 255);

            bunifuLabel11.BackColor = Color.FromArgb(28, 199, 255);
            bunifuLabel41.BackColor = Color.FromArgb(28, 199, 255);
            bunifuLabel42.BackColor = Color.FromArgb(28, 199, 255);
            bunifuLabel10.BackColor = Color.FromArgb(28, 199, 255);
        }


        public static bool IsEmail(string s)
        {
            try
            {
                MailAddress adrr = new System.Net.Mail.MailAddress(s);
                return adrr.Address == s;
            }
            catch
            {
                return false;
            }
        }

        private void TextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEmail.Text.Length > 0)
            {
                pictureBoxEroareEmail.Visible = false;
            }
        }

        private void TextBoxNume_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNume.Text.Length > 0)
            {
                if (textBoxPrenume.Text.Length > 0)
                {
                    pictureBoxEroareNumeSauPrenume.Visible = false;
                }
            }
        }

        private void TextBoxPrenume_TextChanged(object sender, EventArgs e)
        {

            if (textBoxPrenume.Text.Length > 0)
            {
                if (textBoxNume.Text.Length > 0)
                {
                    pictureBoxEroareNumeSauPrenume.Visible = false;
                }
            }
        }

        public static string Proverbe()
        {
            string[] proverbe = new string[] { "\"Învățătura este comoara care își urmează oriunde posesorul. Proverb chinezesc",
                                               "\"De la un om mare ai întotdeauna de învățat, chiar și când tace. Seneca",
                                               "\"Sunt întotdeuna gata să învăț deși nu sunt mereu dornic să primesc o lecție. Winston Churchill",
                                               "\"Nu mai simt altă plăcere decât de a învăța. Francesco Petrarca",
                                               "\"Fiecare zi ne învață ceva nou. Euripides",
                                               "\"Învățătura este un aur care are preț oriunde. Epictet",
                                               "\"Precum apa inima ţi-o răcoreşte, aşa şi învăţătura mintea ţi-o limpezeşte. Proverb chinezesc",
                                               "\"Chiar și cea mai înțeleaptă minte mai are ceva de învățat. George Santayana",
                                               "\"Învățătura necesită o muncă de fiecare moment; munciți câte puțin în fiecare zi. Grigore Moisil",
                                               "\"Școala cea mai bună e aceea în care înveți înainte de toate a învăța. Nicolae Iorga",
                                               "\"Omul învăţat îşi poartă mereu averea cu dansul. Proverb chinezesc",
                                               "\"Învățat se cheamă un om care e bucuros să tot învețe. Nicolae Iorga",
                                               "\"Niciodată n-am învățat de la cei care sunt de acord cu mine. Robert Heinlein",
                                               "\"Îmbătrânesc și tot învăț. Eschil",
                                               "\"Dacă vrei să te înveți, învață pe alții. Marcus Tullius Cicero",
                                               "\"Dacă ești atent, poți învăța câte ceva nou în fiecare zi. Ray LeBlond",
                                               "\"Învață din ziua de ieri, trăiește-o pe cea de azi și spera în ziua de mâine. Albert Einstein",
                                               "\"Dă unui om un peşte și îl hrăneşti o zi, învață-l să pescuiască și îl hrăneşti pentru toată viaţa. Andrew Carnegie",
                                               "\"Trebuie să fi studiat mult ca să știi puțin. Montesquieu",
                                               "\"Nu este greu să înveți mai multe, ceea ce este cu adevărat greu este să te dezbări de lucrurile învățate greșit. Martin Fischer",
                                               "\"Studențească, cine nu repetă, repetă. Valeriu Butulescu",
                                               "\"Educația este pâinea sufletului. Giuseppe Mazzini"
            };

            Random n = new Random();
            return proverbe[n.Next(0, 22)].Replace(".", ".\"" + Environment.NewLine);
        }

        private void LabelMiamAmintitParola_Click(object sender, EventArgs e)
        {
            ClearAutentificare();
            panelConectare.BringToFront();
        }

        private void LabelMiamAmintitParola_MouseEnter(object sender, EventArgs e)
        {
            labelMiamAmintitParola.ForeColor = Color.FromArgb(246, 208, 122);
        }

        private void LabelMiamAmintitParola_MouseLeave(object sender, EventArgs e)
        {
            labelMiamAmintitParola.ForeColor = Color.White;
        }


        private void ButtonResetareParola_Click(object sender, EventArgs e)
        {
            if (textBoxEmailResetareParola.Text == "" || textBoxUtilizatorResetareParola.Text == "")
            {
                if (textBoxUtilizatorResetareParola.Text == "")
                {
                    pictureBoxEroareUtilizatorResetareParola.Visible = true;
                    bunifuToolTip1.SetToolTip(pictureBoxEroareUtilizatorResetareParola, "Nu ai introdus numele de utilizator");
                }
                if (textBoxEmailResetareParola.Text == "")
                {
                    pictureBoxEroareEmailResetareParola.Visible = true;
                    bunifuToolTip1.SetToolTip(pictureBoxEroareEmailResetareParola, "Nu ai introdus niciun e-mail");
                }
            }
            else
            {
                Utilizator u = new Utilizator
                {
                    Email = textBoxEmailResetareParola.Text,
                    UserName = textBoxUtilizatorResetareParola.Text
                };

                DataTable dt = u.VerificareUtilizatorEmail(u);

                if (dt.Rows.Count > 0 && (textBoxUtilizatorResetareParola.Text == dt.Rows[0][0].ToString() && textBoxEmailResetareParola.Text == dt.Rows[0][1].ToString()))
                {
                    labelProverb.Text = Proverbe();
                    panelLoading.BringToFront();
                    backgroundWorker.RunWorkerAsync();
                }
                else
                {
                    pictureBoxEroareUtilizatorResetareParola.Visible = true;
                    bunifuToolTip1.SetToolTip(pictureBoxEroareUtilizatorResetareParola, "Utilizatorul nu există sau ai introdus incorect");
                }
            }
        }

        private void TimerLoading_Tick(object sender, EventArgs e)
        {
            timerLoading.Stop();

            if (buttonVerificareIntrebare.Visible == false)
            {
                labelFelicitari.Text = "Felicitări, " + textBoxPrenume.Text + "!";
                panelAlegereNivel.BringToFront();
            }
            else
            {
                panelIntrebare.BringToFront();
            }
        }

        [Obsolete]
        private void TimerLogin_Tick(object sender, EventArgs e)
        {
            timerLogin.Stop();
            Hide();

            using (SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.booop))
            {
                audio.Play();

                if (rol == 1)
                {
                    MeniuPrincipal mp = new MeniuPrincipal();
                    mp.ShowDialog();
                }
                else
                {
                    Admin admin = new Admin();
                    admin.ShowDialog();
                }
                Close();
            }
        }

        private void textBoxUtilizatorProfilNou_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUtilizatorProfilNou.Text.Length > 0)
            {
                pictureBoxEroareUtilizator.Visible = false;
            }
        }

        private void textBoxParolaProfilNou_TextChanged(object sender, EventArgs e)
        {
            if (textBoxParolaProfilNou.Text.Length > 7)
            {
                pictureBoxEroareParola.Visible = false;
            }
        }

        private void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Utilizator u = new Utilizator
            {
                UserName = textBoxUtilizatorResetareParola.Text,
                Email = textBoxEmailResetareParola.Text
            };

            DataTable dt = u.ResetareParola(u);

            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("biqtuiz@gmail.com", "automatics2020")
            })
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(textBoxEmailResetareParola.Text);
                msg.From = new MailAddress("biqtuiz@gmail.com", "BitQuiz");
                msg.Subject = "BitQuiz [Resetare parolă]";

                msg.Body = "<p><strong>Salut!</strong></p> " +
                           "<p>Resetarea parolei a fost solicitată de către " + textBoxEmailResetareParola.Text + " la ora <strong>" + DateTime.Now.ToString("HH:mm") + "</strong>.</p>" +
                           "<p>Astfel, noua ta parolă este: <strong>" + dt.Rows[0][0].ToString() + "<strong></p>" +
                           "<p>Pentru buna desfășurare a lucrurilor, îți recomand să îți modifici parola imediat ce te autentifici.</p>" +
                           "<p><strong>P.S:</strong> Îmi place să aud de bine despre tine. Dacă ai orice întrebare, mă poți contacta oricând!</p>" +
                           "<p><img src=\" https://i.ibb.co/WDfhfyd/bitquiz.jpg \" width=\"542\" height=\"137\"></img></p>" +
                           "<p>Toate cele bune,</p>" +
                           "<p><i>bitQuiz</i></p>";

                msg.IsBodyHtml = true;
                client.Send(msg);
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            panelParolaResetata.BringToFront();
        }

        private void textBoxUtilizatorEmail_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUtilizatorEmail.Text.Length > 0)
            {
                pictureBoxEroareUtilizatorSauEmail.Visible = false;
            }
        }

        private void textBoxParola_TextChanged(object sender, EventArgs e)
        {
            if (textBoxParola.Text.Length > 0)
            {
                pictureBoxEroareParolaAutentificare.Visible = false;
            }
        }

        private void textBoxUtilizatorResetareParola_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUtilizatorResetareParola.Text.Length > 0)
            {
                pictureBoxEroareUtilizatorResetareParola.Visible = false;
            }
        }

        private void textBoxEmailResetareParola_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEmailResetareParola.Text.Length > 0)
            {
                pictureBoxEroareEmailResetareParola.Visible = false;
            }
        }

        private void buttonAutentificare_Click(object sender, EventArgs e)
        {
            PictureBoxLogo_Click(sender, e);
        }

        int A = 0;
        string raspunsA = null;
        private void buttonA_Click(object sender, EventArgs e)
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
        }

        int B = 0;
        string raspunsB = null;
        private void buttonB_Click(object sender, EventArgs e)
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
        }

        int C = 0;
        string raspunsC = null;

        private void buttonC_Click(object sender, EventArgs e)
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
        }


        private void generareIntrebare()
        {
            ClearIntrebare();

            Intrebare i = new Intrebare();
            i.IntrebareId = Convert.ToInt32(intrebari.Rows[linie][0]);
            DataTable dt = i.SelectIntrebariTip2(i);

            labelEnuntTip2.Text = dt.Rows[0][1].ToString();

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

            buttonA.Text = dt.Rows[0][A1].ToString();
            buttonB.Text = dt.Rows[0][A2].ToString();
            buttonC.Text = dt.Rows[0][A3].ToString();

            foreach (char c in dt.Rows[0][5].ToString())
            {
                if (c == 'A')
                {
                    raspunsCorect += dt.Rows[0][2].ToString();
                }
                else if (c == 'B')
                {
                    raspunsCorect += dt.Rows[0][3].ToString();
                }
                else if (c == 'C')
                {
                    raspunsCorect += dt.Rows[0][4].ToString();
                }
            }
        }

        string raspunsCorect = null;
        private void TestareNivel(int capitol)
        {
            linie = 0;
            contor = 0;
            intrebari = null;

            Intrebare i = new Intrebare();
            i.Id = capitol;
            intrebari = i.Testare(i);

            if (intrebari.Rows.Count > 0)
            {
                generareIntrebare();
            }
            else 
            {
                if (capitoleTerminate > 0)
                {
                    if(capitoleTerminate >= 4)
                    {
                        Utilizator u = new Utilizator();
                        u.UserName = textBoxUtilizatorProfilNou.Text;
                        u.AdaugareRealizare(u, 8);
                    }

                    rol = 1;
                    panelLoading.BringToFront();
                    timerLogin.Enabled = true;
                    timerLogin.Start();
                }
                else
                {
                    rol = 1;
                    panelLoading.BringToFront();
                    timerLogin.Enabled = true;
                    timerLogin.Start();
                }
            }
        }

        int linie;
        DataTable intrebari = null;
        int capitoleTerminate = 0;

        private void ClearIntrebare()
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

            raspunsCorect = null;
        }

        int contor = 0;
        int capitol = 0;
        private void buttonVerificareIntrebare_Click(object sender, EventArgs e)
        {
            if(raspunsA != null || raspunsB != null || raspunsC != null)
            {
                linie++;
                Intrebare i = new Intrebare();
                i.UserName = textBoxUtilizatorProfilNou.Text;
                i.IntrebareId = Convert.ToInt32(intrebari.Rows[0][0]);

                if (raspunsA + raspunsB + raspunsC == raspunsCorect ||
                    raspunsA + raspunsC + raspunsB == raspunsCorect ||
                    raspunsB + raspunsA + raspunsC == raspunsCorect ||
                    raspunsB + raspunsC + raspunsA == raspunsCorect ||
                    raspunsC + raspunsA + raspunsB == raspunsCorect ||
                    raspunsC + raspunsB + raspunsA == raspunsCorect ||
                    raspunsA + raspunsB + raspunsC == raspunsCorect ||
                    raspunsA + raspunsC + raspunsB == raspunsCorect ||
                    raspunsB + raspunsA + raspunsC == raspunsCorect ||
                    raspunsB + raspunsC + raspunsA == raspunsCorect ||
                    raspunsC + raspunsA + raspunsB == raspunsCorect ||
                    raspunsC + raspunsB + raspunsA == raspunsCorect)
                {
                    using (SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.correct))
                    {
                        audio.Play();
                    }

                    contor++;

                    if (contor == intrebari.Rows.Count)
                    {
                        Utilizator u = new Utilizator();
                        u.UserName = textBoxUtilizatorProfilNou.Text;
                        u.Descriere = intrebari.Rows[0][2].ToString();
                        u.FinalizareCapitol(u);
                        capitol++;
                        capitoleTerminate++;
                        TestareNivel(capitol);
                    }
                    else
                    {
                        generareIntrebare();
                    }

                    i.Raspuns = 0;
                    i.InserareIntrebareUtilizator(i);


                }
                else
                {
                    using (SoundPlayer audio = new SoundPlayer(bitQuiz.Properties.Resources.wrong))
                    {
                        audio.Play();
                    }

                    i.Raspuns = 1;
                    i.InserareIntrebareUtilizator(i);
                    capitol++;
                    TestareNivel(capitol);
                }
            }
            else
            {
                Eroare.textEroare = "Nicio variantă selectată";
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
}
