using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int _attackPower = 10;
    public float _attackMultiplier = 1f;

    public virtual int GetAttackPower() { return Mathf.RoundToInt(_attackPower * _attackMultiplier); }

    public void SetAttackPower(int power) { _attackPower = power; }

    public void SetAttackMultiplier(int mult) { _attackMultiplier = mult; }

    //public virtual void SetStats(int[] stats_i, float[] stats_f = null)
    //{
    //    _attackPower = stats_i[0];
    //}
}
