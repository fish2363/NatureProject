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
    [SerializeField]
    private CinemachineVirtualCamera deathCamera;
    [SerializeField]
    private GameObject[] endSetting;
    private bool oneTime = false;
    [SerializeField]
    private GameObject oneJum;
    [SerializeField]
    private Animator animator;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        deathCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHp < 1)
        {
            OnDeathSecond?.Invoke();
            StartCoroutine(Death());
        }

        if(PageTwoBoss.myHp < 1 && !oneTime)
        {
            StartCoroutine(DeathBoss());
            oneTime = true;
        }
    }

    private IEnumerator DeathBoss()
    {
        playerHp = 1000f;
        black.DOFade(1, 1);
        yield return new WaitForSecondsRealtime(1f);

        endSetting[0].GetComponent<MoveGround>().enabled =false;
        endSetting[1].GetComponent<MoveGround>().enabled =false;

        for (int i = 2; i < 12; i++)
            endSetting[i].GetComponent<MovingTree>().enabled = false;
        endSetting[12].SetActive(false);
        endSetting[13].GetComponent<PageTwoBoss>().enabled = false;
        endSetting[13].GetComponent<PageTwoBoss>().StopAllCoroutines();
        endSetting[13].gameObject.transform.DOMove(new Vector3(oneJum.transform.position.x, oneJum.transform.position.y, 0), 1f);

        black.DOFade(0, 1);
        director.Play();
        yield return new WaitForSecondsRealtime(1f);
        cameraBossFinish.gameObject.transform.DOShakePosition(3, 2);
    }


    public void PlayerDamage(float damage)
    {
        playerHp -= damage;
    }

    private IEnumerator Death()
    {
        animator.SetBool("OnDeath", true);
        deathCamera.gameObject.SetActive(true);
        black.DOFade(1, 4);
        yield return new WaitForSecondsRealtime(5f);
        animator.SetBool("OnDeath", false);
        PageTwoBoss.myHp = 4000f;
        playerHp = 100f;
        SceneManager.LoadScene("BossRun");
    }

    public void Fade()
    {
        StartCoroutine(FadeOn());
    }

    private IEnumerator FadeOn()
    {
        black.DOFade(1, 1);
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("Ending");
    }
}
