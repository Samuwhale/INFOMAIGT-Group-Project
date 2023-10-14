using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public GameObject ExpOrbDrop;
    public GameObject HeartDrop;
    public GameObject[] ItemDropList;

    public void DropItem(Vector3 location)
    {
        location.z = -10;
        Instantiate(ExpOrbDrop, location, Quaternion.identity);

        if(Random.value < 0.5f)
        {
            Vector3 heartLocation = location + new Vector3(0, 1, 0);
            Instantiate(HeartDrop, heartLocation, Quaternion.identity);
        }
    }
}
