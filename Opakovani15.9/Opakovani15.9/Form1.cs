using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Opakovani15._9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader cteni=null;
            int n = int.Parse(textBox1.Text);

            try
            {
                string[] radky = File.ReadAllLines("cisla.txt");
                int cislo = int.Parse(radky[4]);
                long cisloumocneni = 1;
                double zaporneumocneni = 1;

                try
                {
                    if (n > 0)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            checked { cisloumocneni *= cislo; }
                        }
                        MessageBox.Show("mocnina : " + cisloumocneni);
                    }
                    else if (n < 0)
                    {
                        for (int i = 0; i > n; i--)
                        {
                            checked { zaporneumocneni /= (double)cislo; }
                        }
                        MessageBox.Show("mocnina : " + zaporneumocneni);
                    }
                    else MessageBox.Show("mocnina : " + cisloumocneni);
                }
                catch (ArithmeticException)
                {
                    MessageBox.Show("Preteceni pri umocnovani !!!");
                }

                double cislo2 = Convert.ToDouble(cislo);

                try { MessageBox.Show("podil celeho cisla : " + checked(cislo / n)); }
                catch (DivideByZeroException ex)
                {
                    MessageBox.Show("DivideByZeroException. " + ex.Message);
                }
                if (n != 0)
                {
                    cislo2 = cislo2 / n;
                    MessageBox.Show("realny podil : " + cislo2);
                }
                else MessageBox.Show("n neodopovida !!!!");

                int soucet = 0;
                try
                {
                    cteni = new StreamReader("cisla.txt");
                    while (!cteni.EndOfStream)
                    {
                        checked { soucet += Convert.ToInt32(cteni.ReadLine()); }
                    }
                    MessageBox.Show("Součet vsech cisel : " + soucet);
                }
                catch (ArithmeticException)
                {
                    MessageBox.Show("Preteceni pri souctu !!!");
                }
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("OverflowException. " + ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("FormatException. " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("FileNotFoundException. " + ex.Message);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("pate cislo neexistuje :-)");
            }
            finally
            {
                if (cteni != null) cteni.Close();
            }
        }
    }
}
