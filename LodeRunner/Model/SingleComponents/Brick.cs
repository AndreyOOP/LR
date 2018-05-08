using LodeRunner.Animation;
using LodeRunner.Model.ModelComponents;
using System;
using System.Drawing;

namespace LodeRunner.Model.SingleComponents
{
    [Serializable]
    public class Brick : SingleComponentBase
    {
        private AnimationImage animation;

        private static AnimationImage burn = new AnimationImage(Const.BrickBurnAnimation, Const.BlockSize, 200);
        private static AnimationImage grow = new AnimationImage(Const.BrickBurnAnimation, Const.BlockSize, 200);
        private static Bitmap brick = new Bitmap(Const.BrickTexture);

        public Brick(int x, int y) : base (x, y)
        {
        }

        public void ActivateBurnAnimation()
        {
            animation = burn;
            animation.Start();
        }

        public void ActivateGrowAnimation()
        {
            animation = grow;
            animation.Start();
        }

        public override void Draw(Graphics g)
        {
            if(animation != null)
            {
                g.DrawImage(animation.GetCurrentFrame(), X, Y);
            }
            else
            {
                g.DrawImage(brick, X, Y);
            }
        }
    }
}
