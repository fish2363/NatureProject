using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;
using TMPro;


public class SceneManegement : MonoBehaviour
{
    [SerializeField]
    private Image[] images;
    [SerializeField]
    private Image logo;
    [SerializeField]
    private Image sliderSprite;
    [SerializeField]
    private Slider slider;

    [Header("컷신 상영 설정값")]
    [SerializeField]
    private float imageFadeTime;
    private float clickCount;
    [SerializeField]
    private string[] chats;
    [SerializeField]
    private TextMeshProUGUI chatText;



    private void Start()
    {
        chatText.text = null;
        StartCoroutine(CutScene());
    }

    public void SliderCollision()
    {
        if (slider.value == 6)
            for (int i = 0; i < images.Length; i++)
            {
                print(images[i].name);
                images[i].DOKill();
                images[i].DOFade(0, 1);

                StopCoroutine(CutScene());
                StartCoroutine(StartNextScene());
            }
    }

    private IEnumerator StartNextScene()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("Stage");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            clickCount += Time.deltaTime;
            sliderSprite.DOFade(1,1);
        }
        else if(!Input.GetMouseButton(0) && clickCount > 1)
        {
            clickCount -= Time.deltaTime;
            sliderSprite.DOFade(0, 1);
        }

        slider.value = clickCount;
    }

    private IEnumerator CutScene()
    {
        logo.DOFade(1, imageFadeTime);
        yield return new WaitForSecondsRealtime(3f);
        logo.DOFade(0, imageFadeTime);
        yield return new WaitForSecondsRealtime(3f);


        for (int i = 0; i < images.Length; i++)
        {
            //for(int j = 0; j < chats.Length; j++)
            //{
                int wait = int.Parse(images[i].name.Substring(0, 1));
                images[i].DOFade(1, imageFadeTime);
            //int waitTime = int.Parse(chats[j].Substring(0, 1));
            //chatText.Do
                StartCoroutine(Typing(chats[i], wait));
                yield return new WaitForSecondsRealtime(wait +2f);
                images[i].DOFade(0, imageFadeTime);
                yield return new WaitForSecondsRealtime(2f);
            //}
                
        }
    }

    public static void TMPD0Text(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;
        DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration);
    }

    IEnumerator Typing(string talk, float wait)
    {
        chatText.text = talk;
        TMPD0Text(chatText, wait);

        yield return new WaitForSecondsRealtime(wait +1f);
        chatText.text = null;
    }
}
