using Scripts.CustomObjectPool;
using System;
using System.Collections;
using UnityEngine;

public class JuiceFillingMachine : FillingMachine
{
    private float _currentCount = 0;

    private void OnEnable()
    {
        IsChangetCount += SetCount;
    }

    private void OnDisable()
    {
        IsChangetCount -= SetCount;
    }

    private void Start()
    {
        if (_isOpen && IsWork == false)
        {
            StartCoroutine(StartCreteJuisePack());
        }
    }


    private IEnumerator StartCreteJuisePack()
    {
        while(_currentCount < MaxCount)
        {
            IsWork = true;
            JuicePack juice = CustomPoolJuice.Get();
            juice.SetTargetMove(PointFinishStack.transform,true);
            _currentCount += 1;
            yield return new WaitForSeconds(3.5f);
            IsWork = false;
        }
        yield return null;
    }

    private void SetCount()
    {
        _currentCount -= 1;
    }
}
