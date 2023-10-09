using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheProjectile : Projectile
{
    [SerializeField] float destroyDelay = 1f;
    const float speed = 500f;
    [SerializeField] float _instakillChance = 0f;

    private void Awake()
    {
        StartCoroutine(DestroyTimer());
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, -1f), speed * Time.deltaTime);
    }

    public override int GetAttackPower() 
    {
        if (Random.Range(0f, 1f) < _instakillChance)
            return 99999999;
        return base.GetAttackPower(); 
    }

    public void SetInstaKillChance(float chance)
    {
        _instakillChance = chance;
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(destroyDelay);

        Destroy(gameObject);
    }
}
