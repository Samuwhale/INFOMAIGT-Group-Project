using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceStaff : Weapon
{
    [SerializeField] private float spawnDistance = 0.5f;
    [SerializeField] private float projectileSpeed = 8f;
    [SerializeField] private int projectileCount = 1;
    private Player playerScript;

    public override void LevelUp()
    {
        switch (level)
        {
            case 0:
                playerScript = gameObject.GetComponent<Player>();
                weaponProjectile.GetComponent<IcicleProjectile>().SetAttackPower(baseAttackPower);
                weaponProjectile.GetComponent<IcicleProjectile>().SetAttackMultiplier(weaponOwner.GetAttackMultiplier());
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
            default:
                break;
        }
        level++;
    }

    private void ShootIcicle()
    {
        Vector3 pos = gameObject.transform.position + new Vector3(0, 0.3f, 0);
        Transform[] enemyPos = playerScript.GetNearestEnemyPosition(projectileCount);
        for (int i = 0; i < enemyPos.Length; i++)
        {
            Vector3 dir = (enemyPos[i].position - transform.position).normalized;
            float rot = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
            GameObject projectile = Instantiate(weaponProjectile, pos + dir * spawnDistance, Quaternion.Euler(0, 0, rot + 90), transform);
            projectile.GetComponent<Rigidbody2D>().velocity = dir * projectileSpeed;
        }
    }

    protected override IEnumerator Initialize()
    {
        while (true)
        {
            ShootIcicle();

            yield return new WaitForSeconds(weaponAttackDelay);
        }
    }
}
