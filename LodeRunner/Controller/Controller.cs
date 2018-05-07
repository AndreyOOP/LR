namespace LodeRunner.Control
{
    using LodeRunner.Model;
    using LodeRunner.Services;
    using LodeRunner.Services.Command;
    using System.Timers;

    public class Controller
    {
        public Model Model { private get; set; }
        public View View { get; set; }

        private Timer timer;
        public Commands commands;

        public Controller(Model model, View view)
        {
            Model = model;
            View = view;
            Initialization();
        }

        public void SetKeyInput(char key)
        {
            commands.SetUserInput(key);
        }

        public void FrameUpdate(object sender, ElapsedEventArgs e)
        {
            commands.GetActiveCommand().Execute();
            View.Invalidate();
        }

        public Model GetModelForDraw()
        {
            return Model;
        }

        private void Initialization()
        {
            commands = new Commands();
            commands.Add('a', new CommandA(Model));
            commands.Add('d', new CommandD(Model));

            timer = new Timer();
            timer.Elapsed += FrameUpdate;
            timer.Interval = Const.FrameUpdatePeriod;
            timer.Enabled = true;
        }

        //public void EnableTimer()
        //{
        //    timer.Enabled = true;
        //}
    }
}
