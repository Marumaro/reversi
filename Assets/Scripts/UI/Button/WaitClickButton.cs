using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent, RequireComponent(typeof(Image)), RequireComponent(typeof(Button))]
public class WaitClickButton : MonoBehaviour
{
    /// <summary> ボタン </summary>
    [SerializeField]
    private Button _button = null;

    /// <summary> クリックされたか </summary>
    private bool _isClicked;

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        // ボタンの処理を購読する
        _button
           .OnClickAsObservable()
           .Subscribe(_ => { _isClicked = true; });
    }

    /// <summary>
    /// クリック待ち
    /// </summary>
    /// <returns></returns>
    public IEnumerator WaitClick()
    {
        _isClicked = false;
        yield return new WaitUntil(() => _isClicked);
    }
}

