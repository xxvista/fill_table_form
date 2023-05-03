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
    public partial class Form1 : Form
    {
        TextBox tb;
        Button btn = new Button();
        int top = 0;
        int left = 0;
        int sum = 0;
        int i;
        double[] tab = new double[100];
        public void addBox(int i) {
            tb = new TextBox();
            left = i / 6;
            top = i % 6;
            tb.Location = new Point(left * 60, top * 25);
            tb.Size = new Size(50, 20);
            tb.Text = "0";
            tb.Name = "val" + i;
            panel1.Controls.Add(tb);
        }
        public void addButton(int i) { 
            left = i / 6;
            top = i % 6;
            btn.Location = new Point(left * 60, top * 25);
            btn.Size = new Size(50, 20);
            btn.Text = "Somme";
            btn.Name = "btn" + i;
            btn.Click += new System.EventHandler(btnSomme_Click);
            panel1.Controls.Add(btn);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            for (i = 0; i < Convert.ToInt32(numBoxes.Text); i++)
                {
                    addBox(i);
                }

            addButton(i);
        }

        private void btnSomme_Click(object sender, EventArgs e)
        {
            /*for (int j = 1; j < i; j++)
            {
                var name = "val" + j;
                sum += Convert.ToInt32(this.panel1.Controls[name].Text);
            }
            label2.Text = sum.ToString();*/
            double sum = 0;
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
            sum = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (i > 1)
            {
                left = i / 6;
                top = i % 6;
                i--;
                panel1.Controls.RemoveAt(i);
                left = i / 6;
                top = i % 6;
                btn.Location = new Point(left * 60, top * 25);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.RemoveAt(i);

            addBox(i);

            i++;

            addButton(i);
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
