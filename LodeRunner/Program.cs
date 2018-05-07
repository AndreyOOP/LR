using LodeRunner.Control;
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
            var model = modelSer.Load("level 1");

            var view = new View();

            var controller = new Controller(model, view);

            view.controller = controller;

            Application.Run(view);
        }
    }
}
