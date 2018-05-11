using LodeRunner.Animation;
using System.Drawing;

namespace LodeRunner.Model.Interfaces
{
    public interface IPlayer
    {
        void SetAnimation(AnimationImage animation);

        void SetImage(Bitmap image);
    }
}
