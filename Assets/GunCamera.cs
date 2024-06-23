using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCamera : GameChatManager
{
    [SerializeField]
    private float duration;

    private string trashChat = "사냥꾼의 총인가?    _어떻게 됐을지 알게 뭐야? _앞으로 이게 필요하겠어   ";

    private void Awake()
    {
        shotGunCamera.SetActive(false);
        mainCamera.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mainCamera.SetActive(false);
            shotGunCamera.SetActive(true);
            StartCoroutine(Typing(trashChat.Split("_"), 2f));
        }
    }
}
