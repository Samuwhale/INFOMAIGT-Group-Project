using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    protected int _maxHealth;
    protected int _currentHealth;
    public int _attackPower;
    protected int _attackSpeed;
    protected int _defencePower;
    public float _movementSpeed;

    public HP_Bar hp_bar;
    
    [SerializeField] protected int _initialHealth = 100;
    [SerializeField] protected int _initialAttackPower = 100;
    [SerializeField] protected int _initialAttackSpeed = 100;
    [SerializeField] protected int _initialDefencePower = 100;
    [SerializeField] protected int _initialMovementSpeed = 2500;


    protected virtual void Awake()
    {
        _maxHealth = _initialHealth;
        _currentHealth = _maxHealth;
        _attackPower = _initialAttackPower;
        _attackSpeed = _initialAttackSpeed;
        _defencePower = _initialDefencePower;
        _movementSpeed = _initialMovementSpeed;
        
        hp_bar.SetMaxHealth(_maxHealth);
        hp_bar.SetHealth(_currentHealth);
    }

    
    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
        
        hp_bar.SetHealth(_currentHealth);
    }
    
    public void IncreaseMaxHealth(int amount)
    {
        _maxHealth += amount;
    }
    
    public virtual void IncreaseAttackPower(int amount)
    {
        _attackPower += amount;
    }
    
    public void IncreaseAttackSpeed(int amount)
    {
        _attackSpeed += amount;
    }
    
    public void IncreaseDefencePower(int amount)
    {
        _defencePower += amount;
    }
    
    public void IncreaseMovementSpeed(int amount)
    {
        _movementSpeed += amount;
    }
    
    public float GetMovementSpeed()
    {
        return _movementSpeed;
    }
    
    public int GetAttackPower()
    {
        return _attackPower;
    }
    
    public int GetAttackSpeed()
    {
        return _attackSpeed;
    }
    
    public int GetDefencePower()
    {
        return _defencePower;
    }
    
    public int GetMaxHealth()
    {
        return _maxHealth;
    }
    
    public int GetCurrentHealth()
    {
        return _currentHealth;
    }
    
    public virtual void Die()
    {
        Debug.Log($"Character {gameObject.name} died, but no die method implemented");
    }

}
