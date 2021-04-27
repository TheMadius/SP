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
        Statistics statInSP;
        string name;
        bool Flag;
        bool Flag2;
        int N = 100;
        double[] infCountCash ;
        double[] infCountHost ;
        double[] infCountAll ;
        double[] time;
        double avgCout;
        double avgDown;
        double avgServ;
        double avgLoud;
        public Form1()
        {
            InitializeComponent();
            this.groupBox1.Visible = false;
            this.groupBox2.Visible = false;
            this.groupBox3.Visible = true;
            sett = new Settings(600, 2, 0.5, 0.05, 70, 32.5, 10, 200, 70, 30);
            setSetting(sett);
            Flag = true;
            Flag2 = true;
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
            this.textBox18.Text = st.DH.ToString();
            this.textBox19.Text = st.MathH.ToString();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.groupBox1.Visible = false;
            this.groupBox2.Visible = false;
            this.groupBox3.Visible = true;
            this.groupBox4.Visible = false;
            this.button1.Visible = true;
            this.button3.Visible = true;
            setSetting(sett);
        }

        private void результатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.groupBox1.Visible = false;
            this.groupBox2.Visible = true;
            this.groupBox3.Visible = false;
            this.groupBox4.Visible = false;
            this.button1.Visible = true;
            this.button3.Visible = true;
        }

        private void графикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.groupBox1.Visible = true;
            this.groupBox2.Visible = false;
            this.groupBox3.Visible = false;
            this.groupBox4.Visible = false;
            this.button1.Visible = true;
            this.button3.Visible = true;

        }

        void setResult(Statistics stat)
        {
            this.textBox1.Text = stat.TotalTime.ToString();
            this.textBox2.Text = stat.CountCust1.ToString();
            this.textBox3.Text = stat.CountProirCust1.ToString();
            this.textBox4.Text = stat.avgTimeCust().ToString();
            this.textBox5.Text = stat.avgCountCust().ToString();
            this.textBox6.Text = stat.avgLoading().ToString();
            this.textBox7.Text = (stat.DownTime / sett.CountServ).ToString();
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
            sett.MathH = Convert.ToDouble(this.textBox19.Text);
            sett.DH = Convert.ToDouble(this.textBox18.Text);
        }

        private void drowChart(string name, double[] arr, SeriesChartType type)
        {
            this.chart4.Series.Clear();
            this.chart4.Series.Add(name);
            this.chart4.Series[name].ChartType = type;

            for (int i = 0; i < arr.Length; ++i)
            {
                this.chart4.Series[name].Points.AddXY(i + 1, arr[i]);
            }
        }

        private void drowChartSp(string name, double[] x, double[] y, SeriesChartType type)
        {
            this.chart1.Series.Clear();
            this.chart1.Series.Add(name);
            this.chart1.Series[name].ChartType = type;
            for(int i = 0; i < x.Length; ++i)
                this.chart1.Series[name].Points.AddXY(x[i], y[i]);
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
                    drowChart(name, loiding, SeriesChartType.Line);
                    break;
                case 2:
                    {
                        name = "Частота:Время обслуживания";
                        double[] CustTimr = stat.getTimeCust().ToArray();
                        CustTimr = interval(8, CustTimr);
                        drowChart(name, CustTimr, SeriesChartType.Line);
                        break;
                    }
                case 3:
                    {
                        name = "Частота:Время прихода";
                        double[] inCust = stat.getTimeСoming().ToArray();
                        inCust = interval(8, inCust);
                        drowChart(name, inCust, SeriesChartType.Line);
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
            this.textBox7.Text = (avgDown/ sett.CountServ).ToString();

        }

        private void случайныеПроцесыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.groupBox1.Visible = false;
            this.groupBox2.Visible = false;
            this.groupBox3.Visible = false;
            this.groupBox4.Visible = true;
            this.button1.Visible = false;
            this.button3.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Settings newSett = new Settings(this.sett);
            newSett.TimeAll = Convert.ToDouble(this.textBox16.Text) * Convert.ToDouble(this.textBox17.Text) * 60.0;
            RGR.Models model = new Models(newSett);
            model.start();
            double[] infCountCash = model.Stat.CoutPosInСash1.ToArray();
            double[] infCountHost = model.Stat.CoutPosInHole1.ToArray();
            double[] infCountAll = model.Stat.CoutPosInAll1.ToArray();
            this.time = model.Stat.T1.ToArray();

            for (int i = 0; i < N-1; ++i)
            {
                model.start();
                double[] temp = model.Stat.CoutPosInСash1.ToArray();
                double[] temp1 = model.Stat.CoutPosInHole1.ToArray();
                double[] temp2 = model.Stat.CoutPosInAll1.ToArray();
                for(int j = 0; j < temp.Length;++j)
                {
                    infCountCash[j] += temp[j];
                    infCountHost[j] += temp1[j];
                    infCountAll[j] += temp2[j];
                }
            }

            for (int j = 0; j < infCountCash.Length; ++j)
            {
                infCountCash[j] /= N;
                infCountHost[j] /= N;
                infCountAll[j] /= N;
            }

            this.infCountCash = infCountCash;
            this.infCountHost = infCountHost;
            this.infCountAll = infCountAll;

            Flag2 = false;
            comboBox2_SelectedIndexChanged(sender, e);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Flag2)
            {
                return;
            }
            switch (this.comboBox2.SelectedIndex)
            {
                case 0:
                    {
                        name = "Процесс 1";
                        drowChartSp(name, time, this.infCountCash, SeriesChartType.Line);
                        break;
                    }
                case 1:
                    {
                        name = "Процесс 2";
                        drowChartSp(name, time, this.infCountHost, SeriesChartType.Line);
                        break;
                    }
                case 2:
                    {
                        name = "Процесс 3";
                        drowChartSp(name, time, this.infCountAll, SeriesChartType.Line);
                        break;
                    }
                case 3:
                    {
                        name = "Процесс 4";
                        double[] y = statInSP.getTimeCust().ToArray();
                        double[] x = statInSP.T1.ToArray();
                        drowChartSp(name, x, y, SeriesChartType.Line);
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
