using Scripts.PlayerWallet;
using System;
using UnityEngine;

namespace Scripts.Purchase
{
    public class PurchaseFillingMachines :MonoBehaviour
    {
        [SerializeField] private FillingMachine _fillingMachineOne;

        public Action<int> CloseButton;
        public void TryPay(int index)
        {
            if(Wallet.Pay(_fillingMachineOne.PriceGold))
            {
                _fillingMachineOne.Open(true);
                _fillingMachineOne.gameObject.SetActive(true);
                CloseButton?.Invoke(index);
            }
        }
    }
}
