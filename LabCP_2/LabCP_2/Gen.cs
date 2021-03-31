using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCP_2
{
    class Gen
    {
        public double getCLT(int n, double m, double G)
        {
            double v, z, x, r;

            v = 0;

            for (int i = 0; i < n; i++)
            {
                r = rand.NextDouble();
                v += r;
            }

            z = (v - ((double)n / 2)) / Math.Sqrt(((double)n / 12));

            x = z * G + m;

            return x;
        }

        public double getUniform(double a, double b)
        {
            return a + (b - a) * rand.NextDouble();
        }
        public double NextDouble()
        {
            return rand.NextDouble();
        }
        public double Exp(double lambda)
        {
            double r = rand.NextDouble();

            return func(lambda, r);
        }
        double func(double lambda, double x)
        {
            return -(1 / lambda) * Math.Log(x);
        }

        static Random rand = new Random();
    }
}
