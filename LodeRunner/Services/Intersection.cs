namespace LodeRunner.Services
{
    using LodeRunner.Model;
    using LodeRunner.Model.ModelComponents;
    using LodeRunner.Model.SingleComponents;

    public class Intersection
    {
        private Model model;
        private Player player;

        public enum Corner { TopLeft, TopRight, BottomLeft, BottomRight }
        public enum Direction { Left, Right, Up, Down, None }
        public enum Operation { Or, And }
        public enum Side { In, Out }

        public Intersection(Model model)
        {
            this.model = model;
            player = model.Player;
        }

        public SingleComponentBase Get(Corner corner, Direction direction = Direction.None)
        {
            int x = 0;
            int y = 0;

            switch (corner)
            {
                case Corner.TopLeft    : x = player.X;     y = player.Y;     break;
                case Corner.TopRight   : x = player.X +19; y = player.Y;     break;
                case Corner.BottomLeft : x = player.X;     y = player.Y +19; break;
                case Corner.BottomRight: x = player.X +19; y = player.Y +19; break;
            }

            switch (direction)
            {
                case Direction.Left : x -= 1; break;
                case Direction.Right: x += 1; break;
                case Direction.Up   : y -= 1; break;
                case Direction.Down : y += 1; break;
            }

            x /= 20;
            y /= 20;

            return model.Get(x, y);
        }

        public bool Line<T>(Direction direction, Side side, Operation operation)
        {
            SingleComponentBase block1 = null;
            SingleComponentBase block2 = null;

            switch (direction)
            {
                case Direction.Left:
                    block1 = Get(Corner.TopLeft, side==Side.Out ? Direction.Left : Direction.None);
                    block2 = Get(Corner.BottomLeft, side == Side.Out ? Direction.Left : Direction.None);
                    break;

                case Direction.Right:
                    block1 = Get(Corner.TopRight, side == Side.Out ? Direction.Right : Direction.None);
                    block2 = Get(Corner.BottomRight, side == Side.Out ? Direction.Right : Direction.None);
                    break;

                case Direction.Up:
                    block1 = Get(Corner.TopLeft, side == Side.Out ? Direction.Up : Direction.None);
                    block2 = Get(Corner.TopRight, side == Side.Out ? Direction.Up : Direction.None);
                    break;

                case Direction.Down:
                    block1 = Get(Corner.BottomLeft, side == Side.Out ? Direction.Down : Direction.None);
                    block2 = Get(Corner.BottomRight, side == Side.Out ? Direction.Down : Direction.None);
                    break;
            }

            switch (operation)
            {
                case Operation.Or:
                    return block1 is T || block2 is T;

                case Operation.And:
                    return block1 is T && block2 is T;
            }

            return false;
        }

        public bool Line(Direction direction, Side side, Operation operation)
        {
            SingleComponentBase block1 = null;
            SingleComponentBase block2 = null;

            switch (direction)
            {
                case Direction.Left:
                    block1 = Get(Corner.TopLeft, side == Side.Out ? Direction.Left : Direction.None);
                    block2 = Get(Corner.BottomLeft, side == Side.Out ? Direction.Left : Direction.None);
                    break;

                case Direction.Right:
                    block1 = Get(Corner.TopRight, side == Side.Out ? Direction.Right : Direction.None);
                    block2 = Get(Corner.BottomRight, side == Side.Out ? Direction.Right : Direction.None);
                    break;

                case Direction.Up:
                    block1 = Get(Corner.TopLeft, side == Side.Out ? Direction.Up : Direction.None);
                    block2 = Get(Corner.TopRight, side == Side.Out ? Direction.Up : Direction.None);
                    break;

                case Direction.Down:
                    block1 = Get(Corner.BottomLeft, side == Side.Out ? Direction.Down : Direction.None);
                    block2 = Get(Corner.BottomRight, side == Side.Out ? Direction.Down : Direction.None);
                    break;
            }

            switch (operation)
            {
                case Operation.Or:
                    return block1 == null || block2 == null;

                case Operation.And:
                    return block1 == null && block2 == null;
            }

            return false;
        }
    }
}
