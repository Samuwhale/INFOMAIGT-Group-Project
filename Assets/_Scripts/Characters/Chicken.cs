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

    protected override void Awake()
    {
        base.Awake();
        _shootingDistance = _initialShootingDistance;
        _fleeDistance = _initialFleeDistance;
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
        eggTransform.GetComponent<Egg>().SetDirection(GetPlayerDirection());

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
                return;
            }

            if (GetPlayerVector().magnitude < GetFleeDistance())
            {
                Vector2 dir = GetPlayerDirection();

                this.MoveCharacter(-dir.x, -dir.y);
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
