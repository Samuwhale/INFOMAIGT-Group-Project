using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Enemy
{
    private SpriteRenderer spriteRenderer;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_player)
        {
            Vector2 dir = GetPlayerDirection();

            this.MoveCharacter(dir.x, dir.y);

            if (dir.x < 0)
                spriteRenderer.flipX = true;
            else 
                spriteRenderer.flipX = false;
        }
    }
}
