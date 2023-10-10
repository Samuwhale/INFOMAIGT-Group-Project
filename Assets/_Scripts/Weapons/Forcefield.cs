using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefield : Weapon
{
    public override void LevelUp() 
    {
        switch (level)
        {
            case 0:
                weaponProjectile.GetComponent<ForcefieldProjectile>().SetAttackPower(baseAttackPower);
                weaponProjectile.GetComponent<ForcefieldProjectile>().SetAttackMultiplier(1f);
                StartCoroutine(Initialize());
                break;
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
        level++;
    }

    private void SpawnWeapon()
    {
        Vector3 pos = gameObject.transform.position;
        Instantiate(weaponProjectile, pos, Quaternion.identity, transform);
    }

    protected override IEnumerator Initialize()
    {
        SpawnWeapon();
        yield break;
    }
}
