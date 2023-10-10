using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : CharacterBase
{
    // SEE BASE CLASS! Lot of things are implemented there (so that the enemies can also inherit from it)

    private List<Weapon> weapons;
    private List<Item> items;

    public gameoverscreen gameoverscreen;

    public bool isAlive;

    protected override void Awake()
    {
        base.Awake();
        weapons = new List<Weapon>
        {
            GetComponent<Scythe>(),
            GetComponent<Forcefield>(),
            GetComponent<ThrowingDagger>()
        };
        items = new List<Item>
        {
            GetComponent<Shield>(),
            GetComponent<Cheese>(),
            GetComponent<Boots>()
        };
    }

    private void Start()
    {
        foreach (var weapon in weapons)
        {
            weapon.Activate();
        }
        foreach (var item in items)
        {
            item.Activate();
        }
        weapons[0].LevelUp(); // Start with one weapon

        isAlive = true;
    }

    public override void IncreaseAttackPower(int amount)
    {
        _attackPower += amount;
        
        float multiplier = _attackPower / _initialAttackPower;
        foreach (Weapon weapon in weapons)
        {
            weapon.IncreaseAttackMultiplier(multiplier);
        }
    }

    public List<Weapon> GetWeaponList()
    {
        return weapons;
    }

    public void LevelUpWeapon(int weaponID)
    {
        weapons[weaponID].LevelUp();
    }

    public void LevelUpItem(int itemID)
    {
        items[itemID].LevelUp();
    }

    public int GetWeaponLevel(int weaponID)
    {
        return weapons[weaponID].level;
    }

    public int GetItemLevel(int itemID)
    {
        return items[itemID].level;
    }

    public WeaponData GetWeaponData(int weaponID)
    {
        return weapons[weaponID].weaponData;
    }

    public ItemData GetItemData(int itemID)
    {
        return items[itemID].itemData;
    }

    public override void Die()
    {
        isAlive = false;
        gameoverscreen.Setup();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Enemy _enemy = collision.gameObject.GetComponent<Enemy>();
            TakeDamage(_enemy.GetAttackPower());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy weapon")
        {
            TakeDamage(10);
            Debug.Log("Took projectile damage, base 10");
        }
    }
}
