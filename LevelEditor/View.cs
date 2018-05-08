using LodeRunner;
using LodeRunner.Model;
using LodeRunner.Model.ModelComponents;
using LodeRunner.Model.SingleComponents;
using LodeRunner.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor
{
    public partial class View : Form
    {
        private Model model;
        private char selectedObject;
        private ModelLoadService mls;
        private int pointerX, pointerY;

        public View()
        {
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(Const.WindowXSize, Const.WindowYSize);
            Text = "Editor";
            DoubleBuffered = true;

            MouseClick += OnMouseClick;
            MouseMove += OnMouseMove;
            KeyPress += OnKeyPress;
            Paint += OnPaint;

            mls = new ModelLoadService();
            model = new Model();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            pointerX = e.X - e.X % Const.BlockSize;
            pointerY = e.Y - e.Y % Const.BlockSize;
            Refresh();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            model.Draw(e.Graphics);

            if(selectedObject == '1')
            {
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(pointerX, pointerY, Const.BlockSize, Const.BlockSize));
                
            }
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 's')
            {
                mls.Save(""); //how to generate path?
            }
            else if(e.KeyChar == 'l')
            {
                mls.Load(""); //how to generate path ?
            }

            selectedObject = e.KeyChar; //or set work collection to ...
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            bool isDoublicate = false;
            int x = e.X - e.X % Const.BlockSize;
            int y = e.Y - e.Y % Const.BlockSize;

            if (selectedObject == '1') //stone block
            {
                var col = model.Get<ComponentsCollection<Stone>>(ComponentType.Stone);

                foreach (var c in col.GetAll())
                {
                    if (c.X == x && c.Y == y)
                    {
                        isDoublicate = true;
                        break;
                    }
                }

                if (!isDoublicate)
                {
                    col.Add(new Stone() { X = x, Y = y });
                }
            }

            Refresh();
        }
    }
}
