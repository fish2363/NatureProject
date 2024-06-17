using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static bool isStop = false;
    public static GameObject player;
    public static Rigidbody2D playerRigid;

    private void Awake()
    {
        if(instance = null)
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
