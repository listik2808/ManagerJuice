using Scripts.PlacementPointsPack;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Hero
{
    public class InventoryHero :MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private List<PlacementPoints> _points = new List<PlacementPoints>();
        private bool _isWork = false;
        private float _curerntCountPack = 0;

        public float CurerntCountPack => _curerntCountPack;
        public bool IsWork => _isWork;
        public List<PlacementPoints> Points => _points;

        public void AddPack(JuicePack juicePack)
        {
            _isWork = true;
            juicePack.transform.parent = null;
            
            foreach (PlacementPoints p in _points)
            {
                if (p.IsFree)
                {
                    p.IsUsed(false,juicePack);
                    _curerntCountPack++;
                    juicePack.transform.position = p.transform.position;
                    juicePack.transform.parent = _container.transform;
                    break;
                }
            }
            _isWork = false;
        }

        public void Cleer(JuicePack juicePack)
        {
            foreach (PlacementPoints p in _points)
            {
                if(p.Pack == juicePack)
                {
                    p.IsUsed(true, null);
                    _curerntCountPack--;
                }
            }
        }
    }
}
