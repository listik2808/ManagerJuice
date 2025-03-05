using Scripts.Juice;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.CustomObjectPool
{
    public class CustomPoolJuice : MonoBehaviour
    {
        private JuicePack _prefab;
        private List<JuicePack> _poll;
        private Transform _containerPoll;
        private float _levelMachine;

        public void Construct(DataJuice juicePack, float prewarmObjects, Transform container, float levelMachine)
        {
            _prefab = juicePack.JuicePack;
            _containerPoll = container;
            _levelMachine = levelMachine;
            _prefab.Construct(juicePack.JuiceTypeId,juicePack.Price,levelMachine);
            _poll = new List<JuicePack>();

            for (int i = 0; i < prewarmObjects; i++)
            {
                JuicePack juice = Create(_prefab, _containerPoll);
                juice.SetStartPoint(_containerPoll);
                juice.gameObject.SetActive(false);
                //_poll.Add(projectile);
            }
        }

        public JuicePack Get()
        {
            JuicePack juice = _poll.FirstOrDefault(x => !x.isActiveAndEnabled);
            if (juice == null)
            {
                juice = Create(_prefab, _containerPoll);
                juice.gameObject.SetActive(false);
                //_poll.Add(projectile);
            }
            juice.transform.localPosition = Vector3.zero;
            juice.gameObject.SetActive(true);
            return juice;
        }

        public JuicePack Charge()
        {
            JuicePack juice = _poll.FirstOrDefault(x => !x.isActiveAndEnabled);
            if (juice == null)
            {
                juice = Create(_prefab, _containerPoll);
                juice.gameObject.SetActive(false);
                //_poll.Add(projectile);
            }
            juice.transform.localPosition = Vector3.zero;
            return juice;
        }

        private JuicePack Create(JuicePack juicePack, Transform container)
        {
            JuicePack juice = Instantiate(juicePack, container);
            juice.Construct(juicePack.JuiceType, juicePack.Price, _levelMachine);
            _poll.Add(juice);
            return juice;
        }
    }
}
