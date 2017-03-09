using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thready1
{
    class Program
    {
        static ConcurrentQueue<String> q1 = new ConcurrentQueue<string>();
        static ConcurrentQueue<String> q2 = new ConcurrentQueue<string>();

        public static ConcurrentQueue<String> Queue1
        {
            get { return q1; }
        }

        public static ConcurrentQueue<String> Queue2
        {
            get { return q2; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("HELLO !");
            
            int p = 0;
            Random rnd = new Random();
            Double d;
            Stuff st1 = new Stuff(1);
            Stuff st2 = new Stuff(2);
            Thread t1 = new Thread(() => { Console.WriteLine("Spustil som tred1"); st1.run(); });
            Thread t2 = new Thread(() => { Console.WriteLine("Spustil som tred2"); st2.run(); });
            t1.Start();
            t2.Start();
            
            while (true)
            {
                for (int i = 0; i < 100000; i++)
                {
                    p=i;
                }
                d = rnd.NextDouble();
                if(d <= 0.5)
                    q1.Enqueue("Ahoj tred 1");
                else
                {
                    q2.Enqueue("Cus tred 2");
                }
                Thread.Sleep(500);

            }
        }
    }
}
