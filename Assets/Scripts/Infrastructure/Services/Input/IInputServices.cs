using UnityEngine;

namespace Scripts.Infrastructure.Services.Input
{
    public interface IInputServices : IService
    {
        Vector2 Axis { get; }
    }
}