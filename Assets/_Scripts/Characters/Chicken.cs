using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Enemy
{
    // Start is called before the first frame update
    private Rigidbody2D _rigidbody2D;
    private float _shootingDistance;
    private bool justShot;

    [SerializeField] float _initialShootingDistance = 5;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _shootingDistance = _initialShootingDistance;
    }

    private float GetShootingDistance()
    {
        return _shootingDistance;
    }

    private void ShootEgg()
    {
        Debug.Log("Shoot egg");
        justShot = true;
        return;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerPos)
        {
            if (GetPlayerVector().magnitude > GetShootingDistance())
            {
                Vector2 dir = GetPlayerDirection();

                this.MoveCharacter(dir.x, dir.y);
                return;
            }

            if (!justShot)
            {
                ShootEgg();
            }
        }
    }
}
