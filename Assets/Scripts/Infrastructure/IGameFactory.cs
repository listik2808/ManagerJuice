using Scripts.Infrastructure.Services;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject point);
        void CreateHud();
    }
}