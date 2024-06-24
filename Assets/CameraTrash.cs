using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTrash : GameChatManager
{

    [SerializeField]
    private float duration;
    public GameObject cloud;
    private string trashChat = "쓰레기가 길을 막고 있다    _1개정도는 밀 수 있을것 같은데   ";

    private void Awake()
    {
        trashCamera.SetActive(false);
        mainCamera.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            mainCamera.SetActive(false);
            trashCamera.SetActive(true);
            StartCoroutine(Typing(trashChat.Split("_"), 2f));
            cloud.SetActive(true);
        }
    }
}
