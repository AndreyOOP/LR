namespace LodeRunner.Control
{
    using LodeRunner.Model;
    using LodeRunner.Services;
    using LodeRunner.Services.Command;
    using LodeRunner.Services.Rules;
    using LodeRunner.Services.Rules.General;
    using System.Timers;

    public class Controller
    {
        private Timer timer;
        public Commands Commands { get; set; } = new Commands();

        public Model Model { get; set; }
        public View View { get; set; }
        
        public Controller(Model model, View view)
        {
            Model = model;
            View = view;
            Initialization();
            InitializeTimer();
        }

        public Model GetModelForDraw()
        {
            return Model;
        }

        public void SetKeyInput(char key)
        {
            Commands.SetUserInput(key);
        }

        public void GameStateUpdate(object sender, ElapsedEventArgs e)
        {
            Commands.ExecuteSelectedCommandAndDefault();

            View.Invalidate();
        }

        public void Initialization()
        {
            Commands.AllowedChars = Const.AllowedInput;

            Commands.General = new Command()
            {
                new GoldRule(this),
                new InWaterRule(this),
                new WinRule(this)
            };

            Commands.Add('a', new Command()
            {
                new IsNotFallRule(this),
                new IsAbleMoveLeftRule(this),
                new MoveLeftRule(this),
                new OnRailRuleLeft(this),
            });
            Commands.Add('d', new Command()
            {
                new IsNotFallRule(this),
                new IsAbleMoveRightRule(this),
                new MoveRightRule(this),
                new OnRailRuleRight(this),
            });
            Commands.Add('w', new Command()
            {
                new IsNotFallRule(this),
                new IsAbleMoveUp(this),
                new MoveUpRule(this)
            });
            Commands.Add('s', new Command()
            {
                new IsNotFallRule(this),
                new IsAbleMoveDownRule(this),
                new MoveDownRule(this),
            });
            Commands.Add(' ', new Command()
            {
                new IsNotFallRule(this),
                new NoInputRule(this),
                new OnRailRule(this)
            });
            Commands.Add('q', new Command(false)
            {
                new IsNotFallRule(this),
                new LeftBurnRule(this)
            });
            Commands.Add('e', new Command(false)
            {
                new IsNotFallRule(this),
                new RightBurnRule(this)
            });
            Commands.Add('n', new Command(false)
            {
                new NewGameRule(this)
            });
            Commands.Add('p', new Command(false)
            {
                new PauseRule(this)
            });

            Commands.SetUserInput('0');
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Elapsed += GameStateUpdate;
            timer.Interval = Const.FrameUpdatePeriod;
            timer.Enabled = true;
        }
    }
}
