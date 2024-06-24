using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTrash : GameChatManager
{

    [SerializeField]
    private float duration;
    public GameObject cloud;
    private string trashChat = "�����Ⱑ ���� ���� �ִ�    _1�������� �� �� ������ ������   ";

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
