using LodeRunner.Model.ModelComponents;

namespace LodeRunner.Model
{
    public interface IModel
    {
        StaticComponent Get(int blockX, int blockY, bool absolute = false);

        void Remove(int blockX, int blockY, bool absolute = false);
    }
}