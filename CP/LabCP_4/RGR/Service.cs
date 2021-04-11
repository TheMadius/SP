using lab2_IM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    class Service
    {
        Generator gen = new Generator();
        double M;
        double D;
        double Min;
        double Max;
        public Service(double m, double d,double max = 200,double min = 10)
        {
            M = m;
            D = d;
            Min = min;
            Max = max;
        }

        private double getNotmal()
        {
            while (true)
            {
                double r = gen.getCLT(100, M, D);
                if (r >= Min && r <= Max)
                    return r / 60; 
            }
        }

        public Customer servis(Customer client)
        {
            client.TimeEndServ = client.TimeStartServ + getNotmal();
            return client;
        }
    }
}
