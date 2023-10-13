using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    public int HealthPerHeart = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().TakeDamage(-HealthPerHeart);
            Destroy(gameObject);
        }
    }
}
