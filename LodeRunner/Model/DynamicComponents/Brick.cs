using LodeRunner.Model.DynamicComponents;
using LodeRunner.Services.Timer;
using System;
using System.Timers;

namespace LodeRunner.Model.SingleComponents
{
    [Serializable]
    public class Brick : DynamicComponent<BrickState>
    {
        private ITimer timer;

        public Brick(int x, int y, ITimer timer) : base (x, y)
        {
            this.timer = timer;
            timer.SetEventHandler(Grow);
        }

        public Brick(int x, int y) : base (x, y)
        {
            State = BrickState.Visible;
        }

        public void Burn()
        {
            State = BrickState.Burn;
        }

        public void OnBurnAnimationFinished(object sender, EventArgs e)
        {
            State = BrickState.NotVisible;
            timer.Start();
        }

        public void Grow(object sender, ElapsedEventArgs e)
        {
            State = BrickState.Grow;
            timer.Stop();
        }

        public void OnGrowAnimationFinished(object sender, EventArgs e)
        {
            State = BrickState.Visible;
        }

        public override void Pause()
        {
            timer.Stop();
            base.Pause();
        }

        public override void Continue()
        {
            if(State == BrickState.NotVisible)
            {
                timer.Resume();
            }
            
            base.Continue();
        }
    }
}
