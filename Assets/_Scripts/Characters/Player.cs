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
    public Measures measures;
    public List<Transform> enemyList; // Somehow it breaks if it is not public

    public bool isAlive;
    [SerializeField] private float invinsibleTime = 0.1f;
    private bool invinsible = false;

    protected override void Awake()
    {
        base.Awake();
        weapons = new List<Weapon>
        {
            GetComponent<Scythe>(),
            GetComponent<Forcefield>(),
            GetComponent<ThrowingDagger>(),
            GetComponent<IceStaff>()
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

    public void AddEnemyPos(Transform transform) => enemyList.Add(transform);

    public void RemoveEnemyPos(Transform transform) => enemyList.Remove(transform);

    public Transform[] GetNearestEnemyPosition(int amount)
    {
        if (amount > enemyList.Count)
            return enemyList.ToArray();

        return enemyList.OrderBy(t => (t.position - transform.position).sqrMagnitude)
                        .Take(amount)
                        .ToArray();
    }

    public override void TakeDamage(int damage)
    {
        if (invinsible)
            return;

        base.TakeDamage(damage);
        measures.DamageTaken += damage;
        StartCoroutine(InvinsibleTime());

        Debug.Log("Took " + damage + " damage");
    }

    public override void Die()
    {
        isAlive = false;
        gameoverscreen.Setup();
        measures.WriteFile();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Enemy _enemy = collision.gameObject.GetComponent<Enemy>();
            int damage = _enemy.GetAttackPower() - (_defencePower / 10);
            TakeDamage(Mathf.Max(0, damage));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy weapon")
        {
            Egg _egg = collision.gameObject.GetComponent<Egg>();
            int damage = _egg.GetAttackPower() - (_defencePower / 10);
            TakeDamage(Mathf.Max(0, damage));
            Destroy(_egg);
        }
    }

    IEnumerator InvinsibleTime()
    {
        invinsible = true;
        yield return new WaitForSeconds(invinsibleTime);
        invinsible = false;
    }
}
