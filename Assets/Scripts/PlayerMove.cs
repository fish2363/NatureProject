using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    PlayerInput playerInput;
    Rigidbody2D rigid;

    PhysicMaterial iuhg;

    [Header("�÷��̾� ����")]
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
            print("�� �����̴� ��");
            rigid.velocity = playerInput.moveDir * moveSpeed;
        }
    }

}
