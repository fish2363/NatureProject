using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    public void Damage(float damage);
}

public class HpManager : MonoBehaviour
{
    public static HpManager instance = null;
    public float playerHp = 100f;
    public static event Action OnDeath;

    [SerializeField]
    public static float bossMaxHp;
    public static float bossCurrentHp;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
    }
}
