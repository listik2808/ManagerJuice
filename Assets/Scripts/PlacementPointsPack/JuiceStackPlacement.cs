using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Scripts.PlacementPointsPack
{
    public class JuiceStackPlacement : MonoBehaviour
    {
        [SerializeField] private List<PlacementPoints> _placementPoint = new List<PlacementPoints>();
        private Stack<PlacementPoints> _stackJuicePacks = new Stack<PlacementPoints>();
        private FillingMachine _machine;

        public Action OpenLoadingArea;

        public Stack<PlacementPoints> StackJuicePack => _stackJuicePacks;
        public FillingMachine Machine => _machine;

        public void Construct(FillingMachine fillingMachine)
        {
            _machine = fillingMachine;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out JuicePack juicePack))
            {
                juicePack.SetTargetMove(null, false);
                SetPackTransfom(juicePack);
            }
        }

        public JuicePack GetPack()
        {
            PlacementPoints point = _stackJuicePacks.Pop();
            JuicePack juicePack = point.Pack;
            point.IsUsed(true, null);
            _machine.IsChangetCount?.Invoke();

            return juicePack;
        }

        private void SetPackTransfom(JuicePack juicePack)
        {
            foreach (var placementPoint in _placementPoint)
            {
                if (placementPoint.IsFree)
                {
                    juicePack.transform.position = placementPoint.transform.position;
                    placementPoint.IsUsed(false,juicePack);
                    _stackJuicePacks.Push(placementPoint);
                    OpenLoadingArea?.Invoke();
                    break;
                }
            }
        }
    }
}
