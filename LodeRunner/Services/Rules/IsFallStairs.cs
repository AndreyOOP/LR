using LodeRunner.Model;
using LodeRunner.Model.ModelComponents;
using LodeRunner.Model.SingleComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodeRunner.Services.Rules
{
    public class IsFallStairs : RuleBase
    {
        private Player player;


        public IsFallStairs(Model.Model model) : base(model)
        {
            player = model.Get<Player>(ComponentType.Player);
        }

        public override bool Check()
        {
            int x = (player.X / Const.BlockSize) * Const.BlockSize;
            int x2 = (player.X / Const.BlockSize + 1) * Const.BlockSize;
            int y = (player.Y / Const.BlockSize + 1) * Const.BlockSize;

            //var brick = model.Get<ComponentsCollection<Brick>>(ComponentType.Brick).Get(x, y);
            //var brick2 = model.Get<ComponentsCollection<Brick>>(ComponentType.Brick).Get(x2, y);

            if (model.Get<ComponentsCollection<Stairs>>(ComponentType.Stairs).Get(x, y) == null &&
               model.Get<ComponentsCollection<Stairs>>(ComponentType.Stairs).Get(x2, y) == null)
            {
                player.Y += 1;
                player.ActivatePlayerFall();
                return false;
            }

            //if (brick == null && brick2 == null)
            //{
            //    player.Y += 1;
            //    player.ActivatePlayerFall();
            //    return false;
            //}

            //if (model.Get<ComponentsCollection<Stone>>(ComponentType.Stone).Get(x, y) == null &&
            //   model.Get<ComponentsCollection<Stone>>(ComponentType.Stone).Get(x2, y) == null)
            //{
            //    player.Y += 1;
            //    player.ActivatePlayerFall();
            //    return false;
            //}

            return true;
        }
    }
}
