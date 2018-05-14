namespace LodeRunner.Model.SingleComponents
{
    using LodeRunner.Model.ModelComponents;
    using LodeRunner.Animation;
    using System.Drawing;
    using System;
    using LodeRunner.Model.Interfaces;
    using static LodeRunner.Services.Intersection;

    [Serializable]
    public class Player : StaticComponent, IPlayer, IPause
    {
        public Direction Direction { get; set; }
        private Animation animation { get; set; }
        private Bitmap texture = new Bitmap(Const.PlayerStand);

        public Player(int x, int y) : base(x, y)
        {
        }

        public void SetAnimation(Animation animation)
        {
            if(this.animation != animation)
            {
                this.animation = animation;
                this.animation.Start();
            }
        }

        public void SetImage(Bitmap image)
        {
            animation = null;
            texture = image;
        }

        public override void Draw(Graphics g)
        {
            if(animation == null)
            {
                g.DrawRectangle(Pens.Blue, new Rectangle(X, Y, Const.BlockSize-1, Const.BlockSize-1));
                g.DrawLine(Pens.Red, X, Y, X + 1, Y + 1);
                g.DrawImage(texture, X, Y);
            }
            else
            {
                g.DrawRectangle(Pens.Blue, new Rectangle(X, Y, Const.BlockSize-1, Const.BlockSize-1));
                g.DrawLine(Pens.Red, X, Y, X + 1, Y + 1);
                g.DrawImage(animation.GetCurrentFrame(), X, Y);
            }
        }

        public void Pause()
        {
            animation?.Pause();
        }

        public void Continue()
        {
            animation?.Start();
        }
    }
}
