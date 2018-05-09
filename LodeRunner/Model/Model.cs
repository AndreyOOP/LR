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

        public Player Player { get; set; }

        private SortedDictionary<ComponentType, IDrawable> dictionary;

        public SingleComponentBase[,] field = new SingleComponentBase[Const.BlockWidth, Const.BlockHeigth];

        public Model()
        {
            dictionary = new SortedDictionary<ComponentType, IDrawable>();
        }

        public void Add<T>(T component) where T : SingleComponentBase
        {
            if(component.BlockX < 0)
            {
                throw new ArgumentException($"{nameof(component.BlockX)} could not be < 0. Now it is {component.BlockX}");
            }

            if (component.BlockX >= Const.BlockWidth)
            {
                throw new ArgumentException($"{nameof(component.BlockX)} could not be >= than maximum field width. It is {component.BlockX} vs {Const.BlockWidth}");
            }

            if (component.BlockY < 0)
            {
                throw new ArgumentException($"{nameof(component.BlockY)} could not be < 0. Now it is {component.BlockY}");
            }

            if (component.BlockY >= Const.BlockWidth)
            {
                throw new ArgumentException($"{nameof(component.BlockY)} could not be >= than maximum field width. It is {component.BlockY} vs {Const.BlockHeigth}");
            }

            if(component.GetType() == typeof(Player))
            {
                Player = (Player)((SingleComponentBase)component);
                return;
            }

            field[component.BlockX, component.BlockY] = component;
        }

        public void Remove(int blockX, int blockY, bool absolute = false)
        {
            if (absolute)
            {
                blockX /= Const.BlockSize;
                blockY /= Const.BlockSize;
            }

            if(Player?.BlockX == blockX && Player?.BlockY == blockY)
            {
                Player = null;
                return;
            }

            field[blockX, blockY] = null;
        }

        public SingleComponentBase Get(int blockX, int blockY, bool absolute = false)
        {
            if (absolute)
            {
                blockX /= Const.BlockSize;
                blockY /= Const.BlockSize;
            }

            return field[blockX, blockY];
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
            foreach(var component in field)
            {
                component?.Draw(g);
            }

            Player?.Draw(g);
            //foreach(var component in dictionary.Values)
            //{
            //    component.Draw(g);
            //}
        }
    }
}
