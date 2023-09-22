using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    protected int _maxHealth;
    protected int _currentHealth;
    protected int _attackPower;
    protected int _defencePower;
    protected float _movementSpeed;
    
    [SerializeField] protected int _initialHealth = 100;
    [SerializeField] protected int _initialAttackPower = 100;
    [SerializeField] protected int _initialDefencePower = 100;
    [SerializeField] protected int _initialMovementSpeed = 10;


    protected virtual void Awake()
    {
        _maxHealth = _initialHealth;
        _currentHealth = _maxHealth;
        _attackPower = _initialAttackPower;
        _defencePower = _initialDefencePower;
        _movementSpeed = _initialMovementSpeed;
    }

    
    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
        
        _currentHealth -= damage;
    }
    
    public void IncreaseMaxHealth(int amount)
    {
        _maxHealth += amount;
    }
    
    public void IncreaseAttackPower(int amount)
    {
        _attackPower += amount;
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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
