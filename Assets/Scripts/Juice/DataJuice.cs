using UnityEngine;

namespace Scripts.Juice
{
    [CreateAssetMenu(fileName = "PackJuice",menuName = "Pack/Juice")]
    public class DataJuice : ScriptableObject
    {
        public int Level = 0;
        public float Price;
        public JuicePack JuicePack;
        public JuiceTypeId JuiceTypeId;
    }
}
