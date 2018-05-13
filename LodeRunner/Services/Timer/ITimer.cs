using System.Timers;

namespace LodeRunner.Services.Timer
{
    public interface ITimer
    {
        void Start();

        void Stop();

        void Resume();

        void SetEventHandler(ElapsedEventHandler handler);
    }
}
