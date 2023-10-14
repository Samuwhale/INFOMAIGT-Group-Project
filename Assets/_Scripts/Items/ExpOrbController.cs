using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrbController : MonoBehaviour
{
    public int ExpPerOrb = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Level>().GetExp(ExpPerOrb);
            Destroy(gameObject);
        }
    }
}
