using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingDaggerProjectile : Projectile
{
    [SerializeField] float destroyDelay = 1f;
    [SerializeField] private float rotationSpeed = 0.5f;
    [SerializeField] private float upwardsForce = 3f;

    private void Awake()
    {
        ThrowBlade();
        StartCoroutine(DestroyTimer());
        type = "dagger";
    }

    private void ThrowBlade()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * upwardsForce, ForceMode2D.Impulse);
        rb.AddTorque(rotationSpeed, ForceMode2D.Impulse);
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(destroyDelay);

        Destroy(gameObject);
    }
}
