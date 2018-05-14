namespace LodeRunner.Model
{
    using LodeRunner.Animation;
    using LodeRunner.Model.DynamicComponents;
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    [Serializable]
    public class Water : DynamicComponent<WaterState>
    {
        public Water(int x, int y, Dictionary<WaterState, Animation> dynamicStates, Dictionary<WaterState, Image> staticStates, WaterState state) : base(x, y, dynamicStates, staticStates, state)
        {
        }
    }
}
