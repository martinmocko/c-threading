using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thready1
{
    class Stuff
    {
        private int k = 0;
        private int threadnum;

        public Stuff(int threadnum)
        {
            this.threadnum = threadnum;
        }

        public int Threadnum
        {
            get { return threadnum; }
            set { threadnum = value; }
        }

        public void run()
        {
            String sprava="";
            ConcurrentQueue<String> q = null;
            if (threadnum == 1)
            {
                q = Program.Queue1;
            }
            else
            {
                q = Program.Queue2;
            }
            while (true)
            {
                if (q.IsEmpty == false)
                {
                    q.TryDequeue(out sprava);
                    Console.WriteLine("Thread " + threadnum + ". Dostal som spravu: " + sprava);
                }
            }
        }

        public int getK()
        {
            Console.WriteLine("GETUJEM K");
            return k;
        }
    }
}
