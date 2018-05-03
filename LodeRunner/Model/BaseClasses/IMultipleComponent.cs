using System.Collections.Generic;

namespace LodeRunner.Model
{
    public interface IMultipleComponent
    {
        void Add<T>(T component) where T : IDrawable;

        void Remove(IDrawable component);

        IEnumerable<IDrawable> GetAll();

        //todo get by criteria
    }
}
