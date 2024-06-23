using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class Fade : MonoBehaviour
{
    [SerializeField]
    private Image black;

    public void FadeOn()
    {
        StartCoroutine(Fading());
    }
    private IEnumerator Fading()
    {
        black.DOFade(1, 1);
        yield return new WaitForSecondsRealtime(1f);
    }
}
