using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float bulletSpeed = 5f;
    private Rigidbody2D rigid;

    private float desiredAngle;
    private GameObject player;
    private SpriteRenderer render;
    private void Awake()
    {
        player = GameObject.Find("Deer");
        render = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemyBullet = Instantiate(bullet);
        enemyBullet.transform.position = transform.position;
        rigid = enemyBullet.GetComponent<Rigidbody2D>();
        Vector2 bulletDirS = player.transform.position - transform.position;
        Bang(bulletDirS);
    }

    private void Bang(Vector2 bulletDirS)
    {
        rigid.velocity = bulletDirS.normalized * bulletSpeed;
    }


    private void Update()
    {
        //Vector2 aimDir = player.transform.position - transform.position;
        //desiredAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);

        render.flipX = transform.position.x > player.transform.position.x;
    }
}
