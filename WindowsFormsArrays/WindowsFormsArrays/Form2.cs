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
    public partial class Form2 : Form
    {
        TextBox tb;
        Label lb;
        Button btn = new Button();
        int i, j, x, y;
        string stri, strj;
        double[,] matrix = new double[100,100];
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

        public void addLabel(int i, int j)
        {
            lb = new Label();
            lb.Location = new Point(j * 60, i * 25);
            lb.Text = i + 1 + " Max: Min: ";
            lb.Name = "l" + i;
            panel1.Controls.Add(lb);
        }
        public void addButton(int i, double j)
        {
            btn.Location = new Point(Convert.ToInt32((j-1) * 30), i * 25);
            btn.Size = new Size(100, 20);
            btn.Text = "Somme";
            btn.Name = "btn";
            btn.Click += new System.EventHandler(btnSomme_Click);
            panel1.Controls.Add(btn);
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            for (i = 0; i < Convert.ToInt32(lignes.Text); i++)
            {
                for (j = 0; j < Convert.ToInt32(colonne.Text); j++)
                {
                    addBox(i, j);
                }
                addLabel(i , j);
            }

            addButton(i,j);
        }

        private void btnSomme_Click(object sender, EventArgs e)
        {
            i = 0;
            j = 0;
            stri = "";
            strj = "";
            b = true;
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox)
                {
                    string str = c.Name;
                    foreach (char ch in str)
                    {
                        if (ch !=  'l' && b == true)
                        {
                            if (ch == 'c')
                            {
                                b = false;
                            } else
                            {
                                stri += ch;
                            }
                            
                        } else if (ch != 'l')
                        { 
                            strj += ch;
                        }
                    }
                    i = Convert.ToInt32(stri);
                    j = Convert.ToInt32(strj);
                    matrix[i,j] = Convert.ToDouble(c.Text);
                    stri = "";
                    strj = "";
                    b = true;
                }
            }

            for (x = 0; x < i + 1; x++)
            {
                double max = matrix[x, 0];
                double min = matrix[x, 0];
                for (y = 1; y < j + 1; y++)
                {
                    double value = matrix[x, y];

                    if (value > max)
                    {
                        max = value;
                    }

                    if (value < min)
                    {
                        min = value;
                    }
                }
                var name = "l" + x;
                panel1.Controls[name].Text = "Max: " + max.ToString() + " Min: " + min.ToString();
            }
        }

        private void lignes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
