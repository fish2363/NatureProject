using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> stonePoint;
    private int randSpwaner;

    [SerializeField]
    private GameObject stone;

    public static Stack<GameObject> bulletPool = new Stack<GameObject>();


    private void Start()
    {
        CreateBulletPool();
        randSpwaner = Random.Range(0, stonePoint.Count);
        StartCoroutine(RandSpwan());
    }

    private IEnumerator RandSpwan()
    {
        int rand = Random.Range(2,4);
        GameObject bully = bulletPool.Pop();
        bully.SetActive(true);
        bully.GetComponent<Collider2D>().isTrigger = false;
        bully.GetComponent<Stone>().qaung = false;
        bully.transform.position = stonePoint[randSpwaner].transform.position;
        yield return new WaitForSecondsRealtime(rand);
        randSpwaner = Random.Range(0, stonePoint.Count);
        StartCoroutine(RandSpwan());
    }


    public void CreateBulletPool()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject bullet = Instantiate(stone);
            bulletPool.Push(bullet);
            bullet.SetActive(false);
        }
    }
}
