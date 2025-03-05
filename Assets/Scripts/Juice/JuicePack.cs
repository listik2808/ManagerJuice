using Scripts.Juice;
using System;
using System.Collections;
using UnityEngine;

public class JuicePack : MonoBehaviour
{
    [SerializeField] private AnimationCurve _muveJuice;
    private JuiceTypeId _juiceType;
    private Transform _target;
    private bool _isMove = false;
    private float _price;
    private Transform _containerPool;

    public Transform ContainerPool => _containerPool;
    public float Price => _price;
    public JuiceTypeId JuiceType => _juiceType;

    public void Construct(JuiceTypeId juiceTypeId,float price,float levelMachine)
    {
        _price = price;
        _juiceType = juiceTypeId;
        
        SetPrice(levelMachine);
    }

    public void SetTargetMove(Transform transform,bool value)
    {
        _target = transform;
        _isMove = value;
        StartCoroutine(Move());
    }

    public void SetStartPoint(Transform containerPoll)
    {
        _containerPool = containerPoll;
    }

    private IEnumerator Move()
    {
        while (_isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, 0.1f);
            yield return null;
        }
    }

    private void SetPrice(float levelMachine) 
    {
        if(levelMachine > 0)
        {
            _price *= levelMachine;
        }
    }
}