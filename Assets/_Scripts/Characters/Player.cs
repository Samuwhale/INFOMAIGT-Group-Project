using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase
{
    // SEE BASE CLASS! Lot of things are implemented there (so that the enemies can also inherit from it)

    Weapon scythe;
    Weapon forcefield;

    protected override void Awake()
    {
        base.Awake();
        scythe = GetComponent<Scythe>();
        scythe.Activate();
        
        forcefield = GetComponent<Forcefield>();
        forcefield.Activate();
    }
}
