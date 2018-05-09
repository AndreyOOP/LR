namespace LodeRunner.Control
{
    using LodeRunner.Model;
    using LodeRunner.Services;
    using LodeRunner.Services.Command;
    using LodeRunner.Services.Rules;
    using System.Timers;

    public class Controller
    {
        public Model Model { private get; set; }
        public View View { get; private set; }

        private Timer timer;
        public Commands commands = new Commands();

        public Controller(Model model, View view)
        {
            Model = model;
            View = view;
            Initialization();
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

        public void SetKeyInput(char key)
        {
            commands.SetUserInput(key);
        }

        private void Initialization()
        {
            commands.Add('0', new Command()
            {
                new IsFallRule(Model),
                new NoInputRule(Model)
            });
            commands.Add('a', new Command()
            {
                new IsFallRule(Model),
                new IsPossibleMoveLeftRule(Model),
                new MoveLeftRule(Model)
            });
            commands.Add('d', new Command()
            {
                new IsFallRule(Model),
                new IsPossibleMoveRightRule(Model),
                new MoveRightRule(Model)
            });
            commands.Add('w', new Command()
            {
                new IsFallRule(Model),
                // todo add isPossibleMoveUpRule    
                new MoveUpRule(Model)
            });

            timer = new Timer();
            timer.Elapsed += FrameUpdate;
            timer.Interval = Const.FrameUpdatePeriod;
            timer.Enabled = true;
        }
    }
}
