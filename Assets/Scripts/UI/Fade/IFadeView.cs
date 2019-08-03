using System.Collections;
using UnityEngine;

public interface IFadeView
{
    IEnumerator PlayFadeAnimationCoroutine(bool isFadeIn, Color color, float sec);
}
