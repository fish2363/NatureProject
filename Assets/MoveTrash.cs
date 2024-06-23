using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrash : MonoBehaviour
{
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HpManagerSecond.instance.PlayerDamage(3f);
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("TrashDester"))
            Destroy(gameObject);
    }

    public void MoveMe(Vector2 moveDir,float str)
    {
        rigid.velocity = moveDir.normalized * str;
    }
}
