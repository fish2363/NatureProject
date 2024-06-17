using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum BossState { DashToDownAttack = 0,}

public class Boss : MonoBehaviour, IDamage
{
    private bool wait;
    private float time;
    private BossState bossState = BossState.DashToDownAttack;
    private GameObject player;

    [SerializeField]
    private GameObject enemyBullet;


    [Header("샷건 설정값")]
    [SerializeField]
    private int shotGunCount = 7;
    [SerializeField]
    private GameObject shotGunPrefab;
    [SerializeField]
    private List<Transform> spawnPosition;

    [Header("집게 설정값")]
    [SerializeField]
    private Transform grabTrans;
    private SpriteRenderer grabSprite;
    private float grabDuration = 6f;
    [SerializeField]
    private GameObject trashPrefab;


    [Header("보스 기본 설정값")]
    [SerializeField]
    private int pattern = 0;
    [SerializeField]
    private float bossHp = 50000f;
    [SerializeField]
    private float dashDamage = 0f;
    [SerializeField]
    private int minPatternCount;
    [SerializeField]
    private int maxPatternCount;

    private void Awake()
    {
        player = GameObject.Find("Deer");
        grabSprite = GameObject.Find("Grab").GetComponent<SpriteRenderer>();
        HpManager.bossMaxHp = bossHp;
        HpManager.bossCurrentHp = bossHp;
    }

    public void ChangeState(BossState newState)
    {
        StopCoroutine(bossState.ToString());
        bossState = newState;
        StartCoroutine(bossState.ToString());
    }


    public void DashAttack(Collider2D collision)
    {
        dashDamage = 25f;
        if(collision.CompareTag("Player"))
        {
            HpManager.instance.playerHp -= dashDamage;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DashAttack(other);
    }

    public void Damage(float damage)
    {
        HpManager.bossCurrentHp -= damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        //pattern = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        print($"보스 남은 체력 : {bossHp}");
        
        if(!wait)
        {
            switch(pattern)
            {
                case 1:
                    PatternOne();
                    wait = true;
                    break;
                case 2:
                    PatternTwo();
                    wait = true;
                    break;
                case 3:
                    PatternThree();
                    wait = true;
                    break;
            }
        }

    }

    

    private void PatternTwo()
    {
        StartCoroutine(FallGrab());
    }

    private void PatternThree()
    {
        StartCoroutine(DashDamage());
    }

    private void PatternOne()
    {
        StartCoroutine(GunRandSpawn());
    }

    IEnumerator GunRandSpawn()
    {
        while(shotGunCount > 0)
        {
            shotGunCount--;
            int randSpawn = Random.Range(0, spawnPosition.Count);
            Vector2 randomOffset = Random.insideUnitCircle * 3;
            Vector2 spawnPoint = spawnPosition[randSpawn].position + (Vector3)randomOffset;
            GameObject gun = Instantiate(shotGunPrefab, spawnPoint, Quaternion.identity);
            yield return new WaitForSecondsRealtime(1f);
            Destroy(gun);
        }
        shotGunCount = 7;
        print("패턴 끝");
        wait = false;
        yield return new WaitForSecondsRealtime(6f);
        pattern = Random.Range(minPatternCount, maxPatternCount);
    }

    IEnumerator FallGrab()
    {
        grabSprite.DOFade(1, 2);
        GameObject trash = Instantiate(trashPrefab);
        SpriteRenderer trashRender = trash.GetComponent<SpriteRenderer>();
        CapsuleCollider2D trashCollider = trash.GetComponent<CapsuleCollider2D>();
        trashRender.DOFade(1, 2);
        trashCollider.enabled = false;

        while(grabDuration > time)
        {
            grabTrans.SetParent(player.transform);
            trash.transform.position = grabTrans.position;
            trash.transform.SetParent(grabTrans);
            Vector3 playerPos = player.transform.position + new Vector3(0, 3, 0);
            grabTrans.DOMove(playerPos,1);
            time += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        time = 0f;
        grabTrans.DOLocalMoveY(4, 1);
        trash.transform.DOLocalMoveY(1, 2);
        trash.transform.DORotate(new Vector3(0, 1, 0), 1);
        yield return new WaitForSecondsRealtime(2f);
        trash.transform.DOScale(0.7f, 3);
        trash.transform.DOLocalMove(new Vector3(0, -1, 0), 3);
        yield return new WaitForSecondsRealtime(3f);
        grabSprite.DOFade(0, 1);
        trashCollider.enabled = true;
        StartCoroutine(Padong(trash));
    }

    IEnumerator Padong(GameObject trash)
    {
        int     count           = 15;
        float   intervalAngle   = 360 / count;
        float   weightAngle     = 0f;


            for(int i =0; i < count; ++i)
            {
                GameObject clone = Instantiate(enemyBullet, trash.transform.position, Quaternion.identity);
                float angle = weightAngle + intervalAngle * i;
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                clone.GetComponent<Bullet>().MoveTo(new Vector2(x,y));

            }

            weightAngle += 1;

        yield return new WaitForSecondsRealtime(7f);
        trash.GetComponent<SpriteRenderer>().DOFade(0,1);
        yield return new WaitForSecondsRealtime(1f);
        Destroy(trash);
        print("패턴2 끝");
        wait = false;
        pattern = Random.Range(minPatternCount, maxPatternCount);
    }

    IEnumerator DashDamage()
    {
        yield return new WaitForSecondsRealtime(3f);
        gameObject.transform.DOMoveY(10, 3);
        StartCoroutine(Padong(gameObject));
        yield return new WaitForSecondsRealtime(3f);
        gameObject.transform.DOKill(true);
        gameObject.transform.DOMoveY(2, 3);
        yield return new WaitForSecondsRealtime(3f);
        gameObject.transform.DOKill(true);
        gameObject.transform.DOMoveY(10, 3);
        //Padong(gameObject);
        yield return new WaitForSecondsRealtime(3f);
    }
}
