namespace LodeRunnerTests.TestModels
{
    using LodeRunner.Model;
    using LodeRunner.Model.ModelComponents;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services;

    public class TestModelFactory
    {
        public Player Player { get; set; }
        public Model Model { get; set; }

        public void SetFallRuleTestModel()
        {
            var stairs = new ComponentsCollection<Stairs>();
            var bricks = new ComponentsCollection<Brick>();
            var stones = new ComponentsCollection<Stone>();
            bricks.Add(new Brick(40, 40));
            bricks.Add(new Brick(60, 40));

            Player = new Player(0, 20);

            Model = new Model();
            Model.Add(ComponentType.Brick, bricks);
            Model.Add(ComponentType.Player, Player);
            Model.Add(ComponentType.Stairs, stairs);
            Model.Add(ComponentType.Stone, stones);
        }

        public void SetFallRuleTestModel1()
        {
            ModelLoadService mls = new ModelLoadService();
            Model = mls.Load(@"TestModels\FallBetweenBricks.lev");
            Player = Model.Get<Player>(ComponentType.Player);
        }
    }
}
