using System.Threading.Tasks;
using System.Windows.Forms;
using TeoVincent.ActiveMVC.Controllers;
using TeoVincent.ActiveMVC.Models;
using TeoVincent.ActiveMVC.Views;

namespace TeoVincent.ActiveMVC
{
    class Program
    {
        private static void Main(string[] args)
        {
            int width = 50;
            int height = 20;
            int scale = 10;

            var model = new Model(0, width, 0, height);
            var controller = new Controller(model);
            var consoleView = new ConsoleView(width, height);
            var winFormsView = new WinFormView(width, height, scale);

            model.Subscribe(consoleView);
            model.Subscribe(winFormsView);

            consoleView.SetController(controller);
            winFormsView.SetController(controller);

            Task.Factory.StartNew(() => consoleView.Navigate());
            Application.Run(winFormsView);
        }
    }
}
