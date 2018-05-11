using System;
using System.Drawing;

namespace LodeRunner.Model.ModelComponents
{
    [Serializable]
    public abstract class SingleComponentBase : IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int BlockX
        {
            get
            {
                return X / Const.BlockSize;
            }
        }

        public int BlockY
        {
            get
            {
                return Y / Const.BlockSize;
            }
        }

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
