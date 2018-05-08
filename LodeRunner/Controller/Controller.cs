namespace LodeRunner.Control
{
    using LodeRunner.Model;
    using LodeRunner.Services;
    using LodeRunner.Services.Command;
    using System.Timers;

    public class Controller
    {
        public Model Model { private get; set; }
        public View View { get; private set; }

        private Timer timer;
        public Commands commands;

        public Controller(Model model, View view)
        {
            Model = model;
            View = view;
            Initialization();
        }

        public void FrameUpdate(object sender, ElapsedEventArgs e)
        {
            //execute default rules like fall, guards update
            

            commands.GetActiveCommand().Execute(); //or some checks have to be done in the command?
            //execute rules related to command - get treasure, wall, is possible to go up on stairs

            View.Invalidate();
        }

        public Model GetModelForDraw()
        {
            return Model;
        }

        public void SetKeyInput(char key)
        {
            commands.SetUserInput(key);
        }

        private void Initialization()
        {
            commands = new Commands(Model);
            commands.Add('a', new CommandA(Model));
            commands.Add('d', new CommandD(Model));
            commands.Add('w', new CommandW(Model));

            timer = new Timer();
            timer.Elapsed += FrameUpdate;
            timer.Interval = Const.FrameUpdatePeriod;
            timer.Enabled = true;
        }
    }
}
