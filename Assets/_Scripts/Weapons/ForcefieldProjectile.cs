using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ForcefieldProjectile : MonoBehaviour
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
        spriteRenderer.transform.RotateAround(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    
    
}