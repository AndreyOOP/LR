using System;
using System.Drawing;

namespace LodeRunner.Model.ModelComponents
{
    // should be used for elements like player, background, pause message, game over message
    [Serializable]
    public abstract class SingleComponentBase : IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract void Draw(Graphics g);
    }
}
