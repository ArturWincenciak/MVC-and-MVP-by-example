using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeoVincent.ActiveMVC.Views;

namespace TeoVincent.ActiveMVC.Models
{
    public class Model : IModel, IObservable
    {
        private readonly int minX;
        private readonly int maxX;

        private readonly int minY;
        private readonly int maxY;

        private int x;
        private int y;

        private readonly List<IObserver> observers;
        private readonly Task overAndOverAgain;
        private Action action;
        private const int INTERVAL = 50;
        private readonly object lockObj;

        public Model(int minX, int maxX, int minY, int maxY)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;

            observers = new List<IObserver>();

            lockObj = new object();
            action = () => { };
            overAndOverAgain = Task.Factory.StartNew(OverAndOverAgain);
        }

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void IncreaseX()
        {
            lock (lockObj)
                action = IncX;
        }

        public void DecreaseX()
        {
            lock (lockObj)
                action = DecX;
        }

        public void IncreaseY()
        {
            lock (lockObj)
                action = IncY;
        }

        public void DecreaseY()
        {
            lock (lockObj)
                action = DecY;
        }

        private void IncX()
        {
            if (x == maxX - 1)
                x = 0;
            else
                x++;

            Notify();
        }

        private void DecX()
        {
            if (x == minX)
                x = maxX - 1;
            else
                x--;

            Notify();
        }

        private void IncY()
        {
            if (y == maxY - 1)
                y = 0;
            else
                y++;

            Notify();
        }

        private void DecY()
        {
            if (y == minY)
                y = maxY - 1;
            else
                y--;

            Notify();
        }

        private void Notify()
        {
            foreach (var observer in observers)
                observer.Update(x, y);
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