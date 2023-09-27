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
    void Update()
    {
        if(_playerPos)
        {
            Vector2 dir = GetPlayerDirection();

            this.MoveCharacter(dir.x, dir.y);
        }
    }
}
