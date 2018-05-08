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
            var service = new ModelLoadService();
            var model = service.Load(@"C:\Users\Anik\Desktop\manualT.lev");

            var view = new View();

            var controller = new Controller(model, view);

            view.controller = controller;

            Application.Run(view);
        }
    }
}
