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

    public void LevelUpWeapon(int weaponID)
    {
        switch (weaponID)
        {
            case 0:
                scythe.LevelUp();
                break;
            case 1:
                forcefield.LevelUp();
                break;
            case 2:
                throwingDagger.LevelUp();
                break;
        }
    }

    public void LevelUpItem(int itemID)
    {

    }

    public int GetWeaponLevel(int weaponID)
    {
        switch (weaponID)
        {
            default:
                return scythe.level;
            case 1:
                return forcefield.level;
            case 2:
                return throwingDagger.level;
        }
    }

    public int GetItemLevel(int itemID)
    {
        return 0;
    }

    public WeaponData GetWeaponData(int weaponID)
    {
        switch (weaponID)
        {
            default:
                return scythe.weaponData;
            case 1:
                return forcefield.weaponData;
            case 2:
                return throwingDagger.weaponData;
        }
    }
}
