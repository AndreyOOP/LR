namespace LodeRunner.Control
{
    using LodeRunner.Model;
    using LodeRunner.Services;
    using LodeRunner.Services.Command;
    using LodeRunner.Services.Rules;
    using LodeRunner.Services.Rules.General;
    using System.Collections.Generic;
    using System.Timers;
    using static LodeRunner.Model.Model;

    public class Controller
    {
        //private char keyInput;
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
            //keyInput = key;
            Commands.SetUserInput(key);
        }

        public void GameStateUpdate(object sender, ElapsedEventArgs e)
        {
            // **********
            //is next level

            //is level reload

            //is Game over

            //is pause

            //proceed active user command

            //proceed default action

            //update frame
            // **********

            //if(keyInput == 'n')
            //{
            //    Model = new ModelLoadService().Load(@"C:\Users\Anik\Desktop\manualT.lev");
            //    Initialization();
            //    View.Invalidate();
            //    return;
            //}

            //if (Model.State == GameState.GameOver || keyInput == 'p')
            //{
            //    return;
            //}

            Commands.ExecuteSelectedCommandAndDefault();

            View.Invalidate();
        }

        //receive to input controller only ?
        public void Initialization()
        {
            Commands.AllowedChars = Const.AllowedInput;// new HashSet<char>() { 'a', 'd', 'w', 's', 'q', ' ', 'n', 'p' };

            Commands.General = new Command()
            {
                new InWaterRule(Model, this)
            };

            Commands.Add('a', new Command()
            {
                new IsNotFallRule(Model),
                new IsAbleMoveLeftRule(Model),
                new MoveLeftRule(Model),
                new OnRailRuleLeft(Model),
            });
            Commands.Add('d', new Command()
            {
                new IsNotFallRule(Model),
                new IsAbleMoveRightRule(Model),
                new MoveRightRule(Model),
                new OnRailRuleRight(Model),
            });
            Commands.Add('w', new Command()
            {
                new IsNotFallRule(Model),
                new IsAbleMoveUp(Model),
                new MoveUpRule(Model)
            });
            Commands.Add('s', new Command()
            {
                new IsNotFallRule(Model),
                new IsAbleMoveDownRule(Model),
                new MoveDownRule(Model),
            });
            Commands.Add(' ', new Command()
            {
                new IsNotFallRule(Model),
                new NoInputRule(Model),
                new OnRailRule(Model)
            });
            Commands.Add('q', new Command(false)
            {
                new BurnRule(Model)
            });
            Commands.Add('n', new Command(false)
            {
                new NewGameRule(Model, this)
            });
            Commands.Add('p', new Command(false)
            {
                new PauseRule(Model, this)
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
