using LodeRunner.Animation;
using System.Drawing;

namespace LodeRunner.Model.Interfaces
{
    public interface IPlayer
    {
        void SetAnimation(Animation.Animation animation);

        void SetImage(Bitmap image);
    }
}
