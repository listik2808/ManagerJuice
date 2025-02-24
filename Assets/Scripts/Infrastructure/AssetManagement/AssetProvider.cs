using UnityEngine;

namespace Scripts.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string path, Vector3 point)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, point, Quaternion.identity);
        }

        public FillingMachine InstantiateFillingMAchine(FillingMachine fillingMachine,Transform point)
        {
            return Object.Instantiate(fillingMachine, point);
        }
    }
}
