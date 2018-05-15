using System.Drawing;

namespace LodeRunner.Animation
{
    public interface IAnimation
    {
        void Start();

        Bitmap GetCurrentFrame();
    }
}
