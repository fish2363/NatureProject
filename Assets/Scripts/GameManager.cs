using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isStop = false;
    public static GameObject player;
    public Rigidbody2D playerRigid;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        player = GameObject.Find("Deer");
        playerRigid = GameObject.Find("Deer").GetComponent<Rigidbody2D>();
    }
}
