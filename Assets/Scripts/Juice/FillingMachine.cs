using Scripts.CustomObjectPool;
using Scripts.Juice;
using Scripts.PlacementPointsPack;
using System;
using UnityEngine;

public abstract class FillingMachine : MonoBehaviour
{
    [SerializeField] protected Transform PointSpawn;
    [SerializeField] protected JuiceStackPlacement PointFinishStack;
    protected CustomPoolJuice CustomPoolJuice;
    protected bool _isOpen = false;
    protected float Price;
    protected float MaxCount;
    protected bool IsWork = false;
    protected float Level;

    public bool IsOpen => _isOpen;
    public float PriceGold => Price;

    public Action IsChangetCount;

    public void Open(bool value)
    {
        _isOpen = value;
        PointFinishStack.Construct(this);
    }

    public void ConstructFillingMachine(float price,DataJuice juice,float maxJuicePack,float maxValuePool, int levelMachine)
    {
        Level = levelMachine;
        Price = price;
        MaxCount = maxJuicePack;
        ComponentSetPool(maxValuePool,Level, juice);
    }

    private void ComponentSetPool(float valueMax,float levelMachine, DataJuice juice)
    {
        CustomPoolJuice = GetComponent<CustomPoolJuice>();
        CustomPoolJuice.Construct(juice, valueMax, PointSpawn, levelMachine);
    }
}
