﻿namespace LodeRunner.Model.SingleComponents
{
    using System;
    using System.Drawing;
    using LodeRunner.Model.ModelComponents;

    [Serializable]
    public class Gold : StaticComponent
    {
        public Gold(int x, int y, Bitmap texture) : base(x, y, texture)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(texture, X, Y);
        }
    }
}
