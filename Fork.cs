using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NIX_4_v._1
{
    public class Fork
    {
        public Mutex M;
        public int forkID { get; set; }
        public bool isLocked { get; private set; }
       
        public Fork(int ID)
        {
            this.forkID = ID;
            M = new Mutex(false, $"MutextFork{this.forkID}");
            isLocked = false;
        }
       
        public void TakeFork()
        {
            M.WaitOne();
            isLocked = true;
        }
        
        public void PutFork()
        {
            M.ReleaseMutex();
            isLocked = false;
        }
        public override string ToString()
        {
            return $"number {forkID}";
        }
    }
}
