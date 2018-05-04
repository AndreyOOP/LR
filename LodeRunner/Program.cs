using LodeRunner.Control;
using LodeRunner.Services;
using System.Windows.Forms;

namespace LodeRunner
{
    public static class Program
    {
        public static void Main()
        {
            var modelSer = new ModelLoadService();
            var model = modelSer.Load("level 1");
            
            var controller = new Controller();
            controller.Model = model;

            var view = new View();
            view.Controller = controller;
            
            Application.Run(view);
        }
    }
}
