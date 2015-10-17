namespace Passive_MVC.Models
{
    public class Model : IModel
    {
        private readonly int minX;
        private readonly int maxX;

        private readonly int minY;
        private readonly int maxY;

        public int X { get; private set; }
        public int Y { get; private set; }

        public Model(int minX, int maxX, int minY, int maxY)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
        }

        public void IncreaseX()
        {
            if (X == maxX - 1)
                X = 0;
            else
                X++;
        }

        public void DecreaseX()
        {
            if (X == minX)
                X = maxX - 1;
            else
                X--;
        }

        public void IncreaseY()
        {
            if (Y == maxY - 1)
                Y = 0;
            else
                Y++;
        }

        public void DecreaseY()
        {
            if (Y == minY)
                Y = maxY - 1;
            else
                Y--;
        }
    }
}