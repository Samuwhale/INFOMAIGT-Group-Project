using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] float destroyDelay = 1f;
    [SerializeField] float speed = 500f;
    [SerializeField] int _attackPower = 10;
    [SerializeField] Vector2 dir = Vector2.zero; 

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        StartCoroutine(DestroyTimer());

        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 shootDir)
    {
        this.dir = shootDir;
    }

    public int GetAttackPower()
    {
        return _attackPower;
    }

    public void FixedUpdate()
    {
        _rigidbody2D.velocity = dir * speed * Time.fixedDeltaTime;
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(destroyDelay);

        Destroy(gameObject);
    }
}
