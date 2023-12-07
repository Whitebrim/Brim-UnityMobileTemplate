using System.Collections;
using UnityEngine;

namespace Core.Services
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine routine);
    }
}