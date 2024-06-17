using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private float desiredAngle;
    private WeaponRendering weaponRenderer;

    private void Awake()
    {
        weaponRenderer = GetComponentInChildren<WeaponRendering>();
    }
    public void AimWeapon(Vector2 pointerPosition)
    {

        Vector2 aimDir = (Vector3)pointerPosition - transform.position;
        desiredAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
        WeaponRendering();
    }

    public void WeaponRendering()
    {
        weaponRenderer.FilpWeapon(desiredAngle > 90f || desiredAngle < -90);
        weaponRenderer.SortingWeapon(desiredAngle > 0 && desiredAngle < 180);
    }


}
