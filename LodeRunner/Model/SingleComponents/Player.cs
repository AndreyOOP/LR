using LodeRunner.Model.ModelComponents;
using LodeRunner.Animation;
using System.Drawing;

namespace LodeRunner.Model.SingleComponents
{
    public class Player : SingleComponentBase
    {
        public AnimationImage Animation { get; set; }
        private AnimationImage RightAnimation = new AnimationImage(new Bitmap(Const.PlayerRightAnimation), Const.BlockSize, 200);
        private AnimationImage LeftAnimation = new AnimationImage(new Bitmap(Const.PlayerLeftAnimation), Const.BlockSize, 200);

        //todo add stay image
        public Player()
        {
            Animation = LeftAnimation;
        }

        public void ActivateLeftAnimation()
        {
            Animation = LeftAnimation;
            Animation.Start();
        }

        public void ActivateRightAnimation()
        {
            Animation = RightAnimation;
            Animation.Start();
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Animation.GetCurrentFrame(), X, Y);
        }
    }
}
