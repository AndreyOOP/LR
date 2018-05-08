using LodeRunner;
using LodeRunner.Animation;
using LodeRunner.Model;
using LodeRunner.Model.ModelComponents;
using LodeRunner.Model.SingleComponents;
using LodeRunner.Services;
using System;
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
            model.Add(ComponentType.Stone, new ComponentsCollection<Stone>());
            model.Add(ComponentType.Water, new ComponentsCollection<Water>());
            model.Add(ComponentType.Brick, new ComponentsCollection<Brick>());
            model.Add(ComponentType.Stairs, new ComponentsCollection<Stairs>());
            model.Add(ComponentType.Rail, new ComponentsCollection<Rail>());
            model.Add(ComponentType.Gold, new ComponentsCollection<Gold>());
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
                   model.Get<ComponentsCollection<Water>>(ComponentType.Water).Get(x, y) != null ||
                   model.Get<ComponentsCollection<Brick>>(ComponentType.Brick).Get(x, y) != null ||
                   model.Get<ComponentsCollection<Stairs>>(ComponentType.Stairs).Get(x, y) != null ||
                   model.Get<ComponentsCollection<Rail>>(ComponentType.Rail).Get(x, y) != null ||
                   model.Get<ComponentsCollection<Gold>>(ComponentType.Gold).Get(x, y) != null;
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
                        model.Get<ComponentsCollection<Stone>>(ComponentType.Stone).Add(new Stone(x, y));
                        break;

                    case '2':
                        model.Get<ComponentsCollection<Water>>(ComponentType.Water).Add(new Water(x, y));
                        break;

                    case '3':
                        model.Get<ComponentsCollection<Brick>>(ComponentType.Brick).Add(new Brick(x, y));
                        break;

                    case '4':
                        model.Get<ComponentsCollection<Stairs>>(ComponentType.Stairs).Add(new Stairs(x, y));
                        break;

                    case '5':
                        model.Get<ComponentsCollection<Rail>>(ComponentType.Rail).Add(new Rail(x, y));
                        break;

                    case '6':
                        model.Get<ComponentsCollection<Gold>>(ComponentType.Gold).Add(new Gold(x, y));
                        break;

                    case '7':
                        model.Remove(ComponentType.Player);
                        model.Add(ComponentType.Player, new Player(x, y));
                        break;
                }
            }
        }

        private void RemoveObject(int x, int y)
        {
            Remove<ComponentsCollection<Stone>>(ComponentType.Stone, x, y);
            Remove<ComponentsCollection<Water>>(ComponentType.Water, x, y);
            Remove<ComponentsCollection<Brick>>(ComponentType.Brick, x, y);
            Remove<ComponentsCollection<Stairs>>(ComponentType.Stairs, x, y);
            Remove<ComponentsCollection<Rail>>(ComponentType.Rail, x, y);
            Remove<ComponentsCollection<Gold>>(ComponentType.Gold, x, y);

            try
            {
                var player = model.Get<Player>(ComponentType.Player);
                if (x == player.X && y == player.Y)
                {
                    model.Remove(ComponentType.Player);
                }
            }
            catch (Exception e) { }
        }

        private void Remove<T>(ComponentType type, int x, int y) where T : IDrawable
        {
            dynamic collection = model.Get<T>(type);
            dynamic element = collection.Get(x, y);
            if (element != null)
            {
                collection.Remove(element);
            }
        }

    }
}
