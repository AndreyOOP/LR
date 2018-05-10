using LodeRunner.Model.ModelComponents;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace LodeRunner.Model.SingleComponents
{
    public class GameOver : SingleComponentBase
    {
        private Bitmap texture = Textures.GameOver;

        public GameOver(int x, int y) : base(x, y)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(texture, X, Y);
        }
    }
}
