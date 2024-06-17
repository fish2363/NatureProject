using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    PlayerInput playerInput;
    Rigidbody2D rigid;

    [Header("플레이어 스탯")]
    [SerializeField]
    private float moveSpeed = 5f;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        if(!GameManager.isStop)
            rigid.velocity = playerInput.moveDir * moveSpeed;
    }

}
