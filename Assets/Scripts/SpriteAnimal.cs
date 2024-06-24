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
        Vector2 dir = mouse - (Vector2)transform.root.position;
        sprite.flipX = dir.x > 0;
    }
}
