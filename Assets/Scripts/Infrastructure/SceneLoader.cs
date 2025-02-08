using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string nameScene, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(nameScene, onLoaded));

        private IEnumerator LoadScene(string nameScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nameScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation asyncOperationScene = SceneManager.LoadSceneAsync(nameScene);
            while (!asyncOperationScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}
