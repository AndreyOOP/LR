namespace LodeRunner.Model
{
    using System;
    using System.Drawing;
    using LodeRunner.Model.ModelComponents;
    using LodeRunner.Model.SingleComponents;

    [Serializable]
    public partial class Model : IModel, IDrawable
    {
        private SingleComponentBase[,] field = new SingleComponentBase[Const.BlockWidth, Const.BlockHeigth];

        public GameState State { get; set; } = GameState.InGame;

        public Player Player { get; set; }

        public SingleComponentBase Message { get; set; }
        
        public void Add<T>(T component) where T : SingleComponentBase
        {
            CheckInput(component);

            field[component.BlockX, component.BlockY] = component;
        }
        
        public SingleComponentBase Get(int blockX, int blockY, bool absolute = false)
        {
            if (absolute)
            {
                blockX /= Const.BlockSize;
                blockY /= Const.BlockSize;
            }

            return field[blockX, blockY];
        }

        public void Remove(int blockX, int blockY, bool absolute = false)
        {
            if (absolute)
            {
                blockX /= Const.BlockSize;
                blockY /= Const.BlockSize;
            }

            field[blockX, blockY] = null;
        }

        public void Draw(Graphics g)
        {
            foreach (var component in field)
            {
                component?.Draw(g);
            }

            Player?.Draw(g);
            Message?.Draw(g);
        }

        private void CheckInput<T>(T component) where T : SingleComponentBase
        {
            if (component.BlockX < 0)
            {
                throw new ArgumentException($"{nameof(component.BlockX)} could not be < 0. Now it is {component.BlockX}");
            }

            if (component.BlockX >= Const.BlockWidth)
            {
                throw new ArgumentException($"{nameof(component.BlockX)} could not be >= than maximum field width. It is {component.BlockX} vs {Const.BlockWidth}");
            }

            if (component.BlockY < 0)
            {
                throw new ArgumentException($"{nameof(component.BlockY)} could not be < 0. Now it is {component.BlockY}");
            }

            if (component.BlockY >= Const.BlockHeigth)
            {
                throw new ArgumentException($"{nameof(component.BlockY)} could not be >= than maximum field heigth. It is {component.BlockY} vs {Const.BlockHeigth}");
            }
        }
    }
}
