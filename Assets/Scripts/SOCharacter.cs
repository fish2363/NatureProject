using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewCharacter", menuName ="SO/Character")]
public class SOCharacter : ScriptableObject
{
    //[field: Range(0, 100)]
    //public int ammoCapacity;
    public int damage;
    public float coolTime;
    public Sprite character;
    public string weaponType;

    public float spreadAngle;

    public int GetBulletCountToSpawn()
    {
        if (weaponType == "Deer")
            return 5;
        else
            return 1;
    }
}
