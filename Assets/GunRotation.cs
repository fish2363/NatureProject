using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    private float desiredAngle;

    public void AimWeapon(Vector2 playerPos)
    {
        Vector2 aimDir = (Vector3)playerPos - transform.position;
        desiredAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
        FilpWeapon(desiredAngle > 90f || desiredAngle < -90);
    }

    public void FilpWeapon(bool value)
    {
        int flip = (value ? -1 : 1);

        transform.localScale = new Vector3(transform.localScale.x,
            flip * Mathf.Abs(transform.localScale.y), transform.localScale.z);
    }

}
