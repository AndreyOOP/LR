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
        [NonSerialized]
        private Timer timer;
        private AnimationImage animation { get; set; }
        private AnimationImage burn;
        private AnimationImage grow;
        private static Bitmap brick = Textures.Brick;

        public bool IsVisible = true;

        public bool IsTransparent { get; set; } = false;

        public Brick(int x, int y) : base (x, y)
        {
            burn = new AnimationImage(Const.BrickBurnAnimation, Const.BlockSize, 200);
            grow = new AnimationImage(Const.BrickGrowAnimation, Const.BlockSize, 200);

            grow.AnimationComplete += OnGrowAnimationFinished;
        }

        private void OnGrowAnimationFinished(object sender, EventArgs e)
        {
            IsVisible = true;
            burn.Freeze();
            grow.Freeze();
        }

        public void Burn()
        {
            IsTransparent = true;
            IsVisible = false;
            TimerStart();
            SetAnimation(burn);
        }

        private void Grow(object sender, ElapsedEventArgs e)
        {
            IsTransparent = false;
            SetAnimation(grow);
            //timer.Stop();
            
        }

        private void SetAnimation(AnimationImage animation)
        {
            this.animation = animation;
            this.animation.Reset();
            this.animation.Start();
        }

        public override void Draw(Graphics g)
        {
            if(IsVisible)
            {
                g.DrawImage(brick, X, Y);
            }
            else
            {
                if(!animation.Finished) //add to animation image...
                    g.DrawImage(animation.GetCurrentFrame(), X, Y);
            }
        }

        private void TimerStart()
        {
            if(timer == null)
            {
                timer = new Timer();
                timer.Interval = Const.BrickGrowPeriod;
                timer.Elapsed += Grow;
                timer.AutoReset = false;
            }

            timer.Start();
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
