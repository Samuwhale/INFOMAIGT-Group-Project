using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : CharacterBase
{
    // SEE BASE CLASS! Lot of things are implemented there.
    protected GameObject _player;
    protected GameObject _measureTracker;
    protected GameObject _spawner;
    protected float _knockBackForce;
    protected float _knockBackTime;
    protected bool _inKnockBack = false;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] protected float _initialKnockBackForce = 2;
    [SerializeField] protected float _initialKnockBackTime = 0.1f;

    protected override void Awake()
    {
        base.Awake();
        _knockBackForce = _initialKnockBackForce;
        _knockBackTime = _initialKnockBackTime;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public float GetKnockBack()
    {
        return _knockBackForce;
    }

    void Start()
    {
        _player = GameObject.Find("/Player");
        _player.GetComponent<Player>().AddEnemyPos(transform);
        _measureTracker = GameObject.Find("/MeasureTracker");
        _spawner = GameObject.Find("/EnemySpawner");
    }

    protected Vector2 GetPlayerVector()
    {
        return _player.transform.position - this.transform.position;
    }

    protected Vector2 GetPlayerDirection()
    {
        return GetPlayerVector().normalized;
    }

    protected void MoveCharacter(float moveX, float moveY)
    {
        if (!_inKnockBack)
        {
            _rigidbody2D.velocity = new Vector2(moveX * GetMovementSpeed() * Time.fixedDeltaTime, moveY * GetMovementSpeed() * Time.deltaTime);
        }
    }

    protected void ApplyKnockBack()
    {
        _rigidbody2D.AddForce(-GetPlayerDirection() * _knockBackForce, ForceMode2D.Impulse);
        StartCoroutine(KnockBackTime());
    }

    private IEnumerator KnockBackTime()
    {
        _inKnockBack = true;
        yield return new WaitForSeconds(_knockBackTime);
        _rigidbody2D.velocity = Vector2.zero;
        _inKnockBack = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" || collision.gameObject.tag == "Player")
        {
            ApplyKnockBack();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "player weapon")
        {
            Projectile _projectile = collision.gameObject.GetComponent<Projectile>();
            int dam = _projectile.GetAttackPower();
            switch (_projectile.GetType())
            {
                case "icestaff":
                    _measureTracker.GetComponent<Measures>().IcestaffDam += dam;
                    break;
                case "scythe":
                    _measureTracker.GetComponent<Measures>().ScytheDam += dam;
                    break;
                case "dagger":
                    _measureTracker.GetComponent<Measures>().DaggerDam += dam;
                    break;
                case "forcefield":
                    _measureTracker.GetComponent<Measures>().ForcefieldDam += dam;
                    break;
            }
            TakeDamage(dam);
            ApplyKnockBack();
        }
    }

    public override void Die()
    {
        _player.GetComponent<Player>().RemoveEnemyPos(transform);
        GetComponent<ItemDropper>().DropItem(gameObject.transform.position);
        _measureTracker.GetComponent<Measures>().EnemiesKilled++;
        _spawner.GetComponent<EnemySpawner>().NumEnemies -= 1;
        Destroy(this.gameObject);
    }
}
