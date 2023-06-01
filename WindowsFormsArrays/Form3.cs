using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsArrays
{
    public partial class Form3 : Form
    {
        TextBox tb;
        Button btn = new Button();
        int i, j, x, y;
        string stri, strj;
        double[,] matrix = new double[100, 100];
        Boolean b;
        public void addBox(int i, int j)
        {
            tb = new TextBox();
            tb.Location = new Point(j * 60, i * 25);
            tb.Size = new Size(50, 20);
            tb.Text = "0";
            tb.Name = "l" + i + "c" + j;
            panel1.Controls.Add(tb);
        }
        public void addButton(int i, int j)
        {
            btn.Location = new Point(Convert.ToInt32((j - 1) * 30), i * 25);
            btn.Size = new Size(50, 20);
            btn.Text = "Somme";
            btn.Name = "btn";
            btn.Click += new System.EventHandler(btnSomme_Click);
            panel1.Controls.Add(btn);
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            for (i = 0; i < Convert.ToInt32(numBoxes.Text); i++)
            {
                for (j = 0; j < Convert.ToInt32(numBoxes.Text); j++)
                {
                    addBox(i, j);
                }
            }

            addButton(i,j);
        }

        private void btnSomme_Click(object sender, EventArgs e)
        {
            /*for (int j = 1; j < i; j++)
            {
                var name = "val" + j;
                sum += Convert.ToInt32(this.panel1.Controls[name].Text);
            }
            label2.Text = sum.ToString();*/
            /*double sum = 0;
            int i = 0;
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox)
                {
                    tab[i] = Convert.ToDouble(c.Text);
                    i++;
                }
            }
            foreach (double val in tab)
            {
                sum += val;
                tab[i] = 0;
            }
            label2.Text = sum.ToString();
            sum = 0;*/
            i = 0;
            j = 0;
            stri = "";
            strj = "";
            double sum = 0;
            b = true;
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox)
                {
                    string str = c.Name;
                    foreach (char ch in str)
                    {
                        if (ch != 'l' && b == true)
                        {
                            if (ch == 'c')
                            {
                                b = false;
                            }
                            else
                            {
                                stri += ch;
                            }

                        }
                        else if (ch != 'l')
                        {
                            strj += ch;
                        }
                    }
                    i = Convert.ToInt32(stri);
                    j = Convert.ToInt32(strj);
                    matrix[i, j] = Convert.ToDouble(c.Text);
                    stri = "";
                    strj = "";
                    b = true;
                }
            }

            for (x = 0; x < i + 1; x++)
            {
                for (y = 0; y < j + 1; y++)
                {
                    if (x == y)
                    {
                        sum += matrix[x, y];
                    }
                    
                }
                label2.Text = sum.ToString();
            }
        }

        private void numBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
