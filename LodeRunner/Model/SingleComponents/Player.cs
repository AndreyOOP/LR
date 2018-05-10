using LodeRunner.Model.ModelComponents;
using LodeRunner.Animation;
using System.Drawing;
using System;
using LodeRunner.Model.Interfaces;
using static LodeRunner.Services.Intersection;

namespace LodeRunner.Model.SingleComponents
{
    [Serializable]
    public class Player : SingleComponentBase, IPlayer
    {
        private AnimationImage animation;
        private Bitmap texture = new Bitmap(Const.PlayerStand);

        public Player(int x, int y) : base(x, y)
        {
        }

        public void SetAnimation(AnimationImage animation)
        {
            this.animation = animation;
            this.animation.Start();
        }

        public void SetImage(Bitmap image)
        {
            animation = null;
            texture = image;
        }

        public Direction GetDirection()
        {
            if(animation == Animations.Right)
            {
                return Direction.Right;
            }
            else if (animation == Animations.Left)
            {
                return Direction.Left;
            }

            return Direction.None;
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
    }
}
