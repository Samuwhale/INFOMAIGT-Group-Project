using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    private Enemy _enemy;
    private Rigidbody2D _rigidbody2D;
    private Transform _playerPos;
    private Animator _animator;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        _playerPos = GameObject.Find("Player").transform;
    }

    private Vector2 GetplayerDirection()
    {
        return (_playerPos.position - _enemy.transform.position).normalized;
    }

    private void SetAnimatorValues(float moveX, float moveY)
    {
        _animator.SetFloat("MoveX", moveX);
        _animator.SetFloat("MoveY", moveY);
    }

    private void MoveCharacter(float moveX, float moveY)
    {
        transform.Translate(Vector2.right * moveX * _enemy.GetMovementSpeed() * Time.deltaTime);
        transform.Translate(Vector2.up * moveY * _enemy.GetMovementSpeed() * Time.deltaTime);
    }


    // Update is called once per frame
    void Update()
    {
        if(_playerPos)
        {
            Vector2 dir = GetplayerDirection();

            SetAnimatorValues(dir.x, dir.y);
            MoveCharacter(dir.x, dir.y);
        }
    }
}
