using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleProjectile : Projectile
{
    private Animator animator;
    private GameObject player;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        player = GameObject.Find("/Player");
    }

    private void Update()
    {
        if ((player.transform.position - transform.position).magnitude > 17.0f) // at distance 17, the object is always outside the camera boundaries
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "enemy")
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            animator.SetBool("EnemyHit", true);
            StartCoroutine(DestroyTimer());
        }
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(0.5f); // about the length of the end animation

        Destroy(gameObject);
    }
}
