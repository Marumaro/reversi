using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class FadeView : MonoBehaviour, IFadeView
{
    private const string FadeInStateName = "FadeIn";
    private const string FadeOutStateName = "FadeOut";

    [SerializeField]
    private Image _fadeImage = null;

    [SerializeField]
    private Animator _fadeAnimator = null;

    private void Start()
    {
        Assert.IsNotNull(_fadeImage);
        Assert.IsNotNull(_fadeAnimator);
    }

    public IEnumerator PlayFadeAnimationCoroutine(bool isFadeIn, Color color, float sec)
    {
        var stateName = isFadeIn ? FadeInStateName : FadeOutStateName;
        _fadeImage.color = color;
        _fadeAnimator.speed = 1.0f / sec;

        _fadeAnimator.enabled = true;
        _fadeAnimator.Play(stateName, 0, 0);

        yield return null;
        yield return new WaitForAnimation(_fadeAnimator, 0);
    }
}
