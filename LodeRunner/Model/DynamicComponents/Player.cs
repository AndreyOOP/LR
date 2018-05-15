namespace LodeRunner.Model.SingleComponents
{
    using System.Drawing;
    using System;
    using LodeRunner.Model.DynamicComponents;

    [Serializable]
    public class Player : DynamicComponent<PlayerState>
    {
        public Player(int x, int y) : base(x, y)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Blue, new Rectangle(X, Y, Const.BlockSize - 1, Const.BlockSize - 1));
            g.DrawLine(Pens.Red, X, Y, X + 1, Y + 1);

            base.Draw(g);
        }
    }
}
