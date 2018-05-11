namespace LodeRunner.Services.Rules.General
{
    using LodeRunner.Control;
    using LodeRunner.Model;

    public class NewGameRule : RuleBase
    {
        public NewGameRule(Model model, Controller controller) : base(model, controller)
        {
        }

        public override bool Check()
        {
            controller.Model = new ModelLoadService().Load(@"C:\Users\Anik\Desktop\manualT.lev");
            controller.Initialization();
            model.Unfreeze();
            return false;
        }
    }
}
