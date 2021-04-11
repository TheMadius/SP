using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabCP_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.tabPage1.Text = "Таблица";
            this.tabPage2.Text = "График";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            (this.tabControl1.TabPages[0].Controls["dataGridView1"] as DataGridView).Rows.Clear();
            this.chart1.Series[0].Points.Clear();
            double lam = Convert.ToDouble(textBox1.Text);
            double time = Convert.ToDouble(textBox2.Text);
            double m = Convert.ToDouble(textBox3.Text);
            double d = Convert.ToDouble(textBox4.Text);
            Gen g = new Gen();
           
            double t = 0;
            int norm = 0;
            int numPro = 0;

            (this.tabControl1.TabPages[0].Controls["dataGridView1"] as DataGridView).Rows.Add(numPro.ToString(), t.ToString(), norm.ToString());
            this.chart1.Series[0].Points.AddXY(t, numPro);
            while (true)
            {
                double newProduct = g.Exp(lam);
                t += newProduct;

                norm = (int)(g.getCLT(1000,m,d));

                while(norm < 0)
                {
                    norm = (int)(g.getCLT(1000, m, d));
                }

                numPro+=norm;

                if (t > time)
                    break;

                (this.tabControl1.TabPages[0].Controls["dataGridView1"] as DataGridView).Rows.Add(numPro.ToString(),t.ToString(), norm.ToString());
                this.chart1.Series[0].Points.AddXY(t, numPro - 1);
                this.chart1.Series[0].Points.AddXY(t, numPro);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
