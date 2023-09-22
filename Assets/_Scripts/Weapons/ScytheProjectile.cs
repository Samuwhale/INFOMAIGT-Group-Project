using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheProjectile : MonoBehaviour
{
    [SerializeField] float destroyDelay = 1f;
    const float speed = 500f;

    private void Awake()
    {
        StartCoroutine(DestroyTimer());
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, -1f), speed * Time.deltaTime);
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(destroyDelay);

        Destroy(gameObject);
    }
}
