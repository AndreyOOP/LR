using System.Collections.Generic;

namespace LodeRunner.Model
{
    public interface IModel<T>
    {
        void Add(ComponentType type, T component);

        void Remove(ComponentType type);

        IEnumerable<T> GetAll();

        T Get(ComponentType type);
    }
}