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
        scythe.Activate();
        
        forcefield = GetComponent<Forcefield>();
        forcefield.Activate();
        
        throwingDagger = GetComponent<ThrowingDagger>();
        throwingDagger.Activate();
        
        
    }
}
