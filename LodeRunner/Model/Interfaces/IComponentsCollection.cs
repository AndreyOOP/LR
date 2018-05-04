using LodeRunner.Model.ModelComponents;
using System.Collections.Generic;

namespace LodeRunner.Model
{
    public interface IComponentsCollection
    {
        void Add(SingleComponentBase component);

        void Remove(SingleComponentBase component);

        List<T> GetAll<T>() where T : SingleComponentBase;

        T Get<T>(int x, int y) where T : SingleComponentBase;
    }
}
