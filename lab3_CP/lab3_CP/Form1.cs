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


            private void button1_Click(object sender, EventArgs e)
        {
            double[] vec = new double[3];
            int time = 1;

            this.dataGridView1.Rows.Clear();
            chart1.Series[0].Points.Clear();

            vec[0] = Convert.ToDouble(this.textBox1.Text);
            vec[1] = Convert.ToDouble(this.textBox2.Text);
            vec[2] = Convert.ToDouble(this.textBox3.Text);

           /*if (vec[0] + vec[1] + vec[2] != 1)
            {
                MessageBox.Show("Неправильный ввод данных: начальный вектор!!!");
                return;
            }
            */

           double[][] mas = new double[2][];
            mas[0] = new double[3];
            mas[1] = new double[3];

            mas[0][0] = Convert.ToDouble(this.textBox4.Text);
            mas[0][1] = Convert.ToDouble(this.textBox5.Text);
            mas[0][2] = Convert.ToDouble(this.textBox6.Text);
/*
            if (mas[0][0] + mas[0][1] + mas[0][2] != 1)
            {
                MessageBox.Show("Неправильный ввод данных: начальный вектор для события S0!!!");
                return;
            }
 */

            mas[1][0] = Convert.ToDouble(this.textBox7.Text);
            mas[1][1] = Convert.ToDouble(this.textBox8.Text);
            mas[1][2] = Convert.ToDouble(this.textBox9.Text);

/*
            if (mas[1][0] + mas[1][1] + mas[1][2] != 1)
            {
                MessageBox.Show("Неправильный ввод данных: начальный вектор для события S1!!!");
                return;
            }
*/

            int status = getRandEvent(vec);

            this.dataGridView1.Rows.Add(time.ToString(), status.ToString());
            chart1.Series[0].Points.AddXY(time, status);

            while (status != 2)
            {
                status = getRandEvent(mas[status]);
                time++;
                this.dataGridView1.Rows.Add(time.ToString(), status.ToString());
                chart1.Series[0].Points.AddXY(time, status);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            double[] vec = new double[3];
            double[] eve = new double[3];
            eve[0] = 0;
            eve[1] = 0;
            eve[2] = 0;

            this.dataGridView1.Rows.Clear();
            chart1.Series[0].Points.Clear();

            vec[0] = Convert.ToDouble(this.textBox1.Text);
            vec[1] = Convert.ToDouble(this.textBox2.Text);
            vec[2] = Convert.ToDouble(this.textBox3.Text);

            double[][] mas = new double[2][];
            mas[0] = new double[3];
            mas[1] = new double[3];

            mas[0][0] = Convert.ToDouble(this.textBox4.Text);
            mas[0][1] = Convert.ToDouble(this.textBox5.Text);
            mas[0][2] = Convert.ToDouble(this.textBox6.Text);

            mas[1][0] = Convert.ToDouble(this.textBox7.Text);
            mas[1][1] = Convert.ToDouble(this.textBox8.Text);
            mas[1][2] = Convert.ToDouble(this.textBox9.Text);

            int sum = 0;

            for(int i = 0; i < 500; ++i)
            {
                
                int time = 1;
                int status = getRandEvent(vec);
                eve[status]++;
                while (status != 2)
                {
                    status = getRandEvent(mas[status]);
                    eve[status]++;
                    time++;
                }

                sum += time;
            }

            double avg = (double)sum / 500;

            this.textBox10.Text = avg.ToString();
            this.textBox11.Text = ((double)eve[0]/500).ToString();
            this.textBox12.Text = ((double)eve[1]/500).ToString();
            this.textBox13.Text = ((double)(eve[2])/500).ToString();

        }
    }
}
