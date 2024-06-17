using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRendering : MonoBehaviour
{
    SpriteRenderer sprite;
    //�̺�Ʈ �̿��ؼ� FaceDir �ذ��ؿ���
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void FaceDir(Vector2 mousePos)
    {
        sprite.flipX = transform.position.x > mousePos.x;
    }
}
