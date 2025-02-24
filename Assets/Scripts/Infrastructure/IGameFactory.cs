using Scripts.Infrastructure.Services;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public interface IGameFactory : IService
    {
        FillingMachine CreateFillingMachine(FillingMachine fillingMachineOne, Transform _pointTransformFillingMachine);
        GameObject CreateHero(GameObject point);
        void CreateHud();
    }
}