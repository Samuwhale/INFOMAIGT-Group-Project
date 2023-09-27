using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player _player;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    public Vector2 LastPlayerDirection { get; private set; }

    private void Awake()
    {
        LastPlayerDirection = Vector2.right;
        _player = GetComponent<Player>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }
    
    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    
    private Vector2 GetInputNormalized()
    {
        return GetInput().normalized;
    }


    private void UpdateLastPlayerDirection()
    {
        if (GetInputNormalized().magnitude > 0)
        {
            LastPlayerDirection = GetInputNormalized();
        }
    }
    
    private void SetAnimatorValues(float moveX, float moveY)
    {
        _animator.SetFloat("MoveX", moveX);
        _animator.SetFloat("MoveY", moveY);
    }

    private void MoveCharacter(float moveX, float moveY)
    {
        _rigidbody2D.velocity = new Vector2(moveX * _player.GetMovementSpeed() * Time.deltaTime, moveY * _player.GetMovementSpeed() * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
       float moveX = GetInputNormalized().x;
       float moveY = GetInputNormalized().y;
       
        SetAnimatorValues(moveX, moveY);

        MoveCharacter(moveX, moveY);
        
        UpdateLastPlayerDirection();

    }
}
