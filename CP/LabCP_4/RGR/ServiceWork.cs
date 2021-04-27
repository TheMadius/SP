using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    class ServiceWork
    {
        Queue<Customer> queue ;
        Queue<Customer> prQueue ;
        Service serv;
        bool Free;
        Customer CustSer;

        double timeWork;

        double custemDone;

        public double TimeWork { get => timeWork; set => timeWork = value; }
        public bool getFree { get => Free; set => Free = value; }
        internal Customer CustSer1 { get => CustSer; }

        public ServiceWork(double m,double d, double max = 200, double min = 10)
        {
            Free = true;
            timeWork = 0;
            custemDone = 0;
            serv = new Service(m, d, max, min);
            queue = new Queue<Customer>();
            prQueue = new Queue<Customer>();
        }

        public void addcustem(Customer cust)
        {
            queue.Enqueue(cust);
        }

        public bool empty()
        {
            return (queue.Count == 0) && (prQueue.Count == 0);
        }

        public void addPrCustem(Customer cust)
        {
            prQueue.Enqueue(cust);
        }

        public int countInQu()
        {
            int cout = (Free) ? 0 : 1;
            return cout+queue.Count;
        }

        public int countInPrQu()
        {
            return prQueue.Count;
        }

        public Customer nextCust()
        {
            if (countInPrQu() != 0)
            {
               return prQueue.Peek();
            }
            else
            {
                return queue.Peek();
            }
        }

        public void moveQue(double timeIn)
        {
            Free = false;
            if (countInPrQu() != 0)
            {
                CustSer = prQueue.Dequeue();
                CustSer.TimeStartServ = timeIn;
                CustSer = serv.servis(CustSer);
            }
            else
            {
                CustSer = queue.Dequeue();
                CustSer.TimeStartServ = timeIn;
                CustSer = serv.servis(CustSer);
            }
        }
        public void Done()
        {
            custemDone++;
            Free = true;
            timeWork += CustSer.TimeEndServ - CustSer.TimeStartServ;
        }
    }
}
