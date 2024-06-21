using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private PlayerInput input;
    private bool isShooting = false;
    private bool isCooltime;
    public Stack<GameObject> bulletPool = new Stack<GameObject>();
    private int bulletCount = 30;
    private Vector2 bulletDir;
    private float bulletSpeed = 15f;
    private Rigidbody2D bulletRigid;
    
    [SerializeField] private GameObject bullPrefab;
    [SerializeField] private SOCharacter characterWeapon;
    [SerializeField] private Transform muzzle;

    [Header("Camera Shake")]
    //private CameraShakeController cameraShake;

    [SerializeField] private float shakeIntensity = 5;
    [SerializeField] private float shakeTime = 1;

    private void Awake()
    {
        //cameraShake = FindAnyObjectByType<CameraShakeController>();
        input = FindAnyObjectByType<PlayerInput>();
    }

    private void OnEnable()
    {
        input.OnFireButtonPressed += TryShooting;
        input.OnFireButtonReleased += StopShooting;
    }

    private void Update()
    {
        FireWeapon();
        

        if(isShooting && bulletPool.Count < 6)
        {
            isShooting = false;
            StartCoroutine(DelayNextShootCoroutine());
        }
    }

    private void FireWeapon()
    {
        if(isShooting && !(isCooltime))
        {
            for (int i = 0; i < characterWeapon.GetBulletCountToSpawn(); i++)
                ShootBullet();
            FinishShooting();
        }
    }

    private void ShootBullet()
    {
        float spreadAngle = UnityEngine.Random.Range(-characterWeapon.spreadAngle, characterWeapon.spreadAngle);
        Quaternion bulletSpreadRotation = Quaternion.Euler(new Vector3(0, 0, spreadAngle));
        GameObject bullet = bulletPool.Pop();
        bullet.transform.SetLocalPositionAndRotation(muzzle.position, muzzle.rotation * bulletSpreadRotation);
        bulletRigid = bullet.GetComponent<Rigidbody2D>();
        bullet.SetActive(true);
        Bang(bullet);
        //cameraShake.ShakeCamera(shakeIntensity, shakeTime);
    }

    public void MouseXY(Vector2 mouseXY)
    {
        bulletDir = mouseXY - new Vector2(transform.position.x, transform.position.y);
        bulletDir = bulletDir.normalized;
    }

    private void Bang(GameObject bullet)
    {
        bulletRigid.velocity = bullet.transform.right * bulletSpeed;
    }

    private void FinishShooting()
    {
        StartCoroutine(DelayNextShootCoroutine());
        isShooting = false;
    }

    private IEnumerator DelayNextShootCoroutine()
    {
        isCooltime = true;
        yield return new WaitForSecondsRealtime(characterWeapon.coolTime);
        isCooltime = false;
    }

    private void TryShooting()
    {
        if (!(input.dash))
        {
            isShooting = true;
        }
    }

    private void StopShooting()
    {
        isShooting = false;
    }

    private void Start()
    {
        CreateBulletPool();
    }

    public void CreateBulletPool()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bullPrefab);
            bulletPool.Push(bullet);
            bullet.SetActive(false);
        }
    }
}
