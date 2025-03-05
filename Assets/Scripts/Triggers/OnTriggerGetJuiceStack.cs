using Scripts.Hero;
using Scripts.PlacementPointsPack;
using UnityEngine;

namespace Scripts.Triggers
{
    public class OnTriggerGetJuiceStack : MonoBehaviour
    {
        [SerializeField] private JuiceStackPlacement _stackPlacement;
        [SerializeField] private Canvas _canvasLoadindArea;

        private JuicePack _juicePack;

        private void OnEnable()
        {
            _stackPlacement.OpenLoadingArea += VisibleCanvas;
        }

        private void OnDisable()
        {
            _stackPlacement.OpenLoadingArea -= VisibleCanvas;
        }

        private void OnTriggerStay(Collider other)
        {
            if(_canvasLoadindArea.gameObject.activeInHierarchy && other.TryGetComponent(out InventoryHero inventoryHero))
            {
                if(_stackPlacement.StackJuicePack.Count > 0 && inventoryHero.IsWork == false)
                {
                   inventoryHero.AddPack(_stackPlacement.GetPack());
                }
            }
        }

        public void Enter()
        {
            _juicePack = _stackPlacement.GetPack();
        }

        private void VisibleCanvas()
        {
            _canvasLoadindArea.gameObject.SetActive(true);
        }
    }
}
