using System;
using System.Drawing;

namespace LodeRunner.Model.ModelComponents
{
    [Serializable]
    public abstract class StaticComponent : IDrawable
    {
        private Bitmap texture;

        public StaticComponent(int x = 0, int y = 0, Bitmap texture = null)
        {
            X = x;
            Y = y;
            this.texture = texture;
        }

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

        public abstract void Draw(Graphics g);
    }
}
