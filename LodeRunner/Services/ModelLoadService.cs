namespace LodeRunner.Services
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;

    // todo add interface for the service
    public class ModelLoadService : IModelLoadService
    {
        public Model Load(string path)
        {
            var m = new Model();

            m.Add(ComponentType.Player, new Player());

            return m;

            //m.Add(ComponentType.Background, new Background());
            //m.Add(ComponentType.Background, new Player());
            //m.Add(ComponentType.Brick, new ComponentCollection<Brick>());

            //throw new NotImplementedException();
        }

        public void Save(string path, Model model)
        {
            //serialize model 
            throw new System.NotImplementedException();
        }
    }
}
