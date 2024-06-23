using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHunter : MonoBehaviour
{

    private float timer;
    [SerializeField] private float bulletDeathTime = 4f;


    private void Update()
    {
        if (timer > bulletDeathTime)
            Destroy(gameObject);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HpManager.instance.PlayerDamage(4f);
            Debug.Log("플레이어 데미지 입음");
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
    }
}
