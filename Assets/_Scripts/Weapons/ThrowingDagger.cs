using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingDagger : Weapon
{
    public override void LevelUp()
    {
        switch (level)
        {
            case 0:
                weaponProjectile.transform.localScale = new Vector3(1, 1, 1);
                weaponProjectile.GetComponent<ThrowingDaggerProjectile>().SetAttackPower(baseAttackPower);
                weaponProjectile.GetComponent<ThrowingDaggerProjectile>().SetAttackMultiplier(weaponOwner.GetAttackMultiplier());
                StartCoroutine(Initialize());
                break;
            case 1:
                weaponAttackDelay -= 0.5f;
                break;
            case 2:
                weaponProjectile.transform.localScale = new Vector3(1.5f, 1.5f, 1);
                break;
            case 3:
                weaponProjectile.GetComponent<ThrowingDaggerProjectile>().SetAttackPower(baseAttackPower + baseAttackPower);
                break;
            case 4:
                weaponAttackDelay -= 0.5f;
                break;
            case 5:
                weaponProjectile.transform.localScale = new Vector3(2, 2, 1);
                break;
            case 6:
                weaponAttackDelay -= 0.5f;
                break;
            default: 
                break;
        }
        level++;
    }

    private void SpawnWeapon()
    {
        Vector3 pos = transform.position;
        Instantiate(weaponProjectile, pos, Quaternion.identity);
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