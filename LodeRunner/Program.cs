using LodeRunner.Control;
using LodeRunner.Model.SingleComponents;
using LodeRunner.Services;
using System;
using System.Windows.Forms;

namespace LodeRunner
{
    public static class Program
    {
        public static void Main()
        {
            var modelSer = new ModelLoadService();
            var model = modelSer.Load(@"C:\Users\Anik\Desktop\test.lev");
            model.Add(Model.ComponentType.Player, new Player());

            var view = new View();

            var controller = new Controller(model, view);

            view.controller = controller;

            Application.Run(view);
        }
    }
}
