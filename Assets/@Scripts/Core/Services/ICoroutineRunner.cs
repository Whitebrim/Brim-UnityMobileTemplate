using Core.Infrastructure.Services;
using System.Collections;
using UnityEngine;

namespace Core.Services
{
    public interface ICoroutineRunner : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine routine);
    }
}