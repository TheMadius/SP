using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    class Settings
    {
        double timeAll;
        int countServ;
        double intensINCast;
        double intensInPrCast;
        double mathServ;
        double d;
        double min;
        double max;

        public Settings(double time, int countServ, double intensINCast, double intensInPrCast, double mathServ, double d, double min, double max)
        {
            timeAll = time;
            this.countServ = countServ;
            this.intensINCast = intensINCast;
            this.intensInPrCast = intensInPrCast;
            this.mathServ = mathServ;
            this.d = d;
            this.min = min;
            this.max = max;
        }

        public double TimeAll { get => timeAll; set => timeAll = value; }
        public int CountServ { get => countServ; set => countServ = value; }
        public double IntensINCast { get => intensINCast; set => intensINCast = value; }
        public double IntensInPrCast { get => intensInPrCast; set => intensInPrCast = value; }
        public double MathServ { get => mathServ; set => mathServ = value; }
        public double D { get => d; set => d = value; }
        public double Min { get => min; set => min = value; }
        public double Max { get => max; set => max = value; }
    }
}
