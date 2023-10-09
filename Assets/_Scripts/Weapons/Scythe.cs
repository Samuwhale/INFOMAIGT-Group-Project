using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : Weapon
{
    public override void LevelUp() 
    {
        switch (level)
        {
            case 0:
                weaponProjectile.transform.localScale = new Vector3(5, 5, 1);
                weaponProjectile.GetComponent<ScytheProjectile>().SetAttackPower(10);
                StartCoroutine(Initialize());
                break;
            case 1:
                weaponProjectile.GetComponent<ScytheProjectile>().SetAttackPower(15);
                break;
            case 2:
                // increase weapon size
                weaponProjectile.transform.localScale = new Vector3(6, 6, 1);
                break;
            case 3:
                weaponProjectile.GetComponent<ScytheProjectile>().SetInstaKillChance(0.02f);
                break;
            case 4:
                weaponProjectile.GetComponent<ScytheProjectile>().SetAttackPower(25);
                break;
            case 5:
                // increase weapon size
                weaponProjectile.transform.localScale = new Vector3(8, 8, 1);
                break;
            case 6:
                weaponProjectile.GetComponent<ScytheProjectile>().SetInstaKillChance(0.05f);
                break;
            default:
                break;
        }
        level++;
    }

    private void SpawnWeapon()
    {
        Vector3 pos = gameObject.transform.position;
        // Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (Vector3)GetComponent<PlayerMovement>().LastPlayerDirection;
        float rot = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
        Instantiate(weaponProjectile, pos + dir, Quaternion.Euler(0, 0, rot + 90), transform);
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
