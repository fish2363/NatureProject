using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Image fadeIn;
    public void StartScene()
    {
        fadeIn.gameObject.SetActive(true);
        fadeIn.DOFade(1, 1);
        StartCoroutine(GameStart());
    }
    private IEnumerator GameStart()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("BossStage");
    }
}
