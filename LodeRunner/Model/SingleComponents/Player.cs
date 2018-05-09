using LodeRunner.Model.ModelComponents;
using LodeRunner.Animation;
using System.Drawing;
using System;

namespace LodeRunner.Model.SingleComponents
{
    [Serializable]
    public class Player : SingleComponentBase
    {
        public AnimationImage Animation { get; set; }
        private Bitmap texture = new Bitmap(Const.PlayerStand);

        private AnimationImage fallAnimation = new AnimationImage(Const.PlayerFallAnimation, Const.BlockSize, 200);
        private AnimationImage upAnimation = new AnimationImage(Const.PlayerUpAnimation, Const.BlockSize, 200);
        private AnimationImage rightAnimation = new AnimationImage(Const.PlayerRightAnimation, Const.BlockSize, 200);
        private AnimationImage leftAnimation = new AnimationImage(Const.PlayerLeftAnimation, Const.BlockSize, 200);
        private AnimationImage railLeftAnimation = new AnimationImage(Const.PlayerRailLeftAnimation, Const.BlockSize, 200);
        private AnimationImage railRightAnimation = new AnimationImage(Const.PlayerRailRightAnimation, Const.BlockSize, 200);
        private Bitmap stand = new Bitmap(Const.PlayerStand);
        private Bitmap stairsDown = new Bitmap(Const.PlayerStairsDown);

        public int GetX(int right)
        {
            return (X / Const.BlockSize + right) * Const.BlockSize;
        }
        public int GetY(int bottom)
        {
            return (Y / Const.BlockSize + bottom) * Const.BlockSize;
        }

        public Player(int x, int y) : base(x, y)
        {
        }

        public void ActivatePlayerStand()
        {
            Animation = null;
            texture = stand;
        }

        public void ActivatePlayerFall()
        {
            Animation = fallAnimation;
            Animation.Start();
        }

        public void ActivatePlayerUp()
        {
            Animation = upAnimation;
            Animation.Start();
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

        public void ActivateRailLeftAnimation()
        {
            Animation = railLeftAnimation;
            Animation.Start();
        }

        public void ActivateRailRightAnimation()
        {
            Animation = railRightAnimation;
            Animation.Start();
        }

        public void ActivatePlayerStairs()
        {
            Animation = null;
            texture = stairsDown;
        }

        public override void Draw(Graphics g)
        {
            if(Animation == null)
            {
                g.DrawRectangle(Pens.Blue, new Rectangle(X, Y, Const.BlockSize-1, Const.BlockSize-1));
                g.DrawLine(Pens.Black, X, Y, X + 1, Y + 1); //temp
                g.DrawImage(texture, X, Y);
            }
            else
            {
                g.DrawRectangle(Pens.Blue, new Rectangle(X, Y, Const.BlockSize-1, Const.BlockSize-1));
                g.DrawLine(Pens.Black, X, Y, X + 1, Y + 1); //temp
                g.DrawImage(Animation.GetCurrentFrame(), X, Y);
            }
        }
    }
}
