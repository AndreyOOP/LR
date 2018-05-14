namespace LodeRunner.Model
{
    using LodeRunner.Animation;
    using LodeRunner.Model.Interfaces;
    using LodeRunner.Model.ModelComponents;
    using LodeRunner.Model.SingleComponents;
    using System;
    using System.Drawing;

    [Serializable]
    public class Water : StaticComponent, IPause
    {
        private static Animation animation { get; set; } 

        static Water()
        {
            animation = Animations.Water;
            //animation.Start();
        }

        public Water(int x, int y) : base(x, y)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(animation.GetCurrentFrame(), X, Y);
        }

        public void Pause()
        {
            animation.Pause();
        }

        public void Continue()
        {
            animation.Continue();
        }
    }
}
