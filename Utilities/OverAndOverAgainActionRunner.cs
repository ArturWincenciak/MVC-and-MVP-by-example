using System;
using System.Threading.Tasks;

namespace TeoVincent.Utilities
{
    public class OverAndOverAgainActionRunner : IActionRunner
    {
        private readonly Task overAndOverAgain;
        private Action action;
        private const int INTERVAL = 50;
        private readonly object lockObj;

        public OverAndOverAgainActionRunner()
        {
            lockObj = new object();
            action = () => { };
            overAndOverAgain = Task.Factory.StartNew(OverAndOverAgain);
        }

        public void DoIt(Action a)
        {
            lock (lockObj)
                action = a;
        }

        private void OverAndOverAgain()
        {
            while (true)
            {
                lock (lockObj)
                {
                    action();
                    overAndOverAgain.Wait(INTERVAL);
                }
            }
        }
    }
}