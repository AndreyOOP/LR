using LodeRunner.Animation;
using LodeRunner.Model.Interfaces;
using LodeRunner.Model.ModelComponents;
using System;
using System.Drawing;
using System.Timers;

namespace LodeRunner.Model.SingleComponents
{
    [Serializable]
    public class Brick : SingleComponentBase, IFreeze
    {
        public bool IsTransparent { get; set; } = false;
        private AnimationImage animation { get; set; }
        private AnimationImage burn = new AnimationImage(Const.BrickBurnAnimation, Const.BlockSize, 200);
        private AnimationImage grow = new AnimationImage(Const.BrickGrowAnimation, Const.BlockSize, 200);
        private static Bitmap brick = Textures.Brick;

        [NonSerialized]
        private Timer timer;

        public Brick(int x, int y) : base (x, y)
        {
            
        }

        public void Burn()
        {
            if (!IsTransparent)
            {
                IsTransparent = true;
                InitializeTimer();
                timer.Enabled = true;
                burn.Reset();
                animation = burn;
                animation.Start();
            }
        }

        private void Grow(object sender, ElapsedEventArgs e)
        {
            IsTransparent = false;
            grow.Reset();
            animation = grow;
            animation.Start();
            timer.Enabled = false;
        }

        public override void Draw(Graphics g)
        {
            if ((animation == null || animation.Finished) && !IsTransparent)
            {
                g.DrawImage(brick, X, Y);
            }

            if (animation != null && !animation.Finished)
            {
                g.DrawImage(animation.GetCurrentFrame(), X, Y);
            }
        }

        private void InitializeTimer()
        {
            if(timer == null)
            {
                timer = new Timer();
                timer.Interval = Const.BrickGrowPeriod;
                timer.Elapsed += Grow;

                burn = new AnimationImage(Const.BrickBurnAnimation, Const.BlockSize, 200);
                grow = new AnimationImage(Const.BrickGrowAnimation, Const.BlockSize, 200);
            }
        }

        public void Freeze()
        {
            animation?.Freeze();
            timer?.Stop();
        }

        public void Unfreeze()
        {
            animation?.Unfreeze();
            timer?.Start();
        }
    }
}
