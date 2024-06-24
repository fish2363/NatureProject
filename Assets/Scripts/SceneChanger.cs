using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Image fadeIn;
    public string sceneName;

    private void Start()
    {

    }

    public void StartScene()
    {
        fadeIn.gameObject.SetActive(true);
        fadeIn.DOFade(1, 1);
        StartCoroutine(GameStart());
    }
    private IEnumerator GameStart()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
