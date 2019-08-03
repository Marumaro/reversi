using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Reversi.Scene
{
    public class TitleSceneController : ControllerBase
    {
        [SerializeField]
        private Button _startButton = null;

        public override void Initialize()
        {
            _startButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    SceneTransitionManager.Instance.Transition(SceneBuildIndex.MenuScene, null);
                })
                .AddTo(this);
        }
    }
}
