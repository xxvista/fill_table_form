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
        int s = 0;
        int l = 0;
        int i = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s = 0;
            l = 0;
            if (Convert.ToInt32(numBoxes.Text) % 1 == 0)
            {
                for (i = 1; i < Convert.ToInt32(numBoxes.Text) + 1; i++)
                {
                    tb = new TextBox();
                    if (l == 6) { l = 0; s += 60; }
                    tb.Location = new Point(s, l * 25);
                    tb.Size = new Size(50, 20);
                    //tb.Text = "val" + i;
                    tb.Name = "val" + i;
                    panel1.Controls.Add(tb);
                    l++;
                }

                if (l == 6) { l = 0; s += 60; }
                btn.Location = new Point(s, l * 25);
                btn.Size = new Size(50, 20);
                btn.Text = "Somme";
                btn.Name = "btn" + i;
                btn.Click += new System.EventHandler(btnSomme_Click);
                panel1.Controls.Add(btn);
            }

        }

        private void btnSomme_Click(object sender, EventArgs e)
        {
            int sum = 0;
            
            for (int j = 1; j < i; j++)
            {
                var name = "val" + j;
                sum += Convert.ToInt32(this.panel1.Controls[name].Text);
            }
            label2.Text = sum.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (i > 1)
            {
                if (l == 0) { l = 6; s -= 60; }
                i--;
                panel1.Controls.RemoveAt(i - 1);
                l--;
                if (l == -1) { l = 6; s -= 60; }
                btn.Location = new Point(s, l * 25);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.RemoveAt(i-1);
            tb = new TextBox();
            if (l == 6) { l = 0; s += 60; }
            tb.Location = new Point(s, l * 25);
            tb.Size = new Size(50, 20);
            //tb.Text = "val" + i;
            tb.Name = "val" + i;
            panel1.Controls.Add(tb);
            i++;
            l++;

            if (l == 6) { l = 0; s += 60; }
            btn.Location = new Point(s, l * 25);
            btn.Size = new Size(50, 20);
            btn.Text = "Somme";
            btn.Name = "btn" + i;
            btn.Click += new System.EventHandler(btnSomme_Click);
            panel1.Controls.Add(btn);
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
