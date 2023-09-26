using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase
{
    // SEE BASE CLASS! Lot of things are implemented there (so that the enemies can also inherit from it)

    private Weapon scythe;
    private Weapon forcefield;
    private Weapon throwingDagger;

    protected override void Awake()
    {
        base.Awake();
        scythe = GetComponent<Scythe>();
        
        
        forcefield = GetComponent<Forcefield>();
        
        
        throwingDagger = GetComponent<ThrowingDagger>();
     
    }

    private void Start()
    {
        scythe.Activate();
        forcefield.Activate();
        throwingDagger.Activate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "enemy")
        {
            Enemy _enemy = collision.gameObject.GetComponent<Enemy>();
            TakeDamage(_enemy.GetAttackPower());
        }
    }
}
