using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ForcefieldProjectile : Projectile
{
    [SerializeField] float rotationSpeed = .5f;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        // rotate sprite
        spriteRenderer.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}