using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingDagger : Weapon
{
    public GameObject Weapon;

    public override void Attack() { }

    public override void LevelUp()
    {
        switch (level)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
        }
    }

    private void SpawnWeapon()
    {
        Vector3 pos = transform.position;
        Instantiate(Weapon, pos, Quaternion.identity);
    }

    protected override IEnumerator Initialize()
    {
        while (true)
        {
            SpawnWeapon();

            yield return new WaitForSeconds(weaponAttackDelay);
        }
    }
}