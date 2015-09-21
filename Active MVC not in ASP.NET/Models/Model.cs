namespace TeoVincent.ActiveMVC.Models
{
    public class Model : Observable, IModel
    {
        private readonly int minX;
        private readonly int maxX;

        private readonly int minY;
        private readonly int maxY;
        
        private int x;
        private int y;

        public Model(int minX, int maxX, int minY, int maxY)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
        }

        protected override void Notify()
        {
            foreach (var observer in observers)
                observer.Update(x, y);
        }

        public void IncreaseX()
        {
            if (x == maxX-1)
                x = 0;
            else
                x++;

            Notify();
        }

        public void DecreaseX()
        {
            if (x == minX)
                x = maxX-1;
            else
                x--;

            Notify();
        }

        public void IncreaseY()
        {
            if (y == maxY-1)
                y = 0;
            else
                y++;

            Notify();
        }

        public void DecreaseY()
        {
            if (y == minY)
                y = maxY-1;
            else
                y--;

            Notify();
        }
    }
}