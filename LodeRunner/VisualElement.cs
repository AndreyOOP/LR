using System.Drawing;

namespace LodeRunner
{
    public abstract class VisualElement : IDrawable
    {
        public Point Position { get; set; }

        public abstract void Draw(Graphics g);
    }
}
