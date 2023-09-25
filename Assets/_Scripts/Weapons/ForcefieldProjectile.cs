using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ForcefieldProjectile : MonoBehaviour
{
    [FormerlySerializedAs("speed")] [SerializeField] float rotationSpeed = 30f;
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