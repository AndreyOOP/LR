using LodeRunner.Model.ModelComponents;
using LodeRunner.Model.SingleComponents;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace LodeRunner.Model
{
    [Serializable]
    public class Model : IModel, IDrawable
    {
        public bool IsPaused { get; set; }

        private SortedDictionary<ComponentType, IDrawable> dictionary;

        public Model()
        {
            dictionary = new SortedDictionary<ComponentType, IDrawable>();
        }

        public void Add<T>(ComponentType type, T component) where T : IDrawable
        {
            dictionary.Add(type, component);
        }

        public T Get<T>(ComponentType type) where T : IDrawable
        {
            return (T)dictionary[type];
        }

        // temp solution just to check if this method is more easy to use
        public ComponentsCollection<T> Get<T>() where T : SingleComponentBase
        {
            
            if(typeof(T) == typeof(Brick))
            {
                return (ComponentsCollection<T>)dictionary[ComponentType.Brick];
            }
            else if (typeof(T) == typeof(Gold))
            {
                return (ComponentsCollection<T>)dictionary[ComponentType.Gold];
            }
            else if (typeof(T) == typeof(Rail))
            {
                return (ComponentsCollection<T>)dictionary[ComponentType.Rail];
            }
            else if (typeof(T) == typeof(Stairs))
            {
                return (ComponentsCollection<T>)dictionary[ComponentType.Stairs];
            }
            else if (typeof(T) == typeof(Stone))
            {
                return (ComponentsCollection<T>)dictionary[ComponentType.Stone];
            }
            else if (typeof(T) == typeof(Water))
            {
                return (ComponentsCollection<T>)dictionary[ComponentType.Water];
            }

            return null;
        }

        public IEnumerable<IDrawable> GetAll()
        {
            return dictionary.Values;
        }

        public void Remove(ComponentType type)
        {
            dictionary.Remove(type);
        }

        public void Draw(Graphics g)
        {
            foreach(var component in dictionary.Values)
            {
                component.Draw(g);
            }
        }
    }
}
