using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public bool qaung =false;

    [SerializeField]
    private float movingSpeed;

    [SerializeField]
    private float returnDamage;

    private void Start()
    {
        qaung = false;
    }

    void FixedUpdate()
    {
        if(!qaung)
            gameObject.transform.position += new Vector3(0, movingSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            HpManagerSecond.instance.PlayerDamage(returnDamage);
            Pop();
        }
        if (collision.CompareTag("Wall"))
        {
            Pop();
        }
    }

    private void Pop()
    {
        gameObject.SetActive(false);
        Spawner.bulletPool.Push(gameObject);
        qaung = false;
    }
}
