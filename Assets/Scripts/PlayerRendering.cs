using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRendering : MonoBehaviour
{
    SpriteRenderer sprite;
    //이벤트 이용해서 FaceDir 해결해오기
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void FaceDir(Vector2 mousePos)
    {
        sprite.flipX = transform.position.x > mousePos.x;
    }
}
