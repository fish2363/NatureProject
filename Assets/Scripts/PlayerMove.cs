using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    PlayerInput playerInput;
    Rigidbody2D rigid;

    PhysicMaterial iuhg;

    [Header("플레이어 스탯")]
    [SerializeField]
    private float moveSpeed = 5f;

    public bool canMove = true;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        if(!GameManager.instance.isStop)
        {
            print("나 움직이는 중");
            rigid.velocity = playerInput.moveDir * moveSpeed;
        }
    }

}
