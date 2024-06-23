using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Playables;
using DG.Tweening;


public class ShotGunObject : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector director;
    [SerializeField]
    private Image blackPanel;
    [SerializeField]
    private GameObject currentCam;
    [SerializeField]
    private GameObject gameCamera;
    [SerializeField]
    private GameObject hunters;
    [SerializeField]
    private SpriteRenderer gunSprite;

    [SerializeField]
    private GameObject bossHpSlider;
    [SerializeField]
    private GameObject bossHpSliderIcon;

    private bool second;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(Wait(2f));
            GameManager.instance.isStop = true;
        }
    }

    public void DestroyMe()
    {
        StartCoroutine(End());
        StartCoroutine(Wait(1f));
    }

    private IEnumerator End()
    {
        yield return new WaitForSecondsRealtime(2f);
        hunters.GetComponent<HunterBoss>().enabled = true;
        GameManager.instance.isStop = false;
        gunSprite.enabled = true;
        GameManager.instance.noGun = false;
        gameCamera.SetActive(true);
        currentCam.SetActive(false);
        bossHpSlider.SetActive(true);
        bossHpSliderIcon.SetActive(true);
        Destroy(gameObject);
    }

    private IEnumerator Wait(float waitTime)
    {
        blackPanel.DOFade(1, 1);
        yield return new WaitForSecondsRealtime(waitTime);
        blackPanel.DOFade(0, 1);
        if(!second)
        {
            director.Play();
            second = true;
        }
    }
}
