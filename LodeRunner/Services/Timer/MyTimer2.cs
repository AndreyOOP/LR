namespace LodeRunner.Services.Timer
{
    using System;
    using System.Runtime.Serialization;
    // using System.Timers instead of System.Windows.Forms
    // Windows.Forms will work only if executed from the same thread - https://stackoverflow.com/questions/13412145/timer-wont-tick
    using System.Timers;
    
    [Serializable]
    public class MyTimer2 : ITimer
    {
        [NonSerialized]
        private Timer innerTimer;

        private int interval;
        private int timeTicks;

        private ElapsedEventHandler handler;

        public MyTimer2(int interval)
        {
            this.interval = interval;

            innerTimer = new Timer();
            innerTimer.Interval = 1;
            innerTimer.Start();
            innerTimer.Elapsed += InnerHandler;

        }

        private void InnerHandler(object sender, ElapsedEventArgs e)
        {
            if (timeTicks++ > interval)
            {
                timeTicks = 0;
                handler?.Invoke(this, e);
            }
        }

        public void Start()
        {
            timeTicks = 0;
            innerTimer.Start();
        }

        public void Stop()
        {
            innerTimer.Stop();
        }

        public void Resume()
        {
            innerTimer.Start();
        }

        public void SetEventHandler(ElapsedEventHandler handler)
        {
            this.handler = handler;
        }

        [OnDeserialized]
        private void OnDeserialization(StreamingContext context)
        {
            innerTimer = new Timer();
            innerTimer.Interval = 1;
            innerTimer.Start();
            innerTimer.Elapsed += InnerHandler;
        }
    }
}
