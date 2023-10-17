using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ForcefieldProjectile : Projectile
{
    [SerializeField] float rotationSpeed = 0.5f;
    private SpriteRenderer spriteRenderer;
    public Forcefield owner_script;
    public float destroyDelay = 1f;
    bool exploding = false;
    public float radiusMultiplier = 1f;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        type = "forcefield";
    }

    private void Update()
    {
        // rotate sprite
        spriteRenderer.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        if (exploding)
            transform.localScale *= 1 + Time.deltaTime * radiusMultiplier;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "enemy" && !exploding)
        {
            owner_script.ActivateRespawnWeapon();
            exploding = true;
            StartCoroutine(DestroyTimer());
        }
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(destroyDelay);

        Destroy(gameObject);
    }
}