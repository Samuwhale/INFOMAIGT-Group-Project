using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : Weapon
{
    public GameObject Weapon;

    public override void LevelUp() 
    {
        switch (level)
        {
            case 0:
                // activate weapon: StartCoroutine(Initialize())
                break;
            case 1:
                Weapon.GetComponent<ScytheProjectile>().attack += 5;
                break;
            case 2:
                // increase weapon size
                Weapon.transform.localScale *= 1.2f;
                break;
            case 3:
                Weapon.GetComponent<ScytheProjectile>().instakillChance += 0.02f;
                break;
            case 4:
                Weapon.GetComponent<ScytheProjectile>().attack += 10;
                break;
            case 5:
                Weapon.transform.localScale *= 1.3f;
                break;
            case 6:
                Weapon.GetComponent<ScytheProjectile>().instakillChance += 0.03f;
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
        Instantiate(Weapon, pos + dir, Quaternion.Euler(0, 0, rot + 90), transform);
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
