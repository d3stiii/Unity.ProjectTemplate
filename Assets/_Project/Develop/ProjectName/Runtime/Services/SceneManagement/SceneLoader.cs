using System;
using System.Collections;
using ProjectName.Runtime.Common;
using UnityEngine.SceneManagement;

namespace ProjectName.Runtime.Services.SceneManagement
{
  public class SceneLoader
  {
    private readonly CoroutineRunner _coroutineRunner;

    public SceneLoader(CoroutineRunner coroutineRunner) =>
      _coroutineRunner = coroutineRunner;

    public void Load(string sceneName, Action onLoaded = null) =>
      _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));

    private IEnumerator LoadScene(string sceneName, Action onLoaded)
    {
      if (SceneManager.GetActiveScene().name == sceneName)
      {
        onLoaded?.Invoke();
        yield break;
      }

      var loadOperation = SceneManager.LoadSceneAsync(sceneName);
      while (!loadOperation.isDone) yield return null;

      onLoaded?.Invoke();
    }
  }
}