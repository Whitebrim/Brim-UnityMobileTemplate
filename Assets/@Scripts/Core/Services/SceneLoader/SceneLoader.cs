using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Services
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void Load(string sceneName, Action onLoad = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoad));

        private IEnumerator LoadScene(string sceneName, Action onLoad)
        {
            if (SceneManager.GetActiveScene().name != sceneName)
            {
                AsyncOperation waitSceneLoad = SceneManager.LoadSceneAsync(sceneName);

                yield return new WaitUntil(() => waitSceneLoad.isDone);
            }

            onLoad?.Invoke();
        }
    }
}