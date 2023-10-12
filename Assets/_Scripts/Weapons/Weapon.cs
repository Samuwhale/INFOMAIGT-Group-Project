using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject weaponProjectile;

    [SerializeField] protected int baseAttackPower;
    [FormerlySerializedAs("baseAttackSpeed")] [SerializeField] protected float baseAttackDelay;
    protected int weaponAttackPower;
    protected float weaponAttackDelay;

    protected CharacterBase weaponOwner;
    
    public int GetWeaponAttackPower() => weaponAttackPower;
    public float GetWeaponAttackSpeed() => weaponAttackDelay;
    
    public int level;
    public WeaponData weaponData;

    private void Awake()
    {
        level = 0;
    }

    private void InitializeWeaponValues()
    {
        weaponOwner = GetComponent<CharacterBase>();
        
        // the higher the attack power of the owner, the higher the weapon power.
        weaponAttackPower = weaponOwner.GetAttackPower() + baseAttackPower;
        
        // the higher the attack speed (base of 100) of the owner, the lower the delay.
        // (200 attack speed in owner = 50% of original delay)
        // the weapon base attack speed is in seconds. So a weapon attack speed of 5 = 5 seconds in between attacks.
        weaponAttackDelay = Mathf.Clamp(baseAttackDelay * 100/weaponOwner.GetAttackSpeed(), 0.1f, 100f);
    }

    public virtual void IncreaseAttackMultiplier(float multiplier)
    {
        weaponProjectile.GetComponent<Projectile>().SetAttackMultiplier(multiplier);
    }

    public abstract void LevelUp();

    public void Activate()
    {
        InitializeWeaponValues();
        
        Debug.Log($"Weapon {this} activated, with attack power {weaponAttackPower} and attack delay {weaponAttackDelay}");
    }

    protected abstract IEnumerator Initialize();
}
