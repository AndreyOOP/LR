namespace LodeRunnerTests.Animation
{
    using System.Timers;
    using LodeRunner.Services.Timer;

    public class TimerMock : ITimer
    {
        public TimerMock()
        {
            State = MockTimerState.Stop;
        }

        public enum MockTimerState
        {
            Start, Stop, Resumed
        }

        public MockTimerState State { get; set; }

        public ElapsedEventHandler Handler { get; set; }

        public void Resume()
        {
            State = MockTimerState.Resumed;
        }

        public void SetEventHandler(ElapsedEventHandler handler)
        {
            Handler = handler;
        }

        public void Start()
        {
            State = MockTimerState.Start;
        }

        public void Stop()
        {
            State = MockTimerState.Stop;
        }

        public void NextTick()
        {
            Handler(null, null);
        }
    }
}
