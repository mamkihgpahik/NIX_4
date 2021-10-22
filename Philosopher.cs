using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NIX_4_v._1
{
    public class Philosopher
    {
        bool X = true;
        public string Name { get; set; }

        private Fork LeftFork { get; set; }
       
        private Fork RightFork { get; set; }
       
        public Philosopher(string name, Fork LeftFork, Fork RightFork)
        {
            this.Name = name;
            this.LeftFork = LeftFork;
            this.RightFork = RightFork;
        }
        private void Thinking()
        {
            Console.WriteLine($"\"{Name}\" doing philosophical tricks.");
            Thread.Sleep(1000);
            Console.WriteLine($"\"{Name}\" ended doing philosophical tricks.");
        }
        private void Eating()
        {
            LeftFork.TakeFork();
            Console.WriteLine($"\"{Name}\" tooks the left fork {LeftFork}.");
            RightFork.TakeFork();
            Console.WriteLine($"\"{Name}\" tooks the right fork {RightFork}.");
            Console.WriteLine($"\"{Name}\" eating.");
            Thread.Sleep(1000);
            RightFork.PutFork();
            Console.WriteLine($"\"{Name}\" puts the right fork.");
            LeftFork.PutFork();
            Console.WriteLine($"\"{Name}\" puts the left fork");
        }
        public void Start()
        {
            while (X)
            {
                Thinking();
            TryEat:
                if (Waiter.ICanEat() == true)
                {
                    Eating();
                }
                else
                {
                    goto TryEat;
                }
            }
        }
        public void Stop()
        {
            X = false;
        }
    }
}
