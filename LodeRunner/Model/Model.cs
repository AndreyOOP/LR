﻿using LodeRunner.Model.ModelComponents;
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
