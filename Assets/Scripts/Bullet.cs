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
        //Debug.Log($"{collision.name} 나 맞음");
        IDamage damage = collision.GetComponent<IDamage>();

        //if (collision.transform.TryGetComponent(out IDamage damage))
        if (damage != null && gameObject.CompareTag("PlayerBullet"))
        {
            damage.Damage(20.7f);
            Puah();
        }


        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerInput>().dash && gameObject.CompareTag("EnemyBullet"))
                Destroy(gameObject);
            else
            {
                Destroy(gameObject);
                HpManager.instance.PlayerDamage(4f);
                Debug.Log("플레이어 데미지 입음");
            }
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
            if (gameObject.CompareTag("PlayerBullet"))
                Puah();
            else
                Destroy(gameObject);
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
