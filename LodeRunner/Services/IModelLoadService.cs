namespace LodeRunner.Services
{
    using LodeRunner.Model;

    public interface IModelLoadService
    {
        Model Load(string path);

        void Save(string path, Model model);
    }
}
