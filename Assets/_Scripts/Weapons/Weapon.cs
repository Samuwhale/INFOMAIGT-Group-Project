using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int attackPower;
    public float attackSpeed;

    protected int level;

    private void Awake()
    {
        level = 1;
    }

    public virtual void Attack() { }
    public virtual void LevelUp() { }

    public void Activate()
    {
        StartCoroutine(Initialize());
    }

    protected abstract IEnumerator Initialize();
}
