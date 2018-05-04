using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace LodeRunner.Model.ModelComponents
{
    //should be used for collection of elements like bricks, gold, water, guards etc
    public class ComponentsCollection : IDrawable, IComponentsCollection 
    {
        private List<SingleComponentBase> list;

        public ComponentsCollection()
        {
            list = new List<SingleComponentBase>();
        }

        public void Add(SingleComponentBase component)
        {
            list.Add(component);
        }

        public List<T> GetAll<T>() where T : SingleComponentBase
        {
            return list.Cast<T>().ToList();
        }

        public void Remove(SingleComponentBase component)
        {
            list.Remove(component);
        }

        public T Get<T>(int x, int y) where T : SingleComponentBase
        {
            foreach (var component in list)
            {
                if (component.X == x && component.Y == y)
                {
                    return (T)component;
                }
            }

            return null;
        }

        public void Draw(Graphics g)
        {
            foreach(var component in list)
            {
                component.Draw(g);
            }
        }
    }
}
