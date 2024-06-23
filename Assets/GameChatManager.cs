using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class GameChatManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI chatText;
    [SerializeField]
    private GameObject chatBox;

    public GameObject mainCamera;
    public GameObject trashCamera;
    public GameObject shotGunCamera;

    public static void TMPD0Text(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;
        DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration);
    }

    protected IEnumerator Typing(string[] talk, float wait)
    {
        chatBox.SetActive(true);
        GameManager.instance.isStop = true;
        for(int i = 0; i < talk.Length; i++)
        {
            chatText.text = talk[i];
            TMPD0Text(chatText, wait);

            yield return new WaitForSecondsRealtime(wait + 2f);
            chatText.text = null;
        }
        chatBox.SetActive(false);
        GameManager.instance.isStop = false;
        trashCamera.SetActive(false);
        mainCamera.SetActive(true);
    }
}
