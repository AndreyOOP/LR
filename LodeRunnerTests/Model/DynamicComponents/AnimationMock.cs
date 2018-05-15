namespace LodeRunnerTests.Model.DynamicComponents
{
    using System.Drawing;
    using LodeRunner;
    using LodeRunner.Animation;
    using LodeRunner.Model.Interfaces;
    using LodeRunner.Services.Timer;
    using LodeRunnerTests.Animation;

    public enum AnimationMockState
    {
        Started, Paused, Continued, ReturnFrame
    }

    public class AnimationMock : Animation//, IAnimation, IPause
    {
        public AnimationMock(string animationImagePath, int frameLength, ITimer myTimer) : base(animationImagePath, frameLength, myTimer)
        {
        }

        //public AnimationMock() : base(Const.StoneTexture, 1, new TimerMock())
        //{
        //}

        public AnimationMockState InnerState { get; set; }

        public new void Start()
        {
            InnerState = AnimationMockState.Started;
        }

        public new void Pause()
        {
            InnerState = AnimationMockState.Paused;
        }

        public new void Continue()
        {
            InnerState = AnimationMockState.Continued;
        }

        public new Bitmap GetCurrentFrame()
        {
            InnerState = AnimationMockState.ReturnFrame;
            return new Bitmap(1, 1);
        }
    }
}
