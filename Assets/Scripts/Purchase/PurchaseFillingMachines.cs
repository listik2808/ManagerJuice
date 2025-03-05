using Scripts.CustomObjectPool;
using Scripts.Infrastructure;
using Scripts.Infrastructure.Services;
using Scripts.PlayerWallet;
using System;
using UnityEngine;

namespace Scripts.Purchase
{
    public class PurchaseFillingMachines :MonoBehaviour
    {
        [SerializeField] private DataFillingMachine _fillingMachineOne;
        [SerializeField] private Transform _pointTransformFillingMachine;
        IGameFactory _gameFactory;

        public Action <FillingMachine> OnFillingMachine;

        private void Awake()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
        }

        public Action<int> CloseButton;
        public void TryPay(int index)
        {
            if(Wallet.Pay(_fillingMachineOne.PrefabSugar.PriceGold))
            {
               FillingMachine machine = _gameFactory.CreateFillingMachine(_fillingMachineOne.PrefabSugar, _pointTransformFillingMachine);
                machine.ConstructFillingMachine(_fillingMachineOne.Price,_fillingMachineOne.DataJuice,_fillingMachineOne.MaxCountJuicePack,_fillingMachineOne.MaxCountPool,_fillingMachineOne.LevelMachine);
                machine.Open(true);
                OnFillingMachine?.Invoke(machine);
                CloseButton?.Invoke(index);
            }
        }
    }
}
