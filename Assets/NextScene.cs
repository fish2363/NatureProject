using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class NextScene : HpManager
{
    private PlayableDirector director;
    private FirstSceneManager manager;
    private Boss boss;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Deer");
        manager = FindAnyObjectByType<FirstSceneManager>();
        boss = FindAnyObjectByType<Boss>();
        black = GameObject.Find("Panel").GetComponent<Image>();
        director = GameObject.Find("TimeLineManager").GetComponent<PlayableDirector>();
    }

    private void Start()
    {
        instance.winBoss += Next;
        instance.OnDeath += DeathCoru;
    }

    public void Next()
    {
        director.Play();
        manager.UnEnable();
        boss.grabStop = true;
        boss.transform.DOMove(boss.bossPoint.position, 3);
        boss.StopAllCoroutines();
        boss.grabSprite.gameObject.SetActive(false);
    }

    private void DeathCoru()
    {
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        black.DOFade(1, 1);
        bossCurrentHp = bossMaxHp;
        playerHp = 100f;
        yield return new WaitForSecondsRealtime(5f);

        SceneManager.LoadScene("BossStage");
    }
}
