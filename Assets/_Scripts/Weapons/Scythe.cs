using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : Weapon
{
    public GameObject Weapon;
    
    public override void Attack()
    {

    }

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
        Vector3 pos = gameObject.transform.position;
        // Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (Vector3)GetComponent<PlayerMovement>().LastPlayerDirection;
        float rot = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
        Instantiate(Weapon, pos + dir, Quaternion.Euler(0, 0, rot + 90));
    }

    protected override IEnumerator Initialize()
    {
        while (true)
        {
            SpawnWeapon();

            yield return new WaitForSeconds(weaponAttackSpeed);
        }
    }
}
