using System;
using System.Drawing;

namespace LodeRunner.Model.ModelComponents
{
    [Serializable]
    public abstract class SingleComponentBase : IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public SingleComponentBase()
        {
        }

        public SingleComponentBase(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract void Draw(Graphics g);
    }
}
