using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeforeChatHelper : GameChatManager
{

    [SerializeField]
    private float duration;

    [SerializeField]
    private GameObject bi;
    [SerializeField]
    private GameObject zehan;

    private string endChat = "���ʿ� ���� �־�    _���� �� ����ִ°� ���ڳ�   ";

    private void Awake()
    {
        trashCamera.SetActive(false);
        mainCamera.SetActive(true);
    }

    private void Start()
    {
        mainCamera.SetActive(false);
        endCamera.SetActive(true);
        zehan.SetActive(false);
        bi.SetActive(false);
        StartCoroutine(Typing(endChat.Split("_"), 2f));
    }
}

