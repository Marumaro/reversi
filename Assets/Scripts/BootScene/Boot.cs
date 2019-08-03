using UnityEngine;

namespace Reversi.Scene
{
    public class Boot : MonoBehaviour
    {
        [SerializeField]
        private GameObject _dontDestroyObject = null;

        private void Start()
        {
            DontDestroyOnLoad(_dontDestroyObject);

            var arg = new TitleSceneArg("SceneArg Test");

            SceneTransitionManager.Instance.Transition(SceneBuildIndex.TitleScene, arg);
        }
    }
}
