using Reversi.Dialog;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Reversi.Scene
{
    public class MenuSceneController : ControllerBase
    {
        [SerializeField]
        private Button _singleButton = null;

        [SerializeField]
        private Button _multiButton = null;

        public override void Initialize()
        {
            _singleButton.OnClickAsObservable()
                .Subscribe(_ =>
                {

                })
                .AddTo(this);

            _multiButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    var arg = new MultiPlayDialogArg("マルチプレイ", null);
                    var dialog = DialogManager.Instance.Open<MultiPlayDialog>(arg);
                })
                .AddTo(this);
        }
    }
}
