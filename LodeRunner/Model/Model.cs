using System.Collections.Generic;
using System.Drawing;

namespace LodeRunner.Model
{
    public class Model<T> : IModel<T>, IDrawable where T : IDrawable
    {
        private SortedDictionary<ComponentType, T> sorted;

        public Model()
        {
            sorted = new SortedDictionary<ComponentType, T>();
        }

        public void Add(ComponentType type, T component)
        {
            sorted.Add(type, component);
        }

        public T Get(ComponentType type)
        {
            return sorted[type];
        }

        public IEnumerable<T> GetAll()
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
