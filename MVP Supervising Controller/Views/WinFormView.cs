using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeoVincent.MVP_Supervising_Controller.Views
{
    public partial class WinFormView : Form, IView<Keys>
    {
        private readonly int width;
        private readonly int height;
        private readonly int scale;

        private readonly Graphics graphics;

        public WinFormView(int width, int height, int scale, IModel model)
        {
            this.width = width * scale;
            this.height = height * scale;
            this.scale = scale;

            InitializeComponent();

            ClientSize = new Size(this.width, this.height);
            graphics = CreateGraphics();

            Bind(model);
        }

        public event EventHandler<Keys> OnPressArrow;

        private void Render(int x, int y)
        {
            ClearLast();
            PrintNew(x, y);
        }

        private void ClearLast()
            => graphics.Clear(Color.Azure);

        private void PrintNew(int x, int y)
        {
            var point = new Point(x * scale, y * scale);
            var size = new Size(scale, scale);
            var rectangle = new Rectangle(point, size);
            graphics.FillEllipse(Brushes.Black, rectangle);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            OnPressArrow?.Invoke(this, keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Bind(IModel model)
            => model.ModelChanged += (m) => Render(m.X, m.Y);
    }
}
