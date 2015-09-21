using System.Drawing;
using System.Windows.Forms;
using TeoVincent.ActiveMVC.Controllers;

namespace TeoVincent.ActiveMVC.Views
{
    public partial class WinFormView : Form, IObserver, IView
    {
        private IController controller;

        private readonly int width;
        private readonly int height;
        private readonly int scale;

        private readonly Graphics graphics;

        public WinFormView(int width, int height, int scale)
        {
            this.width = width * scale;
            this.height = height * scale;
            this.scale = scale;

            InitializeComponent();
            ClientSize = new Size(this.width, this.height);
            graphics = CreateGraphics();
        }

        public void Update(int x, int y)
        {
            Render(x, y);
        }

        public void SetController(IController controller)
        {
            this.controller = controller;
        }

        private void Render(int x, int y)
        {
            ClearLast();
            PrintNew(x, y);
        }

        private void ClearLast()
        {
            graphics.Clear(Color.Azure);
        }

        private void PrintNew(int x, int y)
        {
            var point = new Point(x*scale, y*scale);
            var size = new Size(scale, scale);
            var rectangle = new Rectangle(point, size);
            graphics.FillEllipse(Brushes.Black, rectangle);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                controller.MoveUp();
                return true;
            }

            if (keyData == Keys.Down)
            {
                controller.MoveDown();
                return true;
            }

            if (keyData == Keys.Left)
            {
                controller.MoveLeft();
                return true;
            }

            if (keyData == Keys.Right)
            {
                controller.MoveRight();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
