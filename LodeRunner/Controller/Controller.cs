namespace LodeRunner.Control
{
    using LodeRunner.Model;
    using LodeRunner.Services;
    using LodeRunner.Services.Command;
    using LodeRunner.Services.Rules;
    using LodeRunner.Services.Rules.General;
    using System.Timers;
    using static LodeRunner.Model.Model;

    public class Controller
    {
        private char keyInput;
        private Command defaultActions;
        private Timer timer;
        private Commands commands = new Commands();

        public Model Model { private get; set; }
        public View View { get; private set; }
        
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
            keyInput = key;
            commands.SetUserInput(key);
        }

        public void GameStateUpdate(object sender, ElapsedEventArgs e)
        {
            //is next level

            //is level reload

            //is Game over

            //is pause

            //proceed active user command

            //proceed default action

            //update frame

            if(keyInput == 'n')
            {
                Model = new ModelLoadService().Load(@"C:\Users\Anik\Desktop\manualT.lev");
                Initialization();
                View.Invalidate();
                return;
            }

            if (Model.State == GameState.GameOver || keyInput == 'p')
            {
                return;
            }

            commands.GetActiveCommand().Execute();
            defaultActions.Execute();

            View.Invalidate();
        }

        private void Initialization()
        {
            defaultActions = new Command()
            {
                new InWaterRule(Model)
            };

            commands.Add('a', new Command()
            {
                new IsNotFallRule(Model),
                new IsAbleMoveLeftRule(Model),
                new MoveLeftRule(Model),
                new OnRailRuleLeft(Model),
            });
            commands.Add('d', new Command()
            {
                new IsNotFallRule(Model),
                new IsAbleMoveRightRule(Model),
                new MoveRightRule(Model),
                new OnRailRuleRight(Model),
            });
            commands.Add('w', new Command()
            {
                new IsNotFallRule(Model),
                new IsAbleMoveUp(Model),
                new MoveUpRule(Model)
            });
            commands.Add('s', new Command()
            {
                new IsNotFallRule(Model),
                new IsAbleMoveDownRule(Model),
                new MoveDownRule(Model),
            });
            commands.Add(' ', new Command()
            {
                new IsNotFallRule(Model),
                new NoInputRule(Model),
                new OnRailRule(Model)
            });
            commands.Add('q', new Command(false)
            {
                new BurnRule(Model)
            });

            keyInput = 'p';
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
