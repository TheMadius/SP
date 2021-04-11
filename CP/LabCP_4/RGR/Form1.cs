using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RGR
{
    public partial class Form1 : Form
    {
        Settings sett;
        Statistics stat;
        string name;
        bool Flag;

        double avgCout;
        double avgDown;
        double avgServ;
        double avgLoud;
        public Form1()
        {
            InitializeComponent();
            this.groupBox1.Visible = true;
            this.groupBox2.Visible = true;
            this.groupBox3.Visible = true;
            sett = new Settings(600, 2, 0.5, 0.05, 70, 32.5, 10, 200);
            setSetting(sett);
            Flag = true;
        }

        void setSetting(Settings st)
        {
            this.textBox8.Text = st.IntensINCast.ToString();
            this.textBox9.Text = st.CountServ.ToString();
            this.textBox10.Text = st.TimeAll.ToString();
            this.textBox11.Text = st.IntensInPrCast.ToString();
            this.textBox12.Text = st.MathServ.ToString();
            this.textBox13.Text = st.D.ToString();
            this.textBox14.Text = st.Max.ToString();
            this.textBox15.Text = st.Min.ToString();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.groupBox1.Visible = true;
            this.groupBox2.Visible = true;
            this.groupBox3.Visible = true;

            setSetting(sett);
        }

        private void результатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.groupBox1.Visible = true;
            this.groupBox2.Visible = true;
            this.groupBox3.Visible = false;

        }

        private void графикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.groupBox1.Visible = true;
            this.groupBox2.Visible = false;
            this.groupBox3.Visible = false;

        }

        void setResult(Statistics stat)
        {
            this.textBox1.Text = stat.TotalTime.ToString();
            this.textBox2.Text = stat.CountCust1.ToString();
            this.textBox3.Text = stat.CountProirCust1.ToString();
            this.textBox4.Text = stat.avgTimeCust().ToString();
            this.textBox5.Text = stat.avgCountCust().ToString();
            this.textBox6.Text = stat.avgLoading().ToString();
            this.textBox7.Text = stat.DownTime.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RGR.Models model = new Models(this.sett);
            model.start();
            stat = model.Stat;
            setResult(stat);
            Flag = false;
            draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sett.IntensINCast = Convert.ToDouble(this.textBox8.Text);
            sett.CountServ = Convert.ToInt32(this.textBox9.Text);
            sett.TimeAll = Convert.ToDouble(this.textBox10.Text);
            sett.IntensInPrCast = Convert.ToDouble(this.textBox11.Text);
            sett.MathServ = Convert.ToDouble(this.textBox12.Text);
            sett.D = Convert.ToDouble(this.textBox13.Text);
            sett.Max = Convert.ToDouble(this.textBox14.Text);
            sett.Min = Convert.ToDouble(this.textBox15.Text);
        }

        private void drowChart(string name, double[] arr, SeriesChartType type)
        {
            this.chart4.Series.Clear();
            this.chart4.Series.Add(name);
            this.chart4.Series[name].ChartType = type;

            for(int i = 0; i < arr.Length;++i)
            {
                this.chart4.Series[name].Points.AddXY(i + 1, arr[i]);
            }
        }

        private void getAVG()
        {
            int N = 50;
            avgCout = 0;
            avgDown = 0;
            avgServ = 0;
            avgLoud = 0;

            for (int i = 0; i < N; ++i)
            {
                RGR.Models model = new Models(this.sett);

                model.start();

                avgDown += model.Stat.DownTime;
                avgCout += model.Stat.avgCountCust();
                avgLoud += model.Stat.avgLoading();
                avgServ += model.Stat.avgTimeCust();
            }
            avgCout /= N;
            avgDown /= N;
            avgServ /= N;
            avgLoud /= N;

        }
        private double[] interval(int coutn,double[] vibor)
        {
            double min = vibor.Min();
            double max = vibor.Max();
            List<double> lis = new List<double>();

            double step = (max - min) / (coutn - 1);

            for(double i = min; i < max;i+= step)
            {
                int count = 0;
                for(int j = 0; j < vibor.Length;++j)
                {
                    if((i <= vibor[j]) && ((i+ step) >= vibor[j]))
                    {
                        count++;
                    }
                }
                lis.Add(count/ (double)(vibor.Length));
            }

            return lis.ToArray();
        }
        private void draw()
        {
            if(Flag)
            {
                return;
            }
            switch (this.comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        name = "Время обслуживания";
                        double[] CustTimr = stat.getTimeCust().ToArray();
                        drowChart(name, CustTimr, SeriesChartType.Line);
                        break;
                    }
                case 1:
                    name = "Загруженность касс";
                    double[] loiding = stat.getLoading().ToArray();
                    drowChart(name, loiding, SeriesChartType.Column);
                    break;
                case 2:
                    {
                        name = "Частота:Время обслуживания";
                        double[] CustTimr = stat.getTimeCust().ToArray();
                        CustTimr = interval(8, CustTimr);
                        drowChart(name, CustTimr, SeriesChartType.Column);
                        break;
                    }
                case 3:
                    {
                        name = "Частота:Время прихода";
                        double[] inCust = stat.getTimeСoming().ToArray();
                        inCust = interval(8, inCust);
                        drowChart(name, inCust, SeriesChartType.Column);
                        break;
                    }
                default:
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            draw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getAVG();

            this.textBox4.Text = avgServ.ToString();
            this.textBox5.Text = avgCout.ToString();
            this.textBox6.Text = avgLoud.ToString();
            this.textBox7.Text = avgDown.ToString();

        }
    }
}
