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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private double[] dot(double[] vec, double[][] mas)
        {
            double[] res = new double[vec.Length];
            for (int i = 0; i < vec.Length; ++i)
                res[i] = 0;

            for (int i = 0; i < vec.Length;++i)
                for(int j = 0; j < vec.Length;j++)
                {
                    res[i] += vec[j]* mas[j][i];
                }
            return res;
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double[] vec = new double[4];
            double[] res = new double[4];
            int n = Convert.ToInt32(this.textBox25.Text);

            vec[0] = Convert.ToDouble(this.textBox1.Text);
            vec[1] = Convert.ToDouble(this.textBox2.Text);
            vec[2] = Convert.ToDouble(this.textBox3.Text);
            vec[3] = Convert.ToDouble(this.textBox20.Text);


            for (int i = 0; i < res.Length; ++i)
                res[i] = vec[i];

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

            for (int i = 0; i < n; ++i)
            {
                res = dot(res, mas);
            }

            this.textBox24.Text = res[0].ToString();
            this.textBox23.Text = res[1].ToString();
            this.textBox22.Text = res[2].ToString();
            this.textBox21.Text = res[3].ToString();
        }
    }
}
