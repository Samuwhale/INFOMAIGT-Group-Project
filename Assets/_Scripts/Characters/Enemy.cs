using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    // SEE BASE CLASS! Lot of things are implemented there.
    protected Transform _playerPos;
    protected float _knockBack;
    protected bool isKockedBack = false;

    [SerializeField] protected float _initialKnockBack = 5;

    protected override void Awake()
    {
        base.Awake();
        _knockBack = _initialKnockBack;
    }

    public float GetKnockBack()
    {
        return _knockBack;
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
        if (isKockedBack) return;
        transform.Translate(Vector2.right * moveX * GetKnockBack() * Time.deltaTime);
        transform.Translate(Vector2.up * moveY * GetKnockBack() * Time.deltaTime);
    }

    protected void ApplyKnockBack()
    {
        isKockedBack = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "player")
        {
            ApplyKnockBack();
        }
    }
}
