using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTree : MonoBehaviour
{
    [SerializeField]
    private bool isLeft;

    [SerializeField]
    private float movingSpeed;

    private void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, movingSpeed, 0);

        if (gameObject.transform.position.y > 9.5f)
        {
            if (isLeft)
                transform.localPosition = new Vector3(-2.19f, -7.65f, 0);
            else
                transform.localPosition = new Vector3(5.65f, -7.68f, 0);
        }
    }

}
