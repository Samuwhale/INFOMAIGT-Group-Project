using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable] public class Wave
    {
        public int spawnTime;
        public int waveSize;
        public GameObject enemy;
    }


    [SerializeField] public List<Wave> waveList;

    // Start is called before the first frame update
    void Start()
    {
        SetupWaves();
    }

    void SetupWaves()
    {
        for (int i = 0; i < waveList.Count; i++)
        {
            StartCoroutine(spawnEnemy(waveList[i].spawnTime, waveList[i].waveSize, waveList[i].enemy));
        }
    }

    private IEnumerator spawnEnemy(float spawnTime, int waveSize, GameObject enemy)
    {
        yield return new WaitForSeconds(spawnTime);

        for (int i = 0; i < waveSize; i++)
        {
            GameObject newEnemy;

            float chance = Random.value;
            if (chance < 0.25f)
                newEnemy = Instantiate(enemy, new Vector3(Random.Range(-38f, 36f), 19f, 0), Quaternion.identity);
            else if (chance < 0.5f)
                newEnemy = Instantiate(enemy, new Vector3(Random.Range(-38f, 36f), -21f, 0), Quaternion.identity);
            else if (chance < 0.75f)
                newEnemy = Instantiate(enemy, new Vector3(-38f, Random.Range(-21f, 19f), 0), Quaternion.identity);
            else
                newEnemy = Instantiate(enemy, new Vector3(36f, Random.Range(-21f, 19f), 0), Quaternion.identity);
        }
    }
}
