using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstChat : GameChatManager
{

    [SerializeField]
    private float duration;
    public GameObject cloud;
    private string trashChat = "�� ����� ������ �͹��ȳ�..    _�и��� ����� �̰��� ���Դٰ� �߾��µ�? _ �� �� ������  ";

    private void Start()
    {
            GameManager.instance.isStop = true;
            StartCoroutine(Typing(trashChat.Split("_"), 3f));
    }
}

