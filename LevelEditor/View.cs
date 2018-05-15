using LodeRunner;
using LodeRunner.Model;
using LodeRunner.Services;
using System.Drawing;
using System.Windows.Forms;

namespace LevelEditor
{
    public class Editor : Form
    {
        private Model model;
        private char selectedObject;
        private Bitmap currentObject = new Bitmap(1, 1);
        private ModelLoadService mls;
        private int pointerX, pointerY;
        private BlockFactory blockFactory;

        public Editor()
        {
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(Const.WindowWidth, Const.WindowHeigth);
            Text = "Editor";
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            MouseClick += OnMouseClick;
            MouseMove += OnMouseMove;
            KeyPress += OnKeyPress;
            Paint += OnPaint;

            mls = new ModelLoadService();
            model = new Model();

            blockFactory = new BlockFactory();
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
            return model.Get(x, y, true) != null;
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

                case '3':
                    currentObject = new Bitmap(Const.BrickTexture);
                    break;

                case '4':
                    currentObject = new Bitmap(Const.StairsTexture);
                    break;

                case '5':
                    currentObject = new Bitmap(Const.RailTexture);
                    break;

                case '6':
                    currentObject = new Bitmap(Const.GoldTexture);
                    break;

                case '7':
                    currentObject = new Bitmap(Const.PlayerStand);
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
                model.Remove(pointerX, pointerY, true);
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
                        model.Add(blockFactory.GetStone(x, y));
                        break;

                    case '2':
                        model.Add(blockFactory.GetWater(x, y));
                        break;

                    case '3':
                        model.Add(blockFactory.GetBrick(x, y));
                        break;

                    case '4':
                        model.Add(blockFactory.GetStairs(x, y));
                        break;

                    case '5':
                        model.Add(blockFactory.GetRail(x, y));
                        break;

                    case '6':
                        model.Add(blockFactory.GetGold(x, y));
                        model.MaxScore++;
                        break;

                    case '7':
                        model.Player = blockFactory.GetPlayer(x, y);
                        break;
                }
            }
        }
    }
}