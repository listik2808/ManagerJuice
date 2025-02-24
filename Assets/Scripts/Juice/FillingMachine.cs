using System;
using UnityEngine;

public abstract class FillingMachine : MonoBehaviour
{
    public JuiceTypeId JuiceTypeId;
    [SerializeField] protected float Price;
    protected bool _isOpen = false;
    
    public bool IsOpen => _isOpen;
    public float PriceGold => Price;

    public void Open(bool value)
    {
        _isOpen = value;
    }
}
