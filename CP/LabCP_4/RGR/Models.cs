using lab2_IM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    class Models
    {
        Statistics stat;
        Generator gen = new Generator();
        ServiceWork[] arrServ;
        Settings sett;
        public Models(Settings settings)
        {
            sett = settings;
        }

        private int indexFree(List<int> freeIndex)
        {
            double ver = 1.0 / freeIndex.Count;

            double r = gen.NextDouble();

            for (int i = 0; i < freeIndex.Count; ++i)
            {
                if (r < ver)
                {
                    return freeIndex[i];
                }
                r -= ver;
            }
            return 0;
        }
        private int getIndexQue()
        {
            int min = arrServ[0].countInQu();
            List<int> freeIndex = new List<int>();

            for (int i = 1; i < arrServ.Length; ++i)
            {
                if (arrServ[i].countInQu() < min)
                {
                    min = arrServ[i].countInQu();
                }
            }

            for (int i = 0; i < arrServ.Length; ++i)
            {
                if (arrServ[i].countInQu() == min)
                {
                    freeIndex.Add(i);
                }
            }
            return indexFree(freeIndex);
        }

        private int getIndexPrQue()
        {
            int min = arrServ[0].countInPrQu();
            List<int> freeIndex = new List<int>();

            for (int i = 1; i < arrServ.Length; ++i)
            {
                if (arrServ[i].countInPrQu() < min)
                {
                    min = arrServ[i].countInPrQu();
                }
            }

            for (int i = 0; i < arrServ.Length; ++i)
            {
                if (arrServ[i].countInPrQu() == min)
                {
                    freeIndex.Add(i);
                }
            }
            return indexFree(freeIndex);
        }

        internal Statistics Stat { get => stat; set => stat = value; }

        private double getTimeINCust()
        {
            return gen.Exp(sett.IntensINCast);
        }

        private double getTimeInPrCust()
        {
            return gen.Exp(sett.IntensInPrCast);
        }

        public void start()
        {
            stat = new Statistics();
            arrServ = new ServiceWork[sett.CountServ];
            double[] lastVisit = new double[sett.CountServ];
            for (int i = 0; i < arrServ.Length; ++i)
            {
                arrServ[i] = new ServiceWork(sett.MathServ, sett.D, sett.Max, sett.Min);
                lastVisit[i] = 0;
            }
            double temeStatus = 0;
            double temeMoadel = sett.TimeAll;
            double nextCustom = getTimeINCust();
            stat.addTimeСoming(nextCustom);
            double nextPrCustom = getTimeInPrCust();

            temeStatus = Math.Min(nextCustom, nextPrCustom);

            while (temeStatus < temeMoadel)
            {
                if (temeStatus == nextCustom)
                {
                    int index = getIndexQue();
                    if (arrServ[index].empty() && arrServ[index].getFree)
                    {
                        stat.DownTime += temeStatus - lastVisit[index];
                    }                 
                    arrServ[index].addcustem(new Customer(temeStatus));
                    stat.CountCust1++;
                    double add = getTimeINCust();
                    stat.addTimeСoming(add);
                    nextCustom += add;
                }

                if (temeStatus == nextPrCustom)
                {
                    int index = getIndexPrQue();
                    if (arrServ[index].empty() && arrServ[index].getFree)
                    {
                        stat.DownTime += temeStatus - lastVisit[index];
                    }
                    stat.CountProirCust1++;
                    arrServ[index].addPrCustem(new Customer(temeStatus));
                    nextPrCustom += getTimeInPrCust();
                }

                for (int i = 0; i < arrServ.Length; ++i)
                {
                    if (!arrServ[i].getFree)
                    {
                        if (arrServ[i].CustSer1.TimeEndServ == temeStatus)
                        {
                            arrServ[i].Done();
                            lastVisit[i] = arrServ[i].CustSer1.TimeEndServ;
                            stat.addCust(arrServ[i].CustSer1);
                            if (!arrServ[i].empty())
                            {
                                arrServ[i].moveQue(arrServ[i].CustSer1.TimeEndServ);
                            }
                        }
                    }
                    else
                    if (!arrServ[i].empty() && arrServ[i].getFree)
                    {
                        lastVisit[i] = arrServ[i].nextCust().TimeIn;
                        arrServ[i].moveQue(arrServ[i].nextCust().TimeIn);
                    }
                }

                temeStatus = Math.Min(nextCustom, nextPrCustom);

                for (int i = 0; i < arrServ.Length; ++i)
                {
                    if (!arrServ[i].getFree)
                    {
                        if (arrServ[i].CustSer1.TimeEndServ < temeStatus)
                        {
                            temeStatus = arrServ[i].CustSer1.TimeEndServ;
                        }
                    }
                }
            }

            for (int i = 0; i < arrServ.Length; ++i)
            {
                stat.addLoading(arrServ[i].TimeWork);
            }

            stat.TotalTime = sett.TimeAll;

            stat.DownTime /= arrServ.Length;
        }
    }
}
