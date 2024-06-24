using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IDamage
{
    public void Damage(float damage);
}

public class HpManager : MonoBehaviour
{
    public static HpManager instance;
    public float playerHp = 100f;
    public Action OnDeath;
    protected Image black;
    public Action winBoss;

    [SerializeField]
    public static float bossMaxHp;
    public static float bossCurrentHp;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

    }

    public void PlayerDamage(float damage)
    {
        print("나 아파요 ㅠㅠ");
        playerHp -= damage;
    }

    private void Update()
    {
        if(playerHp < 1)
        {
            OnDeath?.Invoke();
        }
        if(bossCurrentHp < 1)
        {
            winBoss?.Invoke();
        }
    }
}
