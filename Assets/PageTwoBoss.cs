using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PageTwoBoss : MonoBehaviour
{
    private float moveSpeed = 5f;

    public static float myHp = 4000f;

    private int randPatturn;

    [SerializeField]TrashSpawner trashSpawner;

    [SerializeField]
    private Transform oneJum;

    [SerializeField]
    private GameObject shotGunSkill;

    [SerializeField]
    int minPatturn = 1;
    [SerializeField]
    int maxPatturn =3;
    [SerializeField]
    private float stoneDamage;

    private void Start()
    {
        randPatturn = Random.Range(minPatturn,maxPatturn);
        StartCoroutine(Patturn(randPatturn));
    }

    private IEnumerator Patturn(int patturn)
    {
        float strengh = Random.Range(2f, 3f);
        float wait = Random.Range(3f, 7f);
        yield return new WaitForSecondsRealtime(wait);

        switch(patturn)
        {
            case 1:
                StartCoroutine(PatturnOne(strengh));
                break;
            case 2:
                StartCoroutine(PatturnTwo(strengh));
                break;
            case 3:
                StartCoroutine(PatturnThree(strengh));
                break;
        }
    }

    public IEnumerator PatturnThree(float str)
    {
        shotGunSkill.SetActive(true);
        yield return new WaitForSecondsRealtime(str);
        randPatturn = Random.Range(minPatturn, maxPatturn);
        StartCoroutine(Patturn(randPatturn));
    }

    public IEnumerator PatturnTwo(float str)
    {
        print("∆–≈œ2");
        yield return new WaitForSecondsRealtime(str + 3f);
        StartCoroutine(trashSpawner.TrashPatturn(str));
        yield return new WaitForSecondsRealtime(str + 3f);
        randPatturn = Random.Range(minPatturn, maxPatturn);
        StartCoroutine(Patturn(randPatturn));
    }

    public IEnumerator PatturnOne(float strengh)
    {
        gameObject.transform.DOMoveY(Random.Range(0.4f,0.7f),  2f);
        yield return new WaitForSecondsRealtime(strengh + 3f);
        gameObject.transform.DOMove(new Vector3(oneJum.transform.position.x,oneJum.transform.position.y,0), 1f);
        yield return new WaitForSecondsRealtime(1f);
        randPatturn = Random.Range(minPatturn, maxPatturn);
        StartCoroutine(Patturn(randPatturn));
    }

    public static void Damage(float damage)
    {
        myHp -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            float spreadAngle = Random.Range(270, -270);
            //Quaternion bulletSpreadRotation = Quaternion.Euler(new Vector3(0, 0, spreadAngle));
            //collision.gameObject.transform.rotation = bulletSpreadRotation;
            collision.gameObject.GetComponent<Stone>().qaung = true;
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
            Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();
            rigid.velocity = new Vector3(0, -1, spreadAngle) * moveSpeed;
            Damage(stoneDamage);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Player"))
                HpManagerSecond.instance.PlayerDamage(1f);

    }
}