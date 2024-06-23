using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Lever : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private PlayableDirector director;
    [SerializeField]
    private GameObject trashs;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Trash"))
        {
            animator.SetBool("On", true);
            director.Play();
            trashs.GetComponent<Collider2D>().enabled = false;
        }
    }
}
