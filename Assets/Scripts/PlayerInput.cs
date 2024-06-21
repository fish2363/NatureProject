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
    private bool dead;
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GameObject.Find("Sprite").GetComponent<Animator>();
    }

    private void Start()
    {
        HpManager.OnDeath += Death;
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
        Vector2 mouseXY = Camera.main.ScreenToWorldPoint(Input.mousePosition);//스크린을 월드 좌표계로 바꾼다
        MouseXY?.Invoke(mouseXY);


    }

    public void GetFireInput()
    {

        if (Input.GetButton("Fire1"))
            OnFireButtonPressed?.Invoke();
        else if (Input.GetButtonUp("Fire1"))
            OnFireButtonReleased?.Invoke();
        else if (Input.GetKeyDown(KeyCode.R) && dash == false)
            OnDash?.Invoke();

    }

    private void MoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
            animator.SetBool("Walk", true);
        else
            animator.SetBool("Walk", false);


        moveDir = new Vector2(x, y).normalized;
    }
}
