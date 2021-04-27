using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    class Customer
    {
        double timeIn;
        double timeInQueue;
        double timeStartServ;
        double timeEndServ;

        public Customer(double timeIn,double timeInQueue)
        {
            this.timeIn = timeIn;
            this.timeInQueue = timeInQueue;
        }

        public double TimeIn { get => timeIn;}
        public double TimeStartServ { get => timeStartServ; set => timeStartServ = value; }
        public double TimeEndServ { get => timeEndServ; set => timeEndServ = value; }
    }
}
