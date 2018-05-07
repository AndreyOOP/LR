using LodeRunner.Control;
using System.Drawing;
using System.Windows.Forms;

namespace LodeRunner
{
    public partial class View : Form
    {
        public Controller controller { get; set; }

        public View()
        {
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(Const.WindowXSize, Const.WindowYSize);
            Text = Const.WindowName;
            DoubleBuffered = true;

            //communication with controller
            KeyPress += OnKeyPress;
            Paint += OnPaint;
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            controller.SetKeyInput(e.KeyChar);
        }

        //Refresh();
        //or
        //Invalidate();
        //it comes with cost of 25% CPU load! but no freezes, possibly because too often screen update)
        private void OnPaint(object sender, PaintEventArgs e)
        {
            controller.GetModelForDraw().Draw(e.Graphics);
        }
    }
}
