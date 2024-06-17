using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRendering : MonoBehaviour
{
    public int sortingLayer = 0;
    SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public void FilpWeapon(bool value)
    {
        int flip = (value ? -1 : 1);

        transform.localScale = new Vector3(transform.localScale.x,
            flip * Mathf.Abs(transform.localScale.y), transform.localScale.z);
    }

    public void SortingWeapon(bool value)
    {
        sprite.sortingOrder = sortingLayer + (value ? -1 : 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SortingWeapon(true);
        }
    }
}
