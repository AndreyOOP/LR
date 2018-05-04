using LodeRunner.Control;
using LodeRunner.Services;
using System;
using System.Windows.Forms;

namespace LodeRunner
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var modelSer = new ModelLoadService();
            var model = modelSer.Load("level 1");
            
            var controller = new Controller(model);
            controller.Model = model;

            var view = new View(controller);

            controller.View = view;
            
            Application.Run(view);
        }
    }
}
