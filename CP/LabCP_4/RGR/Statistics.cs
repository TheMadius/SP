using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    class Statistics
    {
        List<Customer> Cust = new List<Customer>();
        List<double> loading = new List<double>();
        List<double> TimeСoming = new List<double>();
        double downTime;
        int CountCust;
        int CountProirCust;
        double totalTime;

        public Statistics()
        {
            downTime = 0;
            Cust.Clear();
            loading.Clear();
            CountCust = 0;
            CountProirCust = 0;
        }

        public List<double> Loading { get => loading; set => loading = value; }
        public int CountCust1 { get => CountCust; set => CountCust = value; }
        public int CountProirCust1 { get => CountProirCust; set => CountProirCust = value; }
        internal List<Customer> Cust1 { get => Cust; set => Cust = value; }
        public double TotalTime { get => totalTime; set => totalTime = value; }
        public double DownTime { get => downTime; set => downTime = value; }

        public double avgTimeCust()
        {
            double summ = 0;
            List<double> time = getTimeCust();
            for (int i = 0; i < time.Count; ++i)
            {
                summ += time[i];
            }
            return (summ / (time.Count));
        }

        public double avgLoading()
        {
            double summ = 0;
            List<double> time = getLoading();
            for (int i = 0; i < time.Count; ++i)
            {
                summ += time[i];
            }
            return (summ / (time.Count));
        }

        public void addCust(Customer cust)
        {
            Cust.Add(cust);
        }
        public void addTimeСoming(double ter)
        {
            TimeСoming.Add(ter);
        }

        public List<double> getTimeCust()
        {
            List<double> ListTime = new List<double>();
            for (int i = 0; i < Cust.Count; i++)
            {
                ListTime.Add(Cust[i].TimeEndServ - Cust[i].TimeStartServ);
            }
            return ListTime;
        }

        public List<double> getTimeСoming()
        {
               return TimeСoming;
        }

        public List<double> getLoading()
        {
            List<double> ListTime = new List<double>();
            for (int i = 0; i < loading.Count; i++)
            {
                ListTime.Add(loading[i] / totalTime);
            }
            return ListTime;
        }

        public void addLoading(double timeWork)
        {
            loading.Add(timeWork);
        }
        public double getDownTime()
        {
            double summ = 0;
            for (int i = 0; i < Cust.Count; ++i)
            {
                summ += 0;
            }
            return (summ / (Cust.Count));
        }

        public double avgCountCust()
        {
            double countHour = totalTime / 60;
            double summ = 0;
            List<double> time = getTimeCust();
     
            return time.Count / countHour;
        }
    }
}
