using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.FromArgb(0, Color.Gray);
            pictureBox2.BackColor = Color.FromArgb(0, Color.Gray);
            label1.BackColor = Color.FromArgb(0, Color.Gray);
            label2.BackColor = Color.FromArgb(0, Color.Gray);
            label3.BackColor = Color.FromArgb(0, Color.Gray);
            DeleteButton.BackColor = Color.FromArgb(0, Color.Gray);
        }

        string Szyfrowanie(string text, int klucz)
        #region Szyfrowanie uniwersalne
        {
            string koniec = ""; //wyniczek
            for(int i = 0; i<text.Length;i++)
            {
                if (text[i] != ' ' && text[i] != ';' && text[i] != '.')
                {
                    if (text[i] >= 'A' && text[i] <= 'Z')
                    {
                        koniec = koniec + (char)(65 + (text[i] - (65 - klucz)) % 26);
                    }
                    if (text[i] >= 'a' && text[i] <= 'z')
                    {
                        koniec = koniec + (char)(97 + (text[i] - (97 - klucz)) % 26);
                    }
                }
                else koniec += text[i];
            }
            return koniec;
        }
        #endregion
        string Odszyfrowanie(string text, int klucz)
        {
            string koniec = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ' && text[i] != ';' && text[i] != '.')
                {
                    if (text[i] >= 'A' && text[i] <= 'Z')
                    {
                        koniec = koniec + (char)(65 + (text[i] + (65 - klucz)) % 26);
                    }
                    if (text[i] >= 'a' && text[i] <= 'z')
                    {
                        koniec = koniec + (char)(97 + (text[i] + (85 - klucz)) % 26);
                    }
                }
                else koniec += text[i];
            }
            return koniec;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (KluczTextBox.Text == "0" && KluczTextBox.Text == " ")
            {
                MessageBox.Show("KLUCZ NIE MOŻE BYĆ ZEROWY! WCIŚNIJ USUŃ NA EKRANIE PRZED KOTYNUŁOWANIEM OPERACJI!");
                pictureBox1.Enabled = false;
                pictureBox2.Enabled = false;
            }
            else
                try
                {
                    textBox2.Text += Szyfrowanie(textBox1.Text, Convert.ToInt32(KluczTextBox.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Podano złe parametry");
                }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            KluczTextBox.Clear();
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (KluczTextBox.Text == "0" && KluczTextBox.Text == " ")
            {
                MessageBox.Show("KLUCZ NIE MOŻE BYĆ ZEROWY! WCIŚNIJ USUŃ NA EKRANIE PRZED KOTYNUŁOWANIEM OPERACJI!");
                pictureBox1.Enabled = false;
                pictureBox2.Enabled = false;
            }
            else
                try 
                {
                    textBox3.Text += Odszyfrowanie(textBox4.Text, Convert.ToInt32(KluczTextBox.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Podano złe parametry");
                }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
