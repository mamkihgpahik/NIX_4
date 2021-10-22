using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NIX_4_v._1
{
    static class Waiter
    {
        static readonly Mutex M = new Mutex();
        public static List<Fork> Forks { get; set; } = new List<Fork>();

        static public bool ICanEat()
        {
            M.WaitOne();
            Thread.Sleep(500);
            if (Forks.Where(F => F.isLocked == false).Count() <= 1)
            {
                M.ReleaseMutex();
                return false;
            }
            else
            {
                M.ReleaseMutex();
                return true;
            }
        }
    }
}
