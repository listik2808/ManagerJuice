using Scripts.Hero;
using Scripts.UI.UIPurchaseFillingMachine;
using System;
using UnityEngine;

namespace Scripts.Triggers
{
    public class OnTriggerPurchaseFillingMachines : MonoBehaviour, IOnTriggerExit
    {
        [SerializeField] private BoxCollider _collider;
        [SerializeField] private CanvasPurchaseMachines _machine;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out HeroMove heroMove))
            {
                Enter();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out HeroMove heroMove))
            {
                Exit();
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
