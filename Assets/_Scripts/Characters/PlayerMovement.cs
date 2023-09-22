using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player _player;
    private Animator _animator;

    private void Awake()
    {
        _player = GetComponent<Player>();
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

    private void SetAnimatorValues(float moveX, float moveY)
    {
        _animator.SetFloat("MoveX", moveX);
        _animator.SetFloat("MoveY", moveY);
    }

    private void MoveCharacter(float moveX, float moveY)
    {
        transform.Translate(Vector2.right * moveX * _player.GetMovementSpeed() * Time.deltaTime);
        transform.Translate(Vector2.up * moveY * _player.GetMovementSpeed() * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
       float moveX = GetInputNormalized().x;
       float moveY = GetInputNormalized().y;
       
        SetAnimatorValues(moveX, moveY);

        MoveCharacter(moveX, moveY);

    }
}
