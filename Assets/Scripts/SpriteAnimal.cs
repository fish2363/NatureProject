using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimal : MonoBehaviour
{
    private SpriteRenderer sprite;


    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Filp(Vector2 mouse)
    {
        sprite.flipX = (mouse.x > 0) ? true : false;
    }
}
