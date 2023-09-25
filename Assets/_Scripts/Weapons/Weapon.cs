using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int baseAttackPower;
    [SerializeField] protected float baseAttackSpeed;
    protected int weaponAttackPower;
    protected float weaponAttackSpeed;

    CharacterBase weaponOwner;
    
    public int GetWeaponAttackPower() => weaponAttackPower;
    public float GetWeaponAttackSpeed() => weaponAttackSpeed;
    

    protected int level;

    private void Awake()
    {
        weaponOwner = GetComponent<CharacterBase>();
        level = 1;
        weaponAttackPower = weaponOwner.GetAttackPower() + baseAttackPower;
        weaponAttackSpeed = weaponOwner.GetAttackSpeed() + baseAttackSpeed;
    }

    public virtual void Attack() { }
    public virtual void LevelUp() { }

    public void Activate()
    {
        StartCoroutine(Initialize());
    }

    protected abstract IEnumerator Initialize();
}
