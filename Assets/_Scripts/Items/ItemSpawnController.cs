using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnController : MonoBehaviour
{
    public GameObject heartPrefab;
    public GameObject expOrbPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2.0f;
            Instantiate(heartPrefab, Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2.0f;
            Instantiate(expOrbPrefab, Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
        }
    }
}
