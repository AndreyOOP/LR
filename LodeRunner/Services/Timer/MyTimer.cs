namespace LodeRunner.Services.Timer
{
    using System;
    using System.Runtime.Serialization;
    // using System.Timers instead of System.Windows.Forms
    // Windows.Forms will work only if executed from the same thread - https://stackoverflow.com/questions/13412145/timer-wont-tick
    using System.Timers;
    
    [Serializable]
    public class MyTimer : ITimer
    {
        [NonSerialized]
        private Timer timer;
        private int interval;
        private ElapsedEventHandler handler;

        public MyTimer(int interval)
        {
            this.interval = interval;

            timer = new Timer();
            timer.Interval = interval;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Resume() // todo temporary solution to refactor
        {
            Start();
        }

        public void SetEventHandler(ElapsedEventHandler handler)
        {
            this.handler = handler;
            timer.Elapsed += handler;
        }

        [OnDeserialized]
        private void OnDeserialization(StreamingContext context)
        {
            timer = new Timer();
            timer.Interval = interval;
            timer.Elapsed += handler;
        }
    }
}
