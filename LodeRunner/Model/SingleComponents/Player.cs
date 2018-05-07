using LodeRunner.Model.ModelComponents;
using LodeRunner.Animation;
using System.Drawing;

namespace LodeRunner.Model.SingleComponents
{
    public class Player : SingleComponentBase
    {
        public AnimationImage Animation { get; set; }
        private AnimationImage rightAnimation = new AnimationImage(new Bitmap(Const.PlayerRightAnimation), Const.BlockSize, 200);
        private AnimationImage leftAnimation = new AnimationImage(new Bitmap(Const.PlayerLeftAnimation), Const.BlockSize, 200);
        private Bitmap stand = new Bitmap(Const.PlayerStand);

        public void ActivatePlayerStand()
        {
            Animation = null;
        }

        public void ActivateLeftAnimation()
        {
            Animation = leftAnimation;
            Animation.Start();
        }

        public void ActivateRightAnimation()
        {
            Animation = rightAnimation;
            Animation.Start();
        }

        public override void Draw(Graphics g)
        {
            if(Animation == null)
            {
                g.DrawImage(stand, X, Y);
            }
            else
            {
                g.DrawImage(Animation.GetCurrentFrame(), X, Y);
            }
        }
    }
}
