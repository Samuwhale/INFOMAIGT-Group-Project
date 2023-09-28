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

    private Item shield, cheese, boots;

    public gameoverscreen gameoverscreen;

    public bool isAlive;

    protected override void Awake()
    {
        base.Awake();
        scythe = GetComponent<Scythe>();
        forcefield = GetComponent<Forcefield>();   
        throwingDagger = GetComponent<ThrowingDagger>();

        shield = GetComponent<Shield>();
        cheese = GetComponent<Cheese>();
        boots = GetComponent<Boots>();
    }

    private void Start()
    {
        scythe.Activate();
        forcefield.Activate();
        throwingDagger.Activate();

        shield.Activate();
        cheese.Activate(); 
        boots.Activate();

        isAlive = true;
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
        switch (itemID)
        {
            case 0:
                shield.LevelUp();
                break;
            case 1:
                cheese.LevelUp();
                break;
            case 2:
                boots.LevelUp();
                break;
        }
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
        switch (itemID)
        {
            default:
                return shield.level;
            case 1:
                return cheese.level;
            case 2:
                return boots.level;
        }
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

    public ItemData GetItemData(int itemID)
    {
        switch (itemID)
        {
            default:
                return shield.itemData;
            case 1:
                return cheese.itemData;
            case 2:
                return boots.itemData;
        }
    }

    public override void Die()
    {
        isAlive = false;
        gameoverscreen.Setup();
    }
}
