using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hunters;

    private int randShot;

    [SerializeField]
    private GameObject dd;
    [SerializeField]
    private GameObject dd2;
    [SerializeField]
    private GameObject c;
    [SerializeField]
    private GameObject rc;
    [SerializeField]
    private GameObject plCam;
    [SerializeField]
    private GameObject block;
    [SerializeField]
    private GameObject chatHelper;


    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        HunterAttack();
    }

    public void End()
    {
        StopAllCoroutines();
        dd.SetActive(false);
        dd2.SetActive(false);
        rc.SetActive(false);
        c.SetActive(true);
        plCam.SetActive(false);
        block.SetActive(false);
        chatHelper.SetActive(true);
    }

    private void HunterAttack()
    {

            randShot = Random.Range(0, hunters.Length);
            print(randShot);
            hunters[randShot]?.GetComponent<Hunter>().Shot();
            int randWait = Random.Range(1, 3);
            StartCoroutine(Wait(randWait));
    }
    private IEnumerator Wait(int wait)
    {
        yield return new WaitForSecondsRealtime(wait);
        HunterAttack();
    }
}
