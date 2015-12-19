using System.Threading.Tasks;
using System.Windows.Forms;
using TeoVincent.ActiveMVC.Controllers;
using TeoVincent.ActiveMVC.Models;
using TeoVincent.ActiveMVC.Views;
using TeoVincent.Utilities;

namespace TeoVincent.ActiveMVC
{
    class Program
    {
        private static void Main(string[] args)
        {
            int width = 50;
            int height = 50;
            int scale = 10;

            IActionRunner runner = new OverAndOverAgainActionRunner();
            var model = new Model(0, width, 0, height, runner);

            var controller = new Controller(model);
            var consoleView = new ConsoleView(width, height);
            var winFormsView = new WinFormView(width, height, scale);

            model.Subscribe(consoleView);
            model.Subscribe(winFormsView);

            consoleView.SetController(controller);
            winFormsView.SetController(controller);

            Task.Factory.StartNew(() => consoleView.ReadArrow());
            Application.Run(winFormsView);
        }
    }
}
