using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Enemy
{
    private Rigidbody2D _rigidbody2D;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerPos)
        {
            Vector2 dir = GetPlayerDirection();

            this.MoveCharacter(dir.x, dir.y);
        }
    }
}
