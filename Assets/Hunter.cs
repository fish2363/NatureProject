using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Hunter : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyBullet;

    [SerializeField]
    private GameObject gun;

    private GameObject player;
    private Vector2 playerPos;
    [SerializeField]
    private float bulletSpeed;

    public static float myHp = 200f;

    [SerializeField]
    private HunterBoss hun;

    Rigidbody2D bulletRigid;



    //public UnityEvent<Vector2> rotate;

    private void Awake()
    {
        player = GameObject.Find("Deer");
    }

    private void Update()
    {
        if(myHp < 1)
        {
            gameObject.GetComponent<SpriteRenderer>().DOFade(0, 1);
            StartCoroutine(DestroyMe());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
            myHp -= 2f;
    }

    public void Shot()
    {
        GameObject bullet = Instantiate(enemyBullet, transform.position, transform.rotation);
        playerPos = new Vector2(player.transform.position.x, player.transform.position.y) - new Vector2(transform.position.x, transform.position.y);
        bulletRigid = bullet.GetComponent<Rigidbody2D>();
        BBang();
    }

    private void BBang()
    {
        bulletRigid.velocity = playerPos.normalized * bulletSpeed;
        print("Èû Áá¾î¿ë");
    }

    private IEnumerator DestroyMe()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        hun.End();
        Destroy(gameObject);
    }
}