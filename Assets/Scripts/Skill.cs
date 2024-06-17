using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 mousePosition;
    private PlayerMove playerMove;
    private float speed = 1f;
    private float currentAngle;
    private float targetAngle;
    private bool isR;
    [SerializeField] private float angleSpeed;
    Rigidbody2D rigid;

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
        if (playerInput.dash)
        {
            print("µ¹Áø");
            playerInput.moveDir = new Vector3(mousePosition.x, mousePosition.y) - transform.position;

            speed += Time.deltaTime * 1.3f;
            rigid.velocity = playerInput.moveDir.normalized * speed;
            if (mousePosition == new Vector2(transform.position.x, transform.position.y))
            {
                playerInput.EndDash();
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
            speed = 0f;
        }
    }

    private void Daash()
    {
        GameManager.isStop = true;
        playerInput.dash = true;
        Debug.Log(mousePosition * 10f);
        //for(int i = 0; i < 7; i++)
        //rigid.AddForce(mousePosition * 3f);
    }
}
