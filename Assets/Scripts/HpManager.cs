using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using DG.Tweening;
using UnityEngine.SceneManagement;

public interface IDamage
{
    public void Damage(float damage);
}

public class HpManager : MonoBehaviour
{
    public static HpManager instance;
    public float playerHp = 100f;
    public static event Action OnDeath;
    public Image black;
    [SerializeField]
    private PlayableDirector director;

    [SerializeField]
    public static float bossMaxHp;
    public static float bossCurrentHp;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void PlayerDamage(float damage)
    {
        print("나 아파요 ㅠㅠ");
        playerHp -= damage;
    }

    private void Update()
    {
        if(playerHp < 1)
        {
            OnDeath?.Invoke();
            StartCoroutine(Death());
        }
        if(bossCurrentHp < 1)
        {
            director.Play();
        }
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
