using LodeRunner;
using LodeRunner.Animation;
using LodeRunner.Model;
using LodeRunner.Model.ModelComponents;
using LodeRunner.Model.SingleComponents;
using LodeRunner.Services;
using System.Drawing;
using System.Windows.Forms;

namespace LevelEditor
{
    public partial class Editor : Form
    {
        private Model model;
        private char selectedObject;
        private Bitmap currentObject = new Bitmap(1, 1);
        private ModelLoadService mls;
        private int pointerX, pointerY;

        public Editor()
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

        private void OnPaint(object sender, PaintEventArgs e)
        {
            model.Draw(e.Graphics);

            e.Graphics.DrawImage(currentObject, pointerX, pointerY);
            e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(pointerX, pointerY, Const.BlockSize, Const.BlockSize));
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 's')
            {
                var sfd = new SaveFileDialog();
                sfd.Filter = "Level files (*.lev)|*.lev";
                sfd.ShowDialog();
                if(sfd.FileName != "")
                {
                    mls.Save(sfd.FileName, model);
                }
            }
            else if(e.KeyChar == 'l')
            {
                var fd = new OpenFileDialog();
                fd.Filter = "Level files (*.lev)|*.lev";
                fd.ShowDialog();
                if(fd.FileName != "")
                {
                    model = mls.Load(fd.FileName);
                }
            }

            selectedObject = char.ToLower(e.KeyChar); //or set work collection to ...

            SwitchTexture(selectedObject);

            Refresh();
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            MouseClicksHandling(e);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            MouseClicksHandling(e);
        }

        private bool IsAboveObject(int x, int y)
        {
            return model.Get<ComponentsCollection<Stone>>(ComponentType.Stone).Get(x, y) != null ||
                   model.Get<ComponentsCollection<Water>>(ComponentType.Water).Get(x, y) != null;
        }

        private void SwitchTexture(char c)
        {
            switch (c)
            {
                case '1':
                    currentObject = new Bitmap(Const.StoneTexture);
                    break;

                case '2':
                    var image = new Bitmap(Const.WaterTexture);
                    currentObject = image.Clone(new Rectangle(0, 0, Const.BlockSize, Const.BlockSize), image.PixelFormat);
                    
                    break;

                default:
                    currentObject = new Bitmap(1, 1);
                    break;
            }
        }

        private void MouseClicksHandling(MouseEventArgs e)
        {
            pointerX = e.X - e.X % Const.BlockSize;
            pointerY = e.Y - e.Y % Const.BlockSize;

            if (e.Button == MouseButtons.Left)
            {
                AddObject(pointerX, pointerY);
            }
            else if (e.Button == MouseButtons.Right)
            {
                RemoveObject(pointerX, pointerY);
            }

            Refresh();
        }

        private void AddObject(int x, int y)
        {
            if (!IsAboveObject(x, y))
            {
                switch (selectedObject)
                {
                    case '1':
                        model.Get<ComponentsCollection<Stone>>(ComponentType.Stone).Add(new Stone() { X = x, Y = y });
                        break;

                    case '2':
                        model.Get<ComponentsCollection<Water>>(ComponentType.Water).Add(new Water() { X = x, Y = y });
                        break;
                }
            }
        }

        private void RemoveObject(int x, int y)
        {
            var col = model.Get<ComponentsCollection<Stone>>(ComponentType.Stone);
            var el = col.Get(x, y);
            if (el != null)
            {
                col.Remove(el);
            }

            var col1 = model.Get<ComponentsCollection<Water>>(ComponentType.Water);
            var el1 = col1.Get(x, y);
            if (el1 != null)
            {
                col1.Remove(el1);
            }
        }
    }
}
