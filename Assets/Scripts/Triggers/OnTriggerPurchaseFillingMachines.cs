using Scripts.Hero;
using Scripts.UI.UIPurchaseFillingMachine;
using System;
using UnityEngine;

namespace Scripts.Triggers
{
    public class OnTriggerPurchaseFillingMachines : MonoBehaviour,IOnTrigger
    {
        [SerializeField] private BoxCollider _collider;
        [SerializeField] private CanvasPurchaseMachines _machine;
        public Action EnterTrigger => Enter;

        public Action ExitTrigger => Exit;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out HeroMove heroMove))
            {
                EnterTrigger?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out HeroMove heroMove))
            {
                ExitTrigger?.Invoke();
            }
        }

        public void Enter()
        {
            _machine.gameObject.SetActive(true);
        }

        public void Exit()
        {
            if (_machine.IsOpen)
            {
                _machine.gameObject.SetActive(false);
            }
            else
            {
                return;
            }
            
        }
    }
}
