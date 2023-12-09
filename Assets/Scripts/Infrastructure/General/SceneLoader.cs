using System;
using System.Collections;
using Infrastructure.Handlers.CoroutineHandler;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.General
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunnerHandler _coroutineRunnerHandler;

        public SceneLoader(ICoroutineRunnerHandler coroutineRunnerHandler) => 
            _coroutineRunnerHandler = coroutineRunnerHandler;

        public void LoadScene(string sceneName, Action onLoad = null) => 
            _coroutineRunnerHandler.CoroutineRunner.StartCoroutine(LoadSceneAsync(sceneName, onLoad));

        private IEnumerator LoadSceneAsync(string sceneName, Action onLoad)
        {
            AsyncOperation nextScene = SceneManager.LoadSceneAsync(sceneName);

            while (!nextScene.isDone)
                yield return null;

            onLoad?.Invoke();
        }
    }
}