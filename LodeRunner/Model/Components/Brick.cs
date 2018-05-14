using LodeRunner.Animation;
using LodeRunner.Model.Interfaces;
using LodeRunner.Model.ModelComponents;
using LodeRunner.Services.Timer;
using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Timers;

namespace LodeRunner.Model.SingleComponents
{
    [Serializable]
    public class Brick : SingleComponentBase, IPause
    {
        private ITimer timer;
        private Animation.Animation burn;
        private Animation.Animation grow;
        private static Bitmap brick = Textures.Brick;

        public BrickState state { get; set; }

        public Brick(int x, int y, ITimer timer) : this (x, y)
        {
            this.timer = timer;
            timer.SetEventHandler(Grow);
        }

        //todo animation have to be passed outside
        public Brick(int x, int y) : base (x, y)
        {
            burn = new Animation.Animation(Const.BrickBurnAnimation, Const.BlockSize, new MyTimer(200));
            grow = new Animation.Animation(Const.BrickGrowAnimation, Const.BlockSize, new MyTimer(200));

            burn.AnimationComplete += OnBurnAnimationFinished;
            grow.AnimationComplete += OnGrowAnimationFinished;

            state = BrickState.Visible;
        }

        public void Burn()
        {
            state = BrickState.Burn;
            burn.Start();
        }

        private void OnBurnAnimationFinished(object sender, EventArgs e)
        {
            state = BrickState.NotVisible;
            burn.Pause();
            timer.Start();
        }

        private void Grow(object sender, ElapsedEventArgs e)
        {
            state = BrickState.Grow;
            grow.Start();
            timer.Stop();
        }

        private void OnGrowAnimationFinished(object sender, EventArgs e)
        {
            state = BrickState.Visible;
            grow.Pause();
        }

        public override void Draw(Graphics g)
        {
            switch (state)
            {
                case BrickState.Burn:
                    g.DrawImage(burn.GetCurrentFrame(), X, Y);
                    break;

                case BrickState.NotVisible:
                    break;

                case BrickState.Grow:
                    g.DrawImage(grow.GetCurrentFrame(), X, Y);
                    break;

                case BrickState.Visible:
                    g.DrawImage(brick, X, Y);
                    break;
            }
        }

        public void Pause() //in fact paused & started have to be only one item...
        {
            burn.Pause();
            grow.Pause();
            timer.Stop();
        }

        public void Continue() //!!!
        {
            switch (state)
            {
                case BrickState.Burn: burn.Continue(); break;
                case BrickState.Grow: grow.Continue(); break;
                case BrickState.NotVisible: timer.Resume(); break;
            }
        }

        [OnDeserialized]
        private void OnDeserialization(StreamingContext context)
        {
            burn = new Animation.Animation(Const.BrickBurnAnimation, Const.BlockSize, new MyTimer(200));
            grow = new Animation.Animation(Const.BrickGrowAnimation, Const.BlockSize, new MyTimer(200));

            burn.AnimationComplete += OnBurnAnimationFinished;
            grow.AnimationComplete += OnGrowAnimationFinished;

            state = BrickState.Visible;
        }
    }
}
