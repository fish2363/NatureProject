using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using DG.Tweening;
using System;
using Cinemachine;

public class HpManagerSecond : MonoBehaviour
{
    public static HpManagerSecond instance;
    public float playerHp = 100f;
    public Image black;
    public static event Action OnDeathSecond;
    [SerializeField]
    private PlayableDirector director;
    [SerializeField]
    private CinemachineVirtualCamera cameraBossFinish;
    private bool oneTime = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public object OnDeath { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if (playerHp < 1)
        {
            OnDeathSecond?.Invoke();
            StartCoroutine(DeathBoss());
        }

        if(PageTwoBoss.myHp < 1 && !oneTime)
        {
            StartCoroutine(DeathBoss());
            oneTime = true;
        }
    }

    private IEnumerator DeathBoss()
    {
        black.DOFade(1, 1);
        yield return new WaitForSecondsRealtime(1f);
        black.DOFade(0, 1);
        yield return new WaitForSecondsRealtime(1f);
        director.Play();
        cameraBossFinish.gameObject.transform.DOShakePosition(3, 2);
    }


    public void PlayerDamage(float damage)
    {
        playerHp -= damage;
    }

    private IEnumerator Death()
    {
        black.DOFade(1, 1);
        PageTwoBoss.myHp = 2000f;
        playerHp = 100f;
        yield return new WaitForSecondsRealtime(5f);

        SceneManager.LoadScene("BossRun");
    }
}
