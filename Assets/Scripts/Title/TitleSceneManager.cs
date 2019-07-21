using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] private Button _startButton = null;

    private void Start()
    {
        _startButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                SceneManager.LoadSceneAsync("MenuScene");
            })
            .AddTo(this);
    }
}
