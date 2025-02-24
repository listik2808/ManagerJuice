using Scripts.Infrastructure;
using Scripts.Infrastructure.Services;
using Scripts.PlayerWallet;
using System;
using UnityEngine;

namespace Scripts.Purchase
{
    public class PurchaseFillingMachines :MonoBehaviour
    {
        [SerializeField] private FillingMachine _fillingMachineOne;
        [SerializeField] private Transform _pointTransformFillingMachine;
        IGameFactory _gameFactory;

        private void Awake()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
        }

        public Action<int> CloseButton;
        public void TryPay(int index)
        {
            if(Wallet.Pay(_fillingMachineOne.PriceGold))
            {
                _fillingMachineOne.Open(true);
               FillingMachine machine = _gameFactory.CreateFillingMachine(_fillingMachineOne, _pointTransformFillingMachine);
                //machine.gameObject.SetActive(true);
                CloseButton?.Invoke(index);
            }
        }
    }
}
