using System.Collections;
using UnityEngine;

namespace Scripts
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
