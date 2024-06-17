using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Weapon weapon;
    [SerializeField] private float deathTime = 4f;
    private float timer;
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        weapon = FindAnyObjectByType<Weapon>();
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{collision.name} 시발 나 쳐맞음");
        IDamage damage = collision.GetComponent<IDamage>();

        //if (collision.transform.TryGetComponent(out IDamage damage))
        if (damage != null)
        {
            damage.Damage(20.7f);
            if (gameObject.CompareTag("PlayerBullet"))
            {
                Puah();
            }
            else
                Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            HpManager.instance.PlayerDamage(4f);
            Debug.Log("kjhgfc");
        }

        if (collision.CompareTag("DestroyBullet"))
        {
            if(gameObject.CompareTag("PlayerBullet"))
            {
                Puah();
            }
            else
                Destroy(gameObject);

        }
        else if(timer > deathTime)
        {
            Puah();
        }
    }

    public void MoveTo(Vector2 move)
    {
        rigid.velocity = move * 3f;
    }

    private void Puah()
    {
        gameObject.SetActive(false);
        weapon.bulletPool.Push(gameObject);
        timer = 0f;
    }

}
