using System;
using System.Collections.Generic;
using System.Drawing;

namespace LodeRunner.Model.ModelComponents
{
    //should be used for collection of elements like bricks, gold, water, guards etc
    [Serializable]
    public class ComponentsCollection<T> : IDrawable, IComponentsCollection<T> where T : SingleComponentBase
    {
        private List<T> list;

        public ComponentsCollection()
        {
            list = new List<T>();
        }

        public void Add(T component)
        {
            list.Add(component);
        }

        public List<T> GetAll()
        {
            return list;
        }

        public void Remove(T component)
        {
            list.Remove(component);
        }

        // todo it is possible to implement more fast search if add array[,] 
        public T Get(int x, int y)
        {
            foreach (var component in list)
            {
                if (component.X == x && component.Y == y)
                {
                    return component;
                }
            }

            return null;
        }

        public T GetBlock(int x, int y)
        {
            foreach (var component in list)
            {
                if (component.BlockX == x && component.BlockY == y)
                {
                    return component;
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
