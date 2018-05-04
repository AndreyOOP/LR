namespace LodeRunner.Control
{
    //using System.Windows.Forms;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services;
    using LodeRunner.Services.Command;
    using System.Timers;

    public class Controller
    {
        public Model Model { get; set; }
        public View View { get; set; }

        private Timer timer;

        private Commands commands;

        public Controller(Model model)
        {
            Model = model;

            commands = new Commands();
            commands.Add('a', new CommandA(Model));
            commands.Add('d', new CommandD(Model));

            timer = new Timer()
            {
                Enabled = true,
                Interval = 20
            };
            timer.Elapsed += FrameUpdate;
        }

        public void SetKeyInput(char key)
        {
            commands.SetUserInput(key);
        }

        public void FrameUpdate(object sender, ElapsedEventArgs e)
        {
            commands.GetActiveCommand().Execute();

            //View.Refresh();
        }



        public void OnKeyInput()
        {
            //if(GetKeyInput() == 'a')
            //{
            //    var player = Model.Get<Player>(ComponentType.Player);

            //    player.X += 5;
            //}
        }
    }
}
