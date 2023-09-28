using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject chicken;
    [SerializeField] private GameObject cow;

    [SerializeField] private float chickenInterval = 1;
    [SerializeField] private float cowInterval = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(chickenInterval, chicken));
        StartCoroutine(spawnEnemy(cowInterval, cow));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        GameObject newEnemy;

        float chance = Random.value;
        if (chance<0.25f)
            newEnemy = Instantiate(enemy, new Vector3(Random.Range(-38f, 36f), 19f, 0), Quaternion.identity);
        else if (chance < 0.5f)
            newEnemy = Instantiate(enemy, new Vector3(Random.Range(-38f, 36f), -21f, 0), Quaternion.identity);
        else if (chance < 0.75f)
            newEnemy = Instantiate(enemy, new Vector3(-38f, Random.Range(-21f, 19f), 0), Quaternion.identity);
        else
            newEnemy = Instantiate(enemy, new Vector3(36f, Random.Range(-21f, 19f), 0), Quaternion.identity);



        //GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-38f, 36f) * x, Random.Range(-21f, 19f) * y, 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
