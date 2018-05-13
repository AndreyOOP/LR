using LodeRunner.Services.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LodeRunnerTests.Animation
{
    public class TimerMock : ITimer
    {
        public MockTimerState State;
        public ElapsedEventHandler handler;

        public enum MockTimerState { Start, Stop, Resumed}

        public TimerMock(int interval)
        {
            
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }

        public void SetEventHandler(ElapsedEventHandler handler)
        {
            this.handler = handler;
        }

        public void Start()
        {
            State = MockTimerState.Start;
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void NextFrame()
        {
            handler(null, null);
        }
    }
}
