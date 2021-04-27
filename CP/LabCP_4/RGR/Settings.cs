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
        double mathH;
        double dH;

        public Settings(double time, int countServ, double intensINCast, double intensInPrCast, double mathServ, double d, double min, double max, double mathH,double dH)
        {
            timeAll = time;
            this.countServ = countServ;
            this.intensINCast = intensINCast;
            this.intensInPrCast = intensInPrCast;
            this.mathServ = mathServ;
            this.d = d;
            this.min = min;
            this.max = max;
            this.mathH = mathH;
            this.dH = dH;
        }

        public Settings(Settings obj)
        {
            this.timeAll = obj.timeAll;
            this.countServ = obj.countServ;
            this.intensINCast = obj.intensINCast;
            this.intensInPrCast = obj.intensInPrCast;
            this.mathServ = obj.mathServ;
            this.d = obj.d;
            this.min = obj.min;
            this.max = obj.max;
            this.mathH = obj.mathH;
            this.dH = obj.dH;
        }

        public double TimeAll { get => timeAll; set => timeAll = value; }
        public int CountServ { get => countServ; set => countServ = value; }
        public double IntensINCast { get => intensINCast; set => intensINCast = value; }
        public double IntensInPrCast { get => intensInPrCast; set => intensInPrCast = value; }
        public double MathServ { get => mathServ; set => mathServ = value; }
        public double D { get => d; set => d = value; }
        public double Min { get => min; set => min = value; }
        public double Max { get => max; set => max = value; }
        public double MathH { get => mathH; set => mathH = value; }
        public double DH { get => dH; set => dH = value; }
    }
}
