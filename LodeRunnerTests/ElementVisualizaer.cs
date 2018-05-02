using LodeRunner;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LodeRunnerTests.VisualTester
{
    public partial class ElementVisualizaer : Form
    {
        private List<IDrawable> elements;

        public ElementVisualizaer()
        {
            AutoScaleMode  = AutoScaleMode.Font;
            ClientSize     = new Size(450, 450);
            Text           = "Element Visualizaer";
            DoubleBuffered = true;
            elements       = new List<IDrawable>();
            Paint         += OnPaint;
        }

        public void Start()
        {
            Application.Run(this);
        }

        public void Add(IDrawable visualElement)
        {
            elements.Add(visualElement);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            foreach (var element in elements)
                element.Draw(e.Graphics);

            Invalidate();
        }
    }
}
