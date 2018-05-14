namespace LodeRunner.Services.Timer
{
    using System;
    using System.Diagnostics;
    using System.Runtime.Serialization;
    // using System.Timers instead of System.Windows.Forms
    // Windows.Forms will work only if executed from the same thread - https://stackoverflow.com/questions/13412145/timer-wont-tick
    using System.Timers;
    
    [Serializable]
    public class MyTimer : ITimer
    {
        [NonSerialized]
        private Timer timer;

        [NonSerialized]
        private Stopwatch stopwatch;

        private int interval;
        private int resumeInt;
        private ElapsedEventHandler handler;
        

        public MyTimer(int interval)
        {
            this.interval = interval;
            Initialize();
        }

        public void Start()
        {
            timer.Interval = interval;
            timer.Start();
            stopwatch.Restart();
            resumeInt = 0;
        }

        public void Stop()
        {
            timer.Stop();
            stopwatch.Stop();
            resumeInt = interval - (int)stopwatch.ElapsedMilliseconds % interval;
        }

        public void Resume()
        {
            timer.Interval = resumeInt;
            timer.Start();
        }

        public void SetEventHandler(ElapsedEventHandler handler)
        {
            this.handler = handler;
            timer.Elapsed += handler;
        }

        [OnDeserialized]
        private void OnDeserialization(StreamingContext context)
        {
            Initialize();
        }

        private void Initialize()
        {
            timer = new Timer();
            timer.Interval = interval;
            timer.Elapsed += handler;

            stopwatch = new Stopwatch();
        }
    }
}
