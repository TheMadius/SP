using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3_CP
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Gen g = new Gen();
        public struct Pair
        {
            public Pair(double time, int ev)
            {
                this.ev = ev;
                this.time = time;
            }
            public double time;
            public int ev;
        }
        public Form1()
        {
            InitializeComponent();
            tabPage1.Text = "Таблица";
            tabPage2.Text = "Графики";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int getRandEvent(double[] vec)
        {
            double rand = r.NextDouble();
            double start = 0;

            for (int i = 0; i < vec.Length; ++i)
            {
                start += vec[i];
                if (start >= rand)
                {
                    return i;
                }
            }
            return vec.Length - 1;
        }

        private Pair getRandEventL(double[] vec)
        {
            List<double> listL = new List<double>();
            List<int> listIx = new List<int>();

            for (int i = 0; i < vec.Length; ++i)
            {
                if (vec[i] != 0)
                {
                    listL.Add(g.Exp(vec[i]));
                    listIx.Add(i);
                }
            }
            int pos = listL.IndexOf(listL.Min());
            Pair res = new Pair(listL[pos], listIx[pos]);
            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] vec = new double[3];
            double timeMod = Convert.ToDouble(this.textBox25.Text);
            double time = 0;

            this.dataGridView1.Rows.Clear();
            chart1.Series[0].Points.Clear();

            vec[0] = Convert.ToDouble(this.textBox1.Text);
            vec[1] = Convert.ToDouble(this.textBox2.Text);
            vec[2] = Convert.ToDouble(this.textBox3.Text);

           double[][] mas = new double[4][];
            mas[0] = new double[4];
            mas[1] = new double[4];
            mas[2] = new double[4];
            mas[3] = new double[4];

            mas[0][0] = Convert.ToDouble(this.textBox_00.Text);
            mas[0][1] = Convert.ToDouble(this.textBox_01.Text);
            mas[0][2] = Convert.ToDouble(this.textBox_02.Text);
            mas[0][3] = Convert.ToDouble(this.textBox_03.Text);

            mas[1][0] = Convert.ToDouble(this.textBox_10.Text);
            mas[1][1] = Convert.ToDouble(this.textBox_11.Text);
            mas[1][2] = Convert.ToDouble(this.textBox_12.Text);
            mas[1][3] = Convert.ToDouble(this.textBox_13.Text);

            mas[2][0] = Convert.ToDouble(this.textBox_20.Text);
            mas[2][1] = Convert.ToDouble(this.textBox_21.Text);
            mas[2][2] = Convert.ToDouble(this.textBox_22.Text);
            mas[2][3] = Convert.ToDouble(this.textBox_23.Text);

            mas[3][0] = Convert.ToDouble(this.textBox_30.Text);
            mas[3][1] = Convert.ToDouble(this.textBox_31.Text);
            mas[3][2] = Convert.ToDouble(this.textBox_32.Text);
            mas[3][3] = Convert.ToDouble(this.textBox_33.Text);

            int status = getRandEvent(vec);

            this.dataGridView1.Rows.Add(time.ToString(), status.ToString());
            chart1.Series[0].Points.AddXY(time, status);

            while (time<timeMod)
            {
                Pair res = getRandEventL(mas[status]);
                time+= res.time;
                status = res.ev;
                this.dataGridView1.Rows.Add(time.ToString(), status.ToString());
                chart1.Series[0].Points.AddXY(time, status);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
