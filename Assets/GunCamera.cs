using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCamera : GameChatManager
{
    [SerializeField]
    private float duration;

    private string trashChat = "��ɲ��� ���ΰ�?    _��� ������ �˰� ����? _������ �̰� �ʿ��ϰھ�   ";

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
