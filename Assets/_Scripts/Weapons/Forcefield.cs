using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefield : Weapon
{
    private float respawnDelay = 10f;
    public override void LevelUp() 
    {
        switch (level)
        {
            case 0:
                weaponProjectile.GetComponent<ForcefieldProjectile>().SetAttackPower(baseAttackPower);
                weaponProjectile.GetComponent<ForcefieldProjectile>().SetAttackMultiplier(weaponOwner.GetAttackMultiplier());
                weaponProjectile.GetComponent<ForcefieldProjectile>().owner_script = this;
                weaponProjectile.GetComponent<ForcefieldProjectile>().radiusMultiplier = 1f;
                weaponProjectile.GetComponent<ForcefieldProjectile>().destroyDelay = 1f;
                StartCoroutine(Initialize());
                break;
            case 1:
                weaponProjectile.GetComponent<ForcefieldProjectile>().radiusMultiplier = 1.1f;
                weaponProjectile.GetComponent<ForcefieldProjectile>().destroyDelay = 1.1f;
                break;
            case 2:
                respawnDelay -= 2f;
                break;
             case 3:
                weaponProjectile.GetComponent<ForcefieldProjectile>().SetAttackPower(baseAttackPower + 10);
                break;
            case 4:
                weaponProjectile.GetComponent<ForcefieldProjectile>().radiusMultiplier = 1.2f;
                weaponProjectile.GetComponent<ForcefieldProjectile>().destroyDelay = 1.2f;
                break;
            case 5:
                respawnDelay -= 3f;
                break;
            case 6:
                weaponProjectile.GetComponent<ForcefieldProjectile>().SetAttackPower(baseAttackPower + 20);
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

    public void ActivateRespawnWeapon() => StartCoroutine(RespawnWeapon());

    private IEnumerator RespawnWeapon()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnWeapon();
        yield break;
    }
}
