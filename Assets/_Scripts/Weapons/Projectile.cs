using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected int _attackPower = 10;
    [SerializeField] protected float _attackMultiplier = 1f;

    public virtual int GetAttackPower() { return Mathf.RoundToInt(_attackPower * _attackMultiplier); }

    public void SetAttackPower(int power) { _attackPower = power; }

    public void SetAttackMultiplier(float mult) { _attackMultiplier = mult;
        Debug.Log($"Cheese activated, set attack to {mult}"); }

    //public virtual void SetStats(int[] stats_i, float[] stats_f = null)
    //{
    //    _attackPower = stats_i[0];
    //}
}
