using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Reversi.Scene
{
    public class SceneTransitionManager : SingletonMonoBehaviour<SceneTransitionManager>
    {
        private SceneManagerBase _currentSceneManager;

        public void Transition(int sceneBuildIndex, SceneArgBase argBase)
        {
            StartCoroutine(SceneLoadCoroutine(sceneBuildIndex, argBase));
        }

        public IEnumerator SceneLoadCoroutine(int sceneBuildIndex, SceneArgBase argBase)
        {
            yield return SceneManager.LoadSceneAsync(sceneBuildIndex);

            _currentSceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerBase>();
            if (_currentSceneManager == null)
            {
                Debug.LogError("SceneManager not found");
                yield break;
            }

            _currentSceneManager.Initialize(argBase);
        }
    }
}
