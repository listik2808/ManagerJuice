using UnityEngine;

namespace Scripts.PlacementPointsPack
{
    public class PlacementPoints: MonoBehaviour
    {
        private bool _isFree = true;
        private JuicePack _pack;

        public JuicePack Pack => _pack;
        public bool IsFree => _isFree;

        public void IsUsed(bool value,JuicePack juice)
        {
            _isFree = value;
            _pack = juice;
        }
    }
}
