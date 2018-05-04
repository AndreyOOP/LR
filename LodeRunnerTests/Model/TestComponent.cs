using LodeRunner.Model.ModelComponents;
using System.Drawing;

namespace LodeRunnerTests.Model
{
    public class TestComponent : SingleComponentBase
    {
        public string Label { get; set; }

        public TestComponent()
        {
        }

        public TestComponent(string label)
        {
            Label = label;
        }

        public override void Draw(Graphics g)
        {
        }
    }
}
