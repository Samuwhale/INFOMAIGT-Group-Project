using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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

    [SerializeField] private float _damageFlashDuration = 0.2f;
    [SerializeField] SpriteRenderer _spriteRenderer;

    protected virtual void Awake()
    {
        _maxHealth = _initialHealth;
        _currentHealth = _maxHealth;
        _attackPower = _initialAttackPower;
        _attackSpeed = _initialAttackSpeed;
        _defencePower = _initialDefencePower;
        _movementSpeed = _initialMovementSpeed;
        
        if (hp_bar != null)
        {
            hp_bar.SetMaxHealth(_maxHealth);
            hp_bar.SetHealth(_currentHealth);
        }
    }

    
    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        
        if (_currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(DamageFlash());
        }
        
        if (hp_bar != null)
        {
            hp_bar.SetMaxHealth(_maxHealth);
            hp_bar.SetHealth(_currentHealth);
        }

    }
    
    IEnumerator DamageFlash()
    {
        Color defaultColor = _spriteRenderer.color;
        
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(_damageFlashDuration);

        
        _spriteRenderer.color = defaultColor;
    }
    
    public void IncreaseMaxHealth(int amount)
    {
        _maxHealth += amount;
        if (hp_bar != null)
        {
            hp_bar.SetMaxHealth(_maxHealth);
            hp_bar.SetHealth(_currentHealth);
        }
    }
    
    public virtual void IncreaseAttackPower(int amount)
    {
        _attackPower += amount;
    }
    
    public virtual float GetAttackMultiplier()
    {
        return _attackPower / _initialAttackPower;
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
