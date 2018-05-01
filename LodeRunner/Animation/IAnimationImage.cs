using System.Drawing;

namespace LodeRunner.Animation
{
    public interface IAnimationImage
    {
        void Start();

        void Stop();

        void Reset();

        Bitmap GetCurrentFrame();
    }
}
