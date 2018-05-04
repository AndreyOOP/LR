namespace LodeRunner.Services
{
    using LodeRunner.Model;

    public interface IModelLoadService
    {
        Model Load(string path);
    }
}
