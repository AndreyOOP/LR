namespace LodeRunner.Model.DynamicComponents
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using LodeRunner.Animation;
    using LodeRunner.Model.Interfaces;
    using LodeRunner.Model.ModelComponents;

    [Serializable]
    public class DynamicComponent<T> : StaticComponent, IPause where T : struct
    {
        private T state;

        private Dictionary<T, Animation> dynamicStates;
        private Dictionary<T, Image> staticStates;

        public DynamicComponent(int x, int y) : base(x, y)
        {
            dynamicStates = new Dictionary<T, Animation>();
            staticStates = new Dictionary<T, Image>();
        }

        public T State
        {
            get
            {
                return state;
            }

            set
            {
                if (state.Equals(value))
                {
                    return;
                }
                    
                state = value;

                foreach (var s in dynamicStates)
                {
                    s.Value.Pause();
                }

                if (dynamicStates.ContainsKey(state))
                {
                    dynamicStates[state].Start();
                }
            }
        }

        public void AddDynamicState(T state, Animation animation)
        {
            dynamicStates[state] = animation;
        }

        public void AddStaticState(T state, Image texture)
        {
            staticStates[state] = texture;
        }

        public override void Draw(Graphics g)
        {
            if (staticStates.ContainsKey(state))
            {
                g.DrawImage(staticStates[state], X, Y);
            }
            else
            {
                g.DrawImage(dynamicStates[State].GetCurrentFrame(), X, Y);
            }
        }

        public virtual void Pause()
        {
            if (dynamicStates.ContainsKey(state))
            {
                dynamicStates[state].Pause();
            }
        }

        public virtual void Continue()
        {
            if (dynamicStates.ContainsKey(state))
            {
                dynamicStates[state].Continue();
            }
        }
    }
}
