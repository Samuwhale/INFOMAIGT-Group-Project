using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    // SEE BASE CLASS! Lot of things are implemented there.
    protected Transform _playerPos;
    protected float _knockBackForce;
    protected float _knockBackTime;
    protected bool _inKnockBack = false;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] protected float _initialKnockBackForce = 5;
    [SerializeField] protected float _initialKnockBackTime = 0.5f;

    protected override void Awake()
    {
        base.Awake();
        _knockBackForce = _initialKnockBackForce;
        _knockBackTime = _initialKnockBackTime;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public float GetKnockBack()
    {
        return _knockBackForce;
    }

    void Start()
    {
        _playerPos = GameObject.Find("Player").transform;
    }

    protected Vector2 GetPlayerVector()
    {
        return _playerPos.position - this.transform.position;
    }

    protected Vector2 GetPlayerDirection()
    {
        return GetPlayerVector().normalized;
    }

    protected void MoveCharacter(float moveX, float moveY)
    {
        if (!_inKnockBack)
        {
            _rigidbody2D.velocity = new Vector2(moveX * GetMovementSpeed() * Time.deltaTime, moveY * GetMovementSpeed() * Time.deltaTime);
        }
    }

    protected void ApplyKnockBack()
    {
        _rigidbody2D.AddForce(-GetPlayerDirection() * _knockBackForce, ForceMode2D.Impulse);
        StartCoroutine(KnockBackTime());
    }

    private IEnumerator KnockBackTime()
    {
        _inKnockBack = true;
        yield return new WaitForSeconds(_knockBackTime);
        _rigidbody2D.velocity = Vector2.zero;
        _inKnockBack = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "player")
        {
            ApplyKnockBack();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
    }
}
