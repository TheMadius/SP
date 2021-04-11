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
        double timeStartServ;
        double timeEndServ;

        public Customer(double timeIn)
        {
            this.timeIn = timeIn;
        }

        public double TimeIn { get => timeIn;}
        public double TimeStartServ { get => timeStartServ; set => timeStartServ = value; }
        public double TimeEndServ { get => timeEndServ; set => timeEndServ = value; }
    }
}
