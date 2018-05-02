using LodeRunner.Animation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LodeRunnerTests.VisualTester
{
    public partial class StandForm : Form
    {
        private AnimationImage animationImage;

        public StandForm()
        {
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 450);
            Text = "StandForm";
            DoubleBuffered = true;

            Paint += OnPaint;

            animationImage = new AnimationImage(new Bitmap(@"Animation\AnimatedTestImage.png"), 30, 50);
            animationImage.Start();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(0, 0, 30, 30));

            e.Graphics.DrawImage(animationImage.GetCurrentFrame(), new Point(30, 30));

            Invalidate();
        }

        //~StandForm()
        //{
        //    Dispose(false);
        //}

        protected override void Dispose(bool disposing)
        {
            //if (disposing && (components != null))
            //{
            //    components.Dispose();
            //}
            base.Dispose(disposing);
        }
    }
}
