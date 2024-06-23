using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotShotGun : MonoBehaviour
{
    [SerializeField]
    private int bulletCount;
    [SerializeField]
    private GameObject bulletPre;

    [SerializeField]
    private GameObject player;

    private Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ThreeShot());
    }

    private IEnumerator ThreeShot()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float spreadAngle = Random.Range(-40, 40);
            Quaternion bulletSpreadRotation = Quaternion.Euler(new Vector3(0, 0, spreadAngle));
            GameObject bullet = Instantiate(bulletPre);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.SetLocalPositionAndRotation(gameObject.transform.position, gameObject.transform.rotation * bulletSpreadRotation);

            moveDir = player.transform.position - transform.position;

            rigid.velocity = moveDir.normalized * 3f;
            yield return new WaitForSecondsRealtime(0.2f);
        }
        gameObject.SetActive(false);
    }
}
