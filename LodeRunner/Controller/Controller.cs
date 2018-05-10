﻿namespace LodeRunner.Control
{
    using LodeRunner.Model;
    using LodeRunner.Services;
    using LodeRunner.Services.Command;
    using LodeRunner.Services.Rules;
    using LodeRunner.Services.Rules.General;
    using System.Timers;

    public class Controller
    {
        public Model Model { private get; set; }
        public View View { get; private set; }

        private Timer timer;
        public Commands commands = new Commands();

        private Command defaultActions;

        public Controller(Model model, View view)
        {
            Model = model;
            View = view;
            Initialization();
        }

        public void FrameUpdate(object sender, ElapsedEventArgs e)
        {
            commands.GetActiveCommand().Execute();

            defaultActions.Execute();

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
            defaultActions = new Command()
            {
                new InWaterRule(Model)
            };

            commands.Add('0', new Command()
            {
                new IsNotFallRule(Model),
                new NoInputRule(Model),
                new OnRailRule(Model)
                
            });
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

            timer = new Timer();
            timer.Elapsed += FrameUpdate;
            timer.Interval = Const.FrameUpdatePeriod;
            timer.Enabled = true;
        }
    }
}
