using LodeRunner.Model.ModelComponents;
using System.Collections.Generic;

namespace LodeRunner.Model
{
    public interface IComponentsCollection<T>
    {
        void Add(T component);

        void Remove(T component);

        List<T> GetAll();

        T Get(int x, int y);
    }
}
