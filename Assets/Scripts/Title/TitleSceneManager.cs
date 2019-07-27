using Dialog;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TitleScene
{
    public class TitleSceneManager : MonoBehaviour
    {
        [SerializeField]
        private Button _startButton = null;
        
        private void Start()
        {
            _startButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    SceneManager.LoadSceneAsync("MenuScene");
                })
                .AddTo(this);

            var arg = new ConfirmationDialogArg(
                "テスト",
                "本文",
                "OK",
                null,
                null);
            
            var dialog = DialogManager.Instance.Open<ConfirmationDialog>(arg);
        }
    }
}
