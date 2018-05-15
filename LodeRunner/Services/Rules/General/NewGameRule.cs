namespace LodeRunner.Services.Rules.General
{
    using LodeRunner.Control;

    public class NewGameRule : RuleBase
    {
        public NewGameRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            controller.Model = new ModelLoadService().Load(@"C:\Users\Anik\Desktop\manualT.lev");
            controller.Initialization();
            controller.Model.InitializeStartState();
            return false;
        }
    }
}
