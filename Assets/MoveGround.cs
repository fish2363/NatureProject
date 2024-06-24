using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField]
    private float movingSpeed;

    private void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, movingSpeed, 0);

        if(gameObject.transform.position.y > 8)
        {
            transform.position = new Vector3(-2.8f, -15f, 0);
        }
    }
}
