using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 mousePosition;
    private PlayerMove playerMove;
    private float speed = 3f;
    private float currentAngle;
    private float targetAngle;
    private bool isR;
    [SerializeField] private float angleSpeed;
    Rigidbody2D rigid;

    [SerializeField] private Vector2 boxSize;
    [SerializeField] private LayerMask whatIsWall;

    void Start()
    {
        playerInput.OnDash += Daash;
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerMove = GetComponent<PlayerMove>();
        playerInput = GetComponent<PlayerInput>();
    }

    public void Dash(Vector2 mouse)
    {
        mousePosition = mouse;
    }

    private void Update()
    {
        Dashing();

        Collider2D[] DashDefenser = Physics2D.OverlapBoxAll(gameObject.transform.position, boxSize, 0, whatIsWall);
        if (DashDefenser.Length != 0)
        {
            for(int i = 0; i < DashDefenser.Length; i++)
            {
                if(DashDefenser[i].gameObject.CompareTag("Boss"))
                {
                    print("돌진 박음");
                    //보스 데미지 추가
                    StartCoroutine(EndDash());
                }
                else
                    StartCoroutine(EndDash());
            }
            print($"{DashDefenser[0].name} : name");
            print($"{DashDefenser.Length} : Count");

        }
    }

    public IEnumerator EndDash()
    {
        playerInput.dash = false;
        rigid.AddForce(-mousePosition.normalized * 2f, ForceMode2D.Impulse);
        yield return new WaitForSecondsRealtime(0.2f);
        GameManager.instance.isStop = false;
        //GameManager.instance.playerRigid.AddForce
    }

    void OnDrawGizmos() // 범위 그리기
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxSize);/*
        Gizmos.DrawWireSphere(transform.position, 4f);*/
    }

    private void Dashing()
    {
        if (playerInput.dash)
        {
            playerInput.moveDir = new Vector3(mousePosition.x, mousePosition.y) - transform.position;

            speed += Time.deltaTime * 2f;
            rigid.velocity = playerInput.moveDir.normalized * speed;
            if (speed > 12)
            {
               StartCoroutine(EndDash());
            }
            //////Vector2 angle = new Vector3(mousePosition.x, mousePosition.y) - transform.position;

            //////targetAngle = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg;

            //////isR = targetAngle < 0 ? true : false;

            //////if (targetAngle > transform.eulerAngles.z && !isR)
            //////{
            //////    transform.localEulerAngles += new Vector3(0, 0, angleSpeed);
            //////}
            //////if (targetAngle > transform.eulerAngles.z && isR)
            //////{
            //////    transform.localEulerAngles -= new Vector3(0, 0, angleSpeed);
            //////}

            //currentAngle = transform.localEulerAngles.z;

            //if (currentAngle < targetAngle)
            //{
            //    transform.localEulerAngles += new Vector3(0, 0, angleSpeed * Time.deltaTime);
            //}
            //if (currentAngle < targetAngle)
            //{
            //    transform.localEulerAngles -= new Vector3(0, 0, angleSpeed * Time.deltaTime);
            //}
        }
        else
        {
            speed = 3f;
        }
    }

    private void Daash()
    {
        GameManager.instance.isStop = true;
        playerInput.dash = true;
        //for(int i = 0; i < 7; i++)
        //rigid.AddForce(mousePosition * 3f);
    }
}
