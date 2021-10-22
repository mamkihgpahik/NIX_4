using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NIX_4_v._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fork fork1 = new Fork(1);
            Fork fork2 = new Fork(2);
            Fork fork3 = new Fork(3);
            Fork fork4 = new Fork(4);
            Fork fork5 = new Fork(5);

            Waiter.Forks.Add(fork1);
            Waiter.Forks.Add(fork2);
            Waiter.Forks.Add(fork3);
            Waiter.Forks.Add(fork4);
            Waiter.Forks.Add(fork5);

            Philosopher phil1 = new Philosopher("Aristotle", fork1, fork2);
            Philosopher phil2 = new Philosopher("Confucius", fork2, fork3);
            Philosopher phil3 = new Philosopher("Foucault", fork3, fork4);
            Philosopher phil4 = new Philosopher("Hume", fork4, fork5);
            Philosopher phil5 = new Philosopher("Kant", fork5, fork1);

            Thread T1 = new Thread(() => phil1.Start());
            Thread T2 = new Thread(() => phil2.Start());
            Thread T3 = new Thread(() => phil3.Start());
            Thread T4 = new Thread(() => phil4.Start());
            Thread T5 = new Thread(() => phil5.Start());

            T1.Start();
            T2.Start();
            T3.Start();
            T4.Start();
            T5.Start();

            phil1.Stop();
            phil2.Stop();
            phil3.Stop();
            phil4.Stop();
            phil5.Stop();
            Console.ReadKey();
        }
    }
}
