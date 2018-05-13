using LodeRunner.Animation;
using LodeRunner.Model.Interfaces;
using LodeRunner.Model.ModelComponents;
using LodeRunner.Model.SingleComponents;
using System;
using System.Drawing;

namespace LodeRunner.Model
{
    [Serializable]
    public class Water : SingleComponentBase, IPause
    {
        private static AnimationImage animation { get; set; } 

        static Water()
        {
            animation = Animations.Water;
            animation.Start();
        }

        public Water(int x, int y) : base(x, y)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(animation.GetCurrentFrame(), X, Y);
        }

        public void Freeze()
        {
            animation.Freeze();
        }

        public void Unfreeze()
        {
            animation.Unfreeze();
        }
    }
}
