using Scripts.Purchase;
using Scripts.UI.UIPurchaseFillingMachine;
using System;
using UnityEngine;

namespace Scripts.Infrastructure.Services.ServiceLocator
{
    public class Observer : MonoBehaviour
    {
        [SerializeField] private CanvasPurchaseMachines _canvaspurchaseMachine;
        [SerializeField] private PurchaseFillingMachines _purchaseFillingMachines;

        private void OnEnable()
        {
            foreach (ButtonTrigger.ButtonListener purchase in _canvaspurchaseMachine.ListButtonListener)
            {
                purchase.ClickButton += TryPayMachineJuice;
            }
            _purchaseFillingMachines.CloseButton += CloseButtonMachinePay;
        }

        private void OnDisable()
        {
            foreach (ButtonTrigger.ButtonListener purchase in _canvaspurchaseMachine.ListButtonListener)
            {
                purchase.ClickButton -= TryPayMachineJuice;
            }
            _purchaseFillingMachines.CloseButton -= CloseButtonMachinePay;
        }

        private void TryPayMachineJuice(int indexMachine)
        {
            _purchaseFillingMachines.TryPay(indexMachine);
        }

        private void CloseButtonMachinePay(int indexMachine)
        {
            _canvaspurchaseMachine.DiactivateButtonIndex(indexMachine);
        }
    }
}
