namespace LodeRunner.Model
{
    using LodeRunner.Model.DynamicComponents;
    using System;

    [Serializable]
    public class Water : DynamicComponent<WaterState>
    {
        public Water(int x, int y) : base(x, y)
        {
        }
    }
}
