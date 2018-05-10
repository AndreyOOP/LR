using LodeRunner.Animation;
using System.Drawing;
using static LodeRunner.Services.Intersection;

namespace LodeRunner.Model.Interfaces
{
    public interface IPlayer
    {
        void SetAnimation(AnimationImage animation);

        void SetImage(Bitmap image);
    }
}
