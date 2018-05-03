using System.Collections.Generic;

namespace LodeRunner.Model
{
    public interface IModel
    {
        void Add<T>(ComponentType type, T component) where T : IDrawable;

        void Remove(ComponentType type);

        IEnumerable<IDrawable> GetAll();

        T Get<T>(ComponentType type) where T : IDrawable;
    }
}