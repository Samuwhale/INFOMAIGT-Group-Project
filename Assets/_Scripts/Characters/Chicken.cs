using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Enemy
{
    // Start is called before the first frame update
    private float _shootingDistance;
    private float _fleeDistance;
    private bool justShot;
    [SerializeField] private Transform Egg;

    [SerializeField] float _initialShootingDistance = 5;
    [SerializeField] float _initialFleeDistance = 2;

    private SpriteRenderer spriteRenderer;

    protected override void Awake()
    {
        base.Awake();
        _shootingDistance = _initialShootingDistance;
        _fleeDistance = _initialFleeDistance;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private float GetShootingDistance()
    {
        return _shootingDistance;
    }

    private float GetFleeDistance()
    {
        return _fleeDistance;
    }

    private void ShootEgg()
    {
        Transform eggTransform = Instantiate(Egg, this.transform.position, Quaternion.identity);

        Vector2 dir = GetPlayerDirection();
        eggTransform.GetComponent<Egg>().SetDirection(dir);

        if (dir.x < 0)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;

        StartCoroutine(ShootDelay());
        return;
    }

    private IEnumerator ShootDelay()
    {
        justShot = true;
        yield return new WaitForSeconds(_attackSpeed + 1);
        justShot = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_player)
        {
            if (GetPlayerVector().magnitude > GetShootingDistance())
            {
                Vector2 dir = GetPlayerDirection();

                this.MoveCharacter(dir.x, dir.y);

                if (dir.x < 0)
                    spriteRenderer.flipX = true;
                else
                    spriteRenderer.flipX = false;
                return;
            }

            if (GetPlayerVector().magnitude < GetFleeDistance())
            {
                Vector2 dir = GetPlayerDirection();

                this.MoveCharacter(-dir.x, -dir.y);

                if (dir.x < 0)
                    spriteRenderer.flipX = false;
                else
                    spriteRenderer.flipX = true;
                return;
            }

            this.MoveCharacter(0, 0);

            if (!justShot)
            {
                ShootEgg();
            }
        }
    }
}
