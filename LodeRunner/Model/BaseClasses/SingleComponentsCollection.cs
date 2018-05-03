using System;
using System.Collections.Generic;
using System.Drawing;

namespace LodeRunner.Model.ModelComponents
{
    //should be used for collection of elements like bricks, gold, water, guards etc
    public class SingleComponentsCollection : IDrawable, IMultipleComponent
    {
        public void Add<T>(T component) where T : IDrawable
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDrawable> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(IDrawable component)
        {
            throw new NotImplementedException();
        }

        public void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
