using Scripts.Data;
using Scripts.Purchase;
using Scripts.UI.UIPurchaseFillingMachine;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infrastructure.Services.ServiceLocator
{
    public class Observer : MonoBehaviour
    {
        [SerializeField] private CanvasPurchaseMachines _canvaspurchaseMachine;
        [SerializeField] private PurchaseFillingMachines _purchaseFillingMachines;
        private DataMashineJuice _mashineJuice;

        private void OnEnable()
        {
            foreach (ButtonTrigger.ButtonListener purchase in _canvaspurchaseMachine.ListButtonListener)
            {
                purchase.ClickButton += TryPayMachineJuice;
            }
            _purchaseFillingMachines.CloseButton += CloseButtonMachinePay;
            _purchaseFillingMachines.OnFillingMachine += SaveData;
        }

        private void OnDisable()
        {
            foreach (ButtonTrigger.ButtonListener purchase in _canvaspurchaseMachine.ListButtonListener)
            {
                purchase.ClickButton -= TryPayMachineJuice;
            }
            _purchaseFillingMachines.CloseButton -= CloseButtonMachinePay;
            _purchaseFillingMachines.OnFillingMachine -= SaveData;
        }

        private void Start()
        {
            _mashineJuice = new DataMashineJuice();
        }

        private void TryPayMachineJuice(int indexMachine)
        {
            _purchaseFillingMachines.TryPay(indexMachine);
        }

        private void CloseButtonMachinePay(int indexMachine)
        {
            _canvaspurchaseMachine.DiactivateButtonIndex(indexMachine);
        }

        private void SaveData(FillingMachine machine)
        {
            _mashineJuice.RecipeStorage.Add(machine);
        }
    }
}
