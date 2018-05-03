using System.Collections.Generic;
using System.Drawing;

namespace LodeRunner.Model
{
    public class Model : IModel, IDrawable
    {
        private SortedDictionary<ComponentType, IDrawable> sorted;

        public Model()
        {
            sorted = new SortedDictionary<ComponentType, IDrawable>();
        }

        public void Add<T>(ComponentType type, T component) where T : IDrawable
        {
            sorted.Add(type, component);
        }

        public T Get<T>(ComponentType type) where T : IDrawable
        {
            return (T)sorted[type];
        }

        public IEnumerable<IDrawable> GetAll()
        {
            return sorted.Values;
        }

        public void Remove(ComponentType type)
        {
            sorted.Remove(type);
        }

        public void Draw(Graphics g)
        {
            foreach(var component in sorted.Values)
            {
                component.Draw(g);
            }
        }
    }
}
