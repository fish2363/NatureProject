using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstChat : GameChatManager
{

    [SerializeField]
    private float duration;
    public GameObject cloud;
    private string trashChat = "또 깊숙한 곳까지 와버렸네..    _분명히 놈들이 이곳에 나왔다고 했었는데? _ 좀 더 가보자  ";

    private void Start()
    {
            GameManager.instance.isStop = true;
            StartCoroutine(Typing(trashChat.Split("_"), 3f));
    }
}

