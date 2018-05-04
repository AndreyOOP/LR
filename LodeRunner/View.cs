using LodeRunner.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LodeRunner
{
    public partial class View : Form
    {
        public Controller Controller { get; set; }

        public View(Controller Controller)
        {
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 450);
            Text = "View x";
            DoubleBuffered = true;

            KeyPress += OnKeyPress;
            Paint += OnPaint;

            this.Controller = Controller;
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            Controller.SetKeyInput(e.KeyChar);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Controller.Model.Draw(e.Graphics);

            Invalidate();
        }
    }
}
