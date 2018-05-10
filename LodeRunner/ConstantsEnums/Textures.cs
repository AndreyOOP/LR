﻿using System.Drawing;

namespace LodeRunner
{
    public class Textures
    {
        public static Bitmap Stand { get; }      = new Bitmap(Const.PlayerStand);
        public static Bitmap StairsDown { get; } = new Bitmap(Const.PlayerStairsDown);
        public static Bitmap Gold { get; }       = new Bitmap(@"Resources\Gold.png");
    }
}