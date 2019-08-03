using UnityEngine;

namespace Reversi.Scene
{
    public class MenuSceneManager : SceneManagerBase
    {
        [SerializeField]
        private MenuSceneController _menuSceneController = null;

        public override void Initialize(SceneArgBase argBase)
        {
            _menuSceneController.Initialize();
        }
    }
}
