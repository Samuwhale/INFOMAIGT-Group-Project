using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Enemy
{
    protected override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_player)
        {
            Vector2 dir = GetPlayerDirection();

            this.MoveCharacter(dir.x, dir.y);
        }
    }
}
