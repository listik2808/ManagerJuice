using UnityEngine;

namespace Scripts.Infrastructure.Services.Input
{
    public abstract class InputService : IInputServices
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";

        public abstract Vector2 Axis { get; }

        protected static Vector2 SimplInputAxis() =>
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}
