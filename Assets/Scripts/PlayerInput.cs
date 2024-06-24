using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public Vector2 moveDir { get; set; }
    public UnityEvent<Vector2> MouseXY;
    public event Action OnFireButtonPressed;
    public event Action OnFireButtonReleased;
    public event Action OnDash;
    public bool dash = false;
    public GameObject player;
    private Animator animator;
    private Animator animator2;
    private bool dead;
    private Rigidbody2D rigid;
    public static bool dashCoolTime;
    [SerializeField]
    private bool pageSecond;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        if(!pageSecond)
            animator = GameObject.Find("Sprite").GetComponent<Animator>();
        else
            animator2 = GameObject.Find("Sprite").GetComponent<Animator>();
    }

    private void Start()
    {
        if(pageSecond)
            HpManagerSecond.OnDeathSecond += DeathSecond;
        else
            HpManager.instance.OnDeath += Death;

    }

    private void DeathSecond()
    {
        animator2.SetBool("Death", true);
        dead = true;
        moveDir = Vector2.zero;
    }

    private void Death()
    {
        animator.SetBool("Death", true);
        dead = true;
        moveDir = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pageSecond)
            animator.SetBool("Dash", dash);

        

        if(!dead)
        {
            MoveInput();
            GetFireInput();
            GetPointer();
        }
    }

    public void GetPointer() //마우스 좌표 방지
    {
        Vector2 mouseXY = Camera.main .ScreenToWorldPoint(Input.mousePosition);//스크린을 월드 좌표계로 바꾼다
        MouseXY?.Invoke(mouseXY);
    }

    public void GetFireInput()
    {

        if (Input.GetButton("Fire1"))
            OnFireButtonPressed?.Invoke();
        else if (Input.GetButtonUp("Fire1"))
            OnFireButtonReleased?.Invoke();

        if(!pageSecond)
        {
            if (Input.GetKeyDown(KeyCode.R) && dash == false && !dashCoolTime)
            {
                OnDash?.Invoke();
                dashCoolTime = true;
            }
        }

    }

    private void MoveInput()
    {
        if(GameManager.instance.isStop)
        {
            moveDir = Vector2.zero;

            if (!pageSecond)
                animator.SetBool("Walk", false);
        }
        else if(!dash)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if (!pageSecond)
            {
                if (x != 0 || y != 0)
                    animator.SetBool("Walk", true);
                else
                    animator.SetBool("Walk", false);
            }


            moveDir = new Vector2(x, y).normalized;
        }
    }
}
