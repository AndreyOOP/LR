﻿using LodeRunner.Animation;
using LodeRunner.Model.ModelComponents;
using System;
using System.Drawing;

namespace LodeRunner.Model
{
    [Serializable]
    public class Water : SingleComponentBase
    {
        public static AnimationImage Image { get; set; } 

        static Water()
        {
            Image = new AnimationImage(new Bitmap(Const.WaterTexture), 20, 200);
            Image.Start();
        }

        public Water(int x, int y) : base(x, y)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Image.GetCurrentFrame(), X, Y);
        }
    }
}
