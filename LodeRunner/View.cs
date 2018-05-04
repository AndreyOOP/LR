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

        public View()
        {
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 450);
            Text = "View x";
            DoubleBuffered = true;

            //Paint += OnPaint;
        }
    }
}
