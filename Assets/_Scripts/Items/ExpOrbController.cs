using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrbController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Level>().GetExp(10);
            Destroy(gameObject);
        }
    }
}
