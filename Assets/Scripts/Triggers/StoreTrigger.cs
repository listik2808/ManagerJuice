using Scripts.Hero;
using Scripts.PlacementPointsPack;
using Scripts.Shop;
using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace Scripts.Triggers
{
    public class StoreTrigger : MonoBehaviour
    {
        [SerializeField] private ShopData _shopData;
        [SerializeField] private Transform _transform;
        [SerializeField] private AnimationCurve _animationCurve;
        [SerializeField] private AnimationCurve _jumpCurve;
        Coroutine _coroutine;
        private bool _isWork = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out InventoryHero inventoryHero))
            {
                _isWork = true;
                float count = 0;
                if (_coroutine != null)
                {
                    _coroutine = null;
                }
                _coroutine = StartCoroutine(MovePack(inventoryHero, true, count, _transform));
                _shopData.OnChangeProgress?.Invoke(count);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out InventoryHero inventoryHero))
            {
                _isWork = false;
            }
        }

        private IEnumerator MovePack(InventoryHero inventoryHero,bool value, float count, Transform transform)
        {
            Vector3 startPoint;
            float progress = 0;
            while (_isWork)
            {
                if (inventoryHero.CurerntCountPack >0)
                {
                    foreach(PlacementPoints points in inventoryHero.Points)
                    {
                        if (points.IsFree == false && _isWork)
                        {
                            JuicePack pack = points.Pack;
                            count++;
                            startPoint = pack.transform.position;
                            while (progress < 1)
                            {
                                progress += Time.deltaTime;
                                pack.transform.position = Vector3.LerpUnclamped(startPoint, transform.position, _animationCurve.Evaluate(progress));
                                pack.transform.position = pack.transform.position + Vector3.up * _jumpCurve.Evaluate(progress);
                                yield return null;
                            }

                            //Включить партикл он должен висеть на соке
                            pack.gameObject.SetActive(false);
                            pack.transform.position = pack.ContainerPool.position;
                            pack.transform.parent = pack.ContainerPool;
                            inventoryHero.Cleer(pack);
                            progress = 0;
                        }
                        
                    }
                }
                else
                {
                    _isWork = false;
                }
                progress = 0;
                yield return null;
            }
        }
    }
}
