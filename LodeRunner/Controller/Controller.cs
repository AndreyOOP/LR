namespace LodeRunner.Control
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;

    public class Controller
    {
        public Model Model { get; set; }
        public View View { get; set; }

        public Controller()
        {
        }

        public char GetKeyInput()
        {
            return 'a';
        }

        public void OnKeyInput()
        {
            if(GetKeyInput() == 'a')
            {
                var player = Model.Get<Player>(ComponentType.Player);

                player.X += 5;
            }
        }
    }
}
